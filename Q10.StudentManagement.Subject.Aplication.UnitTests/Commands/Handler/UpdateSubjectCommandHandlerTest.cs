using ErrorOr;
using MediatR;
using Moq;
using Q10.StudentManagement.Subject.Application.Commands;
using Q10.StudentManagement.Subject.Application.Commands.Handler;
using Q10.StudentManagement.Subject.Domain.Entities;
using Q10.StudentManagement.Subject.Domain.Interfaces;

namespace Q10.StudentManagement.Subject.Aplication.UnitTests.Commands.Handler
{
    public class UpdateSubjectCommandHandlerTest
    {
        private readonly Mock<ISubjectRepository> _mockSubjectRepository;
        private readonly UpdateSubjectCommandHandler _handler;

        public UpdateSubjectCommandHandlerTest()
        {
            _mockSubjectRepository = new Mock<ISubjectRepository>();
            _handler = new UpdateSubjectCommandHandler(_mockSubjectRepository.Object);
        }

        [Fact]
        public async Task Handle_WithValidCommand_ShouldCreateSubjectAndReturnSuccess()
        {
            var subjectId = Guid.NewGuid();
            var existingSubject = Domain.Entities.Subject.Create(new Domain.ValueObjects.Id(subjectId), "Old Name", "OLD101", 3, true);
            var command = new UpdateSubjectCommand(pId: subjectId, pName: "New Name", pCode: "NEW101", pCredits: 4, pState: false);

            _mockSubjectRepository.Setup(x => x.GetByIdAsync(It.Is<Domain.ValueObjects.Id>(id => id.pId == subjectId))).ReturnsAsync(existingSubject);
            _mockSubjectRepository.Setup(x => x.AddAsync(It.IsAny<Domain.Entities.Subject>())).Returns(Task.CompletedTask);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result.IsError);
            Assert.Equal(Unit.Value, result.Value);

            _mockSubjectRepository.Verify(
                x => x.UpdateAsync(It.Is<Domain.Entities.Subject>(s =>
                    s.Id.pId == subjectId &&
                    s.Name == command.pName &&
                    s.Code == command.pCode &&
                    s.Credits == command.pCredits &&
                    s.State == command.pState)),
                Times.Once);
        }

        [Fact]
        public async Task Handle_WithNonExistingSubject_ShouldReturnNotFoundError()
        {
            var command = new UpdateSubjectCommand(pId: Guid.NewGuid(), pName: "Mathematics", pCode: "MATH101", pCredits: 4, pState: true);

            _mockSubjectRepository.Setup(x => x.GetByIdAsync(It.IsAny<Domain.ValueObjects.Id>())).ReturnsAsync((Domain.Entities.Subject)null!);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result.IsError);
            Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
            Assert.Equal("Subject.NotFound", result.FirstError.Code);
            Assert.Equal("La asignatura que desea actualizar no fue encontrado.", result.FirstError.Description);
        }

        [Fact]
        public async Task Handle_WhenRepositoryThrowsExceptionOnGet_ShouldReturnError()
        {
            var command = new UpdateSubjectCommand(pId: Guid.NewGuid(), pName: "Physics", pCode: "PHYS101", pCredits: 3, pState: true);

            _mockSubjectRepository.Setup(x => x.GetByIdAsync(It.IsAny<Domain.ValueObjects.Id>())).ThrowsAsync(new Exception("Database error"));

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result.IsError);
            Assert.Equal(Error.Failure(description: "Database error"), result.FirstError);
        }

        [Fact]
        public async Task Handle_WhenRepositoryThrowsExceptionOnUpdate_ShouldReturnError()
        {
            var subjectId = Guid.NewGuid();
            var existingSubject = Domain.Entities.Subject.Create(new Domain.ValueObjects.Id(subjectId), "Old Name", "OLD101", 3, true);
            var command = new UpdateSubjectCommand(pId: subjectId, pName: "New Name", pCode: "NEW101", pCredits: 4, pState: false);

            _mockSubjectRepository.Setup(x => x.GetByIdAsync(It.IsAny<Domain.ValueObjects.Id>())).ReturnsAsync(existingSubject);

            _mockSubjectRepository.Setup(x => x.UpdateAsync(It.IsAny<Domain.Entities.Subject>())).ThrowsAsync(new Exception("Update failed"));

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result.IsError);
            Assert.Equal(Error.Failure(description: "Update failed"), result.FirstError);
        }
    }
}
