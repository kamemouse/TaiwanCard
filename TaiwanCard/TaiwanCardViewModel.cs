using System;
using System.ComponentModel;
using System.Windows.Input;
using Kixmate.Share;
using TaiwanCard.Share;
using Xamarin.Forms;

namespace TaiwanCard
{
	public class TaiwanCardViewModel : ViewModelBase
	{
		#region プロパティ、フィールド定義
		public int WordNo
		{
			get
			{
				return _No;
			}
			set
			{
				if (_No != value)
				{
					_No = value;
					RaisePropertyChanged(nameof(WordNo));
				}
			}
		}
		private int _No = 1;

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

		public string WordPinyin
		{
			get
			{
				return _WordPinyin;
			}
			set
			{
				if (_WordPinyin != value)
				{
					_WordPinyin = value;
					RaisePropertyChanged(nameof(WordPinyin));
				}
			}
		}
		private string _WordPinyin = "";

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

			CardModel.PropertyChanged += HandlePropertyChangedEventHandler;

			ShowCard(CardIndex);
		}

		void HandlePropertyChangedEventHandler(object sender, PropertyChangedEventArgs e)
		{
			switch (e.PropertyName)
			{
				case nameof(CardModel.CardList):
					ShowCard(CardIndex);
					break;
			}
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
			WordNo = nextCard.No;
			WordPinyin = nextCard.Pinyin;
			WordTaiwan = nextCard.Chinese;
			WordJapan = nextCard.Japanese;
		}
	}
}
