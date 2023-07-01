using OpenAI_API;
using ScreenSound.Modelos;
namespace ScreenSound.Menus;

internal class MenuRegistrarBanda : Menu
{
	public override void Executar(Dictionary<string, Banda> bandasRegistradas)
	{
		base.Executar(bandasRegistradas);
		ExibirTituloDaOpcao("Registro das bandas");
		Console.Write("Digite o nome da banda que deseja registrar: ");
		string nomeDaBanda = Console.ReadLine()!;
		Banda banda = new Banda(nomeDaBanda);

		if (bandasRegistradas.ContainsKey(nomeDaBanda))
		{
			Console.WriteLine($"A banda {nomeDaBanda} já está registrada!");
			Console.WriteLine("Digite qualquer tecla para voltar ao menu principal.");
			Console.ReadKey();
			Console.Clear();
		}
		else
		{
			bandasRegistradas.Add(nomeDaBanda, banda);
		}

		var client = new OpenAIAPI("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");
		var chat = client.Chat.CreateConversation();
		chat.AppendSystemMessage($"Resuma a banda {nomeDaBanda} em 1 parágrafo. Adote um estilo informal.");
		var resposta = chat.GetResponseFromChatbotAsync().GetAwaiter().GetResult();
		banda.Resumo = resposta;

		Console.WriteLine($"\nA banda {nomeDaBanda} foi registrada com sucesso!");
		Console.WriteLine("\nDigite uma tecla para voltar ao menu principal");
		Console.ReadKey();
		Console.Clear();

	
	}
}
