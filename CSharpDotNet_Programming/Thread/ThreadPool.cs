using System;
using System.Collections;
using System.Threading;

namespace TreadTraining
{
	public class ReadyState
	{
		public int Cookie;
		public ReadyState(int iCookie)
		{
			Cookie = iCookie;
		}
	}

	public class Alpha
	{
		public Hashtable HashCount;
		public ManualResetEvent eventX;
		public static int iCount=0;
		public static int iMaxCount=0;

		public Alpha(int MaxCount)
		{
			HashCount = new Hashtable (MaxCount);
			iMaxCount = MaxCount;
		}


		//this method could be called when the tread pool has an available thread for 
		//the work item
		public void Beta(Object state)
		{
			//write out the hashcode and cookie for the current thread
			Console.Write ("{0} {1} :", Thread.CurrentThread.GetHashCode (),
				((ReadyState)state).Cookie);
			//the lock keyword allows thread-safe modification
			//of variables accessible across multiple threads
			Console.Write (
				"HashCount.Count=={0}, Thread.CurrentThread.GetHashCode()=={}",
				HashCount.Count,
				Thread.CurrentThread.GetHashCode ());
			lock (HashCount) {
				if (!HashCount.ContainsKey (Thread.CurrentThread.GetHashCode ()))
					HashCount.Add (Thread.CurrentThread.GetHashCode (), 0);
				HashCount [Thread.CurrentThread.GetHashCode ()] =
					((int)HashCount [Thread.CurrentThread.GetHashCode ()]) + 1;
			}
		}

	}
}

