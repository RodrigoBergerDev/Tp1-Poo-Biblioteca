using System;
using static Tp1.Biblioteca;
using static Tp1.Lector;
using static Tp1.Libro;

namespace Tp1
{
    internal class Programa
    {
        static void Main(string[] args)
        {
            Biblioteca biblioteca = new Biblioteca();
            Console.WriteLine(" ");


            //AgregarLibros
            Console.WriteLine("Se agregan los libros a la biblioteca: ");
            Console.WriteLine(" ");
            Console.WriteLine("Se agrega el libro Cien años de soledad de Gabriel García Márquez de la editorial Sudamericana");
            biblioteca.agregarLibro("Cien años de soledad", "Gabriel García Márquez", "Sudamericana");
            Console.WriteLine(" ");
            Console.WriteLine("Se agrega el libro 1984 de George Orwell de la editorial Debolsillo");
            biblioteca.agregarLibro("1984", "George Orwell", "Debolsillo"); 
            Console.WriteLine(" ");
            Console.WriteLine("Se agrega el libro El Principito de Antoine de Saint-Exupéry de la editorial Salamandra");
            biblioteca.agregarLibro("El Principito", "Antoine de Saint-Exupéry", "Salamandra");
            Console.WriteLine(" ");
            Console.WriteLine("Se agrega el libro Don Quijote de la Mancha de Miguel de Cervantes de la editorial Penguin Clásicos");
            biblioteca.agregarLibro("Don Quijote de la Mancha", "Miguel de Cervantes", "Penguin Clásicos");
            Console.WriteLine(" ");
            Console.WriteLine("Se agrega el libro Harry Potter y la piedra filosofal de J.K. Rowling de la editorial Salamandra");
            biblioteca.agregarLibro("Harry Potter y la piedra filosofal", "J.K. Rowling", "Salamandra");
            Console.WriteLine(" ");
            Console.WriteLine("Se agrega el libro Orgullo y prejuicio de Jane Austen de la editorial Alma");
            biblioteca.agregarLibro("Orgullo y prejuicio", "Jane Austen", "Alma");
            Console.WriteLine(" ");
            Console.WriteLine("Se agrega el libro Crónica de una muerte anunciada de Gabriel García Márquez de la editorial Penguin Random Housea");
            biblioteca.agregarLibro("Crónica de una muerte anunciada", "Gabriel García Márquez", "Penguin Random House");
            Console.WriteLine(" ");
            Console.WriteLine("Se agrega el libro El señor de los anillos de J.R.R. Tolkien de la editorial Minotauro");
            biblioteca.agregarLibro("El señor de los anillos", "J.R.R. Tolkien", "Minotauro");
            Console.WriteLine(" ");
            Console.WriteLine("Se agrega el libro Rayuela de Julio Cortázarg de la editorial Alfaguar");
            biblioteca.agregarLibro("Rayuela", "Julio Cortázar", "Alfaguar");
            Console.WriteLine(" ");
            Console.WriteLine("Se agrega el libro La sombra del viento de Carlos Ruiz Zafón de la editorial Planeta");
            biblioteca.agregarLibro("La sombra del viento", "Carlos Ruiz Zafón", "Planeta");
            Console.WriteLine(" ");

            //Listar Libros
            Console.WriteLine("Lista de Libros: ");
            biblioteca.listarLibros();
            Console.WriteLine(" ");

            //Borrar un libro
            Console.WriteLine("Borrar el Libro Orgullo y prejuicio");
            biblioteca.eliminarLibro("Orgullo y prejuicio");
            Console.WriteLine(" ");
            
            //Mostrar nueva lista de libros
            Console.WriteLine("Nueva lista de Libros: ");
            biblioteca.listarLibros();


            //Agregar Lectores
            Console.WriteLine("Se agregan los lectores a la biblioteca: ");
            Console.WriteLine(" ");
            Console.WriteLine("Se agregan a Rodrigo Berger, Dni:12345 a la biblioteca");
            biblioteca.altaLector("Rodrigo Berger", 12345);
            Console.WriteLine(" ");
            Console.WriteLine("Se agregan a Gimena Escalante, Dni:12345 a la biblioteca");
            biblioteca.altaLector("Gimena Escalante", 12345); //Usuario Existente
            Console.WriteLine(" ");
            Console.WriteLine("Se agregan a Gimena Escalante, Dni:23456 a la biblioteca");
            biblioteca.altaLector("Gimena Escalante", 23456);
            Console.WriteLine(" ");
            Console.WriteLine("Se agregan a Tomas Amsler, Dni:45678 a la biblioteca");
            biblioteca.altaLector("Tomas Amsler", 45678);
            Console.WriteLine(" ");
            Console.WriteLine("Se agregan a Alejandra Vazquez, Dni:56789 a la biblioteca");
            biblioteca.altaLector("Alejandra Vazquez", 56789);
            
            
            Console.WriteLine(" ");
            Console.WriteLine("Listado de lectores que pertenecen a la biblioteca");
            biblioteca.listarLectores();
            Console.WriteLine(" ");

            //Gestionar Prestamos
            string resultado;
            Console.WriteLine("Se presta el libro Cien años de soledad al lector con dni:12345");
            resultado = biblioteca.prestarLibro("Cien años de soledad", 12345); // PRESTAMO EXITOSO
            Console.WriteLine(resultado);
            Console.WriteLine(" ");
            Console.WriteLine("Se presta el libro El señor de los anillos al lector con dni:12345");
            resultado = biblioteca.prestarLibro("El señor de los anillos", 12345); // PRESTAMO EXITOSO
            Console.WriteLine(resultado);
            Console.WriteLine(" ");
            Console.WriteLine("Se presta el libro Crónica de una muerte anunciada al lector con dni:12345");
            resultado = biblioteca.prestarLibro("Crónica de una muerte anunciada", 12345); // PRESTAMO EXITOSO
            Console.WriteLine(resultado);
            Console.WriteLine(" ");
            Console.WriteLine("Se presta el libro La sombra del viento anunciada al lector con dni:12345");
            resultado = biblioteca.prestarLibro("La sombra del viento", 12345); // TOPE DE PRESTAMO ALCANZADO
            Console.WriteLine(resultado);
            Console.WriteLine(" ");
            Console.WriteLine("Se presta el libro Cien años de soledad al lector con dni:45678");
            resultado = biblioteca.prestarLibro("Cien años de soledad", 45678); // LIBRO INEXISTENTE
            Console.WriteLine(resultado);
            Console.WriteLine(" ");
            Console.WriteLine("Se presta el libro Rayuela al lector con dni:9999");
            resultado = biblioteca.prestarLibro("Rayuela", 9999); // LECTOR INEXISTENTE
            Console.WriteLine(resultado);
            Console.WriteLine(" ");
            Console.WriteLine("FIN DEL PROGRAMA");
            Console.WriteLine(" ");
        }
    }
}
