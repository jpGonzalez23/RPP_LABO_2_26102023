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

        private void FrmView_Load(object sender, EventArgs e)
        {
            this.cmbTipo.Items.Add("Automovil");
            this.cmbTipo.Items.Add("Camioneta");
            this.cmbTipo.Items.Add("Moto");
            this.IniciciarFabricacion();
            this.Refrescar();
        }

        private void btnFabricar_Click(object sender, EventArgs e)
        {
            Vehiculo nuevoVehiculo = this.CrearVehiculo();

            this.fabrica += nuevoVehiculo;
            this.Refrescar();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Vehiculo eliminarVehiculo = ((Vehiculo)this.lstVehiculos.SelectedItem);
            this.fabrica -= eliminarVehiculo;
            this.Refrescar();
        }

        private void IniciciarFabricacion()
        {
            this.fabrica = new Fabrica(5);
            Camioneta camioneta = new Camioneta(EPropulsion.Electrica, true);
        }

        private Vehiculo CrearVehiculo()
        {
            string tipo = this.cmbTipo.SelectedItem.ToString();

            switch(tipo)
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

        private void Refrescar()
        {
            this.lstVehiculos.DataSource = null;
            this.lstVehiculos.DataSource = this.fabrica.Vehiculos;
        }
    }
}