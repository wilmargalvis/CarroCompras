using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DatosNegocio;

namespace ReglasNegocio
{
    public class clsBRCompras
    {
        clsBDCompras _objBDCompras = new clsBDCompras();
        public IDataReader CargarCompras()
        {
            return _objBDCompras.CargarCompras();
        }

        public void GuadarPedido(string IDProducto, string IDUsuario, string CtdProductos)
        {
            _objBDCompras.GuadarPedido(IDProducto, IDUsuario, CtdProductos);
        }

        public IDataReader CargarProductos()
        {
            //DataTable dt = new DataTable();
            //dt.Load(_objBDCompras.CargarProductos());

            return _objBDCompras.CargarProductos();
        }
    }
}
