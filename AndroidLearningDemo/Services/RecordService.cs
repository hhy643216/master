using System;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;
using System.Collections.Generic;

namespace AndroidLearningDemo
{
	public class RecordService : IRecordService
	{
		/// <summary>
		/// The connection.
		/// </summary>
		private readonly ISQLiteConnection _connection;

		/// <summary>
		/// Initializes a new instance of the <see cref="AndroidLearningDemo.RecordService"/> class.
		/// </summary>
		/// <param name="factory">Factory.</param>
		public RecordService (ISQLiteConnectionFactory factory)
		{
			_connection = factory.Create (LocalDatabase.DBFileName);
		}

		/// <summary>
		/// Finds all records.
		/// </summary>
		/// <returns>The all records.</returns>
		public List<RecordDto> FindAllRecords ()
		{
			RecordDao recordDao = new RecordDao (_connection);
			List<Record> recordList = recordDao.FindAllRecord ();
			List<RecordDto> recordDtoList = null;

			if (recordList != null && recordList.Count != 0) {
				recordDtoList = new List<RecordDto> ();

				foreach (Record record in recordList) {
					recordDtoList.Add (new RecordDto (record));
				}
			}
			return recordDtoList;
		}

		/// <summary>
		/// Finds the record by identifier.
		/// </summary>
		/// <returns>The record by identifier.</returns>
		/// <param name="recordId">Record identifier.</param>
		public Record FindRecordById (int recordId)
		{
			RecordDao recordDao = new RecordDao (_connection);
			return recordDao.FindByRecordId (recordId);
		}

		/// <summary>
		/// Insert the specified record.
		/// </summary>
		/// <param name="record">Record.</param>
		public int InsertRecord (string recordText)
		{
			RecordDao recordDao = new RecordDao (_connection);
			Record record = new Record () {
				Id = 0,
				RecordDetail = recordText
			};
			return recordDao.Insert (record);
		}
	}
}

