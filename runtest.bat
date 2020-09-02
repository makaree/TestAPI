setlocal

:: This script runs all the test cases and saves them as .trx files.
:: This script then generates .html reports for new .trx files.
:: In addition, prints paths to generated files.
::

set name=TestResultsInTime_%time:~0,2%_%time:~3,2%_%time:~6,2%_%time:~6,2%
::The files will be saved by name %name%

::Run all the test cases
:: Running all the test cases at API_Testing_RESTful_booker.sln

"vstest.console.exe" "API_Testing_RESTful_booker\bin\Debug\API_Testing_RESTful_booker.dll" /Logger:trx;LogFileName="%name%"
:: %name%.trx file has been created

::Convert generated trx file to HTML
echo Converting generated trx file to HTML
"packages\TrxToHtml.TrxerConsole.1.0.0\lib\TrxerConsole.exe" "TestResults\%name%"
:: %name%.html file has been created in the folder TestResults.

endlocal