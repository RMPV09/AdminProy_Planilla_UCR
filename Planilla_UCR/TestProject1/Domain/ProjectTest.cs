using Domain.Projects.Entities;
using Xunit;
using FluentAssertions;
using System;

namespace Tests.Domain
{
    public class ProjectTests
    {
        public String EmployerEmail = "leonel@ucr.ac.cr";
        
        public String ProjectName = "Accesorios artesanales";
        
        public String ProjectDescription = "Accesorios artesanales hecos de coco y material recliclado";
        
        public double MaximumAmountForBenefits = 20000.0;
        
        public int MaximumBenefitAmount = 2;
        
        public String PaymentInterval = "quincenal";
        
        public int IsEnabled = 1;
       
        public DateTime LastPaymentDate = DateTime.MinValue;

       [Fact]
        public void ProjectNameEmptyReturnEmpty()
        {
            //arrange
            var input = string.Empty;

            //act
            var result = new Project(EmployerEmail,
                input,
                ProjectDescription,
                MaximumAmountForBenefits,
                MaximumBenefitAmount,
                PaymentInterval,
                IsEnabled,
                LastPaymentDate);

            //assert
            result.ProjectName.Should().Be(string.Empty);
        }

    }
}
