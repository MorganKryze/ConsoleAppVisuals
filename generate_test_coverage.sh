echo " --- Running tests --- \n"

dotnet test -c Release --verbosity m
coverlet testing/bin/Release/net8.0/testing.dll --target dotnet --targetargs "test -c Release --no-build" --format opencover --exclude-by-attribute Visual
reportgenerator "-reports:./coverage.opencover.xml" "-targetdir:coverage" "-reporttypes:lcov"

echo "\n --- Tests completed --- "
