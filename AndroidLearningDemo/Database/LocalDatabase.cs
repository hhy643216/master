using System;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace AndroidLearningDemo
{
	public class LocalDatabase
	{
		/// <summary>
		/// DBファイル名を返す.
		/// </summary>
		/// <value>DBファイル名.</value>
		public static string DBFileName {
			get {
				return "LearningTestDatabase.db";
			}
		}

		/// <summary>
		/// データベース初期化処理
		/// </summary>
		/// <param name="connection">ISQLiteConnection</param>
		public void Initialization (ISQLiteConnection connection)
		{
			//テーブル作成
			connection.CreateTable<Record> ();
		}
	}
}

