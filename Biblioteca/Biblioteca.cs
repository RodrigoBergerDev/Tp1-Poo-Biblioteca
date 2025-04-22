using System;
using System.Collections.Generic;
using System.Text;
using static Tp1.Lector;
using static Tp1.Libro;


namespace Tp1
{
    public class Biblioteca
    {
        private List<Libro> libros;
        private List<Lector> lectores;

        public Biblioteca()
        {
            this.libros = new List<Libro>();
            this.lectores = new List<Lector>();
        }

        private Libro buscarLibro(string titulo)
        {
            Libro libroBuscado = null;
            int i = 0;
            while (i < libros.Count && !libros[i].getTitulo().Equals(titulo)) i++;
            if (i != libros.Count)
                libroBuscado = libros[i];
            return libroBuscado;
        }

        private Lector buscarLector(int dni)
        {
            Lector lectorBuscado = null;
            int i = 0;
            while (i < lectores.Count && !lectores[i].getDni().Equals(dni)) i++;
            if (i != lectores.Count)
                lectorBuscado = lectores[i];
            return lectorBuscado;
        }

        public bool altaLector(string nombre, int dni)
        {
            if (buscarLector(dni) != null)
            {
                Console.WriteLine("Este Lector ya existe");
                return false; // Lector ya existe
            }

            Lector nuevoLector = new Lector(nombre, dni);
            lectores.Add(nuevoLector);
            return true;
        }

        public string prestarLibro(string tituloLibro, int dniLector)
        {
            Libro libro = buscarLibro(tituloLibro);
            if (libro == null)
            {
                return "LIBRO INEXISTENTE";
            }

            Lector lector = buscarLector(dniLector);
            if (lector == null)
            {
                return "LECTOR INEXISTENTE";
            }

            if (!lector.tieneCupoDisponible())
            {
                return "TOPE DE PRESTAMO ALCANZADO";
            }

            // Realizar el préstamo
            libros.Remove(libro);
            lector.agregarPrestamo(libro);

            return "PRESTAMO EXITOSO";
        }

        public bool agregarLibro(string titulo, string autor, string editorial)
        {
            bool resultado = false;
            Libro libro = buscarLibro(titulo);
            if (libro == null)
            {
                libro = new Libro(titulo, autor, editorial);
                libros.Add(libro);
                resultado = true;
                Console.WriteLine("Libro agregado correctamente");
            }
            return resultado;
        }

        public void listarLibros()
        {
            foreach (var libro in libros)
                Console.WriteLine(libro);
        }

        public void listarLectores()
        {
            foreach (var lector in lectores)
                Console.WriteLine(lector);
        }

        public bool eliminarLibro(string titulo)
        {
            bool resultado = false;
            Libro libro = buscarLibro(titulo);
            if (libro != null)
            {
                libros.Remove(libro);
                resultado = true;
            }
            return resultado;
        }

        //DEVOLVER LIBRO
    }
}
