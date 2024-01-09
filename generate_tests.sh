dotnet build -c Release 
dotnet test -c Release --no-build
coverlet testing/bin/Release/net7.0/testing.dll --target "dotnet" --targetargs "test -c Release --no-build" --format opencover --exclude-by-attribute 'Visual' #--exclude-by-attribute 'Obsolete'
reportgenerator "-reports:./coverage.opencover.xml" "-targetdir:coverage" "-reporttypes:lcov"
