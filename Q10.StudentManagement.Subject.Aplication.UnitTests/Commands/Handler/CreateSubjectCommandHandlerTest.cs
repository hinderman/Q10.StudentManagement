using ErrorOr;
using MediatR;
using Moq;
using Q10.StudentManagement.Subject.Application.Commands;
using Q10.StudentManagement.Subject.Application.Commands.Handler;
using Q10.StudentManagement.Subject.Domain.Interfaces;

namespace Q10.StudentManagement.Subject.Aplication.UnitTests.Commands.Handler
{
    public class CreateSubjectCommandHandlerTest
    {
        private readonly Mock<ISubjectRepository> _mockSubjectRepository;
        private readonly CreateSubjectCommandHandler _handler;

        public CreateSubjectCommandHandlerTest()
        {
            _mockSubjectRepository = new Mock<ISubjectRepository>();
            _handler = new CreateSubjectCommandHandler(_mockSubjectRepository.Object);
        }

        [Fact]
        public async Task Handle_WithValidCommand_ShouldCreateSubjectAndReturnSuccess()
        {
            var command = new CreateSubjectCommand(pId: Guid.NewGuid(), pName: "Mathematics", pCode: "MATH-101", pCredits: 4, pState: true);

            _mockSubjectRepository.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.Subject>())).Returns(Task.CompletedTask);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result.IsError);
            Assert.Equal(Unit.Value, result.Value);

            _mockSubjectRepository.Verify(x => x.AddAsync(It.Is<Domain.Entities.Subject>(s =>
                    s.Id.pId != Guid.Empty &&
                    s.Name == command.pName &&
                    s.Code == command.pCode &&
                    s.Credits == command.pCredits &&
                    s.State == command.pState)), Times.Once);
        }

        [Fact]
        public void Constructor_WithNullRepository_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new CreateSubjectCommandHandler(null));
        }

        [Fact]
        public async Task Handle_WhenRepositoryThrowsException_ShouldReturnError()
        {
            var command = new CreateSubjectCommand(pId: Guid.NewGuid(), pName: "Mathematics", pCode: "MATH-101", pCredits: 4, pState: true);

            _mockSubjectRepository.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.Subject>())).ThrowsAsync(new Exception("Database error"));

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result.IsError);
            Assert.Equal(Error.Failure(description: "Database error"), result.FirstError);
        }
    }
}
