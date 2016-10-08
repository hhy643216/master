using System;
using System.Collections.Generic;

namespace AndroidLearningDemo
{
	public interface IRecordService
	{
		List<RecordDto> FindAllRecords ();

		Record FindRecordById (int recordId);

		int InsertRecord (string recordText);
	}
}

