using AutoMapper;
using CretanMusicians.API.Data;
using Microsoft.AspNetCore.Mvc;

namespace CretanMusicians.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly CretanMusiciansDbContext _context;
        private readonly IMapper _mapper;

        public MusiciansController(CretanMusiciansDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // POST /api/musicians/

    }
}
