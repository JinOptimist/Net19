﻿using Data.Interface.Models;
using HealthyFoodWeb.Models.ModelsWikiBAA;

namespace HealthyFoodWeb.Services.WikiServices
{
    public interface IWikiBAAIPageRecomendateServices
    {
        List<IBlockModelBAA> GetBlocks();
        void CreateBlock(BLockPageViewModelBAA block);
        void Remove(int id);
    }
}