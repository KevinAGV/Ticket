using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticket
{
    class Product
    {
        private int _cantidad;
        private double _costo;
        private double _total;
        private string _nombre;

        public int cantidad
        {
            get { return _cantidad; }
        }

        public double costo
        {
            get { return _costo; }
        }

        public double total
        {
            get { return _total; }
        }

      

        public Product (int cantidad, double costo, double total, string nombre)
        {
            _cantidad = cantidad;
            _costo = costo;
            _total = total;
            _nombre = nombre;
        }

        public double importe(int cantidad,double costo)
        {
            double importe = _cantidad * _costo;
            return importe;

        }

        public double iva(double subtotal)
        {
            double iva = subtotal * 0.16;
            return iva;
        }

        
    }
}
