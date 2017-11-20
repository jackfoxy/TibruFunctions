# TibruFunctions

Demonstrates problem https://stackoverflow.com/questions/47383091/compiled-azure-function-functioninvocationexception-method-not-found

src/CompiledTrigger is problematic compiled function

func run CompiledTrigger

results in error

    No job functions found. Try making your job classes and methods public. If you're using binding extensions (e.g. ServiceBus, Timers, etc.) make sure you've called the registration method for the extension(s) in your startup code (e.g. config.UseServiceBus(), config.UseTimers(), etc.).