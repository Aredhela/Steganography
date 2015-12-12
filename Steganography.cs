using System;
using System.Drawing;
using System.Text;

namespace Steganography
{
	/// <summary>
    /// Klasa Steganography obs³uguje ukrywanie informacji. Zawiera wszystkie metody potrzebne do tej czynnoœci. Nie rozró¿nia wielkoœci liter.
	/// </summary>
	public class Steganography
	{
		/// <summary>
		/// Identyfikator, który okreœla czy w obrazku jest zapisany tekst czy nie
		/// </summary>
		private const int identifier=0x4EC2D1BD;
		/// <summary>
		/// Tablica masek wykorzystanych podczas operacji na bitach.
		/// </summary>
		private static byte[] mask={1,2,4,8,16,32,64,128};//tablica masek
		/// <summary>
        /// Okreœla na ilu bitach Steganography zapisuje jeden znak.
		/// </summary>
		protected const byte bitsNeeded=16;//iloœæ bitów potrzebnych do zapamiêtania jednego znaku Unicode
		/// <summary>
		/// Tekst, który chcemy ukryæ
		/// </summary>
		private string message;//wiadomoœæ do zakodowania
		/// <summary>
		/// Iloœæ bitów koloru czerwonego na przechowanie informacji
		/// </summary>
		public byte redBits=1;
		/// <summary>
		/// Iloœæ bitów koloru zielonego na przechowanie informacji
		/// </summary>
		public byte greenBits=1;
		/// <summary>
		/// Iloœæ bitów koloru niebieskiego na przechowanie informacji
		/// </summary>
		public byte blueBits=1;
		/// <summary>
		/// Bitmapa, w której ukryjemy wiadomoœæ
		/// </summary>
		Bitmap bmpWynik;

		/// <summary>
		/// Jest to pozycja w tablicy od której bêdziemy zapisywali nastêpne znaki. Bo na pocz¹tku to powinno byæ 0, ale
		/// na pierwszych 3 bajtach jest zapisana informacja o iloœci bitów a potem jest jeszcze info o d³ugoœci tekstu
		/// </summary>
		private short writePosition=2;//indeksujemy od 0 wiêc 2 a nie 3


		/// <value>
		/// W³aœciwoœæ Message ma dostêp do wiadomoœci. Jest tylko do odczytu
		/// </value>
		/// <summary>
		/// W³aœciwoœæ Message ma dostêp do wiadomoœci. Jest tylko do odczytu
		/// </summary>
		public string Message
		{
			get
			{
				return message;
			}
		}

		/// <value>
		/// Wynik ma dostêp do obrazka. Jest do odczytu i zapisu.
		/// </value>
		/// <summary>
		/// Wynik ma dostêp do obrazka. Jest do odczytu i zapisu.
		/// </summary>
		public Image Wynik
		{
			get
			{
				return bmpWynik;
			}
			set
			{
				bmpWynik=new Bitmap(value);
			}
		}

		/// <summary>
		/// Konstruktor domyœlny. Nie robi nic.
		/// </summary>
		public Steganography()
		{			
		}

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="msg">Wiadomoœæ do zakodowania</param>
		/// <param name="source">Obrazek, w którym ukryjemy wiadomoœæ</param>
		/// <param name="red">Iloœæ bitów koloru czerwonego na przechowywanie informacji</param>
		/// <param name="green">Iloœæ bitów koloru zielonego na przechowywanie informacji</param>
		/// <param name="blue">Iloœæ bitów koloru niebieskiego na przechowywanie informacji</param>
		public Steganography(string msg,Image source,int red,int green,int blue)
		{
			message=msg;
			redBits=(byte)red;
			greenBits=(byte)green;
			blueBits=(byte)blue;
			//bmpSource=(Bitmap)source;
			if(source!=null)
				bmpWynik=new Bitmap(source);//utwórz bitmapê tak¹ sam¹ jak orygina³ i j¹ bêdziemy zmieniaæ
		}

		/// <summary>
		/// Konstruktor. Wywo³uje tylko konstruktor public Koder(string msg,Image source,int red,int green,int blue)
		/// </summary>
		/// <param name="msg">Wiadomoœæ do zakodowania</param>
		/// <param name="source">Obrazek, w którym ukryjemy wiadomoœæ</param>
		public Steganography(string msg,Image source):this(msg,source,1,1,1)
		{
		}

