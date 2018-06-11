using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    class producto
    {
        string nombreproducto;
        string codigo;
        int esistencias;
        string prcio;
        string costo;
      //  string total;

        public string Nombreproducto { get => nombreproducto; set => nombreproducto = value; }
        public string Codigo { get => codigo; set => codigo = value; }
       
        public string Prcio { get => prcio; set => prcio = value; }
    //    public string Total { get => total; set => total = value; }
        public string Costo { get => costo; set => costo = value; } 
        public int Esistencias { get => esistencias; set => esistencias = value; }
    }
}
