using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ModernHttpClient;
using Newtonsoft.Json;

namespace TaiwanCard
{
	public class TaiwanCardModel : ModelBase
	{
		private const string URL_AIRTABLE = "https://api.airtable.com/v0/appiML4EFdwTL9t4l/Cards?view=Main%20View";
		//private const string URL_AIRTABLE = "https://api.airtable.com/v0/appiML4EFdwTL9t4l/Cards?maxRecords=3&view=Main%20View";

		public List<Card> CardList
		{
			get
			{
				return _CardList;
			}
			private set
			{
				if (_CardList != value)
				{
					_CardList = value;
					RaisePropertyChanged(nameof(CardList));
				}
			}
		}
		private List<Card> _CardList;

		public TaiwanCardModel()
		{
			CardList = new List<Card>();
			LoadData();
		}

		void LoadData()
		{
			// 初回は3件のみ
			CardList = RetriveDataCardList(3);

			Task.Factory.StartNew(() =>
			{
				// 遅延処理で全件取得
				CardList = RetriveDataCardList();
			});
		}

		private List<Card> RetriveDataCardList(int size)
		{
			return RetriveDataCards(size).ToCardList();
		}

		private List<Card> RetriveDataCardList()
		{
			List<Card> cardList = new List<Card>();
			Cards cards = RetriveDataCards(100, "");
			cardList.AddRange(cards.ToCardList());
			while (cards.Offset != null)
			{
				cards = RetriveDataCards(100, cards.Offset);
				cardList.AddRange(cards.ToCardList());
			}
			return cardList;
		}

		private Cards RetriveDataCards(int size, string offset = "")
		{
			string url = URL_AIRTABLE;
			url += string.Format("&pageSize={0}", size);
			if (offset != "")
			{
				url += string.Format("&offset={0}", offset);
			}
			string resultJson = GetJsonFromUrl(url);

			// JSON形式のデータをデシリアライズ
			Cards cards = JsonConvert.DeserializeObject<Cards>(resultJson);

			return cards;
		}

		private string GetJsonFromUrl(string url)
		{
			string resultJson = string.Empty;
			using (var httpClient = new HttpClient())
			{
				try
				{
					httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer keyeOzswcE3NEpEDK");
					// 非同期でAPIからデータを取得
					Task<string> contentsTask = httpClient.GetStringAsync(url);
					resultJson = contentsTask.Result;
				}
				catch (Exception exp)
				{
					System.Diagnostics.Debug.WriteLine(exp.Message);
				}
			}
			return resultJson;
		}
	}
}
