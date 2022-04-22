using CretanMusicians.API.Data;

namespace CretanMusicians.API.Contracts
{
    public interface IMusiciansRepository : IGenericRepository<Musician>
    {
        Task<bool> Exists(string name);
    }
}
