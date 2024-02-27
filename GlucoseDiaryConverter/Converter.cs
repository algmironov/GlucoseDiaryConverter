using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Microsoft.Extensions.FileSystemGlobbing.Internal;

using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;

using OpenCsv.Core;

using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GlucoseDiaryConverter
{
    public class Converter
    {

        public Converter() {

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        
        }

        private static GlucoseModel ConvertModels(ParsedModel parsedModel)
        {
            GlucoseModel model = new GlucoseModel();
            model.Date = parsedModel.Date;
            model.BeforeMeal = parsedModel.BeforeMeal;
            model.Note = parsedModel.Note;
            if (decimal.TryParse(parsedModel.Value, out decimal result))
            {
                model.Value = result;
            }
            return model;
        }

        public static bool Convert(string sourcePath, string destinationPath)
        {
            bool result = false;
            var cellData = new string[10];
            List<ParsedModel> parsedModels = new List<ParsedModel>();
            
            string[] recs = File.ReadAllLines(sourcePath);
            foreach (var record in recs)
            {
                cellData = DataParser(record);
                if (cellData[0].Contains('#'))
                {
                    continue;
                }
                parsedModels.Add(ParseModels(cellData));
            }
            List<GlucoseModel> models = new List<GlucoseModel>();
            foreach (var parsedModel in parsedModels)
            {
                models.Add(ConvertModels(parsedModel));
            }
            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                using (ExcelPackage excelPackage = new ExcelPackage())
                {
                    ExcelWorkbook workbook = excelPackage.Workbook;
                    ExcelWorksheet worksheet = workbook.Worksheets.Add("Sheet1");
                    int rowIndex = 1;

                    // Запись заголовков свойств
                    worksheet.Cells[rowIndex, 1].Value = "Date";
                    worksheet.Cells[rowIndex, 2].Value = "Value";
                    worksheet.Cells[rowIndex, 3].Value = "BeforeMeal";
                    worksheet.Cells[rowIndex, 4].Value = "Note";
                    rowIndex++;

                    // Запись значений объектов
                    foreach (var obj in models)
                    {
                        worksheet.Cells[rowIndex, 1].Value = obj.Date;
                        worksheet.Cells[rowIndex, 2].Value = obj.Value;
                        worksheet.Cells[rowIndex, 3].Value = obj.BeforeMeal;
                        worksheet.Cells[rowIndex, 4].Value = obj.Note;
                        rowIndex++;
                    }

                    // Сохранение книги Excel в файл
                    FileInfo excelFile = new FileInfo(destinationPath);
                    excelPackage.SaveAs(excelFile);
                    result = true;
                }
            } catch (Exception ex)
            {
                return false;
            }
            
            return result;
        }

        private static ParsedModel ParseModels(string[] rawData)
        {
            ParsedModel model = new ParsedModel();

            if (rawData.Length == 13)
            {
                model.Date = rawData[1];
                model.Note = rawData[9];
                model.Value = rawData[3];
                model.BeforeMeal = rawData[5];
            }
            else
            {
                model.Date = rawData[1];
                model.Value = rawData[3];
                model.BeforeMeal = rawData[5];
            }
            

            return model;
        }

        private static string[] DataParser(string rawData)
        {

            string pattern = @"\""(.*?)\""";

            MatchCollection matches = Regex.Matches(rawData, pattern);
            string[] result = new string[matches.Count];
            

            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].Groups[1].Value;
            }

            return result;
        }
        
    }
}
