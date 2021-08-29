using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask_SysTech.DTO;
using TestTask_SysTech.Transmitters;

namespace TestTask_SysTech.Controllers
{
    public class HomeController : Controller
    {
        private static string storagePath = "D:/Index.xml";
        public ActionResult List()
        {
            return View();
        }
        public JsonResult Get([DataSourceRequest] DataSourceRequest request)
        {
            List<CardDTO> data = CardsTransmitter.GetData();
            return Json(data.ToDataSourceResult(request));
        }
        [HttpPost]
        public ActionResult Upload()
        {
            List<string> err = new List<string>();
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];
                if (file != null)
                {
                    string fileName = Path.GetFileName(file.FileName);
                    //if (Path.GetExtension(file.FileName).Equals(".xml"))
                    if (fileName.Equals("Index.xml"))
                    {
                        err = CardsTransmitter.UpdateData(new StreamReader(file.InputStream));
                        if (!err.Any())
                        {
                            if (System.IO.File.Exists(storagePath))
                            {
                                System.IO.File.Delete(storagePath);
                            }
                            file.SaveAs(storagePath);
                        }
                    }
                    else
                    {
                        err.Add("Имя файла не соответствует необходимому: 'Index.xml'.");
                    }
                }
            }
            if (err.Any())
            {
                return Json(new { success = false, errors = err }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}