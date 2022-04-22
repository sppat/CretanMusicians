using CretanMusicians.API.Contracts;
using CretanMusicians.API.Data;
using Microsoft.EntityFrameworkCore;

namespace CretanMusicians.API.Repository
{
    public class MusiciansRepository : GenericRepository<Musician>, IMusiciansRepository
    {
        public CretanMusiciansDbContext _context;

        public MusiciansRepository(CretanMusiciansDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<bool> Exists(string name)
        {
            var recordExists = await _context.Musicians.AnyAsync(m => m.Name == name);

            return recordExists;
        }
    }
}
