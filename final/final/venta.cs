using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    class venta
    {
        string producto;
        float precio;
        int existencias;
        float total;

        public string Producto { get => producto; set => producto = value; }
        public int Existencias { get => existencias; set => existencias = value; }
        public float Precio { get => precio; set => precio = value; }
        public float Total { get => total; set => total = value; }
    }
}
