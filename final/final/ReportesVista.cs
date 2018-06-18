using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace final
{
    public partial class ReportesVista : Form
    {
        List<producto> listadoDeProductos = new List<producto>();
        List<Factura> listadoDeFacturas = new List<Factura>();
        List<Usuarios> listaDeUsuarios = new List<Usuarios>();
        List<venta> listaDetalleVentas = new List<venta>();
        public ReportesVista()
        {
            InitializeComponent();
        }

        private void ReportesVista_Load(object sender, EventArgs e)
        {
            leerProductos();
            leerVentas();
            leerVendedores();
            leerDetalleVentas();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<producto> listaProductosAvastecer = new List<producto>();
            for (int i = 0; i < listadoDeProductos.Count; i++)
            {
                if (listadoDeProductos[i].Esistencias < 3)
                {
                    listaProductosAvastecer.Add(listadoDeProductos[i]);
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            if(listaProductosAvastecer.Count == 0)
            {
                MessageBox.Show("No hay productos por avastecer");
            }
            else
            {
                dataGridView1.DataSource = listaProductosAvastecer;
                dataGridView1.Refresh();
            }

        }

        public void leerProductos ()
        {
            string mercaderia = "producto.txt";
            FileStream leer = new FileStream(mercaderia, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(leer);
            while (reader.Peek() > -1)
            {
                producto tem = new producto();
                tem.Nombreproducto = reader.ReadLine();
                tem.Codigo = reader.ReadLine();
                tem.Prcio = reader.ReadLine();
                tem.Esistencias = Convert.ToInt32(reader.ReadLine());
                tem.Costo = reader.ReadLine();
                //   tem.Total = reader.ReadLine();
                listadoDeProductos.Add(tem);
            }
            reader.Close();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }

        public void leerVentas()
        {
            string facturas = "factura.txt";
            FileStream leer = new FileStream(facturas, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(leer);
            while (reader.Peek() > -1)
            {
                Factura tem = new Factura();
                tem.Nit = reader.ReadLine();
                tem.Cliente = reader.ReadLine();
                tem.Fecha = Convert.ToDateTime(reader.ReadLine());
                tem.Fecha = tem.Fecha.Date;
                tem.Total = float.Parse(reader.ReadLine());
                tem.Dinero = float.Parse(reader.ReadLine());
                tem.Cambio = float.Parse(reader.ReadLine());
                tem.Usuario = reader.ReadLine();
                //   tem.Total = reader.ReadLine();
                listadoDeFacturas.Add(tem);
            }
            reader.Close();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }

        public void leerVendedores()
        {
            string archivoUsuario = "Usuario.txt";
            FileStream leer = new FileStream(archivoUsuario, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(leer);
            while (reader.Peek() > -1)
            {
                Usuarios tem = new Usuarios();
                tem.Usuario = reader.ReadLine();
                tem.Contraseña = reader.ReadLine();
                tem.TipoDeUsuario = reader.ReadLine();
                //   tem.Total = reader.ReadLine();
                listaDeUsuarios.Add(tem);
            }
            reader.Close();
            comboBox1.DataSource = null;
            comboBox1.Refresh();
            comboBox1.DataSource = listaDeUsuarios;
            comboBox1.DisplayMember = "usuario";
            comboBox1.ValueMember = "usuario";
        }

        public void leerDetalleVentas()
        {
            string ventasHechas = "detalleVenta.txt";
            FileStream leer = new FileStream(ventasHechas, FileMode.Open, FileAccess.Read);
            StreamReader reader = new StreamReader(leer);
            while (reader.Peek() > -1)
            {
                venta tem = new venta();
                tem.Producto = reader.ReadLine();
                tem.Precio = float.Parse(reader.ReadLine());
                tem.Existencias = Convert.ToInt32(reader.ReadLine());
                tem.Total = float.Parse(reader.ReadLine());
                //   tem.Total = reader.ReadLine();
                listaDetalleVentas.Add(tem);
            }
            reader.Close();
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            List<Factura> VentasPorMes = new List<Factura>();
            for (int y =0; y < listadoDeFacturas.Count; y++)
            {
                if (dateTimePicker3.Value.Month == listadoDeFacturas[y].Fecha.Month)
                {
                    VentasPorMes.Add(listadoDeFacturas[y]);
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            if (VentasPorMes.Count == 0)
            {
                MessageBox.Show("No hay ventas en esta fecha");
            }
            else
            {
                dataGridView1.DataSource = VentasPorMes;
                dataGridView1.Refresh();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string vendedorC = Convert.ToString(comboBox1.SelectedValue);
            List<Factura> ventasDeVendedor = new List<Factura>();
            for ( int x = 0; x < listadoDeFacturas.Count; x++)
            {
                if(vendedorC == listadoDeFacturas[x].Usuario)
                {
                    ventasDeVendedor.Add(listadoDeFacturas[x]);
                }
            }
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            if (ventasDeVendedor.Count == 0)
            {
                MessageBox.Show("No hay ventas en esta fecha");
            }
            else
            {
                dataGridView1.DataSource = ventasDeVendedor;
                dataGridView1.Refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            float contadorDeFacturas = 0;
            float SumaMayorVentas = 0;
            string vendedorMasVentas = "";
            for(int x =0; x<listaDeUsuarios.Count; x++)
            {
                if(listaDeUsuarios[x].TipoDeUsuario == "ventas")
                {
                    for (int y = 0; y<listadoDeFacturas.Count; y++)
                    {
                        if(listaDeUsuarios[x].Usuario == listadoDeFacturas[y].Usuario)
                        {
                            contadorDeFacturas = contadorDeFacturas + listadoDeFacturas[y].Total;
                        }
                    }
                }
                if (SumaMayorVentas <= contadorDeFacturas)
                {
                    SumaMayorVentas = contadorDeFacturas;
                    vendedorMasVentas = listaDeUsuarios[x].Usuario;
                }
            }
            MessageBox.Show("El vendedor con mas ventas es: " + vendedorMasVentas + "Con un total de " + Convert.ToString(SumaMayorVentas));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<venta> listadoVentasTotales = new List<venta>();
            venta temporal = new venta();
            for (int y = 0; y < listadoDeProductos.Count; y++)
            {
                for (int x = 0; x < listaDetalleVentas.Count; x++)
                {
                    if (listadoDeProductos[y].Nombreproducto == listaDetalleVentas[x].Producto)
                    {
                        temporal.Producto = listaDetalleVentas[x].Producto;
                        temporal.Existencias = temporal.Existencias + listaDetalleVentas[x].Existencias;

                    }
                }
                listadoVentasTotales.Add(temporal);
                temporal = new venta();
            }
            listadoVentasTotales = listadoVentasTotales.OrderByDescending(p => p.Existencias).ToList();//ordena la lista de ventas de mayor a menor 
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            if (listadoVentasTotales.Count == 0)
            {
                MessageBox.Show("No hay ventas hechoas");
            }
            else
            {
                dataGridView1.DataSource = listadoVentasTotales;
                dataGridView1.Refresh();
            }
        }
    }
}
