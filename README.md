[![Build status](https://ci.appveyor.com/api/projects/status/0bemisvvtdtbih97/branch/master?svg=true)](https://ci.appveyor.com/project/capslocky/wcfsoaplogger/branch/master)
[![NuGet](https://img.shields.io/nuget/v/WcfSoapLogger.svg?colorB=0f81c1)](https://www.nuget.org/packages/WcfSoapLogger/)
[![Quality Gate](https://sonarcloud.io/api/badges/gate?key=WcfSoapLogger)](https://sonarcloud.io/dashboard?id=WcfSoapLogger)
[![PVS-Studio](https://img.shields.io/badge/pvs--studio-free-brightgreen.svg)](https://www.viva64.com/en/b/0457/)

# WcfSoapLogger #
This library is a message tracing tool for web-services and clients built with WCF.
Acting as [custom message encoder](https://docs.microsoft.com/en-us/dotnet/framework/wcf/samples/custom-message-encoder-custom-text-encoder) it captures raw XML SOAP data as plain HTTP body.


## Features ##
* Exact byte content of each request and response
* Including any malformed requests and soap faults
* Works for both web-services and clients
* Each request and response is a separate file
* Easy start, no code modification needed - just put dll and adjust config file
* Custom handling of byte content in your code


## Standard output sample ##
![ExampleBeta](/docs/images/main_screenshot.png?raw=true)


## Installation ##
* As [NuGet package](https://www.nuget.org/packages/WcfSoapLogger/) in Visual Studio project (Tools -> NuGet -> Console / Manager). How to adjust [config file](/docs/ConfigFile.md).
```
Install-Package WcfSoapLogger
```
* [Manually](/docs/ManualInstallation.md) (for system administators)


## Usage examples ##
The repository contains different [usage examples](/src/UsageExamples).
To clone repository run this command or download as [zip file](https://github.com/capslocky/WcfSoapLogger/archive/master.zip).
```
git clone https://github.com/capslocky/WcfSoapLogger.git
```


## Comparison with alternatives ##
You can find examples [here](/src/AlternativesExamples).

* **IDispatchMessageInspector (IClientMessageInspector)**
[Link 1](https://docs.microsoft.com/en-us/dotnet/framework/wcf/samples/message-inspectors)
[Link 2](https://blogs.msdn.microsoft.com/endpoint/2011/04/23/wcf-extensibility-message-inspectors/)  
can't see malformed requests (HTTP/1.1 400 Bad Request)  
can't see original content


* **SvcTraceViewer.exe (<system.diagnostics>)**
[Link 1](https://docs.microsoft.com/en-us/dotnet/framework/wcf/diagnostics/configuring-message-logging)
[Link 2](https://docs.microsoft.com/en-us/dotnet/framework/wcf/service-trace-viewer-tool-svctraceviewer-exe)  
external utility hard in use  
no custom handling possible


* **Fiddler**
[Link 1](https://www.telerik.com/fiddler)
[Link 2](https://www.telerik.com/fiddler/fiddlercore)  
external proxy application


## Contributing ##
If you find this project useful you are welcome to make it better! Feel free to contact me if you have any ideas, questions or concerns. Also see [issues](https://github.com/capslocky/WcfSoapLogger/issues).