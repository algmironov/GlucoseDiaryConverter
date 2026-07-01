# GlucoseDiaryConverter

Windows Forms app that converts a CSV export from a **Contour Plus One** blood
glucose meter into a clean self-control diary in `.xlsx`, dropping unnecessary
columns.

## Usage

1. Export the CSV from the meter software.
2. Open it in the app.
3. Export the formatted `.xlsx` diary.

## Tech

.NET WinForms, EPPlus (OfficeOpenXml), CSV parsing.

> Built for personal use, but a decent example of CSV → XLSX handling in C#.
