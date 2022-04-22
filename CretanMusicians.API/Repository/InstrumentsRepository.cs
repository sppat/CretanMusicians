using CretanMusicians.API.Contracts;
using CretanMusicians.API.Data;

namespace CretanMusicians.API.Repository
{
    public class InstrumentsRepository : GenericRepository<Instrument>, IInstrumentsRepository
    {
        private readonly CretanMusiciansDbContext _context;

        public InstrumentsRepository(CretanMusiciansDbContext context) : base(context)
        {
            _context = context;
        }

        public bool Exists(string name)
        {
            return _context.Instruments.Any(i => i.Name == name);
        }
    }
}
