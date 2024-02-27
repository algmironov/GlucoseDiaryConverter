using GlucoseDiaryConverter.Properties;

namespace GlucoseDiaryConverter
{
    public partial class Form1 : Form
    {
        private string csvPathText = string.Empty;
        private string xlsPathText = string.Empty;
        private string xlsFullPath = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSelectCsv_Click(object sender, EventArgs e)
        {
            
            csvPath.Filter = "CSV files (*.csv)|*.csv";
            csvPath.Title = "�������� ���� CSV";

            if (csvPath.ShowDialog() == DialogResult.OK)
            {
                csvPathTextBox.Text = csvPath.FileName;
                csvPathText = csvPath.FileName;
            }
        }

        private void BtnSelectXlsPath_Click(object sender, EventArgs e)
        {
            xlsPath.RootFolder = Environment.SpecialFolder.Personal;
            xlsPath.ShowNewFolderButton = true;
            xlsPath.ShowPinnedPlaces = true;

            if (xlsPath.ShowDialog() == DialogResult.OK)
            {
                xlsPathTextBox.Text = xlsPath.SelectedPath;
                xlsPathText = xlsPath.SelectedPath;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            string resultPath = Path.Combine(xlsPathText, "������� ������������.xlsx");
            xlsFullPath = resultPath;
            File.WriteAllBytes(resultPath, Resources.�������_������������);
           
            
            if(Converter.Convert(csvPathText, resultPath))
            {
                MessageBox.Show("������ ������� ���������");
                csvPathText = string.Empty;
                xlsPathText = string.Empty;
                xlsPathTextBox.Text = string.Empty;
                csvPathTextBox.Text = string.Empty;
                showResult.Visible = true;
            }
            else
            {
                MessageBox.Show("��������� ������!, ������ �� ���������!");
            }
            
        }

        private void BtnShowResult_Click(object sender, EventArgs e)
        {
            Table table = new Table(xlsFullPath);
            table.Show();
        }
    }
}
