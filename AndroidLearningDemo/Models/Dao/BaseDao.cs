using System;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using System.Collections.Generic;
using System.Linq;

namespace AndroidLearningDemo
{
	public abstract class BaseDao<T> where T : new()
	{
		/// <summary>
		/// ISQLiteConnection
		/// </summary>
		protected readonly ISQLiteConnection _connection;

		public BaseDao (ISQLiteConnection connection)
		{
			_connection = connection;
			_connection.CreateTable<T> ();
		}

		/// <summary>
		/// テーブルに保存されている全てのEntityを取得
		/// </summary>
		/// <returns>The all.</returns>
		public List<T> FindAll ()
		{
			return _connection.Table<T> ().ToList ();
		}

		/// <summary>
		/// EntityをDBに保存
		/// </summary>
		/// <param name="entity">Entity.</param>
		public int Insert (T entity)
		{
			return _connection.Insert (entity);
		}
	}
}

