using System;

namespace Koder
{
	/// <summary>
	/// Klasa reprezentuj�ca wyj�tek aplikacji
	/// </summary>
	/// <exception cref="System.ApplicationException">Zg�aszany gdy otwierana bitmapa nie zawiera informacji ukrytych</exception>
	public class InvalidFileException:ApplicationException
	{
		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="message">Komunikat b��du</param>
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
