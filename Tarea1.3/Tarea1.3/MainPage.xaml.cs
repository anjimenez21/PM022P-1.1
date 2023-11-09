namespace Tarea1._3
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Limpiar()
        {
            Nombre.Text = "";
            Apellidos.Text = "";
            Edad.Text = "";
            Correo.Text = "";
            Direccion.Text = "";
        }

        private async void btnGuardar(object sender, EventArgs e)
        {
            var person = new Models.Personas
            {
                Nombre = Nombre.Text,
                Apellidos = Apellidos.Text,
                Edad = Convert.ToInt32(Edad.Text),
                Correo = Correo.Text,
                Direccion = Direccion.Text
            };

            if (await MauiProgram.Instancia.AddPeople(person) > 0)
            {
                await DisplayAlert("Alerta", "Se han guardado los registros correctamente!", "Ok");
                Limpiar();
            }
            else
            {
                await DisplayAlert("ERROR", "Ha Ocurrido un Error", "OK");
            }
        }
    }
}