namespace ValidaCartaoApp;

/// <summary>
/// Classe principal para validação completa de cartão de crédito.
/// Integra a validação do Luhn com a identificação da bandeira.
/// </summary>
public class ValidadorCartao
{
    /// <summary>
    /// Valida um cartão e retorna as informações completas.
    /// </summary>
    public Cartao Validar(string numeroCartao)
    {
        // Validação básica
        if (string.IsNullOrWhiteSpace(numeroCartao))
        {
            return new Cartao(
                numeroCartao ?? "",
                "Desconhecida",
                false,
                "Número do cartão não pode estar vazio."
            );
        }

        // Remove espaços e hífens para processamento
        string numeroLimpo = numeroCartao.Replace(" ", "").Replace("-", "");

        // Verifica se contém apenas dígitos
        if (!numeroLimpo.All(char.IsDigit))
        {
            return new Cartao(
                numeroCartao,
                " Bandeira Desconhecida",
                false,
                "O número do cartão deve conter apenas dígitos."
            );
        }

        // Identifica a bandeira
        string bandeira = IdentificadorBandeira.Identificar(numeroLimpo);

        // Valida usando o Algoritmo de Luhn
        bool ehValido = ValidadorLuhn.Validar(numeroLimpo);

        if (!ehValido)
        {
            return new Cartao(
                numeroCartao,
                bandeira,
                false,
                $"O número do cartão {bandeira} é inválido."
            );
        }

        return new Cartao(
            numeroCartao,
            bandeira,
            true,
            "Cartão válido."
        );
    }
}
