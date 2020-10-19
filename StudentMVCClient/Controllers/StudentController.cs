using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using StudentMVCClient.Models;

namespace StudentMVCClient.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            LoginRecords obj = new LoginRecords {Userid = "admin", Password = "admin" };
            using (HttpClient client = new HttpClient())
            {
                var token = GetToken("https://localhost:44353/api/Token", obj);
                client.BaseAddress = new Uri("https://localhost:44383/api/");
                // MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
                // client.DefaultRequestHeaders.Accept.Add(contentType);
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();
                response = client.GetAsync("StudentRecords").Result;

                string stringData = response.Content.ReadAsStringAsync().Result;

                var data = JsonConvert.DeserializeObject<IEnumerable<StudentRecords>>(stringData);

                return View(data);
            }
        }

        static string GetToken(string url, LoginRecords user)
        {
            var json = JsonConvert.SerializeObject(user);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var response = client.PostAsync(url, data).Result;
                string name = response.Content.ReadAsStringAsync().Result;
                dynamic details = JObject.Parse(name);
                return details.token;
            }
        }
    }
}
