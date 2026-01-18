namespace ValidaCartaoApp;

/// <summary>
/// Representa um cartão de crédito com suas informações.
/// </summary>
public class Cartao
{
    public string Numero { get; set; }
    public string Bandeira { get; set; }
    public bool EhValido { get; set; }
    public string Mensagem { get; set; }

    public Cartao(string numero, string bandeira, bool ehValido, string mensagem)
    {
        Numero = numero;
        Bandeira = bandeira;
        EhValido = ehValido;
        Mensagem = mensagem;
    }

    /// <summary>
    /// Formata o número do cartão para exibição (últimos 4 dígitos visíveis).
    /// </summary>
    public string NumeroFormatado
    {
        get
        {
            if (Numero.Length < 4)
                return "****";
            
            string ultimosQuatro = Numero.Substring(Numero.Length - 4);
            return $"**** **** **** {ultimosQuatro}";
        }
    }
}
