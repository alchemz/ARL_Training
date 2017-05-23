//can only add element of the top of stack
//first in and first out
//example a pile of book
 
class Program_Stack
{
	static void Main()
	{
		Stack<string> books= new Stack<string>();
			
		books.Push(“Programming WPF”);
		books.Push(“The Philosophy Book”);
		books.Push(“Heat and Thermodynamics”);
		books.Push(“Harry Potter and the Chamber of Secrets”);
			
		sting topItem= books.Pop();
		string _topItem=books.Peek();

		Console.WriteLine(“All Books”);
		foreach(string title in books)
		Console.WriteLine(title);
	}
}
