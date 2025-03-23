using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Entidades
{
    public class Empleado
    {
        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public double SueldoBase { get; set; }

        public Empleado(int cedula, string nombre, double sueldoBase)
        {
            Cedula = cedula;
            Nombre = nombre;
            SueldoBase = sueldoBase;
        }

        public virtual double SueldoLiquido()
        {

            double SueldoLiquido = SueldoBase * 0.74;

            return SueldoLiquido;
        }

        public string Display
        {
            get { return Cedula + ", " + Nombre; }
        }
    }
}
