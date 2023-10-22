using CretanMusicians.Domain.Exceptions;
using CretanMusicians.Domain.ValueObjects;
using FluentAssertions;
using Xunit;

namespace CretanMusicians.Domain.Tests.MusicianTests;

public class MusicianIdTests
{
    private readonly Guid _emptyGuid = Guid.Empty;
    private readonly Guid _leftGuid = Guid.NewGuid(); 
    private readonly Guid _rightGuid = Guid.NewGuid();

    [Fact]
    public void MusicianIds_Should_BeEqual_WhenHavingTheSameValue()
    {
        var left = MusicianId.Create(_leftGuid);
        var right = MusicianId.Create(_leftGuid);

        var areEqual = left == right;

        areEqual.Should().BeTrue();
    }

    [Fact]
    public void MusicianIds_Should_NotBeEqual_WhenHavingDifferentValues()
    {
        var left = MusicianId.Create(_leftGuid);
        var right = MusicianId.Create(_rightGuid);

        var areEqual = left == right;

        areEqual.Should().BeFalse();
    }
    
    [Fact]
    public void MusicianId_Should_ThrowException_WhenValueIsEmpty()
    {
        Action createAction = () => MusicianId.Create(_emptyGuid);
        
        createAction.Should().Throw<EmptyMusicianIdException>();
    }
}