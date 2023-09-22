using DL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {
        public static ML.Result Add(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (IvbetoPruebaTecnicaEntities context = new IvbetoPruebaTecnicaEntities())
                {
                    ObjectParameter filasInsertadas = new ObjectParameter("filasInsertadas", typeof(int));
                    var query = context.DiscoAdd(disco.Titulo, disco.Duracion, disco.Anio, disco.GeneroMusical, disco.Distribuidora.IdDistribuidora
                        , disco.Artista.IdArtista, disco.Disponibilidad, disco.Ventas, filasInsertadas);

                    if ((int)filasInsertadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo insertar la entidad";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Update(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(IvbetoPruebaTecnicaEntities context = new IvbetoPruebaTecnicaEntities())
                {
                    ObjectParameter filasActualizadas = new ObjectParameter("filasActualizadas", typeof(int));
                    var query = context.DiscoUpdate(disco.IdDisco, disco.Titulo, disco.Duracion, disco.Anio, disco.GeneroMusical,
                        disco.Distribuidora.IdDistribuidora, disco.Artista.IdArtista, disco.Disponibilidad, disco.Ventas,
                        filasActualizadas);

                    if((int)filasActualizadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se pudo actualizar el Disco";
                    }
                }
            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int idDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                ML.Disco disco = new ML.Disco();
                disco.IdDisco = idDisco;
                using (IvbetoPruebaTecnicaEntities context = new IvbetoPruebaTecnicaEntities())
                {
                    ObjectParameter filasEliminadas = new ObjectParameter("filasEliminadas", typeof(int));
                    var query = context.DiscoDelete(disco.IdDisco, filasEliminadas);

                    if((int)filasEliminadas.Value > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se ha podido eliminar a la entidad Disco";
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
            using (IvbetoPruebaTecnicaEntities context = new IvbetoPruebaTecnicaEntities())
            {
                var query = context.DiscoGetAll();
                if (query != null)
                {
                    result.Objects = new List<object>();
                    foreach (var item in query)
                    {
                        ML.Disco disco = new ML.Disco();
                        disco.Artista = new ML.Artista();
                        disco.Distribuidora = new ML.Distribuidora();


                        disco.IdDisco = item.IdDisco;
                        disco.Titulo = item.Titulo;
                        disco.Duracion = item.Duracion;
                        disco.Anio = item.Anio;
                        disco.Disponibilidad = item.Disponibilidad;
                        disco.GeneroMusical = item.GeneroMusical;
                        disco.Artista.IdArtista = item.IdArtista;
                        disco.Artista.Nombre = item.NombreArtista;
                        disco.Distribuidora.IdDistribuidora = item.IdDistribuidora;
                        disco.Distribuidora.Nombre = item.NombreDistribuidora;

                        result.Objects.Add(disco);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No hay discos musicales registrados";
                }
                return result;
            }
        }

        public static ML.Result GetById(int idDisco)
        {
            ML.Result result = new ML.Result();
            ML.Disco disco = new ML.Disco();
            disco.IdDisco = idDisco;
            using (IvbetoPruebaTecnicaEntities context = new IvbetoPruebaTecnicaEntities())
            {
                var query = context.DiscoGetById(disco.IdDisco);
                if (query != null)
                {
                    result.Object = new object();
                    foreach (var item in query)
                    {
                        disco.Artista = new ML.Artista();
                        disco.Distribuidora = new ML.Distribuidora();

                        disco.IdDisco = item.IdDisco;
                        disco.Titulo = item.Titulo;
                        disco.Duracion = item.Duracion;
                        disco.Anio = item.Anio;
                        disco.Disponibilidad = item.Disponibilidad;
                        disco.GeneroMusical = item.GeneroMusical;
                        disco.Artista.IdArtista = item.IdArtista;
                        disco.Artista.Nombre = item.NombreArtista;
                        disco.Distribuidora.IdDistribuidora = item.IdDistribuidora;
                        disco.Distribuidora.Nombre = item.NombreDistribuidora;


                        result.Object = disco;
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                    result.ErrorMessage = "No se encuentra ese disco musical registrado";
                }
                return result;
            }
        }
    }
}
