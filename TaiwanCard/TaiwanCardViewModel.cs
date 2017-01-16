using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace TaiwanCard
{
	public class TaiwanCardViewModel : ViewModelBase
	{
		#region プロパティ、フィールド定義
		public string WordTaiwan
		{
			get
			{
				return _WordTaiwan;
			}
			set
			{
				if (_WordTaiwan != value)
				{
					_WordTaiwan = value;
					RaisePropertyChanged(nameof(WordTaiwan));
				}
			}
		}
		private string _WordTaiwan = "*Loading...*";

		public string WordJapan
		{
			get
			{
				return _WordJapan;
			}
			set
			{
				if (_WordJapan != value)
				{
					_WordJapan = value;
					RaisePropertyChanged(nameof(WordJapan));
				}
			}
		}
		private string _WordJapan = "読み込み中";

		public bool ShowingTransration
		{
			get
			{
				return _ShowingTransration;
			}
			set
			{
				if (_ShowingTransration != value)
				{
					_ShowingTransration = value;
					RaisePropertyChanged(nameof(ShowingTransration));
					RaisePropertyChanged(nameof(TextTurnButton));
				}
			}
		}
		private bool _ShowingTransration = false;

		public string TextTurnButton
		{
			get
			{
				return _ShowingTransration ? "かくす" : "めくる";
			}
		}

		public ICommand ToggleShowingTransrationCommand { get; }
		public ICommand BackWordCommand { get; }
		public ICommand NextWordCommand { get; }

		private TaiwanCardModel CardModel = new TaiwanCardModel();
		private int CardIndex = 0;
		#endregion

		public TaiwanCardViewModel()
		{
			ToggleShowingTransrationCommand = new Command((nothing) =>
			{
				ShowingTransration = !ShowingTransration;
			});
			BackWordCommand = new Command((nothing) =>
			{
				BackWord();
				HideTransration();
			});
			NextWordCommand = new Command((nothing) =>
			{
				NextWord();
				HideTransration();
			});

			ShowCard(CardIndex);
		}

		private void HideTransration()
		{
			ShowingTransration = false;
		}

		private void BackWord()
		{
			CardIndex--;
			if (CardIndex < 0)
			{
				CardIndex = CardModel.CardList.Count - 1;
			}

			ShowCard(CardIndex);
		}
		private void NextWord()
		{
			CardIndex++;
			if (CardIndex >= CardModel.CardList.Count)
			{
				CardIndex = 0;
			}

			ShowCard(CardIndex);
		}

		private void ShowCard(int cardIndex)
		{
			if (cardIndex < 0 || cardIndex >= CardModel.CardList.Count)
			{
				return;
			}

			Card nextCard = CardModel.CardList[cardIndex];
			WordTaiwan = nextCard.Chinese;
			WordJapan = nextCard.Japanese;
		}
	}
}
