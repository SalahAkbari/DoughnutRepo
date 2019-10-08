using Doughnut.Controllers;
using Doughnut.Provider;
using Doughnut.Provider.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Doughnut.Test.Helpers;
using Xunit;

namespace Doughnut.Test
{
    public class DecisionTreeControllerTest
    {
        readonly DecisionTreeController _controller;

        public DecisionTreeControllerTest()
        {
            IDecisionTreeProvider provider = new DecisionTreeProvider();
            _controller = new DecisionTreeController(provider);
        }

        [Fact]
        public void ClientRequest_WhenCalled_ReturnsJsonResult()
        {
            // Arrange
            var clientViewModel = MockData.Current.Choices[0];

            // Act
            var jsonResult = _controller.ClientRequest(clientViewModel);

            // Assert
            Assert.IsType<JsonResult>(jsonResult);
        }

        [Fact]
        public void ClientRequest_NullObjectPassed_ReturnsBadRequest()
        {
            // Arrange
            ClientViewModel clientViewModel = null;

            // Act
            var badResponse = _controller.ClientRequest(clientViewModel);

            // Assert
            Assert.IsType<BadRequestResult>(badResponse);
        }

        [Theory]
        [MemberData(nameof(Helper.GetUserChoiceTestData), MemberType = typeof(Helper))]
        public void ClientRequest_UserChoicesPassed_ReturnsRightAnswer(ClientViewModel clientViewModel, string expectedAnswer)
        {
            // Act
            var jsonResult = _controller.ClientRequest(clientViewModel) as JsonResult;

            // Assert
            Assert.Equal(expectedAnswer, ((ResultDTO)jsonResult.Value).Result);
        }
    }
}
