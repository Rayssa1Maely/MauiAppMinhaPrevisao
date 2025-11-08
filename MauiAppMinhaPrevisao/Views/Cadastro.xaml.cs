using MauiAppMinhaPrevisao.Models;

namespace MauiAppMinhaPrevisao.Views;

public partial class Cadastro : ContentPage
{
	public Cadastro()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            Usuario usuario = new Usuario
            {
                Nome = txt_nome.Text,
                Email = txt_email.Text,
                DataNascimento = txt_Dnas.Text,
                Senha = txt_senha.Text
            };

            await App.Db.Insert(usuario);
            await DisplayAlert("Sucesso!", "Registro Inserido", "OK");
            await Navigation.PopAsync();

        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "OK");
        }
    }
}