namespace ValidaCartaoApp;

/// <summary>
/// Identifica a bandeira do cartão de crédito usando regex.
/// </summary>
public class IdentificadorBandeira
{
    /// <summary>
    /// Dicionário com padrões regex para cada bandeira de cartão.
    /// </summary>
    private static readonly Dictionary<string, string> PadroesBandeiras = new()
    {
        // Visa 16 Dígitos: começa com 4
        { "Visa", @"^4[0-9]{15}$" },
        
        // MasterCard: começa com 51-55 ou 2221-2720, 16 dígitos
        { "MasterCard", @"^(?:5[1-5][0-9]{2}|222[1-9]|22[3-9][0-9]|2[3-6][0-9]{2}|27[01][0-9]|2720)[0-9]{12}$" },
        
        // American Express: começa com 34 ou 37, 15 dígitos
        { "American Express", @"^3[47][0-9]{13}$" },
        
        // Discover: começa com 6011, 622126-622925, 644-649, 65, 16 dígitos
        { "Discover", @"^6(?:011|5[0-9]{2}|4[4-9][0-9]|22(?:12[6-9]|1[3-9][0-9]|[2-8][0-9]{2}|9[01][0-9]|92[0-5]))[0-9]{12}$" },
        
        // Diners Club: começa com 36, 38, 300-305, 14 dígitos
        { "Diners Club", @"^3(?:0[0-5]|[68][0-9])[0-9]{11}$" },
        
        // JCB: começa com 3528-3589, 16 dígitos
        { "JCB", @"^(?:2131|1800|35\d{3})\d{11}$" },
        
        // EnRoute: começa com 2014 ou 2149, 15 dígitos
        { "EnRoute", @"^(?:2014|2149)[0-9]{11}$" },
        
        // Voyager: começa com 36, 16 dígitos
        { "Voyager", @"^36[0-9]{14}$" },
        
        // HiperCard: começa com 606282 ou 3841, 16 dígitos
        { "HiperCard", @"^(606282|3841)[0-9]{11,14}$" },
        
        // Aura: começa com 50, 16 dígitos
        { "Aura", @"^50[0-9]{14}$" }
    };

    /// <summary>
    /// Identifica a bandeira do cartão com base no número.
    /// </summary>
    public static string Identificar(string numeroCartao)
    {
        // Remove espaços e hífens
        string numeroLimpo = numeroCartao.Replace(" ", "").Replace("-", "");

        foreach (var bandeira in PadroesBandeiras)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(numeroLimpo, bandeira.Value))
            {
                return bandeira.Key;
            }
        }

        return "com Bandeira Desconhecida";
    }
}
