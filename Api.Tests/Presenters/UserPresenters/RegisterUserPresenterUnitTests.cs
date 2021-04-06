using Api.Presenters.UserPresenters;
using Core.Dto.UseCaseResponses.UserResponses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Xunit;

namespace Api.Tests.Presenters.UserPresenters
{
    public class RegisterUserPresenterUnitTests
    {
        [Fact]
        public void Contains_Ok_Status_Code_When_Use_Case_Succeeds()
        {
            //Arrange
            var presenter = new RegisterUserPresenter();

            //Act
            presenter.Handle(new RegisterUserResponse("", true));

            //Assert 
            Assert.Equal((int)HttpStatusCode.OK, presenter.ContentResult.StatusCode);
        }

        [Fact]
        public void Contains_Id_When_Use_Case_Succeeds()
        {
            //Arrange
            var presenter = new RegisterUserPresenter();

            //Act
            presenter.Handle(new RegisterUserResponse("1234", true));


            //Assert
            dynamic data = JsonConvert.DeserializeObject(presenter.ContentResult.Content);
            Assert.True(data.success.Value);
            Assert.Equal("1234", data.id.Value);
        }
    }
}
