(*** hide ***)
// This block of code is omitted in the generated HTML documentation. Use 
// it to define helpers that you do not want to show in the documentation.
#I "../../bin"

(**
TibruFunctions
======================

### FunctionsRoot

<div class="row">
  <div class="span1"></div> 
  <div class="span6">
    <div class="well well-small">
      <a href="https://tibru.scm.azurewebsites.net/dev/wwwroot/host.json">TibruFunctions App Service Editor</a>
    </div>
  </div>
  <div class="span1"></div>
</div>


### Stream log:

- PS>Add-AzureAccount
- PS>Get-AzureSubscription  (can be skipped)
- PS>Get-AzureSubscription -SubscriptionName "Visual Studio Enterprise" | Select-AzureSubscription
- PS>Get-AzureWebSiteLog -Name tibru -Tail


### Documentation

<div class="row">
  <div class="span1"></div> 
  <div class="span6">
    <div class="well well-small">
      <a href="https://docs.microsoft.com/en-us/azure/azure-functions/">Azure Functions Documentation</a>
    </div>
  </div>
  <div class="span1"></div>
</div>

### other docs

<div class="row">
  <div class="span1"></div> 
  <div class="span6">
    <div class="well well-small">
      <a href="https://github.com/Azure/azure-webjobs-sdk-script/wiki/Precompiled-functions">Precompiled functions</a>
    </div>
    <div class="well well-small">
      <a href="https://blogs.msdn.microsoft.com/appserviceteam/2017/03/16/publishing-a-net-class-library-as-a-function-app/">Publishing a .NET class library as a Function App</a>
    </div>
    <div class="well well-small">
      <a href="https://blogs.msdn.microsoft.com/webdev/2017/05/10/azure-function-tools-for-visual-studio-2017/">Visual Studio 2017 Tools for Azure Functions</a>
    </div>
    <div class="well well-small">
      <a href="https://blogs.msdn.microsoft.com/appserviceteam/2017/08/14/azure-functions-tools-released-for-visual-studio-2017-update-3/">Azure Functions Tools released for Visual Studio 2017 Update 3</a>
    </div>
    <div class="well well-small">
      <a href="https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference">Azure Functions developers guide</a>
    </div>
    <div class="well well-small">
      <a href="https://docs.microsoft.com/en-us/azure/azure-functions/functions-reference-fsharp">Azure Functions F# Developer Reference</a>
    </div>
    <div class="well well-small">
      <a href="https://docs.microsoft.com/en-us/azure/azure-functions/functions-host-json">Azure Functions host.json reference</a>
    </div>
    <div class="well well-small">
      <a href="https://docs.microsoft.com/en-us/azure/azure-functions/functions-triggers-bindings">Azure Functions triggers and bindings</a>
    </div>
    <div class="well well-small">
      <a href="https://compositional-it.com/blog/2017/08-30-using-the-azure-type-provider-with-azure-functions/index.html">Using the Azure Type Provider with Azure Functions</a>
    </div>
    <div class="well well-small">
      <a href="https://www.npmjs.com/package/azure-functions-core-tools">azure-functions-core-tools</a>
    </div>
    <div class="well well-small">
      <a href="https://stackoverflow.com/questions/tagged/azure-functions">StackOverflow azure-funtions</a>
    </div>
    <div class="well well-small">
      <a href="https://github.com/mikhailshilkov/FSharpHttpFull">F# Azure Function using WebJobs attributes to auto-generate function.json</a>
    </div>
  </div>
  <div class="span1"></div>
</div>

<div>
    <img src="img/FunctionAppsPortal.PNG">
</div>

ContactBlobToQueue
------------------

<div class="row">
  <div class="span1"></div> 
  <div class="span6">
    <div class="well well-small">
      <a href="https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-storage-blob-triggered-function">Azure Blob storage function trigger docs</a>
    </div>
  </div>
  <div class="span1"></div>
</div>

    "bindings": [
        {
          "name": "rawConnections",
          "type": "blobTrigger",
          "direction": "in",
          "path": "contactinput/{folder}/{filename}.{extension}",
          "connection": "tibrutest12_STORAGE"
        }
    ]

writes to rawcontacts queue (this should be parameterized in function app

    new CloudQueueMessage(sprintf "%s/%s.%s" folder filename extension)


ContactQueueToProcess
---------------------

<div class="row">
  <div class="span1"></div> 
  <div class="span6">
    <div class="well well-small">
      <a href="https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-storage-queue-triggered-function">Azure Queue storage function trigger docs</a>
    <div class="well well-small">
    </div>
      <a href="https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-storage-queue">Azure Functions Queue Storage bindings</a>
    </div>
  </div>
  <div class="span1"></div>
</div>

TimerTrigger
------------

<div class="row">
  <div class="span1"></div> 
  <div class="span6">
    <div class="well well-small">
      <a href="https://docs.microsoft.com/en-us/azure/azure-functions/functions-create-scheduled-function">Azure timer function trigger docs</a>
    <div class="well well-small">
    </div>
      <a href="https://docs.microsoft.com/en-us/azure/azure-functions/functions-bindings-timer">Azure Functions timer trigger</a>
    </div>
    </div>
      <a href="https://github.com/mikhailshilkov/FSharpHttpCore">F# HTTP Trigger Function for .NET Core 2.0</a>
    </div>
  </div>
  <div class="span1"></div>
</div>


*)

