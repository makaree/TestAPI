## Introduction
This test project contains testing framework to Restful-booker an API that helps to learn 
more about API Testing or try out API testing tools against. Restful-booker is a Create Read
Update Delete Web API that comes with authentication features. The main objective of this 
framework is to test Create Read Update Delete to Web API and to test PATCH, DELETE and PUT 
methods using basic authentication and token based authentication. 

## Features
Some of the features that are included in the testing framework are as follows:
1.	Executing the test cases in parallel. It runs 4 test cases in parallel which 
is done via runsettings file in the test solution
2.	Serialization and Deserialization of JSON, XML and URL encoded formats.
3.	There is also a bat file present in the Project which could generate an HTML 
report file after running the test cases.


## Testing Tools
Visual Studio 2019 (Object Oriented Programming C#) is used for automating test cases

Nuget Packages :NuGet is the package manager for the Microsoft development platform including .NET. 
The NuGet client tools provide the ability to produce and consume packages. The NuGet Gallery 
is the central package repository used by all package authors and consumers.
There are three different packages used:
1. MSTest:  Unit Testing Framework  which describes Microsoft's suite of unit testing tools
2. Newtonsoft.JSON: Json.NET is a popular high-performance JSON framework for .NET. It is an
 open source platform that can Serialize and deserialize any .NET object and also supports 
 converting between XML and JSON.
3. Restsharp: Simple REST and HTTP API Client. RestSharp is HTTP client library for .NET. 
Featuring automatic serialization and deserialization, request and response type detection,
variety of authentications and other useful features.
4. TrxToHtml.TrxerConsole: Console tool to generate automation tests results HTML report 
from .trx file.
The packages mentioned above needs to be installed in Refrences >> Manage nuget Packages in 
the solution.

## Running the test cases
Here are the list of steps required for the test execution:
1. Download the repository from the GIT.
2. Open the solution file API_Testing_RESTful_booker.sln and build the solution. If necessary 
install the nuget packages mentioned in TESTING TOOL (i.e. MSTest, Newtonsoft.JSON, Restsharp,
TrxToHtml.TrxerConsole) in Refrences >> Manage nuget Packages in the solution.
3. Go to Environmental Variables (Control Panel>>System and Security>>System>>Environmental 
Variables>>System Variables) and in Path >> Add the location for “vstest.console.exe”. 
(In my case it was present in C:\Program Files (x86)\Microsoft Visual Studio\2019\Professional\Common7\
\IDE\Extensions\TestPlatform)
4. Run runtest.bat file present in TestAPI directory. After run, the test results are present 
in TestAPI\TestResults folder in both HTML and TRX format.

## Contact
If you got any questions feel free to contact with me: manz.karki@gmail.com