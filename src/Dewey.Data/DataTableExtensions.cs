using System;
using System.Data;
using System.IO;
using Dewey.Types;

namespace Dewey.Data
{
    public static class DataTableExtensions
    {
        public static void ExportCsv(this DataTable dataTable, string fileName)
        {
            var streamWriter = new StreamWriter(fileName, false);

            var columnCount = dataTable.Columns.Count;

            for (var i = 0; i < columnCount; i++) {
                streamWriter.Write(dataTable.Columns[i].ToString()?.EscapeStringForCsv());

                if (i < columnCount - 1) {
                    streamWriter.Write(",");
                }
            }

            streamWriter.Write(streamWriter.NewLine);

            foreach (DataRow dataRow in dataTable.Rows) {
                for (var i = 0; i < columnCount; i++) {
                    if (!Convert.IsDBNull(dataRow[i])) {
                        streamWriter.Write(dataRow[i].ToString()?.EscapeStringForCsv());
                    }

                    if (i < columnCount - 1) {
                        streamWriter.Write(",");
                    }
                }

                streamWriter.Write(streamWriter.NewLine);
            }

            streamWriter.Close();
        }
    }
}
