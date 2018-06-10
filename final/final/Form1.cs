using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace final
{
    public partial class Form1 : Form
    {
        List<Usuarios> usuario = new List<Usuarios>();
      
        public Form1()
        {
            InitializeComponent();
        }
        string usua;
        string contra;
     
        private void Form1_Load(object sender, EventArgs e)
        {

            string archivo = "Usuario.txt";
            FileStream stream = new FileStream(archivo, FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(stream);
            while (leer.Peek  () > -1)
            {
                Usuarios tem = new Usuarios();
                tem.Usuario = leer.ReadLine();
                tem.Contraseña = leer.ReadLine();
                tem.TipoDeUsuario = leer.ReadLine();
                usuario.Add(tem);
            }
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = usua;
            textBox2.Text = contra;
            for (int a = 0; a < usuario.Count; a++)
                {
                if (usua == (usuario[a].Usuario))&(contra==(usuario[a].Contraseña))&((usuario[a].TipoDeUsuario==admin))
                {
                    gerente b = new gerente(usuario[a]);
                    b.Show();
                } 

            }
            for (int z = 0; z < usuario.Count; z++)
            {
                if(usua==(usuario[z].Usuario))
                {
                    trabajadores q = new trabajadores();
                    q.Show();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
