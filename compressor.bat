REM Dev by Joseph "RoxxorXx" Cabanis /-\ Créajeux 2019
REM v.1.0.2
REM last update 30/09

@ECHO OFF
CLS
GOTO dev

:backConf
CLS
IF EXIST *.compressor.conf (
    IF EXIST dev.compressor.conf (
        ECHO dev
    ) 
    IF EXIST prod.compressor.conf (
        ECHO prod
        GOTO prod
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
FOR %%I in (.) do set CurrDirName=%%~nxI
FOR /f "tokens=3,2,4 delims=/- " %%x in ("%date%") do set d=%%y%%x%%z
SET data=%d%
"C:\Program Files\7-Zip\7z.exe" a -tzip "%CurrDirName%.love" "./*"
GOTO backConf

REM .exe part
:prod
mkdir .\exe
copy .\*.love .\exe
copy "C:\Program Files\LOVE\*" .\exe
del .\exe\changes.txt, .\exe\game.ico, .\exe\license.txt, .\exe\love.ico, .\exe\readme.txt, .\exe\Uninstall.exe
copy /b .\exe\love.exe+.\exe\*.love .\exe\game.exe
del ".\exe\love.exe", ".\exe\lovec.exe", ".\exe\*.love"
"C:\Program Files\7-Zip\7z.exe" a -tzip "%CurrDirName%.zip" "./exe/*"
rmdir /Q /S .\exe
DEL %CurrDirName%.love

:end
CLS
ECHO Termine
REM PAUSE
