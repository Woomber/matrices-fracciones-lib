/*
 * MatrizRotación.cs
 * Yael Arturo Chavoya Andalón
 * 
 * Define una matriz de rotación
 */

using System;

namespace Matemáticas.Tipos.Transformaciones
{
    /// <summary>
    /// Define la rotación de la transformación
    /// </summary>
    public class MatrizRotación : MatrizIdentidad<double>
    {
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Constructores
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        /// <summary>
        /// Crea un nuevo objeto de tipo MatrizRotación
        /// </summary>
        /// <param name="tipo">Tipo de rotación (X, Y, Z)</param>
        /// <param name="beta">Ángulo de rotación en radianes</param>
        public MatrizRotación(Ejes tipo, double beta) : base(4)
        {
            if(tipo == Ejes.X)
            {
                this[1, 1] = Math.Cos(beta);
                this[1, 2] = -Math.Sin(beta);
                this[2, 1] = Math.Sin(beta);
                this[2, 2] = Math.Cos(beta);
            }
            else if(tipo == Ejes.Y)
            {
                this[0, 0] = Math.Cos(beta);
                this[0, 2] = Math.Sin(beta);
                this[2, 0] = -Math.Sin(beta);
                this[2, 2] = Math.Cos(beta);
            }
            else if(tipo == Ejes.Z)
            {
                this[0, 0] = Math.Cos(beta);
                this[0, 1] = -Math.Sin(beta);
                this[1, 0] = Math.Sin(beta);
                this[1, 1] = Math.Cos(beta);
            }
            else
            {
                throw new ArgumentException();
            }

        }
    }
}