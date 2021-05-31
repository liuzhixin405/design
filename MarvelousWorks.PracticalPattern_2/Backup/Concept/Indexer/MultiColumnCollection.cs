using System;
using System.Data;
namespace MarvellousWorks.PracticalPattern.Concept.Indexer
{
    public class MultiColumnCollection
    {
        private static DataSet data = new DataSet();
        static MultiColumnCollection()
        {
            data.Tables.Add("Data");
            data.Tables[0].Columns.Add("name");
            data.Tables[0].Columns.Add("gender");
            data.Tables[0].Rows.Add(new string[] { "joe", "male" });
            data.Tables[0].Rows.Add(new string[] { "alice", "female" });
        }
        public static DataSet Data { get { return data; } }
    }
}
