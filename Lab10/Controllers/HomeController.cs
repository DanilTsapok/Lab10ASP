using Lab10.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;

namespace Lab10.Controllers
{
    public class HomeController : Controller
    {
        static int consultId = 1;

        private static readonly List<string> subjects = new List<string> { "JavaScript", "C#", "Java", "Python", "Основи" };
        private static readonly List<Consultation> _consultations = new ();
        
        public IActionResult Index()
        {
            ViewBag.Subjects = new SelectList(subjects);
            return View();
            
        }
        [HttpPost]
        public IActionResult CreateConsultation(Consultation consultation)
        {
            if (ModelState.IsValid)
            {
                if (consultation.Subject == "Основи" && consultation.DateConsultation.DayOfWeek == DayOfWeek.Monday)
                {
                    ViewBag.Subject = new SelectList(subjects);
                    ModelState.AddModelError("DateConsultation", "Консультація  Основи Програмування не може проходити по понеділках.");
                    return View("Index",consultation);
                }
                consultation.Id = consultId;
                Console.WriteLine($"{consultation.Id}, {consultation.Name}, {consultation.Email}, {consultation.DateConsultation}, {consultation.Subject}");
                _consultations.Add(consultation); 
                consultId++;
                ModelState.Clear();

                return RedirectToAction("Index");

            }
            else
            {
                foreach (var key in ModelState.Keys)
                {
                    for (int i = 0; i < ModelState[key].Errors.Count; i++)
                    {
                        var error = ModelState[key].Errors[i];
                        ModelState.AddModelError(key, error.ErrorMessage);
                    }
                }

                ViewBag.Subjects = new SelectList(subjects);
                return View("Index", consultation);
            }
        }
        public IActionResult ShowConsultations()
        {
            ShowConsultationViewModel consultations = new ShowConsultationViewModel(_consultations);
            return View("Consultations", consultations);
        }
     
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}