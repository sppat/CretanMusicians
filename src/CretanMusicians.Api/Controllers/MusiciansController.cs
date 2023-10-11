using CretanMusicians.Application.Musicians.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CretanMusicians.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MusiciansController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Create(CreateMusicianCommand command)
        {
            return Created("", null);
        }
    }
}
