using CretanMusicians.API.Contracts;
using CretanMusicians.API.Data;

namespace CretanMusicians.API.Repository
{
    public class OriginsRepository : GenericRepository<Origin>, IOriginsRepository
    {
        private readonly CretanMusiciansDbContext _context;

        public OriginsRepository(CretanMusiciansDbContext context) : base(context)
        {
            _context = context;
        }

        public bool Exists(string name)
        {
            return _context.Origins.Any(o => o.Name == name);
        }
    }
}
