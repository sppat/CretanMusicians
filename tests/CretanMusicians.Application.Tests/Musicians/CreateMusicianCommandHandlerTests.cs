using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Application.Musicians.CreateMusician;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;

namespace CretanMusicians.Application.Tests.Musicians;

public class CreateMusicianCommandHandlerTests
{
    private readonly Mock<IMusicianRepository> _musicianRepository = new();
    private readonly Mock<IValidator<CreateMusicianCommand>> _createMusicianValidator = new();
    private readonly Mock<IUnitOfWork> _unitOfWork = new();

    [Fact]
    public async Task Handle_Should_ReturnSuccess_WhenFullNameIsUnique()
    {
        var command = new CreateMusicianCommand("Lyra", "TestName", "TestName");
        
        _unitOfWork
            .Setup(u => u.MusicianRepository)
            .Returns(_musicianRepository.Object);
        
        _createMusicianValidator
            .Setup(c => c.ValidateAsync(It.IsAny<CreateMusicianCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());

        var commandHandler = new CreateMusicianCommandHandler(_createMusicianValidator.Object, _unitOfWork.Object);
        var result = await commandHandler.Handle(command, default);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenFullNameIsNotUnique()
    {
        var command = new CreateMusicianCommand("Lyra", "TestName", "TestName");
        
        _unitOfWork
            .Setup(u => u.MusicianRepository)
            .Returns(_musicianRepository.Object);
        
        _createMusicianValidator
            .Setup(c => c.ValidateAsync(It.IsAny<CreateMusicianCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult(new List<ValidationFailure>
            {
                new()
            }));
        
        var commandHandler = new CreateMusicianCommandHandler(_createMusicianValidator.Object, _unitOfWork.Object);
        var result = await commandHandler.Handle(command, default);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
    }
}