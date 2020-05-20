using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Entities;
using BusinessLayer;
namespace AplicationLayer
{
    public partial class frmFactura : Form
    {
        public frmFactura()
        {
            InitializeComponent();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtdocumento.Text != "")
            {
                ClientesEntity cliente = new ClientesEntity();
                cliente = ClientesBusiness.ObtnerClientePorNumeroDocumento(txtdocumento.Text);
                CargarFormulario(cliente);
            }
        }

        private void CargarFormulario(ClientesEntity cliente)
        {
            txtIdCliente.Text = Convert.ToString(cliente.IdCliente);
            cbTipoDocumento.Text = cliente.TipoDocumento;
            txtdocumento.Text = cliente.NumeroDocumento;
            txtprimernombre.Text = cliente.Primerombre;
            txtsegundonombre.Text = cliente.SegundoNombre;
            txtprimerapellido.Text = cliente.PrimerApellido;
            txtsegundoapellido.Text = cliente.SegudoApellido;
            txtnumero.Text = cliente.Telefono;
            txtemail.Text = cliente.Email;
            txtdireccion.Text = cliente.direccion;
        }


    }
}
