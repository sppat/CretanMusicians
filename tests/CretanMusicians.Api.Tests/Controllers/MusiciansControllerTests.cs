using CretanMusicians.Api.Controllers;
using CretanMusicians.Application.Musicians.Commands;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;

namespace CretanMusicians.Api.Tests.Controllers
{
    public class MusiciansControllerTests
    {
        [Fact]
        public async Task CreateMusician_ShouldReturnContentCreatedResult()
        {
            var controller = new MusiciansController();
            var result =  await controller.Create(new CreateMusicianCommand(
                Guid.NewGuid(),
                "Antonis",
                "Martsakis"));

            result
                .Should()
                .BeOfType<CreatedResult>();
        }
    }
}
