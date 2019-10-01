@ECHO off
REM demander le nom du projet
REM créer le dossier du projet
REM ajouter le main, conf, assets, sources
REM ajout du compressor
REM supprimer le script

echo checking internet connection
Ping www.google.nl -n 1 -w 1000
cls
if errorlevel 1 (set internet=Not connected to internet) else (set internet=Connected to internet)

echo %internet%