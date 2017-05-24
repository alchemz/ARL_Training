class UncasedStringEqualityComparer: IEqualityComparer<string>
{
	public bool Equals(string x, string y)
	{
		return x.ToUpper()==y.ToUpper();
	}

	public int GetHashCode(string obj)
	{
		return obj.ToUpper().GetHashCode();
	}
}

//to use it, just pass it to the new constructor:
//var big= new HashSet<string> (new UncasedStringEqualityComparer()){"",""};