using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using OfficeOpenXml;

namespace GlucoseDiaryConverter
{
    public partial class Table : Form
    {
        public Table(string filePath)
        {
            InitializeComponent();

            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Get the first worksheet
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                // Create a DataTable to hold the Excel data
                DataTable table = new DataTable();

                // Get the first row (headers)
                int colCount = worksheet.Dimension.End.Column;
                for (int i = 1; i <= colCount; i++)
                {
                    table.Columns.Add(worksheet.Cells[1, i].Text);
                }

                // Get the rest of the rows
                int rowCount = worksheet.Dimension.End.Row;
                for (int r = 2; r <= rowCount; r++)
                {
                    var row = worksheet.Cells[r, 1, r, colCount].Select(c => c.Text).ToArray();
                    table.Rows.Add(row);
                }

                // Bind the DataTable to the DataGridView
                dataGridView1.DataSource = table;
            }
        }
    }
}