		/// <summary>
		/// Konwertuje wiadomoœæ na odpowiedni ci¹g bitów zgodny z tabel¹ kodowania.
		/// </summary>
		/// <param name="txt">Tekst do konwersji</param>
		/// <param name="charErr">Liczba znaków, nie obs³ugiwanych przez klasê Koder, które pojawi³y siê we wiadomoœci</param>
		/// <returns>Tablica bitów</returns>
		protected byte[] TextToBits(string txt)
		{
			byte[] tablica=new byte[txt.Length*bitsNeeded];//ka¿dy znak zajmuje 6 bitów
			int tabIndex=0;//s³u¿y do indeksowania powy¿szej tablicy

			//przeleæ po ka¿dym znaku w tekœcie
			foreach(char znak in message)
			{
				//ustaw pocz¹tkow¹ maskê na najstarszy szósty bit
				ushort bit=0x8000;//1000000000000000
				int i=0;
				//lecimy po wszystkich bitach znaku
				for(i=tabIndex;i<tabIndex+bitsNeeded;i++)
				{//zakodujmy ka¿dy znak
					//ka¿dy bit znaku jest w osobnym elementcie tablicy czyli na ka¿dy znak przypada 6 elementów tablicy
					tablica[i]=(byte)(((ushort)znak & bit)>0?1:0);
					//ustaw maskê na kolejny bit czyli 1:100000 2:0100000 3:00100000 itd
					bit>>=1;//przesuñ bit o jedno w lewo czyli 100->010->001
				}
				tabIndex=i;
			}
			return tablica;
		}

		private Color this[int y]
		{
			get
			{
				return bmpWynik.GetPixel(y%bmpWynik.Width,y/bmpWynik.Width);
			}
			set
			{
				bmpWynik.SetPixel(y%bmpWynik.Width,y/bmpWynik.Width ,value);
			}
		}

		/// <summary>
		/// Zapisuje informacjê o liczbie bitów ka¿dego koloru na przechowywanie wiadomoœci do tablicy pikseli (czyli do obrazka).
		/// Te informacje zawsze zapisane s¹ na pojedyñczym bicie ka¿dego koloru, czyli w sumie jak na jedn¹ wartoœæ przeznaczami 3 bity
		/// to na t¹ informacjê musimy przeznaczyæ 3 piksele (9 bajtów) bo ka¿dy piksel przechowa 3 bity, a mamy 3 wartoœci (dla R, G i B)
		/// </summary>
		protected void WriteBitMask()
		{
			Color pixel;
			byte redTmp,greenTmp,blueTmp;
			//odejmij jeden bo zapisujemy tak ¿e 1 -> 0 ,8 -> 7 bo musimy zapisaæ tylko na 3 bitach. PóŸniej dodamy jeden
			redBits--;
			greenBits--;
			blueBits--;

			//przeleæ przez 3 pierwsze piksele w obrazku
			for(int i=0;i<3;i++)
			{
				pixel=this[i];
				redTmp=pixel.R;
				greenTmp=pixel.G;
				blueTmp=pixel.B;

				//usuñ najm³odszy bit ze wszystkich kolorów
				redTmp&=0xFE;
				greenTmp&=0xFE;
				blueTmp&=0xFE;

				switch(i)
				{
					case 0://pierwszy pixel
						redTmp|=(byte)(redBits & 0x1);
						greenTmp|=(byte)((redBits & 0x2)>>1);
						blueTmp|=(byte)((redBits & 0x4)>>2);
						break;
					case 1://drugi pixel
						redTmp|=(byte)(greenBits & 0x1);
						greenTmp|=(byte)((greenBits & 0x2)>>1);
						blueTmp|=(byte)((greenBits & 0x4)>>2);
						break;
					case 2://trzeci pixel
						redTmp|=(byte)(blueBits & 0x1);
						greenTmp|=(byte)((blueBits & 0x2)>>1);
						blueTmp|=(byte)((blueBits & 0x4)>>2);
						break;
				}
				this[i]=Color.FromArgb(redTmp,greenTmp,blueTmp);
			}
			//tutaj zwiêkszamy o jeden
			redBits++;
			greenBits++;
			blueBits++;
		}
		
		/// <summary>
		/// Pobiera poszczególny bit z obrazka
		/// </summary>
		/// <param name="index">Numer bitu do pobrania </param>
		/// <param name="pos">Wyjœciowy - pozycja piksela, z którego odczytaliœmy bit</param>
		/// <returns>Wartpsc 0 lub 1</returns>
		private byte GetBit(int index,out int pos)
		{
			int i=(index/(redBits+greenBits+blueBits)+1)+writePosition;//numer pixela do zmodyfikowania
			int j=index%(redBits+greenBits+blueBits);//+3 bo pierwsze 3 pixle to info
			Color pixel=this[i];
			byte redTmp,greenTmp,blueTmp;

			redTmp=pixel.R;
			greenTmp=pixel.G;
			blueTmp=pixel.B;

			byte bit=0;

			if(j<redBits)
			{
				bit=(byte)((mask[j] & redTmp)>>j);
			}
			else if(j<redBits+greenBits)
			{
				bit=(byte)((mask[redBits+greenBits-(j+1)] & greenTmp)>>redBits+greenBits-(j+1));
			}
			else
			{
				bit=(byte)((mask[blueBits+redBits+greenBits-(j+1)] & blueTmp)>>blueBits+redBits+greenBits-(j+1));
			}
			pos=i;
			return bit;
		}

