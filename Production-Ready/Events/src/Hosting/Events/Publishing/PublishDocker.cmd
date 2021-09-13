cd ../../../../
dotnet restore src
cd src/Hosting/Events/
dotnet publish -c Release -o Publishing/published
cd Publishing
docker build -t events .
RMDIR "published" /S /Q
pause
