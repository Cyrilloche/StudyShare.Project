using Moq;
using StudyShare.Application.Exceptions;
using StudyShare.Application.Services;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Interfaces;

namespace StudyShare.Tests.Services
{
    // Déclaration de la classe de tests pour la classe UserService
    [TestClass]
    public class UserServiceTests
    {
        // Déclaration d'une variable pour le mock du UserRepository
        private Mock<IUserRepository> _repositoryMock;

        // Déclaration d'une variable pour le service UserService à tester
        private UserService _serviceMock;

        // Constructeur de la classe de tests
        public UserServiceTests()
        {
            // Initialisation du mock du UserRepository
            _repositoryMock = new Mock<IUserRepository>();

            // Initialisation du service UserService avec le mock du UserRepository
            _serviceMock = new UserService(_repositoryMock.Object);
        }


        // Méthode de test pour la méthode GetAllUsers de UserService
        [TestMethod]
        public void GetAllUsers_ReturnsOk()
        {
            // Configuration du comportement du mock du UserRepository pour la méthode GetAllUsers
            // Retourner une liste d'utilisateurs lorsqu'elle est appelée
            _repositoryMock.Setup(repo => repo.GetAllUsers()).ReturnsAsync(new List<User>());
            
            // Appel de la méthode GetAllUsers du service UserService à tester
            var result = _serviceMock.GetAllUsers();

            // Vérification que le résultat n'est pas nul
            Assert.IsNotNull(result.Result);
        }
    
        // Méthode de test pour la méthode GetUserById
        [TestMethod]
        public async Task GetUser_WithInvalidId_ShouldThrowException()
        {
            // Arrange
            int id = -1;
            _repositoryMock.Setup(repo => repo.GetUserById(id));

            // Act
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(async () => await _serviceMock.GetUserById(id));

            //Assert
            Assert.AreEqual("Invalid id", exception.Message);
        }

        // Méthode de test pour la méthode DeleteUser
        [TestMethod]
        public async Task DeleteUser_WithInvalidId_ShouldThrowException()
        {
            // Arrange
            int id = -1;
            _repositoryMock.Setup(repo => repo.DeleteUser(id));

            // Act
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(async () => await _serviceMock.DeleteUser(id));

            //Assert
            Assert.AreEqual("Invalid id", exception.Message);
        }

        // Méthodes de tests pour la méthode CreateUser
        [TestMethod]
        public async Task CreateUser_WithInvalidPasswordFormat_ShouldThrowException()
        {
            // Arrange 
             UserDto user = new UserDto {UserId = 1, UserLastname = "user", UserFirstname = "user", UserPassword = "weak", UserEmail = "valid@email.fr" };
            _repositoryMock.Setup(repo => repo.CreateUser(new User())).ReturnsAsync(new User());

            // Act
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(async () => await _serviceMock.CreateUser(user));

            // Assert
            Assert.AreEqual("Invalid user password format", exception.Message);
        }

        [TestMethod]
        public async Task CreateUser_WithInvalidEmailFormat_ShouldThrowtException()
        {
            // Arrange
            UserDto user = new UserDto {UserId = 1, UserLastname = "user", UserFirstname = "user", UserPassword = "Strong1@", UserEmail = "invalidEmail.fr" };
            _repositoryMock.Setup(repo => repo.CreateUser(new User())).ReturnsAsync(new User());

            // Act
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(async () =>await _serviceMock.CreateUser(user));

            // Assert
            Assert.AreEqual("Invalid user email format", exception.Message);
        }

        [TestMethod]
        public async Task CreateUser_WithInvalidLastnameFormat_ShouldThrowException()
        {
            // Arrange 
            UserDto user = new UserDto {UserId = 1, UserLastname = "a", UserFirstname = "user", UserPassword = "Strong1@", UserEmail = "valid@email.fr" };
            _repositoryMock.Setup(repo => repo.CreateUser(It.IsAny<User>())).ReturnsAsync(new User());

           // Act
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(async () =>await _serviceMock.CreateUser(user));

            // Assert
            Assert.AreEqual("Invalid user lastname format", exception.Message);
        }

        [TestMethod]
        public async Task CreateUser_WithInvalidFirstnameFormat_ShouldThrowException()
        {
            // Arrange 
            UserDto user = new UserDto {UserId = 1, UserLastname = "user", UserFirstname = "", UserPassword = "Strong1@", UserEmail = "valid@email.fr" };
            _repositoryMock.Setup(repo => repo.CreateUser(It.IsAny<User>())).ReturnsAsync(new User());

           // Act
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(async () =>await _serviceMock.CreateUser(user));

            // Assert
            Assert.AreEqual("Invalid user firstname format", exception.Message);
        }

        [TestMethod]
        public async Task CreateUser_WithValidFormat_ShouldNotThrowException()
        {
            // Arrange 
            UserDto user = new UserDto {UserId = 1, UserLastname = "user", UserFirstname = "user", UserPassword = "Strong1@", UserEmail = "valid@email.fr" };
            _repositoryMock.Setup(repo => repo.CreateUser(It.IsAny<User>())).ReturnsAsync(new User());

           // Act
            async Task CreateUserAction() => await _serviceMock.CreateUser(user);

            // Assert
            await Task.Run(async () =>
            {
                try
                {
                    await CreateUserAction();
                }
                catch (Exception ex)
                {
                    Assert.Fail($"Expected no exception, but an exception was thrown: {ex}");
                }
            });
        }
    }
 }

