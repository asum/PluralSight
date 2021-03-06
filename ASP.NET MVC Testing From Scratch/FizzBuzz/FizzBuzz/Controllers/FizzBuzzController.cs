﻿#region using

using System.Web.Mvc;

#endregion

namespace FizzBuzz.Controllers
{
    public class FizzBuzzController : Controller
    {
        // GET: FizzBuzz
        public ActionResult Index(int value)
        {
            for (int i = 1; i <= value; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    ViewBag.Output += "FizzBuzz ";
                }
                else if (i % 5 == 0)
                {
                    ViewBag.Output += "Buzz ";
                }
                else if (i % 3 == 0)
                {
                    ViewBag.Output += "Fizz ";
                }
                else
                {
                    ViewBag.Output += i.ToString() + " ";
                }
            }
            return View();
        }
    }
}