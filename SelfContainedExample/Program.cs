using Microsoft.FlightSimulator.SimConnect;
using System.Diagnostics;
using System.Runtime.InteropServices;

var simEvent = new AutoResetEvent(false);

SimConnect simConnect;
try
{
    simConnect = new SimConnect("Self Contained Test", Process.GetCurrentProcess().Handle, 0, simEvent, 0);
}
catch (COMException ex)
{
    Console.WriteLine("Failed to connect to Flight Simulator: " + ex.Message);
    return;
}

simConnect.OnRecvOpen += (sender, data) => Console.WriteLine("Connected to Flight Simulator");

Console.WriteLine("Waiting for sim event...");
simEvent.WaitOne();