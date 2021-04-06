using Core.Dto;
using Core.Dto.UseCaseRequests.UserRequests;
using Core.Dto.UseCaseResponses.UserResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.Interfaces.Services;
using Core.UseCases.UserUseCases;
using Moq;
using Xunit;

namespace Core.Tests.UseCases
{
    public class LoginUseCaseUnitTests
    {
        [Fact]
        public async void Can_Login()
        {
            //Arrange
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(_ => _.FindByNameAsync(It.IsAny<string>()))
                .ReturnsAsync(new User("", "", "", ""));

            mockUserRepository.Setup(_ => _.CheckPasswordAsync(It.IsAny<string>(), It.IsAny<string>()))
                .ReturnsAsync(true);

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory.Setup(_ => _.GenerateEncodedToken(It.IsAny<string>()))
                .ReturnsAsync(new Dto.Token("", "", 0));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);


            var mockOuputPort = new Mock<IOutputPort<LoginResponse>>();
            mockOuputPort.Setup(_ => _.Handle(It.IsAny<LoginResponse>()));


            //Act
            var response = await useCase.Handle(new LoginRequest("test", "test"), mockOuputPort.Object);

            // Assert
            Assert.True(response);

        }
        [Fact]
        public async void Cant_Login_When_Missing_Username()
        {
            // Arrange 
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(_ => _.FindByNameAsync(It.IsAny<string>()))
                            .ReturnsAsync(new User("", "", "", ""));

            mockUserRepository.Setup(_ => _.CheckPasswordAsync(It.IsAny<string>(), It.IsAny<string>()))
                        .ReturnsAsync(true);

            var mockJwtFactory = new Mock<IJwtFactory>();
            mockJwtFactory.Setup(_ => _.GenerateEncodedToken(It.IsAny<string>()))
                        .ReturnsAsync(new Token("", "", 0));

            var useCase = new LoginUseCase(mockUserRepository.Object, mockJwtFactory.Object);

            var mockOutput = new Mock<IOutputPort<LoginResponse>>();
            mockOutput.Setup(_ => _.Handle(It.IsAny<LoginResponse>()));

            //Act
            var response = await useCase.Handle(new LoginRequest("", ""), mockOutput.Object);

            //Assert
            Assert.False(response);



        }
    }
}
