using System;
using System.ComponentModel;
using System.Windows.Input;

namespace TaiwanCard
{
	#region ** Class : ViewModelBase
	/// <summary>
	/// ViewModelの基底クラス
	/// INotifyPropertyChanged と IDataErrorInfo を実装する
	/// </summary>
	public abstract class ModelBase : INotifyPropertyChanged
	{
		#region == implement of INotifyPropertyChanged ==

		// INotifyPropertyChanged.PropertyChanged の実装
		public event PropertyChangedEventHandler PropertyChanged;

		// INotifyPropertyChanged.PropertyChangedイベントを発生させる。
		protected virtual void RaisePropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion

		//#region == implemnt of IDataErrorInfo ==

		//// IDataErrorInfo用のエラーメッセージを保持する辞書
		//private Dictionary<string, string> _ErrorMessages = new Dictionary<string, string>();

		//// IDataErrorInfo.Error の実装
		//string IDataErrorInfo.Error
		//{
		//	get { return (_ErrorMessages.Count > 0) ? "Has Error" : null; }
		//}

		//// IDataErrorInfo.Item の実装
		//string IDataErrorInfo.this[string columnName]
		//{
		//	get
		//	{
		//		if (_ErrorMessages.ContainsKey(columnName))
		//			return _ErrorMessages[columnName];
		//		else
		//			return null;
		//	}
		//}

		//// エラーメッセージのセット
		//protected void SetError(string propertyName, string errorMessage)
		//{
		//	_ErrorMessages[propertyName] = errorMessage;
		//}

		//// エラーメッセージのクリア
		//protected void ClearErrror(string propertyName)
		//{
		//	if (_ErrorMessages.ContainsKey(propertyName))
		//		_ErrorMessages.Remove(propertyName);
		//}

		//#endregion
	}
	#endregion
}
