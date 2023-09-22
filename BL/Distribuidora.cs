using DL;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Distribuidora
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            using (IvbetoPruebaTecnicaEntities context = new IvbetoPruebaTecnicaEntities())
            {
                var query = context.DistribuidoraGetAll();
                if (query != null)
                {
                    ML.Distribuidora distro = new ML.Distribuidora();
                    result.Objects = new List<object>();
                    foreach (var entity in query)
                    {
                        distro.IdDistribuidora = entity.IdDistribuidora;
                        distro.Nombre = entity.Nombre;

                        result.Objects.Add(distro);
                    }
                    result.Correct = true;
                }
                else
                {
                    result.Correct = false;
                }
            }
            return result;
        }
    }
}
