using FluentAssertions;
using GitHubActionsDemo.Pages;
using GitHubActionsDemo.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace GitHubActionsDemo.Tests
{
    public class IndexModelTests
    {
        private readonly Mock<ILogger<IndexModel>> _logger;
        private readonly Mock<IMessageService> _service;
        private readonly IndexModel _underTest;

        public IndexModelTests()
        {
            _logger = new Mock<ILogger<IndexModel>>();
            _service = new Mock<IMessageService>();
            _underTest = new IndexModel(_logger.Object, _service.Object);
        }

        [Fact]
        public void OnGet_Fills_Messages_From_Service()
        {
            var expectedMessages = new List<Message> { new Message("Alpha"), new Message("Beta") };
            _service.Setup(s => s.GetMessages()).Returns(expectedMessages);

            _underTest.OnGet();

            _service.Verify(s => s.GetMessages(), Times.Once);
            _underTest.Messages.Should().BeEquivalentTo(expectedMessages);
        }
    }
}
