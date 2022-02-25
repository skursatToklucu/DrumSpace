using DrumSpace.Application.Common.Behaviours;
using DrumSpace.Application.Common.Interfaces;
using DrumSpace.Application.TodoItems.Commands.CreateTodoItem;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace DrumSpace.Application.UnitTests.Common.Behaviours
{
    public class RequestLoggerTests
    {
        private readonly Mock<IUserService> _userService;
        private readonly Mock<ILogger<CreateTodoItemCommand>> _logger;
        private readonly Mock<ICurrentUserService> _currentUserService;


        public RequestLoggerTests()
        {
            _userService = new Mock<IUserService>();
            _logger = new Mock<ILogger<CreateTodoItemCommand>>();
            _currentUserService = new Mock<ICurrentUserService>();
        }

        [Test]
        public async Task ShouldCallGetUserNameAsyncOnceIfAuthenticated()
        {
            _currentUserService.Setup(x => x.UserId).Returns("Administrator");

            LoggingBehaviour<CreateTodoItemCommand> requestLogger = new(_logger.Object, _currentUserService.Object, _userService.Object);

            await requestLogger.Process(new CreateTodoItemCommand { ListId = 1, Title = "title" }, new CancellationToken());

            _userService.Verify(i => i.GetUserNameAsync(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task ShouldNotCallGetUserNameAsyncOnceIfUnauthenticated()
        {
            LoggingBehaviour<CreateTodoItemCommand> requestLogger = new(_logger.Object, _currentUserService.Object, _userService.Object);
            await requestLogger.Process(new CreateTodoItemCommand { ListId = 1, Title = "title" }, new CancellationToken());
            _userService.Verify(i => i.GetUserNameAsync(null), Times.Never);
        }
    }
}