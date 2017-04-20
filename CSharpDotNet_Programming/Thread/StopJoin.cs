using System;
using System.Threading;

namespace ThreadTutorial
{
	public class StopJoin
	{
		public void Beta()
		{
			while (true) {
				Console.WriteLine ("Beta is running in its own thread");
			}
		}
	};

	public class Simple
	{
		public static int Main()
		{
			Console.WriteLine ("Thread Start/Stop/Join Sample");

			StopJoin oStop = new StopJoin ();

			//create the thread object, passing in the Beta method
			Thread oThread= new Thread(new ThreadStart(oStop.Beta));

			//start the thread
			oThread.Start();

			//Spin for a while waiting for the started thread to become alive
			while(!oThread.IsAlive);

			//put the main thrad to sleep for 1 millisecond to allow oThread
			Thread.Sleep(1);

			//request  that oThread be stopped
			oThread.Abort();

			//wait until oThread finishes,Join also has overloads that takes a ms
			//interval ot a TimeSpan object
			oThread.Join();

			Console.WriteLine();
			Console.WriteLine("Beta has finished");

			try
			{
				Console.WriteLine("Try to restart the StopJoin.Beta thread");
				oThread.Start();
			}
			catch(ThreadStateException) 
			{
				Console.WriteLine ("ThreadStateException trying to restart StopJoin.Beta");
				Console.WriteLine ("Excepted since aborted threads cannot be restarted.");
			}
			return 0;
		}
	}
}

