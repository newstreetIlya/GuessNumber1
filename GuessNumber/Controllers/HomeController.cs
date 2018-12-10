using GuessNumber.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuessNumber.Controllers
{
    public class HomeController : Controller
    {
        private static Dictionary<string, UserGameModel> GenerNumbers = new Dictionary<string, UserGameModel>();

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult StartGame(int N)
        {
            string IP = HttpContext.Request.UserHostAddress;

            var genNumber = _generatNumber(N);
            var UG = GenerNumbers.Keys.Where(g => g == IP).FirstOrDefault();
            if (UG != null)
            {
                GenerNumbers[UG] = new UserGameModel(IP, genNumber, 3, 0);
            }
            else
            {

                GenerNumbers.Add(IP, new UserGameModel(IP, genNumber, 3, 0));

            }

            return Json(new { }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult Check(List<CheckNumberModel> CheckNumber)
        {
            string IP = HttpContext.Request.UserHostAddress;

            var UG = GenerNumbers[IP];

            var res = UG.CheckNumber(CheckNumber);

            return Json(new { res, stap = UG.Stap, finish = UG.CheckFinish() }, JsonRequestBehavior.AllowGet);
        }


        private int[] _generatNumber(int n)
        {
            int[] num = new int[n];

            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                num[i] = random.Next(10);
            }

            return num;
        }

    }
}
