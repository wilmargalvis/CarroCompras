using System;

namespace EntidadesNegocioAPI
{
    public class clsBECompras
    {
        public string Usuario { get; set; }
        public string Identificacion { get; set; }
        public string Direccion { get; set; }

        public string CantidadComprada { get; set; }
        public string FechaCompra { get; set; }

        public string NombreProducto { get; set; }
        public string DescripcionProducto { get; set; }
        public string Stock { get; set; }
        public string Precio { get; set; }
        public int Perfil { get; set; }
    }
}
