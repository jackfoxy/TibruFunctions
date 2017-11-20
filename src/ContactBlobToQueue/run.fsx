#if INTERACTIVE

open System

//#I "C:/Users/ryan/AppData/Roaming/npm/node_modules/azure-functions-core-tools/bin/"

#r "Microsoft.WindowsAzure.Storage"
#r "../../packages/Microsoft.Azure.WebJobs/lib/net45/Microsoft.Azure.Webjobs.Host.dll"
open Microsoft.Azure.WebJobs.Host
open Microsoft.WindowsAzure.Storage
open System.IO

#r "System.Configuration.dll"
//#r "System.Net.Http.dll"
//#r "System.Net.Http.Formatting.dll"
//#r "System.Web.Http.dll"

//#r "microsoft.azure.keyvault/2.3.2/lib/net452/Microsoft.Azure.KeyVault.dll"
//#r "microsoft.azure.keyvault.webkey/2.0.7/lib/net452/Microsoft.Azure.KeyVault.WebKey.dll"
//#r "microsoft.identitymodel.clients.activedirectory/3.16.0/lib/net45/Microsoft.IdentityModel.Clients.ActiveDirectory.dll"
//#r "microsoft.rest.clientruntime/2.3.8/lib/net452/Microsoft.Rest.ClientRuntime.dll"
//#r "microsoft.rest.clientruntime.azure/3.3.7/lib/net452/Microsoft.Rest.ClientRuntime.Azure.dll"
//#r "newtonsoft.json/6.0.8/lib/net45/Newtonsoft.Json.dll"

#else

//#r "System.Data"
//#r "System.Net.Http"
//#r "Microsoft.Azure.KeyVault"
//#r "Microsoft.IdentityModel.Clients.ActiveDirectory"
//#r "Newtonsoft.Json"

#endif



open System.Configuration

open Microsoft.WindowsAzure.Storage.Queue

let Run(rawConnections: Stream, folder: string,  filename: string, extension: string, log: TraceWriter) =
    async {
        let now = DateTime.UtcNow.ToLongTimeString()
        log.Info(sprintf "v2 folder: %s  filename: %s extension %s detected at %s!" folder filename extension now, "ContactBlob")

       // Environment.GetEnvironmentVariable
        let connString = ConfigurationManager.AppSettings.["tibrutest12_STORAGE"]
    
        let storageAccount = CloudStorageAccount.Parse(connString)
        let queueClient = storageAccount.CreateCloudQueueClient()
        let queue = queueClient.GetQueueReference("rawcontacts")
        queue.CreateIfNotExists() |> ignore
        let cloudQueueMessage = new CloudQueueMessage(sprintf "%s/%s.%s" folder filename extension)
        queue.AddMessage(cloudQueueMessage)
    } |> Async.StartAsTask