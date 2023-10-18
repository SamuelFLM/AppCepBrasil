using Cep.Entities;
using CepBrasil.Entities.Services;

namespace CepBrasil;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }


    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        var entry = (Entry)sender;

        if (!string.IsNullOrEmpty(entry.Text))
        {
            bordaInput.Stroke = Color.FromArgb("#00AB37");
        }
        else
        {
            bordaInput.Stroke = Color.FromArgb("#FF0000");
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Cep.IsVisible = false;
        BuscarCep.IsVisible = true;
        Validation();
    }

    private void Button_Clicked_1(object sender, EventArgs e)
    {
        Cep.IsVisible = true;
        BuscarCep.IsVisible = false;
        inputUser.Text = "";
    }

    private async Task Validation()
    {
        int.TryParse(inputUser.Text, out int cepUser);

        CepService service = new CepService();

        BrazilCep cep = await service.Get(cepUser);

        if(cep == null)
            await Console.Out.WriteLineAsync("Erro");

        resultCep.Text = cep.Cep;
        resultLogadouro.Text = cep.Logradouro;
        resultBairro.Text = cep.Bairro;
        resultLocalidade.Text = cep.Localidade;
        resultUF.Text = cep.UF;
        resultDDD.Text = cep.Ddd;
        resultSiafi.Text = cep.Siafi;
        resultIBGE.Text = cep.Ibge;
    }

}