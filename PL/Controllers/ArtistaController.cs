using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ArtistaController : Controller
    {
        // GET: Artista
        [HttpGet]
        public ActionResult GetAllArtista()
        {
            ML.Artista artista = new ML.Artista();
            ML.Result result = BL.Artista.GetAll();
            if (result.Correct)
            {
                artista.Artistas = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(artista);
        }

        [HttpPost]
        public ActionResult GetAllArtista(ML.Artista artista)
        {

            ML.Result result = BL.Artista.GetAll();
            if(result.Correct)
            {
                artista.Artistas = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;
            }
            return View(artista);
        }
    }
}