using System;
using System.Collections.Generic;
using System.Text;
using static Tp1.Biblioteca;
using static Tp1.Libro;

namespace Tp1
{
    public class Lector
    {
        private string nombre;
        private int dni;
        private List<Libro> librosPrestados;

        public Lector(string nombre, int dni)
        {
            this.nombre = nombre;
            this.dni = dni;
            this.librosPrestados = new List<Libro>();
        }

        public int getDni()
        {
            return dni;
        }

        public string getNombre()

        {
            return nombre;
        }

        public override string ToString()
        {
            return $"Nombre y apellido: {nombre} DNI: {dni}";
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
