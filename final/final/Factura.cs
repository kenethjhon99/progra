using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public class Factura
    {
        String cliente;
        String nit;
        DateTime fecha;
        float total;
        float dinero;
        float cambio;
        String usuario;

        public string Usuario { get => usuario; set => usuario = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public float Total { get => total; set => total = value; }
        public string Cliente { get => cliente; set => cliente = value; }
        public float Dinero { get => dinero; set => dinero = value; }
        public float Cambio { get => cambio; set => cambio = value; }
        public string Nit { get => nit; set => nit = value; }
    }
}
