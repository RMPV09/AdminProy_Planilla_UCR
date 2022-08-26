using ClosedXML.Excel;
using Presentation.Employees.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Presentation.Employees.XLS
{ 
    public class PaymentHistoryExcel
    {
        public string Edition(PaymentHistoryModel[] data)
        {
            MemoryStream XLSStream = new();
            var workBook= new XLWorkbook();
            string[] headings = {"Proyecto", "Tipo de contrato","Fecha pago","Salario Bruto","Deducciones obligatorias",
            "Deducciones voluntarias","Salario neto"};
            var workSheet = workBook.Worksheets.Add("Hoja 1");
            for (int i=1; i<=headings.Length; i++)
            {
              workSheet.Cell(1, i).Value = headings[i-1]; 
            }
            for (int row = 1; row <= data.Length(); row++)
            {
                workSheet.Cell(row + 1, 1).Value = data[row - 1].ProjectName;
                workSheet.Cell(row + 1, 2).Value = data[row - 1].ContractType;
                workSheet.Cell(row + 1, 3).Value = data[row - 1].PaymentDate;
                workSheet.Cell(row + 1, 4).Value = data[row - 1].GrossSalary;
                workSheet.Cell(row + 1, 5).Value = data[row - 1].LegalDeductions;
                workSheet.Cell(row + 1, 6).Value = data[row - 1].VoluntaryDeductions;
                workSheet.Cell(row + 1, 7).Value = data[row - 1].NetSalary;
            }
            workBook.SaveAs(XLSStream);
            return Convert.ToBase64String(XLSStream.ToArray());
        }
    }
}
