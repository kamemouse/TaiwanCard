using System;
using System.Collections.Generic;

namespace TaiwanCard
{
	public class Cards
	{
		public List<Record> Records
		{
			get;
			set;
		}
		public string Offset
		{
			get;
			set;
		}

		public Cards()
		{
		}

		/// <summary>
		/// Tos the card list.
		/// </summary>
		/// <returns>The card list.</returns>
		internal List<Card> ToCardList()
		{
			List<Card> cardList = new List<Card>();
			foreach (var record in Records)
			{
				cardList.Add(record.fields);
			}
			return cardList;
		}

		#region inner class
		public class Record
		{
			public string id
			{
				get;
				set;
			}
			public Card fields
			{
				get;
				set;
			}
			public string createdTime
			{
				get;
				set;
			}
		}

	#endregion
	}
}
