using Persistencia;
using Entidades;
using System.Collections;

namespace Logica
{
    public static class LogicaEmpleados
    {

        public static void AltaEmpleado(int cedula, string nombre, double sueldoBase)
        {

            Empleado altaEmpleado = new Empleado(cedula, nombre, sueldoBase);
            PersistenciaEmpleado.Empleados.Add(altaEmpleado);

        }

        public static void AltaJornalero(int cedula, string nombre, double sueldoBase, string especialidad, int horasExtra)
        {
            Jornalero altaJornalero = new Jornalero(especialidad, horasExtra, cedula, nombre, sueldoBase);
            PersistenciaEmpleado.Empleados.Add(altaJornalero);
        }


        public static void BajaEmpleados(int cedula)
        {
            for (int i = 0; i < PersistenciaEmpleado.Empleados.Count; i++)
            {
                if ((PersistenciaEmpleado.Empleados[i] as Empleado).Cedula.Equals(cedula))
                {
                    PersistenciaEmpleado.Empleados.Remove(PersistenciaEmpleado.Empleados[i]);
                }
            }
        }

        public static ArrayList DevolverEmpleados()
        {
            return PersistenciaEmpleado.Empleados;
        }

        public static void ActualizarEmpleado(int cedula, string nombre, double sueldoBase)
        {
            for (int i = 0; i < PersistenciaEmpleado.Empleados.Count; i++)
            {

                if ((PersistenciaEmpleado.Empleados[i] as Empleado).Cedula.Equals(cedula))
                {
                    Empleado empleado = PersistenciaEmpleado.Empleados[i] as Empleado;

                    empleado.Nombre = nombre;
                    empleado.SueldoBase = sueldoBase;

                }

            }
        }

        public static void ActualizarJornalero(int cedula, string nombre, double sueldoBase, string especialidad, int horasExtra)
        {
            for (int i = 0; i < PersistenciaEmpleado.Empleados.Count; i++)
            {

                if ((PersistenciaEmpleado.Empleados[i] as Jornalero).Cedula.Equals(cedula))
                {
                    Jornalero jornalero = PersistenciaEmpleado.Empleados[i] as Jornalero;

                    jornalero.Nombre = nombre;
                    jornalero.SueldoBase = sueldoBase;
                    jornalero.Especialidad = especialidad;
                    jornalero.HorasExtras = horasExtra;

                }

            }
        }







    }
}
