using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Email
{
    public class EmailObject
    {
            public String EmployeeName { get; set; }
            public String EmployerName { get; set; }
            public String ProjectName { get; set; }
            public String Message { get; set; }
            public String Destiny { get; set; }
            
            public EmailObject(string employeeName, string employerName, string projectName, string message, string destiny)
            {
                EmployeeName = employeeName;
                EmployerName = employerName;
                ProjectName = projectName;
                Message = message;
                Destiny = destiny;
            }
    }
}
