/*
 * MatrizProporción.cs
 * Yael Arturo Chavoya Andalón
 * 
 * Define una matriz de proporción
 */

namespace Matemáticas.Tipos.Transformaciones
{
    /// <summary>
    /// Define la proporción de la transformación
    /// </summary>
    public class MatrizProporción : MatrizIdentidad<double>
    {
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Constructores
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        public MatrizProporción(double x) : base(4)
        {
            for (int i = 0; i < 3; i++)
                this[i, i] = x;
        }
    }



}