		/// <summary>
		/// Ustawia konkretny bit w obrazku.
		/// </summary>
		/// <param name="bit">Wartoœæ bitu do ustawienia</param>
		/// <param name="index">Indeks bitu</param>
		/// <returns>Zwraca numer pixela, który zmodyfikowa³a</returns>
		int SetBit(byte bit,int index)
		{
			int i=(index/(redBits+greenBits+blueBits)+1)+writePosition;//numer pixela do zmodyfikowania
			int j=index%(redBits+greenBits+blueBits);//+3 bo pierwsze 3 pixle to info
			Color pixel=this[i];
			byte redTmp,greenTmp,blueTmp;

			redTmp=pixel.R;
			greenTmp=pixel.G;
			blueTmp=pixel.B;

			if(j<redBits)
			{
				//najpierw usuñ bity przeznaczone na wiadomoœæ
				redTmp&=(byte)(~mask[j]);
				redTmp|=(byte)(mask[j] & (bit<<j));
			}
			else if(j<redBits+greenBits)
			{
				greenTmp&=(byte)(~mask[redBits+greenBits-(j+1)]);//najpierw usuñ bity przeznaczone na wiadomoœæ
				greenTmp|=(byte)(mask[redBits+greenBits-(j+1)] & (bit<<redBits+greenBits-(j+1)));
			}
			else
			{
				blueTmp&=(byte)(~mask[blueBits+redBits+greenBits-(j+1)]);//najpierw usuñ bity przeznaczone na wiadomoœæ
				blueTmp|=(byte)(mask[blueBits+redBits+greenBits-(j+1)] & (bit<<blueBits+redBits+greenBits-(j+1)));
			}
			this[i]=Color.FromArgb(redTmp,greenTmp,blueTmp);
			return i;
		}

		/// <summary>
		/// Zapisuje do obrazka specjalny ci¹g bitów, który oznacza, ¿e w obrazu ukryto tekst.
		/// </summary>
		protected void WriteIdentifier()
		{
			WriteTextLength(identifier);
		}

		protected void ReadIdentifier()
		{
			if(ReadTextLength()!=identifier)
			{//w pliku nie ma zapisanego identifikatora czyli plik nie ma zakodowanej informacji
				throw new InvalidFileException();
			}
		}

		/// <summary>
		/// Rozpoczyna ukrywanie informacji w obrazku.
		/// </summary>
		public void Koduj()
		{
			WriteBitMask();

			//zapisuje w obrazku identyfikator który okreœla ¿e plik zawiera ukryt¹ treœæ
			WriteIdentifier();
			//teraz trzeba zapisaæ ile znaków ma tekst
			int l=message.Length;
			WriteTextLength((int)message.Length);
			
			byte[] tekst=TextToBits(message);
			
			for(int i=0;i<tekst.Length;i++)
			{
				SetBit(tekst[i],i);//ustaw odpowiedni bit w obrazku	
			}
		}

		/// <summary>
		/// Czyta z zakodowanej bitmapy informacjê o d³ugoœci tekstu zakodowanego. U¿ywana do odkodowywania.
		/// </summary>
		/// <returns>D³ugoœæ tekstu</returns>
		private int ReadTextLength()
		{
			int tmp=0,length=0;
			int maska=0x40000000;//maska 32bitowa
			int position=0;//aby zapamiêtaæ na którym pixelu zakoñczyliœmy zapisywaæ info o rozmiarze
			//odczytaj 32 bity d³ugoœci
			for(int i=0;i<31;i++)
			{//pobierz kolejne bity
				tmp=GetBit(i,out position);
				//zak³adaj maskê na coraz m³odsze bity przez co na koniec uzyskay ca³¹ liczbê
				length|=(int)((tmp<<(31-(i+1))) & maska);
				
				maska>>=1;//przesuñ maskê
			}
			writePosition=(short)(position+1);//omijamy jeden pixel aby nie zapisaæ przypadkiem jakiœ informacji
			return length;
		}
		
