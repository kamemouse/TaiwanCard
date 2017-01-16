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
		private const string URL_AIRTABLE = "https://api.airtable.com/v0/appiML4EFdwTL9t4l/Cards?maxRecords=3&view=Main%20View";

		public List<Card> CardList
		{
			get;
			private set;
		}

		public TaiwanCardModel()
		{
			CardList = new List<Card>();
			LoadData();
		}

		void LoadData()
		{
			CardList = RetriveDataCardList();
		}

		private List<Card> RetriveDataCardList()
		{
			List<Card> cardList = null;
			string resultJson = GetJsonFromUrl(URL_AIRTABLE);

			// JSON形式のデータをデシリアライズ
			Cards cards = JsonConvert.DeserializeObject<Cards>(resultJson);

			// List でデータを返す
			cardList = cards.ToCardList();

			return cardList;
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
