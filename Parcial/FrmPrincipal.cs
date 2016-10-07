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
    public partial class FrmPrincipal : Form
    {
        private List<Entidades.Mascota> _listaDeMascotas;
        private bool _banderaManejadores = true;

        public FrmPrincipal()
        {
            InitializeComponent();
            this._listaDeMascotas = new List<Entidades.Mascota>();
            this.CargarCombo();
        }

        private void CargarCombo()
        {
            foreach (Entidades.eTipoDeOrdenamiento item in Enum.GetValues(typeof(Entidades.eTipoDeOrdenamiento)))
            {
                toolStripComboBox1.Items.Add(item);
            }
            toolStripComboBox1.SelectedIndex = 0;
        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmMascota unForm = new FrmMascota();

            if (unForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this._listaDeMascotas.Add(unForm.UnaMascota);
            }

            this.CargarLista();
        }

        private void CargarLista()
        {
            this.lstAnimales.Items.Clear();

            foreach (Entidades.Mascota item in _listaDeMascotas)
            {
                this.lstAnimales.Items.Add(item.ToString());
            }
        }

        private void ManejadorCentral(object sender, EventArgs e)
        {
            string button = sender.ToString();
            FrmMascota fMasco;
            Entidades.Mascota auxMasco = new Entidades.Mascota("", Entidades.eTipoDeMascota.hogareña, 0);
            int index;

            if (button == bajaToolStripMenuItem.Text)
            {
                bajaToolStripMenuItem.Click -= new EventHandler(ManejadorCentral);
                modificarToolStripMenuItem.Click -= new EventHandler(ManejadorCentral);
                this._banderaManejadores = true;

                for (int i = 0; i < this._listaDeMascotas.Count; i++)
                {
                    index = this.lstAnimales.SelectedIndex;
                    auxMasco = this._listaDeMascotas[index];
                }

                fMasco = new FrmMascota(auxMasco);

                if (fMasco.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this._listaDeMascotas.Remove(auxMasco);
                }
            }

            if (button == modificarToolStripMenuItem.Text)
            {
                bajaToolStripMenuItem.Click -= new EventHandler(ManejadorCentral);
                modificarToolStripMenuItem.Click -= new EventHandler(ManejadorCentral);
                this._banderaManejadores = true;

                for (int i = 0; i < this._listaDeMascotas.Count; i++)
                {
                    index = this.lstAnimales.SelectedIndex;
                    auxMasco = this._listaDeMascotas[index];
                }

                fMasco = new FrmMascota(auxMasco);

                if (fMasco.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    this._listaDeMascotas.Remove(auxMasco);
                    this._listaDeMascotas.Add(fMasco.UnaMascota);
                }
            }

            this.CargarLista();
        }

        private void lstAnimales_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._banderaManejadores)
            {
                bajaToolStripMenuItem.Click += new EventHandler(ManejadorCentral);
                modificarToolStripMenuItem.Click += new EventHandler(ManejadorCentral);
                this._banderaManejadores = false;
            }
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string Mensaje = "Desea cerrar la aplicación???";
            string Caption = "Salir?";
            MessageBoxButtons Botones = MessageBoxButtons.YesNo;
            DialogResult Resultado;

            Resultado = MessageBox.Show(Mensaje, Caption, Botones, MessageBoxIcon.Question);

            if (Resultado == System.Windows.Forms.DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 0)
            {
                Comparison<Entidades.Mascota> Comparador = new Comparison<Entidades.Mascota>(Entidades.Mascota.OrdenarPorEdad);
                _listaDeMascotas.Sort(Comparador);
            }
            if (toolStripComboBox1.SelectedIndex == 1)
            {
                Comparison<Entidades.Mascota> Comparador = new Comparison<Entidades.Mascota>(Entidades.Mascota.OrdenarPorNombre);
                _listaDeMascotas.Sort(Comparador);
            }
            if (toolStripComboBox1.SelectedIndex == 2)
            {
                Comparison<Entidades.Mascota> Comparador = new Comparison<Entidades.Mascota>(Entidades.Mascota.OrdenarPorTipo);
                _listaDeMascotas.Sort(Comparador);
            }

            this.CargarLista();
        }
    }
}
