$scriptpath = Split-Path $script:MyInvocation.MyCommand.path -parent

cd $scriptpath\..

cmd /c ng build -prod -op "$scriptPath\published"

cd $scriptpath

docker build -t ui .

Remove-Item "$scriptPath\published" -Force -Recurse


Pause
