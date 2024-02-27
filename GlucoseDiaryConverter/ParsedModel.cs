using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlucoseDiaryConverter
{
    public class ParsedModel
    {
        public string? Number {  get; set; }
        public string? Date { get; set; }
        public string? Value {  get; set; }
        public string? BeforeMeal { get; set; }
        public string? DataSource { get;set; }
        public string? Note { get; set; }
        public string? Activity { get; set; }
        public string? Meal { get; set; }
        public string? Drug { get; set; }
        public string? Location { get; set; }

        public ParsedModel() { }

        public ParsedModel(string? number, string? date, string? value, string? beforeMeal, string? dataSource, string? note, string? activity, string? meal, string? drug, string? location)
        {
            Number = number;
            Date = date;
            Value = value;
            BeforeMeal = beforeMeal;
            DataSource = dataSource; 
            Note = note;
            Activity = activity; 
            Meal = meal;
            Drug = drug; 
            Location = location;
        }

    }
}
