using BeekindSolution.Data;
using BeekindSolution.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BeekindSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Requests;
            return View(await applicationDbContext.ToListAsync());
        }

        public IActionResult Privacy()
        {
            return View();
        }


        //generate random act of kindness
        [HttpGet]
        public async Task<IActionResult> Generator()
        {
            string prompt = "You are a generator of random acts of kindness.Generate a random act of kindness as a challenge.It must be acceptable for people who live in New Zealand.";
            string result = await getRandmoGenerator(prompt);




            return RedirectToAction(nameof(Index));
        }

        public async Task<string> getRandmoGenerator(string prompt)
        {
            string kindness = "";
            string functionUrl = "https://njfujiwlmodub6ukod5h6hkytq0gdywt.lambda-url.ap-southeast-2.on.aws/";
            string parameters = $"?prompt={prompt}";

            HttpClient generatorClient = new HttpClient();
            HttpResponseMessage requestCreated = generatorClient.GetAsync(functionUrl + parameters).Result;
            HttpContent content = requestCreated.Content;
            if (content != null)
            {
                kindness = await content.ReadAsStringAsync();
            }
            else
            {
                kindness = "Something went wrong";
            }
            return kindness;
        }



        // GET: Requests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Requests == null)
            {
                return NotFound();
            }

            var request = await _context.Requests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}