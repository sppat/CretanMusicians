using CretanMusicians.Application.Contracts.Repositories;
using CretanMusicians.Application.Musicians.CreateMusician;
using FluentAssertions;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Xunit;

namespace CretanMusicians.Application.Tests.Musicians;

public class CreateMusicianCommandHandlerTests
{
    private const string Instrument = "lyra";
    private const string FirstName = "TestFirstName";
    private const string LastName = "TestLastName";
    private readonly Mock<IMusicianRepository> _musicianRepository = new();
    private readonly Mock<IValidator<CreateMusicianCommand>> _createMusicianValidator = new();
    private readonly Mock<IUnitOfWork> _unitOfWork = new();

    [Fact]
    public async Task Handle_Should_ReturnSuccess_WhenFullNameIsUnique()
    {
        _unitOfWork
            .Setup(u => u.MusicianRepository)
            .Returns(_musicianRepository.Object);
        
        _createMusicianValidator
            .Setup(c => c.ValidateAsync(It.IsAny<CreateMusicianCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult());
        
        var command = new CreateMusicianCommand(Instrument, FirstName, LastName);
        var commandHandler = new CreateMusicianCommandHandler(_createMusicianValidator.Object, _unitOfWork.Object);
        
        var result = await commandHandler.Handle(command, default);

        result.IsSuccess.Should().BeTrue();
        result.Value.Should().NotBeNull();
    }

    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenFullNameIsNotUnique()
    {
        _unitOfWork
            .Setup(u => u.MusicianRepository)
            .Returns(_musicianRepository.Object);
        
        _createMusicianValidator
            .Setup(c => c.ValidateAsync(It.IsAny<CreateMusicianCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult(new List<ValidationFailure>
            {
                new()
            }));
     
        var command = new CreateMusicianCommand(Instrument, FirstName, LastName);
        var commandHandler = new CreateMusicianCommandHandler(_createMusicianValidator.Object, _unitOfWork.Object);
        
        var result = await commandHandler.Handle(command, default);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
    }
    
    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenFirstNameIsNullOrEmpty()
    {
        _unitOfWork
            .Setup(u => u.MusicianRepository)
            .Returns(_musicianRepository.Object);
        
        _createMusicianValidator
            .Setup(c => c.ValidateAsync(It.IsAny<CreateMusicianCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult(new List<ValidationFailure>
            {
                new()
            }));
     
        var command = new CreateMusicianCommand(Instrument, default!, LastName);
        var commandHandler = new CreateMusicianCommandHandler(_createMusicianValidator.Object, _unitOfWork.Object);
        
        var result = await commandHandler.Handle(command, default);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        
        command = new CreateMusicianCommand(Instrument, string.Empty, LastName);
        
        result = await commandHandler.Handle(command, default);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
    }
    
    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenLastNameIsNullOrEmpty()
    {
        _unitOfWork
            .Setup(u => u.MusicianRepository)
            .Returns(_musicianRepository.Object);
        
        _createMusicianValidator
            .Setup(c => c.ValidateAsync(It.IsAny<CreateMusicianCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult(new List<ValidationFailure>
            {
                new()
            }));
        
        var command = new CreateMusicianCommand(Instrument, FirstName, default!);
        var commandHandler = new CreateMusicianCommandHandler(_createMusicianValidator.Object, _unitOfWork.Object);
        
        var result = await commandHandler.Handle(command, default);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
        
        command = new CreateMusicianCommand(Instrument, FirstName, default!);
        
        result = await commandHandler.Handle(command, default);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
    }
    
    [Fact]
    public async Task Handle_Should_ReturnFailure_WhenInstrumentIsNullOrEmpty()
    {
        _unitOfWork
            .Setup(u => u.MusicianRepository)
            .Returns(_musicianRepository.Object);
        
        _createMusicianValidator
            .Setup(c => c.ValidateAsync(It.IsAny<CreateMusicianCommand>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ValidationResult(new List<ValidationFailure>
            {
                new()
            }));
        
        var command = new CreateMusicianCommand(default!, FirstName, LastName);
        var commandHandler = new CreateMusicianCommandHandler(_createMusicianValidator.Object, _unitOfWork.Object);
        
        var result = await commandHandler.Handle(command, default);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();

        command = new CreateMusicianCommand(string.Empty, FirstName, LastName);
        
        result = await commandHandler.Handle(command, default);

        result.IsSuccess.Should().BeFalse();
        result.Value.Should().BeNull();
    }
}