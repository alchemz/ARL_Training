//sequential credit review 
static void UpdatedPredictionsSequential( AccountsRepository accounts)
{
	foreach(Account account in accounts.AllAccounts)
	{
		Trend trend= SampleUtilities.Fit(account.Balance);
		double prediction=trend.Predict(account.Balance.Length+NumberOfMonths);
		account.SeqPrediction=prediction;
		account.SeqWarning=prediction<account.Overdraft;
	}
}

//credit review using Parallel.ForEach
static void UpdatePredictionsParallel(AccountRepository accounts)
{
	Parallel.ForEach(accounts.AllAccounts, account =>
	{
		Trend trend = SampleUtilities.Fit(account.Blance);
		double prediction= trend.Prediction(account.Balance.Length+NumberOfMonths);
		acount.ParPrediction=prediction;
		account.SeqWarning=prediction<account.Overdraft;
	});
}

//credit review using PLINQ
static void UpdatePredictionPlinq(AccountRepository accounts)
{
	accounts.AllAccounts.AsParallel().ForAll(account=>
	{
		Trend trend = SampleUtilities.Fit(account.Balance);
		double prediction= trend.Predict(account.Balance.Length+NumberOfMonths);
		account.PlinqPrediction= prediction;
		account.PlinqPrediction<account.Overdraft;
	});
}
