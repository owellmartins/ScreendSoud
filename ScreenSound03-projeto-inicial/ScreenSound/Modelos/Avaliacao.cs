namespace ScreenSound.Modelos;

internal class Avaliacao
{
	public Avaliacao(int nota)
	{
		Nota = nota;	
	}

	public int Nota { get; }

	public static Avaliacao Parse(string texto) //o static significa que podemos chamar esse método direto sem precisar chamar o new toda vez que for usá-lo, ou seja, o que está sendo executado aqui dentro do static não usa nenhuma informação da instância dessa classe Avaliacao, mas gera um objeto no método através do return new Avaliacao, ou seja, ele usa em algum momento as instâncias da classe para retornar um objeto. 
	{
		int nota = int.Parse(texto);
		if (nota < 0)
		{
			return new Avaliacao(0);
		}
		if (nota > 10)
		{
			return new Avaliacao(10);
		}
		return new Avaliacao(nota);
	}
}
