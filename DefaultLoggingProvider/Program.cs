// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.Logging;
using System.Diagnostics;

/*
 * Console
 */

using ILoggerFactory loggerFactory =
      LoggerFactory.Create(builder =>
          builder.AddSimpleConsole(options =>
          {
              options.IncludeScopes = true;
              options.SingleLine = true;
              options.TimestampFormat = "hh:mm:ss ";
          }));

ILogger<Program> logger = loggerFactory.CreateLogger<Program>();
using (logger.BeginScope("[scope is enabled]"))
{
    logger.LogInformation("Hello World!");
    logger.LogInformation("Logs contain timestamp and log level.");
    logger.LogInformation("Each log message is fit in a single line.");
}

/**
 * Debug
 */

Debug.AutoFlush = true;
Debug.Indent();
Debug.WriteLine("Entering Main");
Console.WriteLine("Hello World.");
Debug.WriteLine("Exiting Main");
Debug.Unindent();

///**
// * Tracing
// */

BooleanSwitch boolSwitch = new BooleanSwitch("ABooleanSwitch",
                                             "Demo bool Switch");
TraceSwitch traceSwitch = new TraceSwitch("ATraceSwitch",
                                           "Demo trace switch");

// Set the switch values programmatically
boolSwitch.Enabled = true;
traceSwitch.Level = TraceLevel.Info;

Trace.WriteLineIf(boolSwitch.Enabled, "bool switch is enabled");
Trace.WriteLineIf(traceSwitch.TraceInfo,
                  "traceSwitch.TraceInfo is enabled");
Trace.WriteLineIf(traceSwitch.TraceError,
                  "traceSwitch.TraceError is enabled");
