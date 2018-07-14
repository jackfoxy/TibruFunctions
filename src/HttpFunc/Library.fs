namespace HttpFunc

open Microsoft.AspNetCore.Mvc
open Microsoft.AspNetCore.Http
open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Host
open Microsoft.Azure.WebJobs.Extensions.Http

module PrecompiledHttp =
    [<FunctionName("HttpFunc")>]
    let run([<HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "hellosanta")>] req: HttpRequest, log: TraceWriter) =
        log.Info("F# HTTP trigger function processed a request.")
        ContentResult(Content = "HO HO HO Merry Christmas", ContentType = "text/html") 
        
        //doesn't work
        // async {
        //     log.Info("F# HTTP trigger function processed a request.")
        //     ContentResult(Content = "HO HO HO Merry Christmas", ContentType = "text/html")
        // } |> Async.StartAsTask
    
