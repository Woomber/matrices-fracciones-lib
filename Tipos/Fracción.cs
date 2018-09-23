/*
 * Fracción.cs
 * Yael Arturo Chavoya Andalón
 * 
 * Define una clase de Fracciones
 */

using System;
using Matemáticas.Procesos;

namespace Matemáticas.Tipos
{
    public class Fracción
    {

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Propiedades
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        public decimal Numerador { set; get; }
        public decimal Denominador { set; get; }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Constructores
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        public Fracción()
        {
            Set(0, 1);
        }
        public Fracción(decimal numerador)
        {
            Set(numerador, 1);
        }
        public Fracción(decimal numerador, decimal denominador)
        {
            Set(numerador, denominador);
        }

        public Fracción(Fracción copia)
        {
            Set(copia.Numerador, copia.Denominador);
        }


        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Métodos Set Get
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        /// <summary>
        /// Coloca los valores de numerador y denominador en la fracción
        /// </summary>
        /// <param name="numerador">El numerador</param>
        /// <param name="denominador">El denominador</param>
        public void Set(decimal numerador, decimal denominador)
        {
            if (denominador == 0) throw new DivideByZeroException();
            this.Numerador = Math.Floor(numerador);
            this.Denominador = Math.Floor(denominador);
            Simplificar();
        }


        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Métodos Miembro
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        /// <summary>
        /// Simplifica una fracción en su más mínima expresión
        /// </summary>
        public void Simplificar()
        {
            if (Denominador < 0)
            {
                Numerador *= -1;
                Denominador *= -1;
            }
            decimal mcd = MCD(Numerador, Denominador);
            Numerador /= mcd;
            Denominador /= mcd;
        }

        /// <summary>
        /// Calcula el máximo común divisor de dos números
        /// </summary>
        /// <param name="a">Número a</param>
        /// <param name="b">Número b</param>
        /// <returns>El MCD de los números</returns>
        decimal MCD(decimal a, decimal b)
        {
            while (a != 0 && b != 0)
            {
                if (Math.Abs(a) > Math.Abs(b)) a %= b;
                else b %= a;
            }
            return a == 0 ? b : a;
        }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Sobrecarga de operadores
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        public static Fracción operator +(Fracción a, Fracción b)
        {
            return Fracciones.Sumar(a, b);
        }

        public static Fracción operator -(Fracción a, Fracción b)
        {
            return Fracciones.Restar(a, b);
        }
        public static Fracción operator *(Fracción a, Fracción b)
        {
            return Fracciones.Multiplicar(a, b);
        }

        public static Fracción operator /(Fracción a, Fracción b)
        {
            return Fracciones.Dividir(a, b);
        }


        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Conversión de tipos
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =

        public static implicit operator Fracción(decimal b)
        {
            return new Fracción(b);
        }

        public static explicit operator double(Fracción a)
        {
            return a.ToDouble();
        }

        /// <summary>
        /// Convierte una fracción en su equivalente en punto flotante
        /// </summary>
        /// <returns>El valor de la fracción en punto flotante</returns>
        public double ToDouble()
        {
            return Convert.ToDouble(this.Numerador) / Convert.ToDouble(this.Denominador);
        }

        public override string ToString()
        {
            if (Numerador % Denominador == 0) return (Numerador / Denominador).ToString();
            return String.Format("{0}/{1}", Numerador, Denominador);
        }
    } //class
} //namespace
