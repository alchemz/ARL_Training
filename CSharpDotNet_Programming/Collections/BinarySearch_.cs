class Program
{
	static void Main(string[] args)
	{
		string[] daysOfWeek=={
					"Monday",
					"Tuesday",
					"Wednesday"
					};

		string[] allWith6Chars = Array.FindAll(
			daysOfWeek, x=>x.Length==6);
		foreach(string item in allWith6Chars)
		{
			Console.WriteLine(item);
		}
		
		int indexOfSun= Array.BinarySearch(sortedDays, "Sunday");
		Console.WriteLine("The Index is"+ indexOfSun);
	}
}