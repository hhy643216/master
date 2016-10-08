using System;

namespace AndroidLearningDemo
{
	public class RecordDto
	{
		/// <summary>
		/// レコードID
		/// </summary>
		/// <value>ワクチンID</value>
		public int RecordId { get; set; }

		/// <summary>
		/// レコード詳細
		/// </summary>
		/// <value>イベントタイプ</value>
		public string RecordDetail { get; set; }

		public RecordDto ()
		{
			RecordId = 0;
			RecordDetail = string.Empty;
		}

		public RecordDto (Record entity)
		{
			RecordId = entity.Id;
			RecordDetail = entity.RecordDetail;
		}
	}
}

