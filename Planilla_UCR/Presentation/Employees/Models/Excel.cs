using Microsoft.JSInterop;
using Presentation.Employees.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Employees.XLS
{ 
    public class Excel
    {
        public async Task GenerateExcelReport2Async(IJSRuntime js, PaymentHistoryModel[] data, string filename = "Reporte histórico de mis pagos.xlsx")
        {
            var report2 = new PaymentHistoryExcel();
            string XLSStream = report2.Edition(data);

            await js.InvokeVoidAsync("jsSaveAsFile", filename, XLSStream);
        }
    }
}