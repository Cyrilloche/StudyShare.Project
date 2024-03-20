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

        [TestInitialize]
        // Constructeur de la classe de tests
        public void Init()
        {
            // Initialisation du mock du UserRepository
            _repositoryMock = new Mock<IUserRepository>();

            // Initialisation du service UserService avec le mock du UserRepository
            _serviceMock = new UserService(_repositoryMock.Object);
        }


        // Méthode de test pour la méthode GetAllUsers de UserService
        [TestMethod]
        public void GetAllUsers_WithUsers_ShouldReturnUsers()
        {
            // Configuration du comportement du mock du UserRepository pour la méthode GetAllUsers
            // Retourner une liste d'utilisateurs lorsqu'elle est appelée
            _repositoryMock.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(new List<User> {
                new User(),
                new User()
            });

            // Appel de la méthode GetAllUsers du service UserService à tester
            var result = _serviceMock.GetAllUsersAsync();

            // Vérification que le résultat n'est pas nul
            // Assert.IsNotNull(result.Result);
            Assert.AreEqual(2, result.Result.Count());
        }

        // TO DO FAIRE UNE MEETHODE OU IL N'Y A PAS DE USER
        [TestMethod]
        public void GetAllUsers_WithNoUsers_ShouldReturnEmptyList()
        {
            _repositoryMock.Setup(repo => repo.GetAllUsersAsync()).ReturnsAsync(new List<User>());

            var result = _serviceMock.GetAllUsersAsync();

            Assert.AreEqual(0, result.Result.Count());
        }


        // Méthode de test pour la méthode GetUserById
        [TestMethod]
        public async Task GetUser_WithInvalidId_ShouldThrowException()
        {
            // Arrange
            int id = -1;
            _repositoryMock.Setup(repo => repo.GetUserByIdAsync(id));

            // Act
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(async () => await _serviceMock.GetUserByIdAsync(id));

            //Assert
            Assert.AreEqual("Invalid id", exception.Message);
        }

        // Méthode de test pour la méthode DeleteUser
        [TestMethod]
        public async Task DeleteUser_WithInvalidId_ShouldThrowException()
        {
            // Arrange
            int id = -1;
            _repositoryMock.Setup(repo => repo.DeleteUserAsync(id));

            // Act
            var exception = await Assert.ThrowsExceptionAsync<BadRequestException>(async () => await _serviceMock.DeleteUserAsync(id));

            //Assert
            Assert.AreEqual("Invalid id", exception.Message);
        }
    }
}

