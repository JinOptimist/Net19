﻿using Data.Interface.DataModels;
using Data.Interface.Models;
using HealthyFoodWeb.Models;

namespace HealthyFoodWeb.Services
{
	public interface IWikiMCService
	{
		void AddImg(WikiMcViewModel viewModel);

		IEnumerable<WikiMcImage> GetAllImgByYear();

		IEnumerable<WikiMcImage> GetAllImgByType();

		IEnumerable<ImagesAndInfoAboutTheirUploaderData> GetUserImages();

        void RemoveByType(ImgTypeEnum type);

		void RemoveByYear(int year);
	}
}
