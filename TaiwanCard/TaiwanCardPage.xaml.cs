using Xamarin.Forms;

namespace TaiwanCard
{
	public partial class TaiwanCardPage : ContentPage
	{
		public TaiwanCardPage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// 左方向へのスワイプ
		/// </summary>
		/// <param name="sender">Sender.</param>
		/// <param name="e">E.</param>
		void Handle_LeftSwipe(object sender, System.EventArgs e)
		{
			var vm = (TaiwanCardViewModel)BindingContext;
			var command = vm.NextWordCommand;
			if (command.CanExecute(null))
			{
				command.Execute(null);
			}
		}

		void Handle_RightSwipe(object sender, System.EventArgs e)
		{
			var vm = (TaiwanCardViewModel)BindingContext;
			var command = vm.BackWordCommand;
			if (command.CanExecute(null))
			{
				command.Execute(null);
			}
		}
}
}
