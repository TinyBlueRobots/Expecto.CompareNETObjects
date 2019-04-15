set -e
rm -rf build
if [ ! -d .paket ]
then
  dotnet tool install paket --tool-path .paket
  .paket/paket install
else
  .paket/paket restore
fi
dotnet run -p tests