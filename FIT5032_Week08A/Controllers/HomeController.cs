﻿using FIT5032_Week08A.Models;
using FIT5032_Week08A.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FIT5032_Week08A.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Please comment out these codes once you have registered your API key.
            //EmailSender es = new EmailSender();
            //es.RegisterAPIKey();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            EmailSender es = new EmailSender();
            es.Send("po97320@163.com", "Test1", "Test content", null);

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Send_Email()
        {
            SendEmailViewModel sendEmailViewModel = new SendEmailViewModel();
            sendEmailViewModel.ToEmail = "123@163.com";
            sendEmailViewModel.Contents = "This is content";
            return View(sendEmailViewModel);
        }

        [HttpPost]
        public ActionResult Send_Email(SendEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    String toEmail = model.ToEmail;
                    String subject = model.Subject;
                    String contents = model.Contents;
                    HttpPostedFileBase attachment = model.Attachment;

                    EmailSender es = new EmailSender();
                    es.Send(toEmail, subject, contents, attachment);

                    ViewBag.Result = "Email has been send.";

                    ModelState.Clear();

                    return View(new SendEmailViewModel());
                }
                catch
                {
                    return View();
                }
            }

            return View();
        }

    }
}