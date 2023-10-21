namespace CretanMusicians.Application.Contracts.Repositories;

public interface IUnitOfWork
{
    IMusicianRepository MusicianRepository { get; }
    Task SaveChangesAsync();
}