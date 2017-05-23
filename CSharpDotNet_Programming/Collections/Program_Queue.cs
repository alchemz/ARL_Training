//the opposite of the stack
//queue: first in and first out
//endqueue and Dequeue

class Program_Queue
{
	static void Main(string[] agrs)
	{
		Queue<string> tasks= new Queue<string>();
		
		tasks.Enqueue(“Do the washing up”);
		tasks.Enqueue(“Finish the C# tutorial”);
		tasks.Enqueue(“Buy some chocolate”);
		tasks.Enqueue(“Buy some more chocolate”);
		
		string firstTask= tasks.Dequeue();
		string firstTask= tasks.Peek();
		Console.WriteLine(“”\r\nAll TASKS:”);
		foreach(string title in tasks)
		Console.WriteLine(title);
	}	
}
