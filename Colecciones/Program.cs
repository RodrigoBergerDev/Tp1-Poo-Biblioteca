using System;
using System.Collections.Generic;

namespace Colecciones
{
    internal class Test
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            cargarLibros(10);
            cargarLibros(2);
            biblioteca.listarLibros();
            biblioteca.eliminarLibro("Libro5");
            biblioteca.listarLibros();

            // Test nuevos métodos
            biblioteca.altaLector("Juan Perez", "12345678");
            biblioteca.altaLector("Maria Garcia", "87654321");

            string resultado;
            resultado = biblioteca.prestarLibro("Libro1", "12345678"); // PRESTAMO EXITOSO
            Console.WriteLine(resultado);
            resultado = biblioteca.prestarLibro("Libro2", "12345678"); // PRESTAMO EXITOSO
            Console.WriteLine(resultado);
            resultado = biblioteca.prestarLibro("Libro3", "12345678"); // PRESTAMO EXITOSO
            Console.WriteLine(resultado);
            resultado = biblioteca.prestarLibro("Libro4", "12345678"); // TOPE DE PRESTAMO ALCANZADO
            Console.WriteLine(resultado);
            resultado = biblioteca.prestarLibro("Libro99", "12345678"); // LIBRO INEXISTENTE
            Console.WriteLine(resultado);
            resultado = biblioteca.prestarLibro("Libro1", "99999999"); // LECTOR INEXISTENTE
            Console.WriteLine(resultado);

            void cargarLibros(int cantidad)
            {
                bool pude = true;
                for (int i = 1; i <= cantidad; i++)
                {
                    pude = biblioteca.agregarLibro("Libro" + i, "Autor" + i, "Editorial" + i);
                    if (pude)
                        Console.WriteLine("libro" + i + "agregado correctamente.");
                    else Console.WriteLine("libro" + i + " Ya existe en la biblioteca");
                }
            }
        }
    }

    internal class Biblioteca
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

        private Lector buscarLector(string dni)
        {
            Lector lectorBuscado = null;
            int i = 0;
            while (i < lectores.Count && !lectores[i].getDni().Equals(dni)) i++;
            if (i != lectores.Count)
                lectorBuscado = lectores[i];
            return lectorBuscado;
        }

        public bool altaLector(string nombre, string dni)
        {
            if (buscarLector(dni) != null)
            {
                return false; // Lector ya existe
            }

            Lector nuevoLector = new Lector(nombre, dni);
            lectores.Add(nuevoLector);
            return true;
        }

        public string prestarLibro(string tituloLibro, string dniLector)
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
            }
            return resultado;
        }

        public void listarLibros()
        {
            foreach (var libro in libros)
                Console.WriteLine(libro);
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

        internal class Libro
        {
            private string titulo;
            private string autor;
            private string editorial;

            public Libro(string titulo, string autor, string editorial)
            {
                this.titulo = titulo;
                this.autor = autor;
                this.editorial = editorial;
            }

            public string getTitulo()
            {
                return titulo;
            }

            public override string ToString()
            {
                return $"Titulo: {titulo} Autor: {autor} Editorial: {editorial}";
            }
        }

        internal class Lector
        {
            private string nombre;
            private string dni;
            private List<Libro> librosPrestados;

            public Lector(string nombre, string dni)
            {
                this.nombre = nombre;
                this.dni = dni;
                this.librosPrestados = new List<Libro>();
            }

            public string getDni()
            {
                return dni;
            }

            public bool tieneCupoDisponible()
            {
                return librosPrestados.Count < 3;
            }

            public bool agregarPrestamo(Libro libro)
            {
                if (!tieneCupoDisponible())
                {
                    return false;
                }

                librosPrestados.Add(libro);
                return true;
            }
        }
    }
}
