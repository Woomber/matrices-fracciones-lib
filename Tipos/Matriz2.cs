using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matemáticas.Tipos
{
    public class Matriz<T> where T: new()
    {
        public T[,] Datos { set; get; }
        public int X { get; }
        public int Y { get; }
        public const int minSize = 1;
        public const int maxSize = int.MaxValue;

        public Matriz(int x, int y)
        {
            if (x < minSize ||
                x > maxSize ||
                y < minSize ||
                y > maxSize) throw new ArgumentOutOfRangeException();
            this.X = x;
            this.Y = y;
            Datos = new T[this.X, this.Y];

        }
        public Matriz(Matriz<T> copia)
        {
            this.X = copia.X;
            this.Y = copia.Y;
            Datos = new T[this.X, this.Y];
            for (int i = 0; i < this.X; i++)
                for (int j = 0; j < this.X; j++)
                    Datos[i, j] = copia.Datos[i, j];
        }

        public Matriz(T[,] arreglo, int dimX)
        {
            Datos = arreglo;
            this.X = dimX;
            this.Y = Datos.Length / this.X;
        }

        public void Llenar(T[] datos)
        {
            int currDato = 0;

            if (datos.Length != this.X * this.Y) throw new ArgumentOutOfRangeException();

            for (int i = 0; i < this.X; i++)
                for (int j = 0; j < this.Y; j++)
                    this.Datos[i, j] = datos[currDato++];

        }

        public static Matriz<T> operator +(Matriz<T> ax, Matriz<T> b)
        {
            dynamic a = ax;
            if (a.X != b.X || a.Y != b.Y) throw new Exception();
            Matriz<T> resultado = new Matriz<T>(a.X, a.Y);
            for (int i = 0; i < a.X; i++)
                for (int j = 0; j < a.Y; j++)
                    resultado.Datos[i, j] = a.Datos[i, j] + b.Datos[i, j];
            return resultado;
        }

        public static Matriz<T> operator -(Matriz<T> ax, Matriz<T> b)
        {
            dynamic a = ax;
            if (a.X != b.X || a.Y != b.Y) throw new Exception();
            Matriz<T> resultado = new Matriz<T>(a.X, a.Y);
            for (int i = 0; i < a.X; i++)
                for (int j = 0; j < a.Y; j++)
                    resultado.Datos[i, j] = a.Datos[i, j] - b.Datos[i, j];
            return resultado;
        }

        public static Matriz<T> operator *(Matriz<T> ax, Matriz<T> b)
        {
            dynamic a = ax;
            if (a.Y != b.X) throw new Exception();
            Matriz<T> resultado = new Matriz<T>(a.X, b.Y);
            for (int i = 0; i < a.X; i++)
            {
                for (int j = 0; j < b.Y; j++)
                {
                    resultado.Datos[i, j] = new T();
                    for (int k = 0; k < a.Y; k++)
                    {
                        resultado.Datos[i, j] += a.Datos[i, k] * b.Datos[k, j];
                    }//k
                }//j
            }//i

            return resultado;
        }
        public Matriz<T> Invertir()
        {
            if (this.X != this.Y) throw new Exception();
            dynamic resultado = new Matriz<T>(this);
            dynamic identidad = new MatrizIdentidad<T>(this.X);
            dynamic auxiliar;
            for (int i = 0; i < this.X; i++)
            {
                auxiliar = 1/resultado.Datos[i, i];
                for (int j = 0; j < this.X; j++)
                {
                    resultado.Datos[i, j] *= auxiliar;
                    identidad.Datos[i, j] *= auxiliar;
                }
                for (int j = 0; j < this.X; j++)
                {
                    auxiliar = new T();
                    auxiliar = resultado.Datos[j, i];
                    if (j == i) continue;
                    for (int k = 0; k < this.X; k++)
                    {    
                        resultado.Datos[j, k] -= resultado.Datos[i, k] * auxiliar;
                        identidad.Datos[j, k] -= identidad.Datos[i, k] * auxiliar;
                    }//for k
                }//for j
            }//for i

            return identidad;
        }

        public T GetDeterminante()
        {
            if (this.X != this.Y) throw new FormatException();
            return GetDeterminante(this);
        }

        T GetDeterminante(Matriz<T> matrizX)
        {
            dynamic matriz = matrizX;
            dynamic solución = new T();

            if (matriz.X == 2)
                return matriz.Datos[0, 0] * matriz.Datos[1, 1] - matriz.Datos[1, 0] * matriz.Datos[0, 1];

            for (int i = 0; i < matriz.X; i++)
            {
                solución += ((i % 2 == 0) ? 1 : -1) * matriz.CruceEn(i) * GetDeterminante(matriz.CortarEn(i));
            }

            return solución;
        }

        Matriz<T> CortarEn(int index)
        {
            Matriz<T> nueva = new Matriz<T>(this.X - 1, this.X - 1);
            int currIndex = 0;
            T[] datos = new T[(this.X - 1) * (this.X - 1)];

            if (index >= this.X || index < 0) throw new ArgumentOutOfRangeException();


            for (int i = 1; i < this.X; i++)
            {
                for (int j = 0; j < this.X; j++)
                {
                    if (j == index) continue;
                    datos[currIndex++] = this.Datos[i, j];
                }
            }
            nueva.Llenar(datos);
            return nueva;
        }

        T CruceEn(int index)
        {
            return Datos[0, index];
        }

        public override string ToString()
        {
            string cadena = "";
            for (int i = 0; i < this.X; i++)
            {
                cadena += "|\t";
                for (int j = 0; j < this.Y; j++)
                {
                    cadena += this.Datos[i, j] + "\t";
                }
                cadena += "|\n";
            }
            return cadena;
        }

        public T this[int x, int y]
        {
            get
            {
                return this.Datos[x, y];
            }
            set
            {
                this.Datos[x, y] = value;
            }
        }


    }//class

    public class MatrizIdentidad<T> : Matriz<T> where T: new()
    {
        public MatrizIdentidad(int x) : base(x, x)
        {
            dynamic r;
            for (int i = 0; i < x; i++)
                for (int j = 0; j < x; j++)
                {
                    r = (i == j) ? 1 : 0;
                    this.Datos[i, j] = new T();
                    this.Datos[i, j] = r;
                }
                    
        }
    }//class

}//namespace
