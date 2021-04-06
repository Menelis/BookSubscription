using Core.Dto.UseCaseRequests.UserRequests;
using Core.Dto.UseCaseResponses.UserResponses;
using Core.Entities;
using Core.Interfaces;
using Core.Interfaces.Gateways.Repositories;
using Core.UseCases.UserUseCases;
using Moq;
using Xunit;

namespace Core.Tests.UseCases
{
    public class RegisterUserUseCaseUnitTests
    {
        [Fact]
        public async void Can_RegisterUse()
        {
            // Arrange

            //1. we need to store user data
            var mockUserRepository = new Mock<IUserRepository>();
            mockUserRepository.Setup(_ => _.CreateAsync(It.IsAny<User>(), It.IsAny<string>()))
                .ReturnsAsync(new Dto.GatewayResponses.Repositories.CreateUserResponse("", true));

            //2.The use case and start of test
            var useCase = new RegisterUserUseCase(mockUserRepository.Object);

            //3. The output port is the mechanism to pass the response data from use case to a presenter(client)
            // for final presentation to deliver back to UI/web page, api response
            var mockOutputPort = new Mock<IOutputPort<RegisterUserResponse>>();
            mockOutputPort.Setup(_ => _.Handle(It.IsAny<RegisterUserResponse>()));

            //Act

            //4. we need to request model to carry data into the use case from upper layer
            var response = await useCase.Handle(new RegisterUserRequest("firstName", "lastName", "email", "username", "password"), mockOutputPort.Object);

            //Assert
            Assert.True(response);
        }
    }
}
