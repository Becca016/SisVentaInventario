using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace SisVentaInventario.PRESENTACION
{
    public partial class frmTiposEmpresas : Form
    {
        public frmTiposEmpresas()
        {
            InitializeComponent();
        }

        #region "MIS VARIABLES"
        int nEstadoGuarda = 0;
        #endregion

        #region "MIS DATOS"

        private void Formato_te()
        {
            dgvListado.Columns[0].Width = 100;
            dgvListado.Columns[0].HeaderText = "CÓDIGO";
            dgvListado.Columns[1].Width = 250;
            dgvListado.Columns[1].HeaderText = "TIPO DE EMPRESA";
            dgvListado.Columns[2].Width = 100;
            dgvListado.Columns[2].HeaderText = "ACTIVO";
        }
        private void Listado_te(string cTexto)
        {
            //Trae las etiquetas o columnas al datagridview
            DATOS.D_TiposEmpresas Datos = new DATOS.D_TiposEmpresas();
            dgvListado.DataSource = Datos.Listado_te(cTexto);
            this.Formato_te();
        }
        #endregion

        private void LimpiarTexto()
        {
            txtCodigo_te.Clear();
            txtDescripcion_te.Clear();
        }

        private void EstadoTexto(bool lEstado)
        {
            txtDescripcion_te.Enabled = lEstado;
            txtBuscar.Enabled = lEstado;
            btnBuscar.Enabled = lEstado;
            dgvListado.Enabled = lEstado;
        }

        private void BotonesProcesos(bool lEstado)
        {
            btnCancelar.Visible = lEstado;
            btnGuardar.Visible = lEstado;
        }
        
        private void BotonesPrincipales(bool lEstado)
        {
            btnNuevo.Enabled = lEstado;
            btnActualizar.Enabled = lEstado;
            btnActivo.Enabled = lEstado;
            btnReporte.Enabled = lEstado;
            btnSalir.Enabled = lEstado;

        }

        private void frmTiposEmpresas_Load(object sender, EventArgs e)
        {
            this.Listado_te("%");
            txtBuscar.Select(); //El cursor se posiciona al ejecutar en la caja de texto txtBuscar
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Listado_te(txtBuscar.Text.Trim());
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            nEstadoGuarda = 1;  //Nuevo regsitro creado
            this.LimpiarTexto();
            this.EstadoTexto(true);
            this.BotonesProcesos(true);
            this.BotonesPrincipales(false);
            txtCodigo_te.Text = "#";
            txtDescripcion_te.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.LimpiarTexto();
            this.EstadoTexto (false);
            this.BotonesProcesos(false); ;
            this.BotonesPrincipales(true);
        }
    }
}
