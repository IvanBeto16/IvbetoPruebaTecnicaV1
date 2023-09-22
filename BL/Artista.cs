using DL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Artista
    {
        public static ML.Result AddEF(ML.Artista artista)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvbetoPruebaTecnicaEntities context = new DL.IvbetoPruebaTecnicaEntities())
                {
                    ObjectParameter filasInsertadas = new ObjectParameter("filasInsertadas", typeof(int));
                    var query = context.ArtistaAdd(artista.Nombre, artista.AnioDebut, artista.Nacionalidad, filasInsertadas);
                    if((int)filasInsertadas.Value > 0)
                    {

                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo agregar al artista";
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Artista artista)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.IvbetoPruebaTecnicaEntities context = new IvbetoPruebaTecnicaEntities())
                {
                    ObjectParameter filasActualizadas = new ObjectParameter("filasActualizadas", typeof(int));
                    var query = context.ArtistaUpdate(artista.IdArtista, artista.Nombre,
                        artista.AnioDebut, artista.Nacionalidad, filasActualizadas);

                    if((int)filasActualizadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar al artista";
                    }

                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }


        public static ML.Result DeleteEF(int idArtista)
        {
            ML.Result result = new ML.Result();
            try
            {
                ML.Artista artista = new ML.Artista();
                artista.IdArtista = idArtista;
                using(DL.IvbetoPruebaTecnicaEntities context = new IvbetoPruebaTecnicaEntities())
                {
                    ObjectParameter filasEliminadas = new ObjectParameter("filasEliminadas", typeof(int));
                    var query = context.ArtistaDelete(idArtista, filasEliminadas);

                    if((int)filasEliminadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo eliminar al artista";
                    }
                }
            }catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            using(IvbetoPruebaTecnicaEntities context = new IvbetoPruebaTecnicaEntities())
            {
                var query = context.ArtistaGetAll();
                if(query != null)
                {
                    result.Objects = new List<object>();
                    foreach(var item in query)
                    {
                        ML.Artista artista = new ML.Artista();
                        artista.IdArtista = item.IdArtista;
                        artista.Nombre = item.Nombre;
                        artista.AnioDebut = item.AnioDebut;
                        artista.Nacionalidad = item.Nacionalidad;

                        result.Objects.Add(artista);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No hay artistas registrados";
                }
                return result;
            }
        }

        public static ML.Result GetById(int idArtista)
        {
            ML.Result result = new ML.Result();
            ML.Artista artista = new ML.Artista();
            artista.IdArtista = idArtista;
            using (IvbetoPruebaTecnicaEntities context = new IvbetoPruebaTecnicaEntities())
            {
                var query = context.ArtistaGetById(artista.IdArtista);
                if(query != null)
                {
                    result.Object = new object();
                    foreach(var item in query)
                    {
                        artista.IdArtista = item.IdArtista;
                        artista.Nombre = item.Nombre;
                        artista.AnioDebut = item.AnioDebut;
                        artista.Nacionalidad = item.Nacionalidad;


                        result.Object = artista;
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encuentra ese artista registrado";
                }
                return result; 
            }
        }
    }
}
