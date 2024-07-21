using LxApi.Models;
using MongoDB.Driver;

namespace LxApi.Services;

public interface IMongoService {
    public IMongoCollection<EntryFR> EntriesFR { get; }
}
