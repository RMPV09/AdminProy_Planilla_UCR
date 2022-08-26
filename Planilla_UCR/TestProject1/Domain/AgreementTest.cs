using Xunit;
using Domain.Agreements.Entities;
using FluentAssertions;
using System;

namespace Tests.Domain
{
    public class AgreementTests
    {
        private static string EmployeeEmail = "jeremy@ucr.ac.cr";

        private static string EmployerEmail = "mau@ucr.ac.cr";

        private static string ProjectName = "Accesorios artesanales";

        private static DateTime ContractStartDate = new DateTime(2022,08,02);

        private static string ContractType = "Tiempo completo";

        private static int MountPerHour = 1500;

        private static DateTime ContractFinishDate = new DateTime(2022,09,02);

        private static int IsEnabled = 1;

        private static string Justification = string.Empty;


        [Fact]
        public void AgreementJustificationReturnsEmpty()
        {
            //arrange
            var justification = string.Empty;

            //act
            var result = new Agreement(EmployeeEmail,
                EmployerEmail,
                ProjectName,
                ContractStartDate,
                ContractType,
                MountPerHour,
                ContractFinishDate,
                IsEnabled,
                justification);

            //assert
            result.Justification.Should().Be(string.Empty);
        }

    }
}
