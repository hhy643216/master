using System;
using System.Collections.Generic;
using Cirrious.MvvmCross.Droid.Fragging.Fragments;
using Cirrious.MvvmCross.ViewModels;
using Android.OS;
using Cirrious.CrossCore;
using Android.Support.V4.App;

namespace AndroidLearningDemo.Droid
{
	public class MvxFragmentHost : MvxActionBarActivity
	{
		//ViewModelのTypeをキーに子として持つViewControllerを保持
		private Dictionary<Type, MvxFragment> allViews = new Dictionary<Type, MvxFragment> ();

		/// <summary>
		/// 指定したレイアウトIDにFragmentを表示させる
		/// 注:MvxViewModelRequestからFragmentインスタンスの生成をする機能が準備されていないため、Fragmentの形を渡しているが、
		/// 自前で実装できそうであればそちらに変更したい
		/// </summary>
		/// <param name="containerId">レイアウトID.</param>
		/// <param name="viewType">表示するFragmentのType.</param>
		/// <param name="request">MvxViewModelRequest.</param>
		protected void ShowFragment (int containerId, Type viewType, MvxViewModelRequest request)
		{
			MvxFragment newFlg;

			if (!allViews.TryGetValue (request.ViewModelType, out newFlg)) {

				//DictionaryにViewが登録されていない時、Fragmentのインスタンスを生成して、Dictionaryに追加
				newFlg = Activator.CreateInstance (viewType) as MvxFragment;

				//後で、Bundleに保存するようにする
				newFlg.ProvideViewModelRequest(request);

				allViews.Add (request.ViewModelType, newFlg);
			}

			//レイアウトに表示するFragmentを切り替える
			Show (containerId, newFlg);
		}

		/// <summary>
		/// 指定したレイアウトIDにFragmentを表示.
		/// </summary>
		/// <param name="containerId">レイアウトID.</param>
		/// <param name="newFlg">表示するFragment.</param>
		private void Show (int containerId, MvxFragment newFlg)
		{

			FragmentTransaction transaction = this.SupportFragmentManager.BeginTransaction ();

			var currentFlg = SupportFragmentManager.FindFragmentById (containerId);

			if (newFlg == currentFlg)
				return;

			transaction.Replace (containerId, newFlg);
			transaction.AddToBackStack (null);

			transaction.Commit ();
		}
	}
}

