/*
 * Excepciones.cs
 * Yael Arturo Chavoya Andalón
 * 
 * Define una excepción que se da cuando el tamaño de una matriz no es el correcto para
 * realizar una operación
 */

using System;

namespace Matemáticas.Tipos
{

    /// <summary>
    /// El tamaño de la matriz no es correcto para realizar la operación.
    /// </summary>
    public class IncorrectSizedMatrixException : Exception
    {
        public IncorrectSizedMatrixException()
        {
        }

        public IncorrectSizedMatrixException(string message)
            : base(String.Format("Tamaño incorrecto para la matriz. {0}", message))
        {
        }
    }
}
