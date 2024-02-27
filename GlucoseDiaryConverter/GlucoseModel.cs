using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoseDiaryConverter
{
    public class GlucoseModel
    {
        public string? Date { get; set; }
        public decimal? Value { get; set; }
        public string? BeforeMeal { get; set; }
        public string? Note { get; set; }

        public GlucoseModel() { }

        public GlucoseModel(string? date, decimal? value, string? beforeMeal, string? note)
        {
            Date = date;
            Value = value;
            BeforeMeal = beforeMeal;
            Note = note;
        }
    }
}
