using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Dewey.Data;

namespace Dewey.WinForms
{
    /// <summary>
    /// Extension methods for a DataGridView
    /// </summary>
    public static class DataGridViewExtensions
    {
        /// <summary>
        /// Export a DataGridViews rows and columns to a CSV
        /// </summary>
        /// <param name="dataGridView">The DataGridView from which to export</param>
        public static void ExportCsv(this DataGridView dataGridView)
        {
            var saveFileDialog = new SaveFileDialog();

            saveFileDialog.AddExtension = true;
            saveFileDialog.Filter = "CSV Files (*.csv)|*.csv";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.Title = "Export to CSV...";

            var dataTable = new DataTable();

            foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns) {
                if (dataGridViewColumn.Visible && dataGridViewColumn.ValueType != typeof(Bitmap)) {
                    dataTable.Columns.Add(dataGridViewColumn.Name, typeof(string));
                }
            }

            foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows) {
                var obj = new object[dataTable.Columns.Count];
                var index = 0;

                foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns) {
                    if (dataGridViewColumn.Visible && dataGridViewColumn.ValueType != typeof(Bitmap)) {
                        if (dataGridViewRow.Cells[dataGridViewColumn.Index].Value == null) {
                            obj[index] = "";
                        } else {
                            obj[index] = dataGridViewRow.Cells[dataGridViewColumn.Index].Value.ToString();
                        }

                        index++;
                    }
                }
                dataTable.Rows.Add(obj);
            }

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                dataTable.ExportCsv(saveFileDialog.FileName);
            }
        }

        /// <summary>
        /// Export multiple DataGridViews rows and columns to a CSV
        /// </summary>
        /// <param name="dataGridViews">The DataGridViews from which to export</param>
        public static void ExportCsv(this DataGridView[] dataGridViews)
        {
            var fullName = "";

            var saveFileDialog = new SaveFileDialog
            {
                AddExtension = true,
                Filter = "CSV Files (*.csv)|*.csv",
                FilterIndex = 0,
                OverwritePrompt = true,
                Title = "Export Multiple to CSV"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK) {
                fullName = saveFileDialog.FileName;
            }

            var i = 0;

            foreach (var dataGridView in dataGridViews) {
                var dataTable = new DataTable();

                foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns) {
                    if (dataGridViewColumn.Visible && dataGridViewColumn.ValueType != typeof(Bitmap)) {
                        dataTable.Columns.Add(dataGridViewColumn.Name, typeof(string));
                    }
                }

                foreach (DataGridViewRow dataGridViewRow in dataGridView.Rows) {
                    var obj = new object[dataTable.Columns.Count];
                    var index = 0;

                    foreach (DataGridViewColumn dataGridViewColumn in dataGridView.Columns) {
                        if (dataGridViewColumn.Visible && dataGridViewColumn.ValueType != typeof(Bitmap)) {
                            if (dataGridViewRow.Cells[dataGridViewColumn.Index].Value == null) {
                                obj[index] = "";
                            } else {
                                obj[index] = dataGridViewRow.Cells[dataGridViewColumn.Index].Value.ToString();
                            }

                            index++;
                        }
                    }
                    dataTable.Rows.Add(obj);
                }

                var fileName = fullName.Replace(Path.GetFileNameWithoutExtension(fullName), Path.GetFileNameWithoutExtension(fullName) + " (" + (i++ + 1) + ")");

                dataTable.ExportCsv(fileName);
            }
        }
    }
}
