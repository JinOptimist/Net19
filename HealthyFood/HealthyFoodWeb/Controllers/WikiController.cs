using Data.Fake.Models;
using HealthyFoodWeb.Models.ModelsWiki;
using Data.Interface.Models;
using HealthyFoodWeb.Services;
using Microsoft.AspNetCore.Mvc;
using HealthyFoodWeb.Models.ModelsWikiBAA;
using HealthyFoodWeb.Services.IServices;

namespace HealthyFoodWeb.Controllers
{
    public class WikiController : Controller
    {
        private IWikiBAAIPageRecomendateServices _blockInformationServices;


        public WikiController(IWikiBAAIPageRecomendateServices blockInformationServices)
        {
            _blockInformationServices = blockInformationServices;
        }


        public IActionResult Main()
        {
            //step 1
            return View();
        }

        public IActionResult BiologicallyActiveAdditives()
        {
            var PageViewModel = new PageViewModelBAA();
            PageViewModel.BlocksList = _blockInformationServices.GetBlocks().Select(x => new BLockPageViewModelBAA
            {
                Text = x.Text,
                Title = x.Title,
                Id=x.Id
            }).ToList();

            return View(PageViewModel);
        }

        [HttpGet]
        public IActionResult CreateBlockInformatoin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateBlockInformatoin(BLockPageViewModelBAA block)
        {
            _blockInformationServices.CreateBlock(block);
            return RedirectToAction("BiologicallyActiveAdditives");
        }

        
        public IActionResult Remove(int id)
        {
            _blockInformationServices.Remove(id);
            return RedirectToAction("BiologicallyActiveAdditives");
        }
    }
}