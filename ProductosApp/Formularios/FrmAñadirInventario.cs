using Domain.Entities.Inventario;
using Domain.Enums;
using Infraestructure.Inventario;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProductosApp.Formularios
{
    public partial class FrmAñadirInventario : Form
    {
        public ModelIventario invetario = new ModelIventario();
        public FrmAñadirInventario()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Registro R = new Registro()
            {
                Existencia = (int)nudCantidad.Value,
                FechaRegistro = dtpFecha.Value,
                ValorUnidad = nudPrecio.Value,
                ValorTotal = (int)nudCantidad.Value * nudPrecio.Value,
                Especie = (CuentaE)cmbTipo.SelectedIndex
            };
        }
    }
}
