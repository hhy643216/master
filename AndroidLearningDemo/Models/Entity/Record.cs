using System;
using Cirrious.MvvmCross.Community.Plugins.Sqlite;

namespace AndroidLearningDemo
{
	public class Record
	{
		/// <summary>
		/// Gets or sets the record ID.
		/// </summary>
		/// <value>The identifier.</value>
		[PrimaryKey]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the record detail.
		/// </summary>
		/// <value>The record detail.</value>
		public string RecordDetail { get; set; }
	}
}

