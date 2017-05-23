class Program
{
	static void Main(string[] args)
	{
		object[] objArray= new object[3]
		{
			"Hello World",
			4,
			new Button{Text= "Click me!"}
		};

		Type objArrType=objArray.GetType();

		foreach(object item in objArray)
			Console.WriteLine(item);
	}
}