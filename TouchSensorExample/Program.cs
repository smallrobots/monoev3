using System;
using MonoBrickFirmware.IO;
using System.Threading;
namespace TouchSensorExample
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			ManualResetEvent terminateProgram = new ManualResetEvent(false);
			var touchSensor = new TouchSensor(SensorPort.In1);
			ButtonEvents buts = new ButtonEvents ();
			buts.EnterPressed += () => { 
				terminateProgram.Set();
			};
			buts.UpPressed += () => { 
				Console.WriteLine("Sensor value:" + touchSensor.ReadAsString());
			};
			buts.DownPressed += () => { 
				Console.WriteLine("Raw sensor value: " + touchSensor.ReadRaw());
			};  
			terminateProgram.WaitOne();
		}
	}
}
