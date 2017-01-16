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
		public ICommand NextWordCommand { get; }

		private TaiwanCardModel CardModel = new TaiwanCardModel();
		private int CardIndex = -1;
		#endregion

		public TaiwanCardViewModel()
		{
			ToggleShowingTransrationCommand = new Command((nothing) =>
			{
				ShowingTransration = !ShowingTransration;
			});
			NextWordCommand = new Command((nothing) =>
			{
				NextWord();
				HideTransration();
			});

			NextWord();
		}

		private void HideTransration()
		{
			ShowingTransration = false;
		}

		private void NextWord()
		{
			if (CardModel.CardList.Count == 0)
			{
				return;
			}

			CardIndex++;
			if (CardIndex >= CardModel.CardList.Count){
				CardIndex = 0;
			}

			Card nextCard = CardModel.CardList[CardIndex];
			WordTaiwan = nextCard.Chinese;
			WordJapan = nextCard.Japanese;
		}
	}
}
