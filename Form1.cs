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

namespace Ticket
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double iva;
        double subtotal;
        double total;
        private void button1_Click(object sender, EventArgs e)
        {
            double costo = Convert.ToInt32(txtcosto.Text);
            int cantidad = Convert.ToInt32(txtcantidad.Value);
           // double total = costo*cantidad;
            string nombre = Convert.ToString(txtproducto.Text);

            Product miproducto = new Product(cantidad,costo,total,nombre);

            double importet = miproducto.importe(cantidad, costo);
            txtimporte.Text = "$"+importet.ToString();

            
            subtotal += importet;
            txtsubtotal.Text = "$"+subtotal.ToString();
          

        
            iva += miproducto.iva(importet);
            txtiva.Text = "$"+iva.ToString();

            total = subtotal + iva;
            txttotal.Text = "$"+total.ToString();

            //subtotal

            listBox1.Items.Add("Producto: "+txtproducto.Text +"- Cantidad:"+txtcantidad.Value+"- Costo: $"+txtcosto.Text+"- Importe: $"+importet);

           
        }

        int pago;
        double cambio;
        private void bpagar_Click(object sender, EventArgs e)
        {
             pago = Convert.ToInt32(txtpago.Text);
             cambio = pago - total;
            txtcambio.Text = "Su cambio: $"+cambio.ToString();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bticket_Click(object sender, EventArgs e)
        {
            SaveFileDialog generar = new SaveFileDialog();
            generar.FileName = "t.txt";
            generar.Filter = "Text File | *.txt";

            if(generar.ShowDialog() == DialogResult.OK)
            {
                StreamWriter pasar = new StreamWriter(generar.OpenFile());
                pasar.WriteLine("SORIANA SUPER");
                pasar.WriteLine ("compra #####");
                for (int i = 0; i < listBox1.Items.Count;i++)
                {
                    pasar.WriteLine(listBox1.Items[i].ToString());
                }

                pasar.WriteLine("Impuesto: $" + iva);
                pasar.WriteLine("Subtotal: $" + subtotal);
                pasar.WriteLine("Total: $" + total);
                pasar.WriteLine("Efectivo: $" + pago);
                pasar.WriteLine("Cambio: $" + cambio);
                pasar.WriteLine("Gracias por su compra! Vuelva pronto");

                pasar.Dispose();
                pasar.Close();

                
            }

        }
    }
}
