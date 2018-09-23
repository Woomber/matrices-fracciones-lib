using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matemáticas.Tipos
{
    public class Fracción
    {
        public int Numerador { set; get; }
        public int Denominador { set; get; }

        const int precisión = 6;

        public Fracción()
        {
            Set(0, 1);
        }
        public Fracción(int numerador)
        {
            Set(numerador, 1);
        }
        public Fracción(int numerador, int denominador)
        {
            Set(numerador, denominador);
        }

        public Fracción(Fracción copia)
        {
            Set(copia.Numerador, copia.Denominador);
        }

        //Establece el valor del numerador y el denominador de la fracción
        public void Set(int numerador, int denominador)
        {
            if (denominador == 0) throw new DivideByZeroException();
            this.Numerador = numerador;
            this.Denominador = denominador;
            this.Simplificar();
        }

        //Simplifica una fracción en su mínima expresión
        void Simplificar()
        {
            if (Denominador < 0)
            {
                Numerador *= -1;
                Denominador *= -1;
            }

            int menor = (Math.Abs(this.Numerador) < Math.Abs(this.Denominador)) ?
                this.Numerador : this.Denominador;
            for (int i = 2; i*i <= Math.Abs(menor); i++)
            {
                if ((this.Numerador % i == 0) && (this.Denominador % i == 0))
                {
                    this.Set(this.Numerador / i, this.Denominador / i);
                    i--;
                }
            }//for
        }

        //Devuelve el recíproco de una fracción
        public Fracción Recíproco()
        {
            return new Fracción(this.Denominador, this.Numerador);
        }

        public static Fracción operator +(Fracción a, Fracción b)
        {
            return new Fracción(
                a.Numerador * b.Denominador +
                a.Denominador * b.Numerador,
                a.Denominador * b.Denominador
                );
        }

        public static Fracción operator -(Fracción a, Fracción b)
        {
            return new Fracción(
                a.Numerador * b.Denominador -
                a.Denominador * b.Numerador,
                a.Denominador * b.Denominador
                );
        }
        public static Fracción operator *(Fracción a, Fracción b)
        {
            return new Fracción(
                a.Numerador * b.Numerador,
                a.Denominador * b.Denominador
                );
        }
        public static Fracción operator *(Fracción a, int b)
        {
            return new Fracción(
                a.Numerador * b,
                a.Denominador
                );
        }
        public static Fracción operator *(int b, Fracción a)
        {
            return new Fracción(
                a.Numerador * b,
                a.Denominador
                );
        }
        public static Fracción operator /(Fracción a, Fracción b)
        {
            if (b.Numerador == 0) throw new DivideByZeroException();
            return new Fracción(
                a.Numerador * b.Denominador,
                a.Denominador * b.Numerador
                );
        }

        public static Fracción operator /(int a, Fracción b)
        {
            if (b.Numerador == 0) throw new DivideByZeroException();
            return new Fracción(
                a * b.Denominador,
                b.Numerador
                );
        }

        public static implicit operator Fracción(int b)
        {
            return new Fracción(b);
        }

        public static implicit operator double(Fracción a)
        {
            return a.ToDouble();  
        }

        public static implicit operator Fracción(double a)
        {
            Fracción resultado = new Fracción(Convert.ToInt32(Math.Truncate(a)));
            a = a - ((a > 0) ? 1 : -1) * Math.Truncate(a);
            int ceros = 0;
            while(ceros++ < precisión)
            {
                a *= 10;
                if (!(Math.Abs(a) < 1))
                {
                    resultado += new Fracción(
                    Convert.ToInt32(Math.Truncate(a)),
                    Convert.ToInt32(Math.Pow(10, ceros))
                    );
                }
                a = a - ((a > 0) ? 1 : -1) * Math.Truncate(a);
            }
            return resultado;
        }

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
