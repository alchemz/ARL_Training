//before 
foreach(string symbol in symbols)
{
	Task t= Task.Factory.StartNew(()=>
	{
		ProcessStockSymbol(symbol, numYearsOfHistory);
	});
}

//pass the data properly
//after
foreach (string symbol in symbols)
{
	Task t= Task.Factory.StartNew((arg) =>
	{
		string sym= (string)arg;
		ProcessStockSymbol(sym, numYearsOfHistory);
	}, symbol);
	
	tasks.Add(t);
}