		/// <summary>
		/// Zapisuje do obrazka (tablicy pikseli) rozmiar wiadomoœci, któr¹ w nim ukryjemy.
		/// </summary>
		/// <param name="length">D³ugoœæ tekstu</param>
		private void WriteTextLength(int length)
		{
			//wielkoœæ tekstu to liczba 32 bitowa
			int tmp=0x40000000;//maska 32bitowa
			int pixel=writePosition;
			for(byte i=0;i<31/*bo int jest 32 bitowa*/;i++)
			{//zapisujemy ka¿dy bit d³ugoœci osobno
				int t=(int)(length & tmp);
				byte b=(byte)(t>>(31-(i+1)));
				pixel=SetBit((byte)(b),i);
				tmp>>=1;
			}
			//zapamiêtaj pozycjê pixela który by³ zmodyfikowany i ustaw siê automatycznie na pixel nastêpny
			//bo inaczej mog¹ byæ wa³ki bo nie wiemy dok³adnie na którym kolorze ostatnio pisaliœmy wiêc lepiej
			//jest omin¹æ ca³y pixel
			writePosition=(short)(pixel+1);
		}

		/// <summary>
		/// Odczytuje wiadomoœæ z obrazka
		/// </summary>
		/// <param name="path">Œcie¿ka do pliku z bitmap¹</param>
		public void Odczytaj(string path)
		{
			//otwiera bitmapê
			try
			{
				bmpWynik=new Bitmap(path);
			}
			catch
			{
				throw new InvalidFileException();
			}
			//odczytaj info o iloœci bitów
			ReadBitMask();
			ReadIdentifier();//odczytuje identifikator – jeœli nie ma to oznacza, ¿e plik nie zawiera informacji i generuje wyj¹tek
			//oraz rozmiar tekstu przechowywanego w obrazku
			int length=ReadTextLength();
			

			int position;

			StringBuilder txt=new StringBuilder(length);

			//przeleæ przez ca³y tekst
			for(int i=0;i<length;i++)
			{
				ushort znak=0;
				//ka¿dy znak zajmuje bitsNeeded bitów wiêc nale¿y tyle odczytaæ
				for(int j=0;j<bitsNeeded;j++)
				{//pobierz kolejny bit nale¿¹cy do jednego znaku
					byte bit=GetBit((i*bitsNeeded)+j,out position);
					znak|=(ushort)(bit<<(bitsNeeded-(j+1)));//po zakoñczeniu pêtelki bêdzie tutaj indeks w tablicy znaki
				}
				//do³¹cz kolejn¹ odczytan¹ literê do wiadomoœci
				txt.Append((char)znak);
			}
			message=txt.ToString();
		}

		/// <summary>
		/// Okreœla ró¿ne w³aœciwoœci wiadomoœci
		/// </summary>
		/// <param name="pixelCount">Iloœæ pikseli potrzebnych na zakodowanie informacji - wyjœciowy</param>
		public void Oblicz(out int pixelCount)
		{
			pixelCount=(message.Length*bitsNeeded+16+9)/*na info o bitach i d³ugoœæ tekstu*//(redBits+greenBits+blueBits);
		}

		/// <summary>
		/// Odczytuje z zakodowanego obrazka informacjê o iloœci bitów ka¿dego koloru na przechowywanie informacji. U¿ywany przy dekodowaniu
		/// </summary>
		/// <param name="bitmap">Tablica pikseli</param>
		protected void ReadBitMask()
		{
			Color pixel;
			byte redTmp,greenTmp,blueTmp;

			redBits=greenBits=blueBits=0;

			for(int i=0;i<3;i++)
			{
				pixel=this[i];
				redTmp=pixel.R;
				greenTmp=pixel.G;
				blueTmp=pixel.B;

				switch(i)
				{
					case 0://pierwszy pixel
						redBits|=(byte)(redTmp & 0x1);
						redBits|=(byte)((greenTmp & 0x1)<<1);
						redBits|=(byte)((blueTmp & 0x1)<<2);
						if(redBits>7)
							throw new InvalidFileException();
						break;
					case 1://drugi pixel
						greenBits|=(byte)(redTmp & 0x1);
						greenBits|=(byte)((greenTmp & 0x1)<<1);
						greenBits|=(byte)((blueTmp & 0x1)<<2);
						if(greenBits>7)
							throw new InvalidFileException();
						break;
					case 2://trzeci pixel
						blueBits|=(byte)(redTmp & 0x1);
						blueBits|=(byte)((greenTmp & 0x1)<<1);
						blueBits|=(byte)((blueTmp & 0x1)<<2);
						if(blueBits>7)
							throw new InvalidFileException();
						break;
				}
			}
			//zwiêkszamy o jeden bo iloœæ zapisana jest na 3 bitach czyli np 0 to 1 a 7 to 8 :-)
			blueBits++;
			redBits++;
			greenBits++;
		}
	}
}
