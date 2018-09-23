/*
 * Punto.cs
 * Yael Arturo Chavoya Andalón
 * 
 * Define una clase de Puntos
 */

using System;

namespace Matemáticas.Tipos.Transformaciones
{
    /// <summary>
    /// Define un punto bidimensional en el espacio
    /// </summary>
    public class Punto
    {
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Propiedades
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        public int X { set; get; }
        public int Y { set; get; }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Constructores
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        public Punto()
        {
            X = 0;
            Y = 0;
        }

        public Punto(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Construye un punto bidimensional a partir de una matriz de traslación tridimensional y un ángulo
        /// </summary>
        /// <param name="matriz">Matriz de traslación con X, Y, Z</param>
        /// <param name="ángulo">Ángulo de proyección en grados</param>
        public Punto(MatrizTraslación matriz, double ángulo)
        {
            X = (int)(matriz.CoordX - matriz.CoordZ * Math.Cos(ángulo * Math.PI / 180));
            Y = (int)(matriz.CoordY - matriz.CoordZ * Math.Sin(ángulo * Math.PI / 180));
        }
    }
}
