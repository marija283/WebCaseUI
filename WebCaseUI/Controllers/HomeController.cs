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
        public async Task<ActionResult> Update(int id, HttpPostedFileBase file)
        {
            ViewBag.Message = "Your update post page.";
            await UpdateProductAsync(id, file);
            return View();
        }





        static async Task<Case> GetCaseAsync(string path)
        {
            Case product = null;
            HttpResponseMessage response = await client.GetAsync("/api/cases");
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<Case>();
            }
            return product;
        }



        static async Task<Case> UpdateProductAsync(int myCaseId, HttpPostedFileBase file)
        {
            HttpResponseMessage response = null;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                //response = await client.PostAsync($"api/cases/{myCaseId}", file);
                response.EnsureSuccessStatusCode();

            }

            // Deserialize the updated product from the response body.
            Case myCase = await response.Content.ReadAsAsync<Case>();
            return myCase;
        }
    }
}