@echo off

set startdir=%~dp0

REG ADD "HKLM\SOFTWARE\Cakewalk Music Software\Tools Menu\SONAR Voice" /v "ExePath" /t REG_SZ /d "%startdir%SONARVoicePrototype.exe" /f 
REG ADD "HKLM\SOFTWARE\Cakewalk Music Software\Tools Menu\SONAR Voice" /v "MenuText" /t REG_SZ /d "SONAR Voice..." /f
REG ADD "HKLM\SOFTWARE\Cakewalk Music Software\Tools Menu\SONAR Voice" /v "type" /t REG_SZ /d "generic" /f

REG ADD "HKLM\SOFTWARE\Wow6432Node\Cakewalk Music Software\Tools Menu\SONAR Voice" /v "ExePath" /t REG_SZ /d "%startdir%SONARVoicePrototype.exe" /f /reg:64
REG ADD "HKLM\SOFTWARE\Wow6432Node\Cakewalk Music Software\Tools Menu\SONAR Voice" /v "MenuText" /t REG_SZ /d "SONAR Voice..." /f /reg:64
REG ADD "HKLM\SOFTWARE\Wow6432Node\Cakewalk Music Software\Tools Menu\SONAR Voice" /v "type" /t REG_SZ /d "generic" /f /reg:64
