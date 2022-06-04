using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DatosNegocio;
using EntidadesNegocio;

namespace ReglasNegocio
{
    public class clsBRUsuarioNuevo
    {
        clsBDUsuarioNuevo _ObjBDUsuarioNuevo = new clsBDUsuarioNuevo();
        public IDataReader ValidarAcceso(string usuario, string contraseña)
        {
            return _ObjBDUsuarioNuevo.ValidarAcceso(usuario, contraseña);
        }

        public int Guardar(clsBEUsuarioNuevo obj_BEUsuarioNuevo)
        {
            return _ObjBDUsuarioNuevo.Guardar(obj_BEUsuarioNuevo);
        }
    }
}
