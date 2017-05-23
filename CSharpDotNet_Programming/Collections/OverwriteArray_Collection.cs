class Program
{
	static void Main(string[] args)
	{
		string[] daysOfWeek={"Monday","Tueday"};
		ICollection<string> collection= (ICollection<string>)daysOfWeek;
		Console.WriteLine("Count()="+Collection.Count());
		Console.WriteLine("Count"+Conllection.Count);
		Console.WriteLine("Length"+ daysOfWeek.Length());
		
		ICollection<string> collection=
		(ICollection<string>)daysOfWeek;
		
		(collection as string[])[5]="SlaveDay";
		if(!collection.IsReadOnly)
			collection.Add("SlaveDay");
		else
			Console.WriteLine("Collection is read only");		
	}
}