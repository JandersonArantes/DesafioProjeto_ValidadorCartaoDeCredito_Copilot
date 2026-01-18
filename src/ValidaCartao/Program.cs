using ValidaCartaoApp;

Console.WriteLine("╔════════════════════════════════════════╗");
Console.WriteLine("║   VALIDADOR DE CARTÃO DE CRÉDITO       ║");
Console.WriteLine("╚════════════════════════════════════════╝\n");

try
{
    Console.Write("Digite o número do cartão de crédito: ");
    string? numeroCartao = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(numeroCartao))
    {
        Console.WriteLine("\n❌ Erro: Número do cartão não pode estar vazio.");
        return;
    }

    var validador = new ValidadorCartao();
    var resultado = validador.Validar(numeroCartao);

    if (resultado.EhValido)
    {
        Console.WriteLine($"\n✅ Cartão VÁLIDO");
        Console.WriteLine($"📌 Bandeira: {resultado.Bandeira}");
        Console.WriteLine($"🔢 Número: {resultado.NumeroFormatado}");
    }
    else
    {
        Console.WriteLine($"\n❌ Cartão INVÁLIDO");
        Console.WriteLine($"Motivo: {resultado.Mensagem}");
    }
}
catch (Exception ex)
{
    Console.WriteLine($"\n❌ Erro inesperado: {ex.Message}");
}
