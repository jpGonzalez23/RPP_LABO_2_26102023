using Entidades;

namespace FrmView
{
    public partial class FrmView : Form
    {
        Fabrica fabrica;

        public FrmView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmView_Load(object sender, EventArgs e)
        {
            this.cmbTipo.Items.Add("Automovil");
            this.cmbTipo.Items.Add("Camioneta");
            this.cmbTipo.Items.Add("Moto");
            this.IniciciarFabricacion();
            this.Refrescar();
        }

        /// <summary>
        /// Evento para fabricar un vehiculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFabricar_Click(object sender, EventArgs e)
        {
            Vehiculo nuevoVehiculo = this.CrearVehiculo();

            this.fabrica += nuevoVehiculo;
            this.Refrescar();
        }

        /// <summary>
        /// Evento para eleminar un vehiculo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (this.lstVehiculos.SelectedItem != null)
            {
                Vehiculo eliminarVehiculo = ((Vehiculo)this.lstVehiculos.SelectedItem);
                this.fabrica -= eliminarVehiculo;
                this.Refrescar();

                MessageBox.Show("Se elimino corractamente el vehiculo", "Correcto", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Seleccione un vehiculo para eliminar.", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Metodo para iniciar la fabricacion
        /// </summary>
        private void IniciciarFabricacion()
        {
            this.fabrica = new Fabrica(5);
            Camioneta camioneta = new Camioneta(EPropulsion.Electrica, true);
        }

        /// <summary>
        /// Metodo para crear un vehiculo
        /// </summary>
        /// <returns>Retorna un vehiculo</returns>
        private Vehiculo CrearVehiculo()
        {
            string tipo = this.cmbTipo.SelectedItem.ToString();

            switch (tipo)
            {
                case "Automovil":
                    return new Automovil();
                case "Moto":
                    return new Moto(EPropulsion.Combustion);
                case "Camioneta":
                    return new Camioneta(EPropulsion.Hibrida, true);
                default:
                    return null;
            }
        }

        /// <summary>
        /// Metodo para refrescar el listbox
        /// </summary>
        private void Refrescar()
        {
            this.lstVehiculos.DataSource = null;
            this.lstVehiculos.DataSource = this.fabrica.Vehiculos;
        }
    }
}