/*
 * MatrizTraslación.cs
 * Yael Arturo Chavoya Andalón
 * 
 * Define una matriz de traslación
 */

namespace Matemáticas.Tipos.Transformaciones
{
    /// <summary>
    /// Define la traslación de una transformación
    /// </summary>
    public class MatrizTraslación : MatrizIdentidad<double>
    {

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Propiedades
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        public double CoordX
        {
            get
            {
                return this[0, 3];
            }
            set
            {
                this[0, 3] = value;
            }
        }
        public double CoordY
        {
            get
            {
                return this[1, 3];
            }
            set
            {
                this[1, 3] = value;
            }
        }
        public double CoordZ
        {
            get
            {
                return this[2, 3];
            }
            set
            {
                this[2, 3] = value;
            }
        }

        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =  
        // Constructores
        // = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = = =
        public MatrizTraslación(double x, double y, double z) : base(4)
        {
            this.CoordX = x;
            this.CoordY = y;
            this.CoordZ = z;
        }

        public MatrizTraslación(Matriz<double> matriz) : base(4)
        {
            if (matriz.X == matriz.Y && matriz.X == 4)
            {
                this.Datos = matriz.Datos;
            }
            else
            {
                throw new IncorrectSizedMatrixException();
            }
        }


    }//class
}
