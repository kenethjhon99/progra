using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final
{
    public class  Usuarios
    {
        String usuario;
        String contraseña;
        String tipoDeUsuario;//para identificar que tipo de usuario que se logea

        public string Usuario { get => usuario; set => usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string TipoDeUsuario { get => tipoDeUsuario; set => tipoDeUsuario = value; }
    }
}
