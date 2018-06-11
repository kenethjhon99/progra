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
    public partial class trabajadores : Form
    {
        List<clientes> clientes = new List<clientes>();
        String nit;
        String nombre;
        public trabajadores()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String client = "clientes.txt";
            FileStream stream = new FileStream(client, FileMode.Open, FileAccess.Read);
            StreamReader leer = new StreamReader(stream);
            while (leer.Peek() > -1)
            {
                clientes tem = new clientes();
                tem.Nit = leer.ReadLine();
                tem.Nombre = leer.ReadLine();
                
                clientes.Add(tem);
            }
            leer.Close();
            for (int q = 0; q < clientes.Count; q++)
            {
                if (textBox1.Text == clientes[q].Nit)
                {
                    textBox2.Text = (clientes[q].Nombre);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            String cliente = "clientes.txt";
            FileStream escribir = new FileStream(cliente, FileMode.Append, FileAccess.Write);
            StreamWriter agregar = new StreamWriter(escribir);
            agregar.WriteLine(textBox1.Text);
            agregar.WriteLine(textBox2.Text);
            agregar.Close();
            limpiar();
        }
        public void limpiar()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }
        }
}
