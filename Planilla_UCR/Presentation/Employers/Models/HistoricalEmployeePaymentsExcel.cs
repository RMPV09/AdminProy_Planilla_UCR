using ClosedXML.Excel;
using Presentation.Employers.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Presentation.Employers.XLS
{
    public class HistoricalEmployeePaymentsExcel
    {
        public string Edition(EmployeeHistoryList[] data)
        {
            MemoryStream XLSStream = new();
            var workBook = new XLWorkbook();
            string[] headings = {"Nombre", "Primer apellido","Segundo apellido","Proyecto", "Cédula", 
                "Tipo empleado","Salario bruto","Beneficios","Mis cargas sociales","Deducciones obligatorias",
                "Deducciones voluntarias","Costo total"};
            var workSheet = workBook.Worksheets.Add("Hoja 1");
            for (int i = 1; i <= headings.Length; i++)
            {
                workSheet.Cell(1, i).Value = headings[i - 1];
            }
            for (int row = 1; row <= data.Length(); row++)
            {
                workSheet.Cell(row + 1, 1).Value = data[row - 1].EmployeeName;
                workSheet.Cell(row + 1, 2).Value = data[row - 1].EmployeeLastName1;
                workSheet.Cell(row + 1, 3).Value = data[row - 1].EmployeeLastName2;
                workSheet.Cell(row + 1, 4).Value = data[row - 1].ProjectName;
                workSheet.Cell(row + 1, 5).Value = data[row - 1].Ssn;
                workSheet.Cell(row + 1, 6).Value = data[row - 1].ContractType;
                workSheet.Cell(row + 1, 7).Value = data[row - 1].GrossSalary;
                workSheet.Cell(row + 1, 8).Value = data[row - 1].TotalBenefits;
                workSheet.Cell(row + 1, 9).Value = data[row - 1].EmployerSocialCharges;
                workSheet.Cell(row + 1, 10).Value = data[row - 1].MandatoryEmployeeDeductions;
                workSheet.Cell(row + 1, 11).Value = data[row - 1].VoluntaryDeductions;
                workSheet.Cell(row + 1, 12).Value = data[row - 1].EmployeeCost;


            }
            workBook.SaveAs(XLSStream);
            return Convert.ToBase64String(XLSStream.ToArray());
        }

    }
}
