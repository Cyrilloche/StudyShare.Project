using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudyShare.Application.Interfaces;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Interfaces;

namespace StudyShare.Tests.Controllers
{
    [TestClass]
    public class UserController
    {

        private Mock<IUserService> _mockIUserService;
        private UserController _userController;
        [TestInitialize]
        public void Initialize()
        {
            _mockIUserService = new Mock<IUserService>();
        }

        [TestMethod]
        public void GetUserById_WithWrongId()
        {
            // Arrange 
            int id = -1;

            //Act
            var result = _mockIUserService.Setup(service => service.GetUserById(id));

            //Assert

            Assert.IsNotNull(result);
        }
    }
}