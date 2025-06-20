using ErrorOr;
using MediatR;
using Moq;
using Q10.StudentManagement.Subject.Application.Commands;
using Q10.StudentManagement.Subject.Application.Commands.Handler;
using Q10.StudentManagement.Subject.Domain.Interfaces;

namespace Q10.StudentManagement.Subject.Aplication.UnitTests.Commands.Handler
{
    public class DeleteSubjectCommandHandlerTest
    {
        private readonly Mock<ISubjectRepository> _mockSubjectRepository;
        private readonly DeleteSubjectCommandHandler _handler;

        public DeleteSubjectCommandHandlerTest()
        {
            _mockSubjectRepository = new Mock<ISubjectRepository>();
            _handler = new DeleteSubjectCommandHandler(_mockSubjectRepository.Object);
        }

        [Fact]
        public async Task Handle_WithExistingSubject_ShouldDeleteSubjectAndReturnSuccess()
        {
            var subjectId = Guid.NewGuid();
            var existingSubject = Domain.Entities.Subject.Create(new Domain.ValueObjects.Id(subjectId), "Mathematics", "MATH101", 4, true);

            var command = new DeleteSubjectCommand(pId: subjectId);

            _mockSubjectRepository.Setup(x => x.GetByIdAsync(It.Is<Domain.ValueObjects.Id>(id => id.pId == subjectId))).ReturnsAsync(existingSubject);
            _mockSubjectRepository.Setup(x => x.DeleteAsync(It.Is<Domain.ValueObjects.Id>(id => id.pId == subjectId))).Returns(Task.CompletedTask);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.False(result.IsError);
            Assert.Equal(Unit.Value, result.Value);

            _mockSubjectRepository.Verify(x => x.DeleteAsync(It.Is<Domain.ValueObjects.Id>(id => id.pId == subjectId)), Times.Once);
        }

        [Fact]
        public async Task Handle_WithNonExistingSubject_ShouldReturnNotFoundError()
        {
            var command = new DeleteSubjectCommand(pId: Guid.NewGuid());

            _mockSubjectRepository.Setup(x => x.GetByIdAsync(It.IsAny<Domain.ValueObjects.Id>())).ReturnsAsync((Domain.Entities.Subject)null!);

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result.IsError);
            Assert.Equal(ErrorType.NotFound, result.FirstError.Type);
            Assert.Equal("Subject.NotFound", result.FirstError.Code);
            Assert.Equal("La asignatura que desea eliminar no fue encontrado.", result.FirstError.Description);
        }

        [Fact]
        public async Task Handle_WhenRepositoryThrowsExceptionOnGet_ShouldReturnError()
        {
            var command = new DeleteSubjectCommand(pId: Guid.NewGuid());

            _mockSubjectRepository.Setup(x => x.GetByIdAsync(It.IsAny<Domain.ValueObjects.Id>())).ThrowsAsync(new Exception("Database error"));

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result.IsError);
            Assert.Equal(Error.Failure(description: "Database error"), result.FirstError);
        }

        [Fact]
        public async Task Handle_WhenRepositoryThrowsExceptionOnDelete_ShouldReturnError()
        {
            var subjectId = Guid.NewGuid();
            var existingSubject = Domain.Entities.Subject.Create(new Domain.ValueObjects.Id(subjectId), "Physics", "PHYS101", 3, true);

            var command = new DeleteSubjectCommand(pId: subjectId);

            _mockSubjectRepository.Setup(x => x.GetByIdAsync(It.IsAny<Domain.ValueObjects.Id>())).ReturnsAsync(existingSubject);
            _mockSubjectRepository.Setup(x => x.DeleteAsync(It.IsAny<Domain.ValueObjects.Id>())).ThrowsAsync(new Exception("Delete failed"));

            var result = await _handler.Handle(command, CancellationToken.None);

            Assert.True(result.IsError);
            Assert.Equal(Error.Failure(description: "Delete failed"), result.FirstError);
        }
    }
}