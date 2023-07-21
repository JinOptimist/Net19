﻿using HealthyFoodWeb.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace HealthyFoodWeb.Controllers.Quiz
{
    public class QuizController : Controller
    {
        private IQuizServices _quizServices;


        public QuizController(IQuizServices quizServices)
        {
            _quizServices = quizServices;          
        }
        public IActionResult Index()
        {
           var viewModel = _quizServices.GetAllQuiz();
            return View(viewModel);
        }
    }
}
