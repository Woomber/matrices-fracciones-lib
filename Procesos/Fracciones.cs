/*
 * Fracciones.cs
 * Yael Arturo Chavoya Andalón
 * 
 * Realiza todas las operaciones relacionadas con fracciones
 */


using System;
using Matemáticas.Tipos;

namespace Matemáticas.Procesos
{
    public static class Fracciones
    {

        /// <summary>
        /// Número máximo de intentos para simplificar
        /// </summary>
        const int MAX_INTENTOS = 500;


        /// <summary>
        /// Calcula el recíproco de una fracción
        /// </summary>
        /// <param name="fracción">La fracción a usar</param>
        /// <returns>El recíproco de la fracción</returns>
        public static Fracción Recíproco(Fracción fracción)
        {
            return new Fracción(fracción.Denominador, fracción.Numerador);
        }

        /// <summary>
        /// Calcula la suma entre dos fracciones
        /// </summary>
        /// <param name="a">Sumando A</param>
        /// <param name="b">Sumando B</param>
        /// <returns>La suma de las fracciones</returns>
        public static Fracción Sumar(Fracción a, Fracción b)
        {
            return new Fracción(
                a.Numerador * b.Denominador +
                a.Denominador * b.Numerador,
                a.Denominador * b.Denominador
                );
        }

        /// <summary>
        /// Calcula la resta entre dos fracciones
        /// </summary>
        /// <param name="a">Minuendo</param>
        /// <param name="b">Sustraendo</param>
        /// <returns>La resta de las fracciones</returns>
        public static Fracción Restar(Fracción a, Fracción b)
        {
            return new Fracción(
                a.Numerador * b.Denominador -
                a.Denominador * b.Numerador,
                a.Denominador * b.Denominador
                );
        }

        /// Calcula el producto entre dos fracciones
        /// </summary>
        /// <param name="a">Factor A</param>
        /// <param name="b">Factor B</param>
        /// <returns>El producto de las fracciones</returns>
        public static Fracción Multiplicar(Fracción a, Fracción b)
        {
            return new Fracción(
                a.Numerador * b.Numerador,
                a.Denominador * b.Denominador
                );
        }

        /// Calcula el cociente entre dos fracciones
        /// </summary>
        /// <param name="a">Dividendo</param>
        /// <param name="b">Divisor</param>
        /// <returns>El cociente de las fracciones</returns>
        public static Fracción Dividir(Fracción a, Fracción b)
        {
            if (b.Numerador == 0) throw new DivideByZeroException();
            return new Fracción(
                a.Numerador * b.Denominador,
                a.Denominador * b.Numerador
                );
        }

       
    }
}
