using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebCaseUI.Models;

namespace WebCaseUI.Controllers
{
    public class HomeController : Controller
    {

        static HttpClient client = new HttpClient();
        public HomeController()
        {
            client.BaseAddress = new Uri("http://localhost:8787/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Case()
        {
            ViewBag.Message = "Your case page.";

            return View();
        }
        public ActionResult Update()
        {
            ViewBag.Message = "Your update page.";

            return View();
        }

        [HttpPost]
        public ActionResult Update(int id, HttpPostedFileBase uploadFile)
        {
            ViewBag.Message = "Your update post page.";

            return View();
        }





        static async Task<Case> UpdateProductAsync(Case myCase, HttpPostedFileBase uploadFile)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/cases/{myCase.ID}", uploadFile);
            response.EnsureSuccessStatusCode();

            // Deserialize the updated product from the response body.
            myCase = await response.Content.ReadAsAsync<Case>();
            return myCase;
        }
    }
}