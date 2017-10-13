using Payment.DAL.Core.Model;
using PaymentBLL.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PaymentSolutionWeb.Areas.Manage.Controllers
{
    public class BankController : Controller
    {
      //net.tcp://wema-wdb-lc0370.wemabank.local/PayService/BankService.svc
      // public BankController();
        // GET: Manage/Bank
        public ActionResult Index()
        {
            return View();
        }

        // GET: Manage/Bank/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Manage/Bank/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manage/Bank/Create
        [HttpPost]
        public ActionResult Create(Bank bank)
        {
            //try
            //{
            //    if (manage.CreateNewBank(bank))
            //    {
            //        ViewBag.msg = string.Format("{0} has been successfully created", bank.BankName);
            //        ViewBag.flag = true;
            //    }
            //    else
            //    {
            //        ViewBag.msg = string.Format("Attempt to create {0} failed", bank.BankName);
            //        ViewBag.flag = false;
            //    }
                return View(bank);
            //}
            //catch
            //{
            //    return View();
            //}
        }

        // GET: Manage/Bank/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Manage/Bank/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Manage/Bank/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Manage/Bank/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
