using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using TaiwanCard.Share;

namespace TaiwanCard.Shares
{
	public class CardSerializer
	{
		public CardSerializer()
		{
		}

		//public string Serialize(Card card)
		//{
		//	return JsonConvert.SerializeObject(card);
		//}

		public List<Card> Deserialize(String text)
		{
			return JsonConvert.DeserializeObject<List<Card>>(text);
		}
	}
}
