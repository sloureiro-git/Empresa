namespace Entidades
{
    // hola
    public class Jornalero : Empleado
    {
        public string Especialidad { get; set; }
        public int HorasExtras { get; set; }

        public Jornalero(string especialidad, int horasExtra, int cedula, string nombre, double sueldoBase) : base(cedula, nombre, sueldoBase)
        {
            Especialidad = especialidad;
            HorasExtras = horasExtra;

        }

        public override double SueldoLiquido()
        {

            double SueldoLiquido = base.SueldoLiquido();

            SueldoLiquido += HorasExtras * 250;

            return SueldoLiquido;
        }

    }




}