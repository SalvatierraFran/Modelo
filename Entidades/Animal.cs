using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Animal
    {
        //Atributo
        private int _edad;

        //Propiedad
        public int Edad
        {
            get { return this._edad; }
        }

        //Metodos
        public Animal()
        { }

        public Animal(int Edad)
        {
            this._edad = Edad;
        }

        public override string ToString()
        {
            StringBuilder Muestreo = new StringBuilder();

            Muestreo.Append("Edad: " + this.Edad);

            return Muestreo.ToString();
        }
    }
}
