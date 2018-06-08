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
        string esistencias;
        string prcio;

        public string Nombreproducto { get => nombreproducto; set => nombreproducto = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Esistencias { get => esistencias; set => esistencias = value; }
        public string Prcio { get => prcio; set => prcio = value; }
    }
}
