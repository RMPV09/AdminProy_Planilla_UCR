using System.Collections.Generic;
using Application.Subscribes.Implementations;
using Moq;
using Xunit;
using System;
using Domain.Subscribes.Repositories;
using Domain.Subscribes.Entities;


namespace Tests.Application
{

    public class SubscribesServiceTest
    {
        private static string EmployeeEmail = "jeremy@ucr.ac.cr";

        private static string EmployerEmail = "leonel@ucr.ac.cr";

        private static string ProjectName = "Dulces Artesanales";

        private static DateTime SubscribesStartDate = new DateTime(2022, 08, 02);

        private static string SubscriptionName = "Gym";

        private static double Cost = 15000.0;

        List<Subscribe> subscribesList = new List<Subscribe>
        {
            new Subscribe("jeremy@ucr.ac.cr", "leonel@ucr.ac.cr", "Proyecto 1", "Gym", 86000.0, DateTime.Now),
            new Subscribe("jeremy@ucr.ac.cr", "leonel@ucr.ac.cr", "Proyecto 2", "Piscinas", 15000.0, DateTime.Now),
        };


        [Fact]
        public void AddNewSubscribes()
        {
            //arrange
            var subscribes = new Subscribe(EmployeeEmail, EmployerEmail, ProjectName, SubscriptionName, Cost, SubscribesStartDate);
            var mockSubscribeRepository = new Mock<ISubscribeRepository>();
            var subscribeService = new SubscribeService(mockSubscribeRepository.Object);
            mockSubscribeRepository.Setup(repo => repo.AddSubscribe(subscribes));

            //act
            subscribeService.AddSubscribe(subscribes);

            //assert
            mockSubscribeRepository.Verify(repo => repo.AddSubscribe(subscribes), Times.Once);
        }
    }
}