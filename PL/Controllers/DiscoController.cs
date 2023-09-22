using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Disco disco = new ML.Disco();
            ML.Result result = BL.Disco.GetAll();
            if (result.Correct)
            {
                disco.Discos = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(disco);
        }

        [HttpPost]
        public ActionResult GetAll(ML.Disco disco)
        {

            ML.Result result = BL.Disco.GetAll();
            if (result.Correct)
            {
                disco.Discos = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(disco);
        }

        [HttpGet]
        public ActionResult Form(int? idDisco)
        {
            ML.Disco disco = new ML.Disco();
            disco.IdDisco = idDisco.Value;

            ML.Result resultDistros = BL.Distribuidora.GetAll();
            ML.Result resultArtistas = BL.Artista.GetAll();
        }
    }
}