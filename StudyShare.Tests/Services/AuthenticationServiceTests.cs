using Moq;
using StudyShare.Application.Exceptions;
using StudyShare.Application.Services;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Infrastructure.Interfaces;

namespace StudyShare.Tests.Services
{
    [TestClass]
    public class AuthenticationServiceTests
    {
        private Mock<IAuthenticationRepository> _repositoryMock;
        private AuthenticationService _serviceMock;

        [TestInitialize]
        public void Init()
        {
            _repositoryMock = new Mock<IAuthenticationRepository>();
            _serviceMock = new AuthenticationService(_repositoryMock.Object);

        }
        // Méthodes de tests pour la méthode CreateUser
        [TestMethod]
        [DataRow("lastname", "a")]
        [DataRow("firstname", "a")]
        [DataRow("email", "wrongEmail")]
        [DataRow("password", "weak")]
        public async Task CreateUser_WithInvalidInput_ShouldThrowException(string field, string invalidValue)
        {
            // Arrange 
            CreateUserDto user = new CreateUserDto
            {
                UserLastname = field == "lastname" ? invalidValue : "valid",
                UserFirstname = field == "firstname" ? invalidValue : "valid",
                UserPassword = field == "password" ? invalidValue : "Strong1@",
                UserEmail = field == "email" ? invalidValue : "valid@email.fr"
            };
            _repositoryMock.Setup(repo => repo.RegisterNewUserAsync(new User()));

            // Act
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(async () => await _serviceMock.RegisterNewUserAsync(user));

            // Assert
            Assert.AreEqual($"Invalid user {field} format", exception.Message);
        }


        [TestMethod]
        public async Task CreateUser_WithValidFormat_ShouldNotThrowException()
        {
            // Arrange 
            CreateUserDto user = new CreateUserDto { UserLastname = "user", UserFirstname = "user", UserPassword = "Strong1@", UserEmail = "valid@email.fr" };
            _repositoryMock.Setup(repo => repo.RegisterNewUserAsync(It.IsAny<User>()));

            // Act
            await _serviceMock.RegisterNewUserAsync(user);

        }
    }
}
