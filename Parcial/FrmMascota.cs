using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial
{
    public partial class FrmMascota : FrmAnimal
    {
        private Entidades.Mascota _unaMascota = new Entidades.Mascota();

        public Entidades.Mascota UnaMascota
        {
            get { return this._unaMascota; }
        }

        public FrmMascota()
        {
            InitializeComponent();
            this.CargarCombo();
        }

        public FrmMascota(Entidades.Mascota Masco):this()
        {
            this.txtNombre.Text = Masco.Nombre;
            this.cmbBox.SelectedItem = Masco.TipoDeMascota;
            this.txtEdad.Text = Masco.Edad.ToString();
        }

        protected override void txtEdad_TextChanged(object sender, EventArgs e)
        {
            base.txtEdad_TextChanged(sender, e);
        }

        protected override void lblEdad_Click(object sender, EventArgs e)
        {
            base.lblEdad_Click(sender, e);
        }

        private void CargarCombo()
        {
            foreach (Entidades.eTipoDeMascota item in Enum.GetValues(typeof(Entidades.eTipoDeMascota)))
            {
                this.cmbBox.Items.Add(item);
            }

            this.cmbBox.SelectedItem = Entidades.eTipoDeMascota.exotica;
        }

        protected override void btnAceptar_Click(object sender, EventArgs e)
        {
            this._unaMascota = new Entidades.Mascota(this.txtNombre.Text, (Entidades.eTipoDeMascota)this.cmbBox.SelectedItem, int.Parse(txtEdad.Text));    

            base.btnAceptar_Click(sender, e);
        }

        protected override void btnCancelar_Click(object sender, EventArgs e)
        {
            base.btnCancelar_Click(sender, e);
        }
    }
}
