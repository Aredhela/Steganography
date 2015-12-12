using System;

namespace Koder
{
	/// <summary>
	/// Klasa reprezentuj¹ca wyj¹tek aplikacji
	/// </summary>
	/// <exception cref="System.ApplicationException">Zg³aszany gdy otwierana bitmapa nie zawiera informacji ukrytych</exception>
	public class InvalidFileException:ApplicationException
	{
		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="message">Komunikat b³êdu</param>
		public InvalidFileException(string message):base(message)
		{
			
		}

		/// <summary>
		/// Konstruktor bezparametrowy
		/// </summary>
		public InvalidFileException():this("Przetwarzany obraz nie zawiera informacji ukrytych!")
		{
		}
	}
}
