using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Text.RegularExpressions;

namespace EasyCashIdentityProject.PresentationLayer.Controllers
{
    public class ExchangeController : Controller
    {
        [HttpGet]
        // GET: ExchangeController
        public async Task<ActionResult> Index()
        {
            #region
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=usd&to=try&q=1.0"),
                Headers =
    {
                { "X-RapidAPI-Key", "4d54f1bc10mshc07e4ba976b0516p1f8fc2jsnc479666b62bd" },
                { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                body.Replace('.', ',');
                double usd = Convert.ToDouble(body);

                ViewBag.UsdToTry = usd.ToString("0.00");
            }
            #endregion

            #region
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=Eur&to=try&q=1.0"),
                Headers =
    {
                { "X-RapidAPI-Key", "4d54f1bc10mshc07e4ba976b0516p1f8fc2jsnc479666b62bd" },
                { "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com" },
    },
            };
            using (var response2 = await client.SendAsync(request2))
            {
                response2.EnsureSuccessStatusCode();
                var body2 = await response2.Content.ReadAsStringAsync();
                ViewBag.EuroToTry = body2;
            }
            #endregion

            #region
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=GBP&to=try&q=1.0"),
                Headers =
    {
                { 
                    "X-RapidAPI-Key", "4d54f1bc10mshc07e4ba976b0516p1f8fc2jsnc479666b62bd"
                },

                { 
                    "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com"
                },
    },
            };
            using (var response3 = await client.SendAsync(request3))
            {
                response3.EnsureSuccessStatusCode();
                var body3 = await response3.Content.ReadAsStringAsync();
                ViewBag.GbpToTry = body3;
            }

            #endregion

            #region
            var client4 = new HttpClient();
            var request4 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://currency-exchange.p.rapidapi.com/exchange?from=USD&to=EUR&q=1.0"),
                Headers =
    {
                {
                    "X-RapidAPI-Key", "4d54f1bc10mshc07e4ba976b0516p1f8fc2jsnc479666b62bd"
                },

                {
                    "X-RapidAPI-Host", "currency-exchange.p.rapidapi.com"
                },
    },
            };
            using (var response4= await client.SendAsync(request4))
            {
                response4.EnsureSuccessStatusCode();
                var body4 = await response4.Content.ReadAsStringAsync();
                ViewBag.UsdToEur = body4;
            }
            #endregion

            return View();
        }

        // GET: ExchangeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ExchangeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExchangeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExchangeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExchangeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ExchangeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ExchangeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
