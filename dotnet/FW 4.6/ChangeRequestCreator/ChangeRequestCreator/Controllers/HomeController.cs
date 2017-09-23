using OpenXmlPowerTools;
using System.Web;
using System.Collections.Generic;
using System.Web.Mvc;
using ChangeRequestCreator.Models;

namespace ChangeRequestCreator.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Documento/
        public ActionResult Index()
        {
            List<string> serverTypes = new List<string> { "WebSite", "Dll", "Serviço", "Base de Dados" };

            ViewBag.ServerTypes = new MultiSelectList(serverTypes);

            return View();
        }

        public ActionResult Download(string ownerName, string description, string version ,string[] SelectedServers)
        {
            var gmud = new Gmud(Server.MapPath("\\Files\\ScriptTemplate.docx"), SelectedServers, ownerName, description, version);

            WmlDocument wmlAssembledDoc = gmud.GetDoc();

            return File(wmlAssembledDoc.DocumentByteArray, System.Net.Mime.MediaTypeNames.Application.Octet, "GMUD.docx");
        }

    }
}