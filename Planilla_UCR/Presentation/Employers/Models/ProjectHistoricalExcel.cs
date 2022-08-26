using ClosedXML.Excel;
using Presentation.Employers.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Presentation.Employers.XLS
{
    public class ProjectHistoricalExcel
    {
        public string Edition(ProjectHistorical[] data)
        {
            MemoryStream XLSStream = new();
            var workBook = new XLWorkbook();
            string[] headings = {"Proyecto", "Frecuencia de pago","Fecha pago","Salario Bruto","Beneficios",
                "Cargas sociales empleador","Deducciones obligatorias empleado",
            "Deducciones voluntarias","Costo empleador"};
            var workSheet = workBook.Worksheets.Add("Hoja 1");
            for (int i = 1; i <= headings.Length; i++)
            {
                workSheet.Cell(1, i).Value = headings[i - 1];
            }
            for (int row = 1; row <= data.Length(); row++)
            {
                workSheet.Cell(row + 1, 1).Value = data[row - 1].ProjectName;
                workSheet.Cell(row + 1, 2).Value = data[row - 1].PaymentFrecuency;
                workSheet.Cell(row + 1, 3).Value = data[row - 1].EndDate;
                workSheet.Cell(row + 1, 4).Value = data[row - 1].GrossSalary;
                workSheet.Cell(row + 1, 5).Value = data[row - 1].Benefits;
                workSheet.Cell(row + 1, 6).Value = data[row - 1].EmployerCharges;
                workSheet.Cell(row + 1, 7).Value = data[row - 1].ObligatoryDeductions;
                workSheet.Cell(row + 1, 8).Value = data[row - 1].VoluntaryDeductions;
                workSheet.Cell(row + 1, 9).Value = data[row - 1].EmployerCost;
            }
            workBook.SaveAs(XLSStream);
            return Convert.ToBase64String(XLSStream.ToArray());
        }
    }
}