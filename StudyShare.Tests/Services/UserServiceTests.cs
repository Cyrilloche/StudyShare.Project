using System.Text.RegularExpressions;
using Moq;
using System.Threading.Tasks;
using StudyShare.Application.Exceptions;
using StudyShare.Application.Services;
using StudyShare.Application.Utilities;
using StudyShare.Domain.Dtos;
using StudyShare.Domain.Entities;
using StudyShare.Domain.Interfaces;
using System.Runtime.InteropServices;

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
        public void UseInvalidId_ShouldThrowException()
        {
            
        }

        // Méthode de tests pour la méthode CreateUser

        [TestMethod]
        public async Task CreateUser_WithInvalidPasswordFormat_ShouldThrowPasswordFormatException()
        {
            // Arrange 
            UserDto user = new UserDto { UserPassword = "weak" };
            _repositoryMock.Setup(repo => repo.CreateUser(new User())).ReturnsAsync(new User());

            // Act
            var exception = await Assert.ThrowsExceptionAsync<PasswordFormatException>(async () => await _serviceMock.CreateUser(user));

            // Assert
            Assert.AreEqual("Password does not meet format requirements", exception.Message);
        }

        [TestMethod]
        public async Task CreateUser_WithValidPasswordFormat_ShouldNotThrowException()
        {
            // Arrange 
            UserDto user = new UserDto { UserPassword = "Strong1@" };
            _repositoryMock.Setup(repo => repo.CreateUser(new User())).ReturnsAsync(new User());

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

