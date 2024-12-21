using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using techwork_after_america_return.ViewModels;
using techwork_after_america_return.Services;
using techwork_after_america_return.Data;

namespace techwork_after_america_return.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
       //  private readonly TechworkContext _ctx;// 23-9
        private readonly ITechworkRepository _repository;


        public AppController(IMailService mailService ,ITechworkRepository repository)// TechworkContext ctx)
        {
            _mailService = mailService;
            _repository = repository;
          //  _ctx = ctx;
            //23-9
        }
        public IActionResult Index() //way of taking what is happening into view
        {
         //   var Result = _ctx.Products.ToList(); just for test
            return View();
        }  
        
        [HttpGet("contact")]
        public  IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ViewModels.ContactViewModel model)
        {
            if(ModelState.IsValid)
            {
                //send mail
                _mailService.SendMessage("poojapuja.p79@gmail.com", model.Subject, $"from:{model.Name}{model.Email},message:{model.Message}");
                ViewBag.UserMessage = "mail sent";
                ModelState.Clear();
            }
            else
            {
                //no 

            }
            return View();

        }

        public IActionResult  About()
        {
            ViewBag.Title = "about";
            return View();
        }

        public IActionResult Shop()
        {
            var results = _repository.GetAllProducts();
               return View(results) ;
        }

            /* before creating techworkrepositoty
             * public IActionResult Shop()
               {
                   var Results = from p in _ctx.Products
                                 orderby p.Category
                                 select p;

                   return View(Results.ToList());
               }  */


        }
}
