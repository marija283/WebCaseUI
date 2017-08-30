using Newtonsoft.Json;
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

        public async Task<ActionResult> All()
        {
            var myCase = await GetAllCaseAsync();
            ViewBag.Message = myCase;

            return View();
        }
        public ActionResult Update()
        {
            ViewBag.Message = "Your update page.";

            return View();
        }
           public ActionResult GetCaseById()
        {
            ViewBag.Message = "Your GetCaseById page.";

            return View();
        }
        [HttpPost]
        public async Task<ActionResult> GetCaseById(int id)
        {

           
            var myCase = await GetCaseAsync(id);
            ViewBag.Message = myCase;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Update(int id, HttpPostedFileBase file)
        {
            ViewBag.Message = "Your update post page.";
            await UpdateProductAsync(id, file);
            return View();
        }



        static async Task<List<Case>> GetAllCaseAsync()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8787/");
                List<Case> product = null;
                HttpResponseMessage response = await client.GetAsync("api/cases");
                if (response.IsSuccessStatusCode)
                {
                    //product = await response.Content.ReadAsAsync<ListCases>();
                    var jsonString = await response.Content.ReadAsStringAsync();
                    product = JsonConvert.DeserializeObject<List<Case>>(jsonString);
                }
                return product;
            }
        }

        static async Task<Case> GetCaseAsync(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8787/");
                Case product = null;
                HttpResponseMessage response = await client.GetAsync("api/cases/"+id);
                if (response.IsSuccessStatusCode)
                {
                    product = await response.Content.ReadAsAsync<Case>();
                }
                return product;
            }
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