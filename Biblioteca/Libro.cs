using System;
using System.Collections.Generic;
using System.Text;
using static Tp1.Biblioteca;
using static Tp1.Lector;

namespace Tp1
{
    public class Libro
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
            return $"Titulo: {titulo} / Autor: {autor} / Editorial: {editorial}";
        }

    }
}
