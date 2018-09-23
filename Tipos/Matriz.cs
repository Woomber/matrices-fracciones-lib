/*
 * Matriz.cs
 * Yael Arturo Chavoya Andalón
 * 
 * Define una clase de Matrices
 */

using System;
using Matemáticas.Procesos;

namespace Matemáticas.Tipos
{
    public class Matriz<T> where T : new()
    {

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Propiedades
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        public T[,] Datos { set; get; }
        public int X { get; }
        public int Y { get; }


        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Constantes
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        public const int minSize = 1;
        public const int maxSize = int.MaxValue;


        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Constructores
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        public Matriz(int x, int y)
        {
            if (x < minSize ||
                x > maxSize ||
                y < minSize ||
                y > maxSize) throw new ArgumentOutOfRangeException();
            X = x;
            Y = y;
            Datos = new T[X, Y];

        }
        public Matriz(Matriz<T> copiap)
        {
            dynamic copia = copiap;
            X = copia.X;
            Y = copia.Y;
            Datos = new T[X, Y];
            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    Datos[i, j] = copia[i, j];
                }//for j

            }//for i

        }

        public Matriz(T[,] arreglo, int dimX)
        {
            Datos = arreglo;
            X = dimX;
            Y = Datos.Length / X;
        }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Métodos Set Get
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        /// <summary>
        /// Coloca los datos de un arreglo unidimensional a la matriz.
        /// </summary>
        /// <param name="datos">El arreglo de datos a insertar</param>
        /// <returns>Verdadero si el arreglo fue insertado correctamente.</returns>
        public bool Set(T[] datos)
        {
            int currDato = 0;

            if (datos.Length != X * Y) return false;

            for (int i = 0; i < X; i++)
            {
                for (int j = 0; j < Y; j++)
                {
                    this[i, j] = datos[currDato++];
                }//for j
            }//for i

            return true;
        }

        /// <summary>
        /// Obtiene el determinante de la matriz
        /// </summary>
        /// <returns>El determinante de la matriz</returns>
        public T GetDeterminante()
        {
            return Matrices<T>.GetDeterminante(this);
        }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        // Sobrecarga de operadores
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        public T this[int x, int y]
        {
            get
            {
                return Datos[x, y];
            }
            set
            {
                Datos[x, y] = value;
            }
        }

        public static Matriz<T> operator +(Matriz<T> a, Matriz<T> b)
        {
            return Matrices<T>.Sumar(a, b);
        }

        public static Matriz<T> operator -(Matriz<T> a, Matriz<T> b)
        {
            return Matrices<T>.Restar(a, b);
        }

        public static Matriz<T> operator *(Matriz<T> a, Matriz<T> b)
        {
            return Matrices<T>.Multiplicar(a, b);
        }

        public static Matriz<T> operator /(Matriz<T> a, Matriz<T> b)
        {
            return Matrices<T>.Dividir(a, b);
        }


        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Conversión de tipos
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        public override string ToString()
        {
            string cadena = "";
            for (int i = 0; i < X; i++)
            {
                cadena += "| \t";
                for (int j = 0; j < Y; j++)
                {
                    cadena += this[i, j] + " \t";
                }
                cadena += " |\n";
            }
            return cadena;
        }

    }//class

}//namespace
