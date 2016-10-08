using System;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using System.Collections.Generic;
using System.Linq;

namespace AndroidLearningDemo
{
	public class RecordDao : BaseDao<Record>
	{
		public RecordDao (ISQLiteConnection connection) : base (connection)
		{
		}

		/// <summary>
		/// Finds the by record identifier.
		/// </summary>
		/// <returns>The by record identifier.</returns>
		/// <param name="recordId">Record identifier.</param>
		public Record FindByRecordId (int recordId)
		{
			lock (_connection) {
				return _connection.Table<Record> ()
					.Where (x => x.Id == recordId)
					.FirstOrDefault ();
			}
		}

		public List<Record> FindAllRecord ()
		{
			lock (_connection) {
				return _connection.Table<Record> ()
					.OrderBy (x => x.Id)
					.ToList ();
			}
		}

		/// <summary>
		/// EntityをDBに保存
		/// </summary>
		/// <param name="entity">Entity</param>
		public int Insert (Record record)
		{
			if (0 == record.Id) {
				record.Id = LastInsertID() + 1;
			}

			return _connection.Insert (record);
		}

		/// <summary>
		/// 最新登録したレコードのID
		/// </summary>
		/// <returns>Record型.</returns>
		public int LastInsertID()
		{
			lock (_connection) {
				var item = _connection.Table<Record> ().LastOrDefault ();
				if (item == null) {
					return 0;
				} 
				return item.Id;
			}
		}
	}
}

