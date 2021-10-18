using AppCore.Interfaces;
using Domain.Entities;
using Domain.Enums;
using Infraestructure.Productos;
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
    public partial class FrmProducto : Form
    {
        private IProductoService productoService;
        public FrmProducto(IProductoService productoService)
        {
            this.productoService = productoService;
            InitializeComponent();
        }

        private void FrmProducto_Load(object sender, EventArgs e)
        {
            cmbMeasureUnit.Items.AddRange(Enum.GetValues(typeof(UnidadMedida))
                                              .Cast<object>()
                                              .ToArray()
                                          );
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            Producto p = new Producto()
            {
                Id = productoService.GetLastProductoId() + 1,
                Nombre = txtNombre.Text,
                Descripcion = txtDesc.Text,
                Existencia = (int)nudExist.Value,
                Precio = nudPrice.Value,
                FechaVencimiento = dtpCaducity.Value,
                UnidadMedida = (UnidadMedida)cmbMeasureUnit.SelectedIndex
            };

            productoService.Create(p);

            Dispose();
        }
    }
}
