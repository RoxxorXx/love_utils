REM Dev by Joseph "RoxxorXx" Cabanis /-\ Créajeux 2019
REM v.1.2.0
REM last update 28/10/19
@ECHO OFF
CLS

FOR %%I in (.) do set CurrDirName=%%~nxI
echo %CurrDirName%



REM NEEDED TOOLS : LOVE
IF not EXIST "C:\Program Files\LOVE\love.exe" (
    ECHO Impossible de localiser Love dans le chemin par defaut
    pause 
    REM https://bitbucket.org/rude/love/downloads/love-11.3-win64.zip j'peux le dl ? 
    GOTO end
)

:backConf
CLS

IF EXIST *.compressor.conf (
    IF EXIST dev.compressor.conf (
        REM ECHO dev
        IF "%loved%"=="1" (
            goto end
        )
        goto dev
    ) 
    IF EXIST prod.compressor.conf (
        IF not "%loved%"=="1" (
           goto dev
        )
        goto prod
        REM ECHO prod
    )
    GOTO end
) ELSE (
    GOTO question
    :check
    IF "%backAgain%"=="1" (
        ECHO Votre saisie est incorrecte 
        GOTO :question
    )
    IF /I "%id%" == "1" (
        type nul > dev.compressor.conf
        GOTO backConf
    )
    IF /I "%id%" == "2" (
        type nul > prod.compressor.conf
        GOTO backConf
    )
    IF /I "%id%" neq "2" (
       IF /I"%id%" neq "1" (
           GOTO error
        )  
    )    
)


:question
ECHO Choisisez votre mode de compression : [1].love, [2].exe
SET /P id=Enter votre selection:
SET backAgain=0
GOTO check

:error
CLS
SET backAgain=1
GOTO check

REM .love part
:dev
mkdir %CurrDirName%
robocopy .\ .\%CurrDirName% /E >NUL
del .\%CurrDirName%\compressor.bat .\%CurrDirName%\*compressor.conf
powershell -Command "Compress-Archive -Path .\%CurrDirName%\* -DestinationPath %CurrDirName%.zip" 
move %CurrDirName%.zip %CurrDirName%.love
RMDIR /Q/S .\%CurrDirName%
SET loved=1
GOTO backConf

REM .exe part
:prod
mkdir .\%CurrDirName%
copy .\*.love .\%CurrDirName%
copy "C:\Program Files\LOVE\*" .\%CurrDirName%
del .\%CurrDirName%\changes.txt, .\%CurrDirName%\game.ico, .\%CurrDirName%\license.txt, .\%CurrDirName%\love.ico, .\%CurrDirName%\readme.txt, .\%CurrDirName%\Uninstall.exe
copy /b .\%CurrDirName%\love.exe+.\%CurrDirName%\*.love .\%CurrDirName%\%CurrDirName%.exe
del .\%CurrDirName%.love
del ".\%CurrDirName%\love.exe", ".\%CurrDirName%\lovec.exe", ".\%CurrDirName%\*.love"
IF EXIST ReadMe.txt (
    mkdir .\%CurrDirName%\%CurrDirName%
    move .\%CurrDirName%\* .\%CurrDirName%\%CurrDirName%
    copy .\ReadMe.txt .\%CurrDirName%\
)
powershell -Command "Compress-Archive -Path %CurrDirName% -DestinationPath %CurrDirName%.zip 
rmdir /Q/S .\%CurrDirName%
DEL %CurrDirName%.love

:end
CLS
ECHO Termine
