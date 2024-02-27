namespace GlucoseDiaryConverter
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            selectCsv = new Button();
            csvPathTextBox = new TextBox();
            xlsPathBtn = new Button();
            xlsPathTextBox = new TextBox();
            convertBtn = new Button();
            csvPath = new OpenFileDialog();
            xlsPath = new FolderBrowserDialog();
            showResult = new Button();
            SuspendLayout();
            // 
            // selectCsv
            // 
            selectCsv.Location = new Point(63, 50);
            selectCsv.Name = "selectCsv";
            selectCsv.Size = new Size(163, 34);
            selectCsv.TabIndex = 0;
            selectCsv.Text = "Выбрать CSV";
            selectCsv.UseVisualStyleBackColor = true;
            selectCsv.Click += BtnSelectCsv_Click;
            // 
            // csvPathTextBox
            // 
            csvPathTextBox.Location = new Point(232, 50);
            csvPathTextBox.Name = "csvPathTextBox";
            csvPathTextBox.Size = new Size(433, 31);
            csvPathTextBox.TabIndex = 1;
            // 
            // xlsPathBtn
            // 
            xlsPathBtn.Location = new Point(63, 112);
            xlsPathBtn.Name = "xlsPathBtn";
            xlsPathBtn.Size = new Size(163, 34);
            xlsPathBtn.TabIndex = 2;
            xlsPathBtn.Text = "Куда сохранить";
            xlsPathBtn.UseVisualStyleBackColor = true;
            xlsPathBtn.Click += BtnSelectXlsPath_Click;
            // 
            // xlsPathTextBox
            // 
            xlsPathTextBox.Location = new Point(232, 115);
            xlsPathTextBox.Name = "xlsPathTextBox";
            xlsPathTextBox.Size = new Size(433, 31);
            xlsPathTextBox.TabIndex = 3;
            // 
            // convertBtn
            // 
            convertBtn.Location = new Point(351, 216);
            convertBtn.Name = "convertBtn";
            convertBtn.Size = new Size(112, 34);
            convertBtn.TabIndex = 4;
            convertBtn.Text = "Сохранить";
            convertBtn.UseVisualStyleBackColor = true;
            convertBtn.Click += BtnSave_Click;
            // 
            // csvPath
            // 
            csvPath.FileName = "data.csv";
            // 
            // showResult
            // 
            showResult.Location = new Point(309, 266);
            showResult.Name = "showResult";
            showResult.Size = new Size(212, 34);
            showResult.TabIndex = 5;
            showResult.Text = "Показать результат";
            showResult.UseVisualStyleBackColor = true;
            showResult.Visible = false;
            showResult.Click += BtnShowResult_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(817, 589);
            Controls.Add(showResult);
            Controls.Add(convertBtn);
            Controls.Add(xlsPathTextBox);
            Controls.Add(xlsPathBtn);
            Controls.Add(csvPathTextBox);
            Controls.Add(selectCsv);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Конвертер CSV";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button selectCsv;
        private TextBox csvPathTextBox;
        private Button xlsPathBtn;
        private TextBox xlsPathTextBox;
        private Button convertBtn;
        private OpenFileDialog csvPath;
        private FolderBrowserDialog xlsPath;
        private Button showResult;
    }
}
