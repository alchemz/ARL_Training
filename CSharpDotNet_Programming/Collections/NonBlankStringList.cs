using System;
using System.Collection.Generic;
using System.Collection.ObjectModel;
using System.Linq;
using System.Text;

namespace SummerTraining
{
	class NonBlankStringList: Collection<string>
	{
		protected override void InsertItem(int index, string item)
		{
			if(string.IsNullOrWhiteSpace(item)
				throw new ArgumentedException("Elements of nonblankStringList
					must not be null or whitespace");
			base.InsertItem(index,item);
		}
		
		protected override void SetItem(int index, string item)
		{
			if(string.IsNullOrWhiteSpace(item)
				throw new ArgumentedException("Elements of nonblankStringList
					must not be null or whitespace");
			base.SetItem(index,item);
		}
	}
}