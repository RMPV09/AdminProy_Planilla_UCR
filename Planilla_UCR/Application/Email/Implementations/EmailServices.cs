using Domain.Subscriptions.Entities;
using Domain.LegalDeductions.Entities;
using Domain.People.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Application.Email.Implementations
{
    public class EmailServices : IEmailServices
    {
        private EmailSender _emailSender = new EmailSender();

        public void SendConfirmationEmail(string message, string destiny)
        {
            string htmlContent = "<section>" + "<div>" + "<header style = BACKGROUND-COLOR:#00695c>" + "<center>" + "<FONT SIZE=5 COLOR=#FFFFFF>" + 
                    "<strong>" + "PlanillaUCR" + "</strong>" + "</FONT>" + "</center>" + "<br>" + "</br>" + "</div>" + "</header>" + "<br>" +
                    "</br>" + "<div>" + "¡Gracias por registrarte en PlanillaUCR! " + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + 
                    "<div>" + "<strong>" + message + "</strong>" + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + 
                    "Recibiste este email porque te registraste en una cuenta de PlanillaUCR con esta dirección de email. " +
                    "Si piensas que fue un error, por favor, ignora este email. No te preocupes la cuenta aún no ha sido creada." +
                    "</div>" + "<div>" + "<FONT COLOR=#00695c>" + "PlanillaUCR" + "</FONT>" + "<br>" + "</br>" + "</div>" + "</section>";
            string subject = "Confirmación de registro Planilla_UCR";
            _emailSender.SendMail(destiny, subject, htmlContent);
        }

        public void SendFiredEmployeeEmail(EmailObject emailData)
        {
            string employeeName = emailData.EmployeeName;
            string employerName = emailData.EmployerName;
            string projectName = emailData.ProjectName;
            string message = emailData.Message;
            string destiny = emailData.Destiny;
            string htmlContent = "<section>" + "<div>" + "<header style = BACKGROUND-COLOR:#00695c>" + "<center>" + "<FONT SIZE=5 COLOR=#FFFFFF>" + "<strong>" + "PlanillaUCR" + 
                "</strong>" + "</FONT>" + "</center>" + "</div>" + "</header>" + "</section>" + "<br>" + "</br>" + "<section>" + "<div>" + "Señor(a): " + employeeName + "<br>" + 
                "</br>" + "</div>" + "</section>" + "<section>" + "<div>" +  "Reciba un cordial saludo," + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + 
                "Yo," + " " + employerName + " a cargo de " + projectName + " me dirijo a usted con todo el respeto que se merece, para comunicarle que desafortunadamente debemos " +
                " de prescindir de sus servicios en la compañía." + "<section>" + "<div>" + "Queremos dejar en claro que la causa del despido no tiene nada que ver con su " +
                "comportamiento dentro de la empresa, por el contrario, consideramos que usted es un excelente empleado, cumplidor de su deber y le agradecemos su compromiso. " +
                "No obstante, nos vimos obligados a tomar esta decisión por " + message + "."+ "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + "De antemano " +
                "agradecemos su comprensión y le agradecemos profundamente todo lo que aportó a la empresa durante el ejercicio de su labor. Asimismo, es importante que tenga en " +
                "cuenta que le pagaremos todo lo relacionado a nuestras obligaciones." + "</div>" + "<section>" + "<div>" + "No siendo más, nos despedimos de usted con un gran " +
                "agradecimiento por su labor, y deseando que encuentre un nuevo trabajo acorde a su potencial." + "<br>" + "</br>" + "</div>" + "</section>" +  "<section>" + "<div>" +
                "Cordialmente, " + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + employerName + "<br>" + "</br>" + "</div>" + "</section>";
            string subject = "Carta de despido";
            _emailSender.SendMail(destiny, subject, htmlContent);
        }

        public void SendLastPayEmail(EmailObject emailData, IList<string> rows, IList<Subscription> deductions, IList<LegalDeduction> legalDeductions)
        {
            string employeeName = rows[0].Split("#")[0];
            string contractType = rows[0].Split("#")[1];
            string date = rows[0].Split("#")[2];
            string projectName = rows[1].Split("#")[0];
            string salary = rows[1].Split("#")[2];
            string netSalary = rows[2].Split("#")[2];
            string htmlContent = File.ReadAllText("../wwwroot/wwwroot/emails/LastPayEmail.html");
            htmlContent = htmlContent.Replace("[employeeName]", employeeName);
            htmlContent = htmlContent.Replace("[contractType]", contractType);
            htmlContent = htmlContent.Replace("[Date]", date);
            htmlContent = htmlContent.Replace("[projectName]", projectName);
            htmlContent = htmlContent.Replace("[salary]", salary);
            htmlContent = htmlContent.Replace("[netSalary]", netSalary);

            htmlContent = htmlContent.Replace("[Heading]", "Reporte de último pago en " + projectName.Replace("Proyecto: ", "") + " el " + date.Replace("Fecha: ", ""));
            string legal = string.Empty;
            foreach (LegalDeduction tax in legalDeductions)
            {
                legal += "<tr>";
                legal += "<td>" + tax.DeductionName + "</td>";
                legal += "<td>" + "₡" + string.Format("{0:N}", tax.Cost) + " </td>";
                legal += "</tr>";
            }
            htmlContent = htmlContent.Replace("[Legal]", legal);

            string voluntary = string.Empty;
            foreach (Subscription subscription in deductions)
            {
                voluntary += "<tr>";
                voluntary += "<td>" + subscription.SubscriptionName + "</td>";
                voluntary += "<td>" + "₡" + string.Format("{0:N}", subscription.Cost) + " </td>";
                voluntary += "</tr>";
            }
            htmlContent = htmlContent.Replace("[Voluntary]", voluntary);

            _emailSender.SendMail(emailData.Destiny, "Último pago", htmlContent);
        }

        public void SendPaymentBreakdownEmail(EmailObject emailData, IList<LegalDeduction> summaryTable, IList<LegalDeduction> salariesTable, IList<LegalDeduction> deductionTable, IList<LegalDeduction> benefitsTable)
        {
            string projectName = summaryTable.ElementAtOrDefault(0).DeductionName;
            string date = summaryTable.ElementAtOrDefault(2).DeductionName;
            string htmlContent = File.ReadAllText("../wwwroot/wwwroot/emails/PlanillaReportEmail.html");
            htmlContent = htmlContent.Replace("[date]", date);
            htmlContent = htmlContent.Replace("[projectName]", projectName);

            htmlContent = htmlContent.Replace("[Heading]", "Reporte de pagos en " + projectName.Replace("Proyecto: ", "") + " el " + date.Replace("Fecha: ", ""));
            string summary = string.Empty;
            string salaries = string.Empty;
            string benefits = string.Empty;
            string deductions = string.Empty;


            summary += "<tr>";
            summary += "<td>" + summaryTable.ElementAtOrDefault(3).DeductionName + "</td>";
            summary += "<td>" + "₡" + string.Format("{0:N}", summaryTable.ElementAtOrDefault(3).Cost) + " </td>";
            summary += "</tr>";
            
            htmlContent = htmlContent.Replace("[summary]", summary);

            foreach (LegalDeduction salary in salariesTable)
            {
                salaries += "<tr>";
                salaries += "<td>" + salary.DeductionName + "</td>";
                salaries += "<td>" + "₡" + string.Format("{0:N}", salary.Cost) + " </td>";
                salaries += "</tr>";
            }

            htmlContent = htmlContent.Replace("[salaries]", salaries);


            foreach (LegalDeduction benefit in benefitsTable)
            {
                benefits += "<tr>";
                benefits += "<td>" + benefit.DeductionName + "</td>";
                benefits += "<td>" + "₡" + string.Format("{0:N}", benefit.Cost) + " </td>";
                benefits += "</tr>";
            }
            htmlContent = htmlContent.Replace("[benefits]", benefits);


            foreach (LegalDeduction deduction in deductionTable)
            {
                deductions += "<tr>";
                deductions += "<td>" + deduction.DeductionName + "</td>";
                deductions += "<td>" + "₡" + string.Format("{0:N}", deduction.Cost) + " </td>";
                deductions += "</tr>";
            }
            htmlContent = htmlContent.Replace("[deductions]", deductions);

            _emailSender.SendMail(emailData.Destiny, "Reporte planilla", htmlContent);
        }

        public void SendIncreaseBenefitsEmail(EmailObject emailData)
        {
            string employeeName = emailData.EmployeeName;
            string employerName = emailData.EmployerName;
            string projectName = emailData.ProjectName;
            string message = emailData.Message;
            string destiny = emailData.Destiny;
            string htmlContent = "<section>" + "<div>" + "<header style = BACKGROUND-COLOR:#00695c>" + "<center>" + "<FONT SIZE=5 COLOR=#FFFFFF>" + "<strong>" + "PlanillaUCR" +
                "</strong>" + "</FONT>" + "</center>" + "</div>" + "</header>" + "</section>" + "<br>" + "</br>" + "<section>" + "<div>" + "Señor(a): " + employeeName + "<br>" +
                "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + "Reciba un cordial saludo." + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" +
                "Yo," + " " + employerName + ", a cargo de " + projectName + "; me dirijo a usted para comunicarle que actualmente tenemos mayor cantidad de beneficios disponibles " +
                "para nuestros trabajadores." + "</br>" + " </div>" +"</section >" + "<section>" + "<div>" + "Decidimos aumentar los beneficios como agradecimiento por su trabajo. " +
                "Para poder hacer uso de estos beneficios puede dirigirse a nuestra página, en la sección de beneficios y seleccionar los beneficios de su preferencia." + "</br>" + " </div>" + "</section >" +
                "<section>" + "<div>" + "Esperamos que disfrute y le sean de provecho estos nuevos servicios que la compañía ha puesto a su disposición." + "<br>" + "</br>" + "</div>" + "</section>" + 
                "<section>" + "<div>" + "Estamos muy agradecidos por sus grandes labores. Esperamos seguir creciendo y mejorando para nuestros trabajadores y clientes." + "</div>" + 
                "<section>" + "<div>" + "Nos despedimos de usted con un gran agradecimiento." + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" +
                "Cordialmente, " + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + employerName + "<br>" + "</br>" + "</div>" + "</section>";
            string subject = "Nuevos beneficios";
            _emailSender.SendMail(destiny, subject, htmlContent);

        }

        public void SendDecreaseBenefitsEmail(EmailObject emailData)
        {
            string employeeName = emailData.EmployeeName;
            string employerName = emailData.EmployerName;
            string projectName = emailData.ProjectName;
            string message = emailData.Message;
            string destiny = emailData.Destiny;
            string htmlContent = "<section>" + "<div>" + "<header style = BACKGROUND-COLOR:#00695c>" + "<center>" + "<FONT SIZE=5 COLOR=#FFFFFF>" + "<strong>" + "PlanillaUCR" +
                "</strong>" + "</FONT>" + "</center>" + "</div>" + "</header>" + "</section>" + "<br>" + "</br>" + "<section>" + "<div>" + "Señor(a): " + employeeName + "<br>" +
                "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + "Reciba un cordial saludo." + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" +
                "Yo," + " " + employerName + ", a cargo de " + projectName + "; me dirijo a usted para comunicarle que lamentablemente hemos actualizado el proyecto y ahora " +
                "tenemos menor cantidad de beneficios disponibles." + "</br>" + "</div>" + "</section>" + "Nos disculpamos por los inconvenientes. Además, le pedimos que por " +
                "favor se dirija a nuestra página web en la sección de beneficios y se desuscriba de alguno de ellos, esto para que se cumpla con el presupuesto máximo definido "+
                "por la compañía, el tiempo límite para realizar esta acción es " + message +"" + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + 
                "De antemano nos disculpamos por todos los inconvenientes que esto le pueda causar." + "<br>" + "</br>" + "</div>" + "</section>" +
                "<section>" + "<div>" + "Nos despedimos de usted con un gran agradecimiento por su labor."+ "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" +
                "Cordialmente, " + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + employerName + "<br>" + "</br>" + "</div>" + "</section>";
            string subject = "Cambio en beneficios";
            _emailSender.SendMail(destiny, subject, htmlContent);
        }

        public void SendOverbenefitsEmployeesEmail(IList<string> _overbenefitEmployeesEmail, IList<string> _overbenefitEmployeesName, EmailObject emailData)
        {
            string employees = string.Empty;
            string projectName = emailData.ProjectName;
            string employeeName = emailData.EmployeeName;
            string employerName = emailData.EmployerName;
            string message = emailData.Message;
            string destiny = emailData.Destiny;
            string htmlContent = "<section>" + "<div>" + "<header style = BACKGROUND-COLOR:#00695c>" + "<center>" + "<FONT SIZE=5 COLOR=#FFFFFF>" + "<strong>" + "PlanillaUCR" +
                "</strong>" + "</FONT>" + "</center>" + "</div>" + "</header>" + "</section>" + "<br>" + "</br>" + "<section>" + "<div>" + "Señor(a): " + employerName + "<br>" +
                "</br>" + "</div>" + "</section>" + "<section>" + "<div>" + "En este correo se incluye la lista de empleados que actualmente están excediendo el monto y/o " +
                "la cantidad de beneficios de " + projectName + ". " + "<br>" + "</br>" + "</div> " + "</section>";
            htmlContent += File.ReadAllText("../wwwroot/wwwroot/emails/OverstaffedEmployees.html");
            
            htmlContent += "<section>" + "<div>" +"<br>" + "</br>" + "A cada uno de ellos se les envió un correo indicando que deben desuscribirse de alguno de sus beneficios." +
                "</div> " + "</section>" + "<section>" + "<div>" + "Favor monitorear que cumplan con la fecha límite." + "<br>" + "</br>" + "</div>" + "</section>";

            string subject = "Empleados excedidos en beneficios";

            for (int i = 0; i < _overbenefitEmployeesEmail.Length(); i++)
            {
                employees += "<tr>";
                employees += "<td>" + _overbenefitEmployeesName.ElementAt(i) + "</td>";
                employees += "<td>" + _overbenefitEmployeesEmail.ElementAt(i) + "</td>";
                employees += "</tr>";
            }
            htmlContent = htmlContent.Replace("[employees]", employees);
            _emailSender.SendMail(destiny, subject, htmlContent);
        }

        public void SendQuittingEmailToEmployee(EmailObject emailData, IList<string> employeeInfo) 
        {
            string employeeEmail = employeeInfo.ElementAtOrDefault(0);
            string projectName = employeeInfo.ElementAtOrDefault(1);
            string startDate = employeeInfo.ElementAtOrDefault(2);
            string endDate = employeeInfo.ElementAtOrDefault(3);
            string employerName = employeeInfo.ElementAtOrDefault(4);
            string htmlContent = File.ReadAllText("../wwwroot/wwwroot/emails/QuitCommunicate.html");
           
            htmlContent = htmlContent.Replace("[Heading]", "Recibido la solicitud de renuncia del proyecto " + projectName);
            htmlContent = htmlContent.Replace("[Body]", "Por este medio se le informa que se ha completado la solicitud de renuncia del proyecto "
                +projectName + " por parte del empleado asociado al correo electrónico " + employeeEmail + ". Se adjunta la siguiente tabla la cual" +
                " indica el último día al cual debe asistir a su labor en el proyecto "+ projectName + ".");
            htmlContent = htmlContent.Replace("[projectName]", projectName);
            htmlContent = htmlContent.Replace("[startDate]", startDate);
            htmlContent = htmlContent.Replace("[endDate]", endDate);
            htmlContent = htmlContent.Replace("[Greetings]", "Coordialmente, se despide " + employerName);
            _emailSender.SendMail(emailData.Destiny, "Confirmación preaviso de renuncia", htmlContent);
        }
        public void SendQuittingEmailToEmployer(EmailObject emailData, IList<string> employeeInfo)
        {
            string employeeEmail = employeeInfo.ElementAtOrDefault(0);
            string projectName = employeeInfo.ElementAtOrDefault(1);
            string startDate = employeeInfo.ElementAtOrDefault(2);
            string endDate = employeeInfo.ElementAtOrDefault(3);
            string employerName = employeeInfo.ElementAtOrDefault(4);
            string htmlContent = File.ReadAllText("../wwwroot/wwwroot/emails/QuitCommunicate.html");

            htmlContent = htmlContent.Replace("[Heading]", "Preaviso de renuncia por parte del empleado " + employeeEmail);
            htmlContent = htmlContent.Replace("[Body]", "Por este medio se le informa que el empleado asociado al correo electrónico " + employeeEmail +
                " ha solicitado renunciar al proyecto " + projectName + ". " + "A continuación, se adjunta una tabla informativa con la información pertinente" +
                "al empleado, proyecto al que estaba asociado así como el día en que se hara efectiva la renuncia.");
            htmlContent = htmlContent.Replace("[projectName]", projectName);
            htmlContent = htmlContent.Replace("[startDate]", startDate);
            htmlContent = htmlContent.Replace("[endDate]", endDate);
            htmlContent = htmlContent.Replace("[Greetings]", "");
            _emailSender.SendMail(emailData.Destiny, "Aviso de preaviso de renuncia", htmlContent);
        }


        public void ReactivateAccountEmail(string message, string destiny)
        {
            string htmlContent = "<section>" + "<div>" + "<header style = BACKGROUND-COLOR:#00695c>" + "<center>" + "<FONT SIZE=5 COLOR=#FFFFFF>" +
                    "<strong>" + "PlanillaUCR" + "</strong>" + "</FONT>" + "</center>" + "<br>" + "</br>" + "</div>" + "</header>" + "<br>" +
                    "</br>" + "<div>" + "¡Bienvenido de nuevo a PlanillaUCR! " + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" +
                    "<div>" + "<strong>" + message + "</strong>" + "<br>" + "</br>" + "</div>" + "</section>" + "<section>" + "<div>" +
                    "Recibiste este email porque deseas reactivar una cuenta de PlanillaUCR con esta dirección de email. " +
                    "Si piensas que fue un error, por favor, ignora este email. No te preocupes la cuenta aún no ha sido reactivada." +
                    "</div>" + "<div>" + "<FONT COLOR=#00695c>" + "PlanillaUCR" + "</FONT>" + "<br>" + "</br>" + "</div>" + "</section>";
            string subject = "Confirmación de reactivación de cuenta Planilla_UCR";
            _emailSender.SendMail(destiny, subject, htmlContent);
        }

        public void SendEmployeeBenefitNotification(EmailObject emailData, string benefitName) 
        {
            string htmlContent = File.ReadAllText("../wwwroot/wwwroot/emails/EmployeeBenefitNotification.html");
            htmlContent = htmlContent.Replace("[employeeName]", emailData.EmployeeName);
            htmlContent = htmlContent.Replace("[employerName]", emailData.EmployerName);
            htmlContent = htmlContent.Replace("[projectName]", emailData.ProjectName);
            htmlContent = htmlContent.Replace("[benefitName]", benefitName);
            _emailSender.SendMail(emailData.Destiny, "Gestión de beneficios", htmlContent);
        }

        public void SendEmployerBenefitNotification(EmailObject emailData, IList<Person> employeesEmail, string benefitName)
        {
            string affectedEmployees = string.Empty;

            string htmlContent = File.ReadAllText("../wwwroot/wwwroot/emails/EmployerBenefitNotification.html");
            htmlContent = htmlContent.Replace("[employerName]", emailData.EmployerName);
            htmlContent = htmlContent.Replace("[projectName]", emailData.ProjectName);
            htmlContent = htmlContent.Replace("[benefitName]", benefitName);
            foreach (Person employee in employeesEmail)
            {
                string fullName = employee.Name + " " + employee.LastName1 + " " + employee.LastName2;
                affectedEmployees += "<tr>";
                affectedEmployees += "<td>" + fullName + "</td>";
                affectedEmployees += "<td>" + employee.Email + " </td>";
                affectedEmployees += "</tr>";
            }
            htmlContent = htmlContent.Replace("[employees]", affectedEmployees);
            _emailSender.SendMail(emailData.Destiny, "Gestión de beneficios", htmlContent);
        }

        public void SendDeletedSubscriptionEmail(EmailObject emailData, string subscriptionName)
        {
            string htmlContent = File.ReadAllText("../wwwroot/wwwroot/emails/DeletedSubscription.html");
            htmlContent = htmlContent.Replace("[employeeName]", emailData.EmployeeName);
            htmlContent = htmlContent.Replace("[employerName]", emailData.EmployerName);
            htmlContent = htmlContent.Replace("[projectName]", emailData.ProjectName);
            htmlContent = htmlContent.Replace("[subscriptionName]", subscriptionName);
            _emailSender.SendMail(emailData.Destiny, "Gestión de beneficios", htmlContent);
        }
    }
}
