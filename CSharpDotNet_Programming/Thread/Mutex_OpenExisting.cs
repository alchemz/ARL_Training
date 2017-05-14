/*
This simple example uses the Mutex.OpenExisting method. If the OpenExisting method throws an exception, 
the specified named Mutex does not exist or is inaccessible. The IsSingleInstance method uses this behavior.
If the Mutex does not exist, it creates a new one. Further instances of the program then can tell that an 
instance is already open.
*/
using System;
using System.Threading;

class Mutex_OpenExisting
{
    static Mutex _m;

    static bool IsSingleInstance()
    {
        try
        {
            // Try to open existing mutex.
            Mutex.OpenExisting("PERL");
        }
        catch
        {
            // If exception occurred, there is no such mutex.
            Mutex_OpenExisting._m = new Mutex(true, "PERL");

            // Only one instance.
            return true;
        }
        // More than one instance.
        return false;
    }

    static void Main()
    {
        if (!Mutex_OpenExisting.IsSingleInstance())
        {
            Console.WriteLine("More than one instance"); // Exit program.
        }
        else
        {
            Console.WriteLine("One instance"); // Continue with program.
        }
        // Stay open.
        Console.ReadLine();
    }
}
