// shared resources
//unsafe: writes and reads the sum the same time
int sum=0;//parallel code;

Task.Factory.StartNew(()=>
{sum= sum+ obj1.Computation();});

Task.Factory.StartNew(()=>
{sum=sum+obj2.Computation();});

Task.Factory.StartNew(()=>
{sum= sum+ obj3.Computation();});

