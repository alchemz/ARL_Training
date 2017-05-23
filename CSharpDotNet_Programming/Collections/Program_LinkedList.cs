class Program_LinkedList
{
	static void Main(string[] args)
	{
		var presidents= new LinkedList<string>();
		presidents.AddLast(“JFK”);
		presidents.AddLast*”Lyndon B Johnson”);
		presidents.AddLast(“Richard Nixon”);
		presidents.AddLast(“Jimmy Carter”);
		
		//replace the first element
		//remove the first element
		presidents.RemoveFirst();
		presidents.AddFirst(“John F Kennedy”);
		
		//Add element after certain position
		LinkedListNode<string> nixon= presidents.Find(“Richard Nixon”);
		presidents.AddAfter(nixon, “Gerald Ford”);

		foreach(string item in presidents)
		consosle.WriteLine(item);
	}
}
