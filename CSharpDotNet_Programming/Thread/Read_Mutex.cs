using System;
using System.Threading;

namespace Thread_Mutext
{
	public class Read_Mutex
	{
		static Mutex gM1;
		static Mutex gM2;
		const int ITERS =100;
		static AutoResetEvent Event1= new AutoResetEvent(false);
		static AutoResetEvent Event2= new AutoResetEvent(false);
		static AutoResetEvent Event3= new AutoResetEvent(false);
		static AutoResetEvent Event4= new AutoResetEvent(false);

		public static void Main(String[] args)
		{
			Console.WriteLine ("Mutex Sample...");
			//Create Mutext initialOwned, with the name of "MyMutext".
			gM1= new Mutex(true,"MyMutex");
			gM2 = new Mutex (true);
			Console.WriteLine ("-Main owns gM1 and gM2");

			AutoResetEvent[] evs = new AutoResetEvent[4];
			evs[0] = Event1; //Event for t1
			evs[1]= Event2; //Event for t2
			evs[2]= Event3;
			evs[3] = Event4; 

			Read_Mutex tm = new Read_Mutex ();
			Thread t1 = new Thread (new ThreadStart(tm.t1Start));
			Thread t2 = new Thread (new ThreadStart(tm.t2Start));
			Thread t3 = new Thread (new ThreadStart(tm.t3Start));
			Thread t4 = new Thread (new ThreadStart(tm.t4Start));
			t1.Start ();
			t2.Start ();
			t3.Start ();
			t4.Start ();

			Thread.Sleep (2000);
			Console.WriteLine ("- Main release gM1");
			gM1.ReleaseMutex (); //t2 and t3 will end and signal

			Thread.Sleep (1000);
			Console.WriteLine ("- Main release gM2");
			gM2.ReleaseMutex ();

			//waiting until all four threads signal that they are done
			WaitHandle.WaitAll(evs);
			Console.WriteLine ("...Mutext Sample");
		}

		public void t1Start()
		{
			Console.WriteLine ();
			Mutex[] gMs = new Mutex[2];
			gMs [0] = gM1;
			gMs [1] = gM2;
			Mutex.WaitAll (gMs);
			Thread.Sleep (2000);
			Console.WriteLine ("t1Start finished, Mutex.WaitAll(Mutex[]) satisfied");
			Event1.Set ();
		}

		public void t2Start()
		{
			Console.WriteLine ("t2Start started, gM1.WaitOne()");
			gM1.WaitOne ();
			Console.WriteLine ("t2Start finished, gM1.WaitOne() satisfied");
			Event2.Set ();
		}

		public void t3Start()
		{
			Console.WriteLine ("t3Start started, Mutex.WaitAny(Mutex[])");
			Mutex[] gMs = new Mutex[2];
			gMs [0] = gM1;
			gMs [1] = gM2;
			Mutex.WaitAny (gMs);
			Console.WriteLine ("t3Start finish, Mutex.WaitAny(Mutex[])");
			Event3.Set ();
		}

		public void t4Start()
		{
			Console.WriteLine ("t4Start started, gM2.WaitOne()");
			gM2.WaitOne ();
			Console.WriteLine ("t4Start finished, gM2.WaitOne()");
			Event4.Set (); //AutoResetEvent.Set() flagging method is done
		}
	}
}

