/*
 * Matrices.cs
 * Yael Arturo Chavoya Andalón
 * 
 * Realiza todas las operaciones relacionadas con matrices
 */

using System;
using Matemáticas.Tipos;

namespace Matemáticas.Procesos
{
    public static class Matrices<T> where T: new()
    {
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Relacionadas con operaciones aritméticas
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        /// <summary>
        /// Suma dos matrices de tamaño igual
        /// </summary>
        /// <param name="a">Sumando A</param>
        /// <param name="b">Sumando B</param>
        /// <returns>La suma de las matrices</returns>
        public static Matriz<T> Sumar(Matriz<T> a, Matriz<T> b)
        {
            dynamic dynA = a;
            if (dynA.X != b.X || dynA.Y != b.Y) throw new IncorrectSizedMatrixException();
            Matriz<T> resultado = new Matriz<T>(dynA.X, dynA.Y);
            for (int i = 0; i < dynA.X; i++)
                for (int j = 0; j < dynA.Y; j++)
                    resultado[i, j] = dynA[i, j] + b[i, j];
            return resultado;
        }

        /// <summary>
        /// Resta dos matrices de tamaño igual
        /// </summary>
        /// <param name="a">Minuendo</param>
        /// <param name="b">Sustraendo</param>
        /// <returns>La resta de las matrices</returns>
        public static Matriz<T> Restar(Matriz<T> a, Matriz<T> b)
        {
            dynamic dynA = a;
            if (dynA.X != b.X || dynA.Y != b.Y) throw new IncorrectSizedMatrixException();
            Matriz<T> resultado = new Matriz<T>(dynA.X, dynA.Y);
            for (int i = 0; i < dynA.X; i++)
                for (int j = 0; j < dynA.Y; j++)
                    resultado[i, j] = dynA[i, j] - b[i, j];
            return resultado;
        }

        /// <summary>
        /// Multiplica dos matrices con tamaño correcto
        /// </summary>
        /// <param name="a">Factor A</param>
        /// <param name="b">Factor B</param>
        /// <returns>El producto de las matrices</returns>
        public static Matriz<T> Multiplicar(Matriz<T> a, Matriz<T> b)
        {
            dynamic dynA = a;
            if (dynA.Y != b.X) throw new IncorrectSizedMatrixException();
            Matriz<T> resultado = new Matriz<T>(dynA.X, b.Y);
            for (int i = 0; i < dynA.X; i++)
            {
                for (int j = 0; j < b.Y; j++)
                {
                    resultado[i, j] = new T();
                    for (int k = 0; k < dynA.Y; k++)
                    {
                        resultado[i, j] += dynA[i, k] * b[k, j];
                    }//k
                }//j
            }//i

            return resultado;
        }

        /// <summary>
        /// Divide dos matrices con tamaño correcto
        /// </summary>
        /// <param name="a">Dividendo</param>
        /// <param name="b">Divisor</param>
        /// <returns>El cociente de las matrices</returns>
        public static Matriz<T> Dividir(Matriz<T> a, Matriz<T> b)
        {
            return new Matriz<T>(Invertir(b) * a);
        }

        /// <summary>
        /// Calcula la matriz invertida de una matriz
        /// </summary>
        /// <param name="matriz"></param>
        /// <returns>La matriz invertida</returns>
        public static Matriz<T> Invertir(Matriz<T> matriz)
        {
            if (matriz.X != matriz.Y) throw new IncorrectSizedMatrixException();
            dynamic resultado = new Matriz<T>(matriz);
            dynamic identidad = new MatrizIdentidad<T>(matriz.X);
            dynamic auxiliar;
            for (int i = 0; i < matriz.X; i++)
            {
                auxiliar = 1 / resultado[i, i];
                for (int j = 0; j < matriz.X; j++)
                {
                    resultado[i, j] *= auxiliar;
                    identidad[i, j] *= auxiliar;
                }
                for (int j = 0; j < matriz.X; j++)
                {
                    auxiliar = new T();
                    auxiliar = resultado[j, i];
                    if (j == i) continue;
                    for (int k = 0; k < matriz.X; k++)
                    {
                        resultado[j, k] -= resultado[i, k] * auxiliar;
                        identidad[j, k] -= identidad[i, k] * auxiliar;
                    }//for k
                }//for j
            }//for i

            return identidad;
        }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Relacionadas con determinante
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        /// <summary>
        /// Obtiene el determinante de una matriz cuadrada
        /// </summary>
        /// <param name="matrizX">Matriz cuadrada</param>
        /// <returns>El determinante de la matriz</returns>
        public static T GetDeterminante(Matriz<T> matrizX)
        {
            if (matrizX.X != matrizX.Y) throw new IncorrectSizedMatrixException();

            dynamic matriz = matrizX;
            dynamic solución = new T();

            if (matriz.X == 2)
                return matriz[0, 0] * matriz[1, 1] - matriz[1, 0] * matriz[0, 1];

            for (int i = 0; i < matriz.X; i++)
            {
                solución += ((i % 2 == 0) ? 1 : -1) * matriz.CruceEn(i) * GetDeterminante(matriz.CortarEn(i));
            }

            return solución;
        }

        /// <summary>
        /// Obtiene una matriz de tamaño (n-1)*(n-1) con todos los elementos
        /// menos la primera fila y la columna con índice index de una matriz cuadrada
        /// </summary>
        /// <param name="matriz">La matriz a cortar</param>
        /// <param name="index">El índice de la columna a eliminar</param>
        /// <returns>La matriz recortada</returns>
        public static Matriz<T> CortarEn(Matriz<T> matriz, int index)
        {
            Matriz<T> nueva = new Matriz<T>(matriz.X - 1, matriz.X - 1);
            int currIndex = 0;
            T[] datos = new T[(matriz.X - 1) * (matriz.X - 1)];

            if (index >= matriz.X || index < 0) throw new ArgumentOutOfRangeException();


            for (int i = 1; i < matriz.X; i++)
            {
                for (int j = 0; j < matriz.X; j++)
                {
                    if (j == index) continue;
                    datos[currIndex++] = matriz[i, j];
                }
            }
            nueva.Set(datos);
            return nueva;
        }

        /// <summary>
        /// Obtiene el elemento en [0, index] de una matriz cuadrada
        /// </summary>
        /// <param name="matriz">La matriz</param>
        /// <param name="index">El índice a buscar</param>
        /// <returns>El elemento en la posición</returns>
        public static T CruceEn(Matriz <T> matriz, int index)
        {
            return matriz[0, index];
        }
    }
}
