using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using ClasesInstanciables;
using Excepciones;

namespace Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            //Persona personita = new Persona("asdasdadsasd", "Perez", "888888f" ,Persona.ENacionalidad.Argentino);

            //Universitario u1 = new Universitario(5, "Juan", "Perez", "45", Persona.ENacionalidad.Argentino);
            //Universitario u2 = new Universitario(6, "Juan", "Perez", "45", Persona.ENacionalidad.Argentino);

            //if (u1 == u2)
            //    Console.WriteLine("EQUIS DEE");

            //Profesor pr = new Profesor(8, "Juan", "Perez", "48", Persona.ENacionalidad.Argentino);

            //Console.WriteLine(pr);
            //Console.ReadLine();

            //if (pr == Universidad.EClases.Programacion)
            //    Console.WriteLine("SIIIIIII");
            //else
            //    Console.WriteLine("El profesor no da esta clase");

            //Jornada j = new Jornada(Universidad.EClases.Laboratorio, pr);
            //Jornada j1 = new Jornada(Universidad.EClases.Legislacion, pr);

            //Alumno al = new Alumno(4, "Pedrito", "Jocesito", "4888", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,Alumno.EEstadoCuenta.Becado);
            //Alumno al1 = new Alumno(6, "Lele", "Lulu", "90000001", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio, Alumno.EEstadoCuenta.AlDia);

            //j += al;
            //j += al1;

            //Console.WriteLine(j);

            //Jornada.Guardar(j);

            //Console.WriteLine(j[0]);
            //Console.WriteLine(j[1]);

            //Console.ReadLine();

            Universidad gim = new Universidad();
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
           Alumno.EEstadoCuenta.Becado);
            gim += a1;
            try
            {
                Alumno a2 = new Alumno(2, "Juana", "Martinez", "12234458",
               EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
               Alumno.EEstadoCuenta.Deudor);
                gim += a2;
            }
            catch (NacionalidadInvalidaException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                Alumno a3 = new Alumno(3, "José", "Gutierrez", "12234456",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);
                gim += a3;
            }
            catch (AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);
            }
            Alumno a4 = new Alumno(4, "Miguel", "Hernandez", "92264456",
           EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Legislacion,
           Alumno.EEstadoCuenta.AlDia);
            gim += a4;
            Alumno a5 = new Alumno(5, "Carlos", "Gonzalez", "12236456",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
           Alumno.EEstadoCuenta.AlDia);
            gim += a5;
            Alumno a6 = new Alumno(6, "Juan", "Perez", "12234656",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio,
           Alumno.EEstadoCuenta.Deudor);
            gim += a6;
            Alumno a7 = new Alumno(7, "Joaquin", "Suarez", "91122456",
           EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio,
           Alumno.EEstadoCuenta.AlDia);
            gim += a7;
            Alumno a8 = new Alumno(8, "Rodrigo", "Smith", "22236456",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Legislacion,
           Alumno.EEstadoCuenta.AlDia);
            gim += a8;
            Profesor i1 = new Profesor(1, "Juan", "Lopez", "12234456",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            gim += i1;
            Profesor i2 = new Profesor(2, "Roberto", "Juarez", "32234456",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            gim += i2;
            try
            {
                gim += Universidad.EClases.Programacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Universidad.EClases.Laboratorio;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Universidad.EClases.Legislacion;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                gim += Universidad.EClases.SPD;
            }
            catch (SinProfesorException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine(gim.ToString());
            Console.ReadKey();
            Console.Clear();
            try
            {
                Universidad.Guardar(gim);
                Console.WriteLine("Archivo de Universidad guardado.");
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            try
            {
                int jornada = 0;
                Jornada.Guardar(gim[jornada]);
                Console.WriteLine("Archivo de Jornada {0} guardado.", jornada);
                //Console.WriteLine(Jornada.Leer());
            }
            catch (ArchivosException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadKey();
        }
    }
}
