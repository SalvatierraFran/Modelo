using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mascota:Animal
    {
        //Atributos
        private string _nombre;
        private eTipoDeMascota _tipoDeMascota;

        //Propiedades
        public string Nombre
        {
            get { return this._nombre; }
        }

        public eTipoDeMascota TipoDeMascota
        {
            get { return this._tipoDeMascota; }
        }

        //Constructor
        public Mascota()
        { }

        public Mascota(string nombre, eTipoDeMascota tipo, int edad):base(edad)
        {
            this._nombre = nombre;
            this._tipoDeMascota = tipo;
        }

        //Métodos
        public static int OrdenarPorEdad(Mascota mascotaUno, Mascota mascotaDos)
        {
            if (mascotaUno.Edad > mascotaDos.Edad)
            {
                return 1;
            }
            else
            {
                if (mascotaUno.Edad == mascotaDos.Edad)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }

        public static int OrdenarPorNombre(Mascota mascotaUno, Mascota mascotaDos)
        {
            return string.Compare(mascotaUno.Nombre, mascotaDos.Nombre);
        }

        public static int OrdenarPorTipo(Mascota mascotaUno, Mascota mascotaDos)
        {
            if (mascotaUno.TipoDeMascota > mascotaDos.TipoDeMascota)
            {
                return 1;
            }
            else
            {
                if (mascotaUno.TipoDeMascota == mascotaDos.TipoDeMascota)
                {
                    return 0;
                }
                else
                {
                    return -1;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder Muestreo = new StringBuilder();

            Muestreo.Append("Nombre: " + this.Nombre)
                .Append("Tipo: " + this.TipoDeMascota)
                .Append(base.ToString());

            return Muestreo.ToString();
        }
    }
}
