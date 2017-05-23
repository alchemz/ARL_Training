using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SummerTraining
{
	class Program_Main
	{
		static void Main(string[] args)
		{

			/*
			var primeMinisters= new List<PrimeMinister>
			{
				new PrimeMinister(“James Callaghan”, 1976);
				new PrimeMinister(“Margaret Thatcher”,1979);
				new PrimeMinister(“Tony Blair”, 1997);
			};
			*/
			var primeMinister = new Dictionary(<string, PrimeMinister>
			{
				{“JC”, new PrimeMinister(“James Callaghan”, 1976)},
				{“MT”, new PrimeMinister(“Margrate Thatcher”, 1976)},
				{“TB”, new PrimeMinister(“Tony Blair”, 1976)},
			};
			foreach(var pm in primeMinisters)
			Console.WriteLine(pm.Values);
			foreach(var pm in primeMinisters)
			Console.WriteLine(pm.Keys);

		}
		
	..}

	public class PrimeMinister
	{
		public string Name{get; private set;}
		public int YearElected{get; private set;}
		

		public PrimeMinister(string name, int yearElected)
		{
			this.Name=name;
			this.YearElected= yearElected;
		}

		public override string ToString()
		{
			return string.Format(“{0}, elected:{1}”, Name, YearElected);
		}
	}
}
