using Moq;
using StudyShare.Application.Interfaces;

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