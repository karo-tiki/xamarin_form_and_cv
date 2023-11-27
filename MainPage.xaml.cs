using System;
using System.IO;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace cv
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Capturar los datos del formulario
            string nombre = nombreEditor.Text;
             string apellido= apellidoEditor.Text;
            string perfil = perfilEditor.Text;
            string contacto = contactoEntry.Text;
            string idiomas = idiomasEditor.Text;
            string habilidades = habilidadesEditor.Text;
  

            string cvContent = $"nombre: {nombre}\n"+
                                $"apellido: {apellido}\n"+
                                 $"Perfil: {perfil}\n"+
                                $"Contacto: {contacto}\n" +
                               $"Idiomas: {idiomas}\n" +
                               $"Habilidades: {habilidades}\n"  ;


            string filePath = Path.Combine(FileSystem.CacheDirectory, "CV.txt");
            File.WriteAllText(filePath, cvContent);


            await Share.RequestAsync(new ShareFileRequest
            {
                Title = "Curriculum Vitae",
                File = new ShareFile(filePath, "application/pdf")
            });
        }
    }
}