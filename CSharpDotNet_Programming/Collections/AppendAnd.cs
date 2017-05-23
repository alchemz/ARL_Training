//List<T>

class program
{
	string[] daysOfWeek= new string[] {"Monday", "Tuesday"};
	static void main(string[] args)
	{
		for (int i=0; i<3; i++)
		{
			Console.WriteLine(daysOfWeek[i]);
		}
		
		StringBuilder sb= new StringBuilder();
		for(int i=0; i<daysOfWeek.Length; i++)
		{
			sb.Append(daysOfWeek[i]);
			if(i<daysOfWeek.Length-2)
			{
				sb.Append(",");
			}else if(i==daysOfWeek.Length-2)
				sb.Append("and");
		}
		Console.WriteLine(sb.ToString());
		MakeDaysPlural(daysOfWeek);
	}

	static void MakeDaysPlural(string[] daysOfWeek)
	{
		for(int i=0; <daysOfWeek.Length; i++)
		{
			daysOfWeek[i]= daysOfWeek[i]+"s";
		}
	}

	
	 
}