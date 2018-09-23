/*
 * MatrizIdentidad.cs
 * Yael Arturo Chavoya Andalón
 * 
 * Define una clase de Matriz de Identidad
 */

namespace Matemáticas.Tipos
{
    /// <summary>
    /// Matriz de identidad. Matriz cuadrada donde todos los elementos son 0 excepto
    /// la diagonal que va desde [0, 0] hasta [n, n], que es 1.
    /// </summary>
    /// <typeparam name="T">Elemento con el que se llena la matriz. Debe aceptar los valores 1 y 0</typeparam>
    public class MatrizIdentidad<T> : Matriz<T> where T : new()
    {
        public MatrizIdentidad(int x) : base(x, x)
        {
            for (int i = 0; i < x; i++)
                for (int j = 0; j < x; j++)
                {
                    dynamic valor = (i == j) ? 1 : 0;
                    this[i, j] = valor;
                }

        }

    }//class
}
