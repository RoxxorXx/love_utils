REM Dev by Joseph "RoxxorXx" Cabanis /-\ Créajeux 2019
REM https://github.com/RoxxorXx/love_utils
REM v.1.0.0
REM last update 30/09

@ECHO off
cls

REM supprimer le script

echo checking internet connection
Ping www.google.com -n 1 -w 1000
cls
if errorlevel 1 (
    set internet=Vous n'etes pas connectes a internet, le script ne fonctionnera pas.
    pause
    GOTO end
) else (
    set internet=Connected to internet
    GOTO makeDir
)
echo %internet%


:makeDir
set /p projet="Saisisez le nom de votre projet : "
mkdir %projet%
if errorlevel 1 (
    cls
    echo Votre nom de dossier comporte un caratere interdit, merci de le retaper.
    GOTO makeDir
) else (
    cd %projet%
    mkdir assets
    mkdir sources
    powershell -Command "Invoke-WebRequest https://raw.githubusercontent.com/RoxxorXx/love_utils/master/compressor.bat -OutFile compressor.bat"
    powershell -Command "Invoke-WebRequest https://raw.githubusercontent.com/RoxxorXx/love_utils/master/default_love/main.lua -OutFile main.lua"
    powershell -Command "Invoke-WebRequest https://raw.githubusercontent.com/RoxxorXx/love_utils/master/default_love/conf.lua -OutFile conf.lua"
)

:end

