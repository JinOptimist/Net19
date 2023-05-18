﻿using Data.Interface.DataModels;
using Data.Sql.Models;

namespace Data.Interface.Repositories
{
    public interface IWikiBaaRepository : IBaseRepository<PageWikiBlock>
    {
        IEnumerable<BlockPageBaaData> GetBlocksWithAuthorComMents();

        BlockPageBaaData GetBLockPageBaaViewModel(int id);

        void UpdateBlock(int id, string title, string text);
    }
}