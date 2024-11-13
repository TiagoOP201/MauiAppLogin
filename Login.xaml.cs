namespace MauiAppLogin;

public partial class Login : ContentPage
{
	public Login()
	{
		InitializeComponent();
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
		try
		{
			List<DadosUsuario> list_usuarios = new List<DadosUsuario>()
			{
				new DadosUsuario()
				{
					Usuario = "Jose",
					Senha = "123" 
				},
				new DadosUsuario()
				{
					Usuario = "Maria",
					Senha = "321"
				}
				

			};

			DadosUsuario dados_digitados = new DadosUsuario()
			{
				Usuario = txt_usuario.Text,
				Senha = txt_senha.Text
			};

            // LINQ
            bool encontrou = list_usuarios.Any(i => (dados_digitados.Usuario == i.Usuario && dados_digitados.Senha == i.Senha));

            if (encontrou)
            {
                await SecureStorage.Default.SetAsync("usuario_logado", dados_digitados.Usuario);

                App.Current.MainPage = new Protegida();

            }
            else
            {
                throw new Exception("Usu�rio ou senha incorretos.");
            }


        }
        catch (Exception ex)
        {
            await DisplayAlert("Ops", ex.Message, "Fechar");
        }
    }
}