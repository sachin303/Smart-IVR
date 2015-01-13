using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using InteractiveResponse.Service;
using InteractiveResponse.Model;

namespace InteractiveResponse.Client.Controllers
{
    public class ResponseController : Controller
    {
        //
        // GET: /Response/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Search(Query query)
        {
            var path = Request.MapPath("~\\Lib\\NLP\\");
            ResponseService response = new ResponseService(new QueryAnalyzer(new SearchEngine(), new Sanitizer(path)));

            var queryResponse = response.Search(new Query
            {
                Text = query.Text,
                Type = QueryType.Text
            });

            return Json(queryResponse, JsonRequestBehavior.AllowGet);
        }


        public ActionResult RespondTo(Query query)
        {
            return Json("Good Luck", JsonRequestBehavior.AllowGet);
            
        }
    }
}
