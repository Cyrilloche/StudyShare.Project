using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using StudyShare.Application.Interfaces;
using StudyShare.Application.Services;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Interfaces;

namespace StudyShare.Tests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IUserRepository> _repositoryMock;
        private UserService _serviceMock;

        public UserServiceTests()
        {
            _repositoryMock = new Mock<IUserRepository>();
            _serviceMock = new UserService(_repositoryMock.Object);
        }

        [TestMethod]
        public void GetAllUser_ReturnsOk()
        {
            _repositoryMock.Setup(repo => repo.GetAllUsers()).ReturnsAsync(new List<User>());
            
            var result = _serviceMock.GetAllUsers();
            Assert.IsNotNull(result.Result);
        }
    }
}