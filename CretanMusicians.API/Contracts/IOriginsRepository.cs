﻿using CretanMusicians.API.Data;

namespace CretanMusicians.API.Contracts
{
    public interface IOriginsRepository : IGenericRepository<Origin>
    {
        bool Exists(string name);
    }
}
