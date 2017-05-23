namespace Modify.Elements.In.ForeachLoop
{
	class Program
	{
		static void Main(string[] args)
		{
			Person[] people = new Person[]
			{
				new Person{Name="Bill", Age=7},
				new Person{Name="Ben", Age=8}
			};
			
			foreach (Person person in people
			{
				person.Age=11;//modify the age properties
				Console.WriteLine(person);
			}
		}
	}

	public class Person
	{	
		//reference
		public string Name{get; set;}
		public int Age(get; set;}


		//over-reference
		public override string ToString()
		{
			return string.Format("{0}, age={1}", Name, Age);
		}
	}
}
