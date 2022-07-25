using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidad;
using Datos;
using System.Data.SqlClient;
using System.Configuration;

namespace AgendaLogica
{
    public class Logica
    {
        D_Caracteristicas objDato = new D_Caracteristicas();
        public List<E_Caracteristicas> ListarDatos(string buscar)
        {
            return objDato.ListarDatos(buscar);
        }

        public void InsertarDatos(E_Caracteristicas datos)
        {
            objDato.InsertarDatos(datos);
        }

        public void EditarDatos(E_Caracteristicas datos)
        {
            objDato.EditarDatos(datos);
        }

        public void EliminarDatos(E_Caracteristicas datos)
        {
            objDato.EliminarCategoria(datos);
        }
    }
}
