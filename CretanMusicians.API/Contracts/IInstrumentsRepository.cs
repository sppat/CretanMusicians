using CretanMusicians.API.Data;

namespace CretanMusicians.API.Contracts
{
    public interface IInstrumentsRepository : IGenericRepository<Instrument>
    {
        bool Exists(string name);
    }
}
