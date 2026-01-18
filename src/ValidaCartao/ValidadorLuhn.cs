namespace ValidaCartaoApp;

/// <summary>
/// Valida números de cartão de crédito usando o Algoritmo de Luhn.
/// </summary>
public class ValidadorLuhn
{
    /// <summary>
    /// Valida um número de cartão usando o Algoritmo de Luhn.
    /// Este é o algoritmo padrão utilizado pela indústria de cartões de crédito.
    /// </summary>
    public static bool Validar(string numero)
    {
        if (string.IsNullOrWhiteSpace(numero))
            return false;

        // Remove espaços e hífens
        string numeroLimpo = numero.Replace(" ", "").Replace("-", "");

        // Verifica se contém apenas dígitos
        if (!numeroLimpo.All(char.IsDigit))
            return false;

        // Verifica o comprimento (geralmente entre 13 e 19 dígitos)
        if (numeroLimpo.Length < 13 || numeroLimpo.Length > 19)
            return false;

        return VerificaDigitoVerificador(numeroLimpo);
    }

    /// <summary>
    /// Implementação do Algoritmo de Luhn para verificar o dígito verificador.
    /// </summary>
    private static bool VerificaDigitoVerificador(string numero)
    {
        int soma = 0;
        bool alternado = false;

        // Percorre o número de trás para frente
        for (int i = numero.Length - 1; i >= 0; i--)
        {
            int digito = numero[i] - '0';

            if (alternado)
            {
                digito *= 2;
                if (digito > 9)
                    digito -= 9;
            }

            soma += digito;
            alternado = !alternado;
        }

        return soma % 10 == 0;
    }
}
