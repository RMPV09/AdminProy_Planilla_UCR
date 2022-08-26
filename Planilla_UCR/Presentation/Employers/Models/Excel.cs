using Microsoft.JSInterop;
using Presentation.Employers.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Employers.XLS
{
    public class Excel
    {
        public async Task GenerateExcelReport2Async(IJSRuntime js, ProjectHistorical[] data, string filename = "Reporte histórico pagos por proyecto.xlsx")
        {
            var report3 = new ProjectHistoricalExcel();
            string XLSStream = report3.Edition(data);

            await js.InvokeVoidAsync("jsSaveAsFile", filename, XLSStream);
        }


        public async Task GenerateExcelReport5Async(IJSRuntime js, EmployeeHistoryList[] data, string filename = "Reporte histórico del pago de mis empleados.xlsx")
        {
            var report5 = new HistoricalEmployeePaymentsExcel();
            string XLSStream = report5.Edition(data);

            await js.InvokeVoidAsync("jsSaveAsFile", filename, XLSStream);
        }
    }

}