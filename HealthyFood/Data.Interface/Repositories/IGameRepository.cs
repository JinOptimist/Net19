﻿using Data.Interface.Models;

namespace Data.Interface.Repositories
{
    public interface IGameRepository : IBaseRepository<Game>
    {
        Game GetGameByName(string name);

        void RemoveByName(string name);
    }
}
