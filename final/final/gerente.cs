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
    public partial class gerente : Form
    {
        List<producto> producto = new List<producto>();
        String nombre;
        String cantidad;
        String precio;
        String codigo;
        Usuarios nuevo = new Usuarios();
        public gerente()
        {

            InitializeComponent();
        }
        public gerente(Usuarios entrada)
        {
            nuevo = entrada;
            InitializeComponent();
        }

        private void gerente_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = nombre;
            textBox2.Text = codigo;
            textBox3.Text = precio;
            textBox4.Text = cantidad;
            String mercaderia = "producto.txt";
            FileStream escribir = new FileStream(mercaderia, FileMode.Open, FileAccess.Write);
            StreamWriter modificar = new StreamWriter(escribir);
            
        }
    }
}
