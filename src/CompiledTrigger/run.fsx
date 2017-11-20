#if INTERACTIVE

#r "../../packages/Microsoft.Azure.WebJobs/lib/net45/Microsoft.Azure.Webjobs.Host.dll"
#r "../../packages/Microsoft.Azure.WebJobs.Core/lib/net45/Microsoft.Azure.Webjobs.dll"
#r "../../packages/Microsoft.Azure.WebJobs.Extensions/lib/net45/Microsoft.Azure.WebJobs.Extensions.dll"

#r "../../lib/PSlogger/PSlogger.dll"
#r "../../lib/PSlogger/FsPickler.dll"
#r "../../../PSlogger/bin/PSlogger/Microsoft.WindowsAzure.Storage.dll"

#r "System.Configuration.dll"

#endif

open System
open Microsoft.Azure.WebJobs
open Microsoft.Azure.WebJobs.Host
open Microsoft.Azure.WebJobs.Extensions
open PSlogger             //this DLL is called            
open MBrace.FsPickler     //which calls this DLL



let initLog processName =

     let utcTime = DateTime.UtcNow

     let assemblyFullName =
         let assembly = System.Reflection.Assembly.GetExecutingAssembly()
         assembly.FullName

     CountingLog("Dashboard", utcTime, LogLevel.Info, assemblyFullName, Environment.MachineName, processName)

let logMessage (initLog : CountingLog) connString curretnProcess message addlInfo  =
    
    // fails inside this call, whether I use the async or non-async function
    //IO.insertAsync connString {initLog.Log with 
    IO.insert connString {initLog.Log with 
                                UtcTime = DateTime.UtcNow;
                                Process = curretnProcess
                                Message = message
                                StringInfo = addlInfo
                                } "MyLogPrefix"

let public Run(myTimer: TimerInfo, log: TraceWriter ) =
    async {
        JobHostConfiguration().UseTimers()
        let logger = initLog None
        let connString = Environment.GetEnvironmentVariable("tibrutest12_STORAGE")
        
        logMessage logger connString None "starting run" None |> ignore

        if (myTimer. IsPastDue) then
            log.Info("running late", "TestScheduled")

        let now = DateTime.UtcNow.ToLongTimeString()
        log.Info(sprintf "v8 executed at %s!" now, "TestScheduled")

        logMessage logger connString None "ending run" None |> ignore

    } |> Async.StartAsTask