#if INTERACTIVE

#r "../../packages/Microsoft.Azure.WebJobs/lib/net45/Microsoft.Azure.Webjobs.Host.dll"
#r "../../packages/Microsoft.Azure.WebJobs.Core/lib/net45/Microsoft.Azure.Webjobs.dll"
#r "../../packages/Microsoft.Azure.WebJobs.Extensions/lib/net45/Microsoft.Azure.WebJobs.Extensions.dll"

#r "../../../PSlogger/bin/PSlogger/PSlogger.dll"
#r "../../../PSlogger/bin/PSlogger/Microsoft.WindowsAzure.Storage.dll"

#r "System.Configuration.dll"

open System
open Microsoft.Azure.WebJobs.Host
open Microsoft.Azure.WebJobs

#else
#r "../bin/PSlogger/PSlogger.dll"
#endif

open PSlogger

let initLog processName =

    let utcTime = DateTime.UtcNow

    let assemblyFullName =
        let assembly = System.Reflection.Assembly.GetExecutingAssembly()
        assembly.FullName

    CountingLog("Dashboard", utcTime, LogLevel.Info, assemblyFullName, Environment.MachineName, processName)

//let logMessage (initLog : CountingLog) connString curretnProcess message addlInfo  =
    
//    IO.insertAsync connString {initLog.Log with 
//                                UtcTime = DateTime.UtcNow;
//                                Process = curretnProcess
//                                Message = message
//                                StringInfo = addlInfo
//                                } "MyLogPrefix"
    
//    |> Async.AwaitTask
//    |> Async.RunSynchronously
//    |> ignore

let Run(myTimer: TimerInfo, log: TraceWriter ) =
    async {
        let logger = initLog None
        let connString = Environment.GetEnvironmentVariable("tibrutest12_STORAGE")

        //logMessage logger connString None "starting run" None

        if (myTimer. IsPastDue) then
            log.Info("running late", "TestScheduled")

        let now = DateTime.UtcNow.ToLongTimeString()
        log.Info(sprintf "v4 executed at %s!" now, "TestScheduled")

        //logMessage logger connString None "ending run" None

    } |> Async.StartAsTask