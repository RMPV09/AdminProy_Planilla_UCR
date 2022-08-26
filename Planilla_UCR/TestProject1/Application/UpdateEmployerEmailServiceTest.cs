using Application.Employers.Implementations;
using Moq;
using Xunit;
//Proyectos
using Domain.Employers.Repositories;


namespace Tests.Application
{
    public class UpdateEmployerEmailServiceTest
    {
        private static string Email = "leonel@ucr.ac.cr";

        [Fact]
        public void UpdateEmployerTest()
        {
            //arrange
            var mockEmployerRepository = new Mock<IEmployerRepository>();
            var employerService = new EmployerService(mockEmployerRepository.Object);
            mockEmployerRepository.Setup(repo => repo.UpdateEmployer(Email));

            //act
            employerService.UpdateEmployer(Email);

            //assert
            mockEmployerRepository.Verify(repo => repo.UpdateEmployer(Email), Times.Once);      
        }
    }
}
