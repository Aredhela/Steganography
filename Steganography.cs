using System;
using System.Drawing;
using System.Text;

namespace Steganography
{
	/// <summary>
    /// Klasa Steganography obs�uguje ukrywanie informacji. Zawiera wszystkie metody potrzebne do tej czynno�ci. Nie rozr�nia wielko�ci liter.
	/// </summary>
	public class Steganography
	{
		/// <summary>
		/// Identyfikator, kt�ry okre�la czy w obrazku jest zapisany tekst czy nie
		/// </summary>
		private const int identifier=0x4EC2D1BD;
		/// <summary>
		/// Tablica masek wykorzystanych podczas operacji na bitach.
		/// </summary>
		private static byte[] mask={1,2,4,8,16,32,64,128};//tablica masek
		/// <summary>
        /// Okre�la na ilu bitach Steganography zapisuje jeden znak.
		/// </summary>
		protected const byte bitsNeeded=16;//ilo�� bit�w potrzebnych do zapami�tania jednego znaku Unicode
		/// <summary>
		/// Tekst, kt�ry chcemy ukry�
		/// </summary>
		private string message;//wiadomo�� do zakodowania
		/// <summary>
		/// Ilo�� bit�w koloru czerwonego na przechowanie informacji
		/// </summary>
		public byte redBits=1;
		/// <summary>
		/// Ilo�� bit�w koloru zielonego na przechowanie informacji
		/// </summary>
		public byte greenBits=1;
		/// <summary>
		/// Ilo�� bit�w koloru niebieskiego na przechowanie informacji
		/// </summary>
		public byte blueBits=1;
		/// <summary>
		/// Bitmapa, w kt�rej ukryjemy wiadomo��
		/// </summary>
		Bitmap bmpWynik;

		/// <summary>
		/// Jest to pozycja w tablicy od kt�rej b�dziemy zapisywali nast�pne znaki. Bo na pocz�tku to powinno by� 0, ale
		/// na pierwszych 3 bajtach jest zapisana informacja o ilo�ci bit�w a potem jest jeszcze info o d�ugo�ci tekstu
		/// </summary>
		private short writePosition=2;//indeksujemy od 0 wi�c 2 a nie 3


		/// <value>
		/// W�a�ciwo�� Message ma dost�p do wiadomo�ci. Jest tylko do odczytu
		/// </value>
		/// <summary>
		/// W�a�ciwo�� Message ma dost�p do wiadomo�ci. Jest tylko do odczytu
		/// </summary>
		public string Message
		{
			get
			{
				return message;
			}
		}

		/// <value>
		/// Wynik ma dost�p do obrazka. Jest do odczytu i zapisu.
		/// </value>
		/// <summary>
		/// Wynik ma dost�p do obrazka. Jest do odczytu i zapisu.
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
		/// Konstruktor domy�lny. Nie robi nic.
		/// </summary>
		public Steganography()
		{			
		}

		/// <summary>
		/// Konstruktor
		/// </summary>
		/// <param name="msg">Wiadomo�� do zakodowania</param>
		/// <param name="source">Obrazek, w kt�rym ukryjemy wiadomo��</param>
		/// <param name="red">Ilo�� bit�w koloru czerwonego na przechowywanie informacji</param>
		/// <param name="green">Ilo�� bit�w koloru zielonego na przechowywanie informacji</param>
		/// <param name="blue">Ilo�� bit�w koloru niebieskiego na przechowywanie informacji</param>
		public Steganography(string msg,Image source,int red,int green,int blue)
		{
			message=msg;
			redBits=(byte)red;
			greenBits=(byte)green;
			blueBits=(byte)blue;
			//bmpSource=(Bitmap)source;
			if(source!=null)
				bmpWynik=new Bitmap(source);//utw�rz bitmap� tak� sam� jak orygina� i j� b�dziemy zmienia�
		}

		/// <summary>
		/// Konstruktor. Wywo�uje tylko konstruktor public Koder(string msg,Image source,int red,int green,int blue)
		/// </summary>
		/// <param name="msg">Wiadomo�� do zakodowania</param>
		/// <param name="source">Obrazek, w kt�rym ukryjemy wiadomo��</param>
		public Steganography(string msg,Image source):this(msg,source,1,1,1)
		{
		}

		/// <summary>
		/// Konwertuje wiadomo�� na odpowiedni ci�g bit�w zgodny z tabel� kodowania.
		/// </summary>
		/// <param name="txt">Tekst do konwersji</param>
		/// <param name="charErr">Liczba znak�w, nie obs�ugiwanych przez klas� Koder, kt�re pojawi�y si� we wiadomo�ci</param>
		/// <returns>Tablica bit�w</returns>
		protected byte[] TextToBits(string txt)
		{
			byte[] tablica=new byte[txt.Length*bitsNeeded];//ka�dy znak zajmuje 6 bit�w
			int tabIndex=0;//s�u�y do indeksowania powy�szej tablicy

			//przele� po ka�dym znaku w tek�cie
			foreach(char znak in message)
			{
				//ustaw pocz�tkow� mask� na najstarszy sz�sty bit
				ushort bit=0x8000;//1000000000000000
				int i=0;
				//lecimy po wszystkich bitach znaku
				for(i=tabIndex;i<tabIndex+bitsNeeded;i++)
				{//zakodujmy ka�dy znak
					//ka�dy bit znaku jest w osobnym elementcie tablicy czyli na ka�dy znak przypada 6 element�w tablicy
					tablica[i]=(byte)(((ushort)znak & bit)>0?1:0);
					//ustaw mask� na kolejny bit czyli 1:100000 2:0100000 3:00100000 itd
					bit>>=1;//przesu� bit o jedno w lewo czyli 100->010->001
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
		/// Zapisuje informacj� o liczbie bit�w ka�dego koloru na przechowywanie wiadomo�ci do tablicy pikseli (czyli do obrazka).
		/// Te informacje zawsze zapisane s� na pojedy�czym bicie ka�dego koloru, czyli w sumie jak na jedn� warto�� przeznaczami 3 bity
		/// to na t� informacj� musimy przeznaczy� 3 piksele (9 bajt�w) bo ka�dy piksel przechowa 3 bity, a mamy 3 warto�ci (dla R, G i B)
		/// </summary>
		protected void WriteBitMask()
		{
			Color pixel;
			byte redTmp,greenTmp,blueTmp;
			//odejmij jeden bo zapisujemy tak �e 1 -> 0 ,8 -> 7 bo musimy zapisa� tylko na 3 bitach. P�niej dodamy jeden
			redBits--;
			greenBits--;
			blueBits--;

			//przele� przez 3 pierwsze piksele w obrazku
			for(int i=0;i<3;i++)
			{
				pixel=this[i];
				redTmp=pixel.R;
				greenTmp=pixel.G;
				blueTmp=pixel.B;

				//usu� najm�odszy bit ze wszystkich kolor�w
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
			//tutaj zwi�kszamy o jeden
			redBits++;
			greenBits++;
			blueBits++;
		}
		
		/// <summary>
		/// Pobiera poszczeg�lny bit z obrazka
		/// </summary>
		/// <param name="index">Numer bitu do pobrania </param>
		/// <param name="pos">Wyj�ciowy - pozycja piksela, z kt�rego odczytali�my bit</param>
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
		/// <param name="bit">Warto�� bitu do ustawienia</param>
		/// <param name="index">Indeks bitu</param>
		/// <returns>Zwraca numer pixela, kt�ry zmodyfikowa�a</returns>
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
				//najpierw usu� bity przeznaczone na wiadomo��
				redTmp&=(byte)(~mask[j]);
				redTmp|=(byte)(mask[j] & (bit<<j));
			}
			else if(j<redBits+greenBits)
			{
				greenTmp&=(byte)(~mask[redBits+greenBits-(j+1)]);//najpierw usu� bity przeznaczone na wiadomo��
				greenTmp|=(byte)(mask[redBits+greenBits-(j+1)] & (bit<<redBits+greenBits-(j+1)));
			}
			else
			{
				blueTmp&=(byte)(~mask[blueBits+redBits+greenBits-(j+1)]);//najpierw usu� bity przeznaczone na wiadomo��
				blueTmp|=(byte)(mask[blueBits+redBits+greenBits-(j+1)] & (bit<<blueBits+redBits+greenBits-(j+1)));
			}
			this[i]=Color.FromArgb(redTmp,greenTmp,blueTmp);
			return i;
		}

		/// <summary>
		/// Zapisuje do obrazka specjalny ci�g bit�w, kt�ry oznacza, �e w obrazu ukryto tekst.
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

			//zapisuje w obrazku identyfikator kt�ry okre�la �e plik zawiera ukryt� tre��
			WriteIdentifier();
			//teraz trzeba zapisa� ile znak�w ma tekst
			int l=message.Length;
			WriteTextLength((int)message.Length);
			
			byte[] tekst=TextToBits(message);
			
			for(int i=0;i<tekst.Length;i++)
			{
				SetBit(tekst[i],i);//ustaw odpowiedni bit w obrazku	
			}
		}

		/// <summary>
		/// Czyta z zakodowanej bitmapy informacj� o d�ugo�ci tekstu zakodowanego. U�ywana do odkodowywania.
		/// </summary>
		/// <returns>D�ugo�� tekstu</returns>
		private int ReadTextLength()
		{
			int tmp=0,length=0;
			int maska=0x40000000;//maska 32bitowa
			int position=0;//aby zapami�ta� na kt�rym pixelu zako�czyli�my zapisywa� info o rozmiarze
			//odczytaj 32 bity d�ugo�ci
			for(int i=0;i<31;i++)
			{//pobierz kolejne bity
				tmp=GetBit(i,out position);
				//zak�adaj mask� na coraz m�odsze bity przez co na koniec uzyskay ca�� liczb�
				length|=(int)((tmp<<(31-(i+1))) & maska);
				
				maska>>=1;//przesu� mask�
			}
			writePosition=(short)(position+1);//omijamy jeden pixel aby nie zapisa� przypadkiem jaki� informacji
			return length;
		}
		
		/// <summary>
		/// Zapisuje do obrazka (tablicy pikseli) rozmiar wiadomo�ci, kt�r� w nim ukryjemy.
		/// </summary>
		/// <param name="length">D�ugo�� tekstu</param>
		private void WriteTextLength(int length)
		{
			//wielko�� tekstu to liczba 32 bitowa
			int tmp=0x40000000;//maska 32bitowa
			int pixel=writePosition;
			for(byte i=0;i<31/*bo int jest 32 bitowa*/;i++)
			{//zapisujemy ka�dy bit d�ugo�ci osobno
				int t=(int)(length & tmp);
				byte b=(byte)(t>>(31-(i+1)));
				pixel=SetBit((byte)(b),i);
				tmp>>=1;
			}
			//zapami�taj pozycj� pixela kt�ry by� zmodyfikowany i ustaw si� automatycznie na pixel nast�pny
			//bo inaczej mog� by� wa�ki bo nie wiemy dok�adnie na kt�rym kolorze ostatnio pisali�my wi�c lepiej
			//jest omin�� ca�y pixel
			writePosition=(short)(pixel+1);
		}

		/// <summary>
		/// Odczytuje wiadomo�� z obrazka
		/// </summary>
		/// <param name="path">�cie�ka do pliku z bitmap�</param>
		public void Odczytaj(string path)
		{
			//otwiera bitmap�
			try
			{
				bmpWynik=new Bitmap(path);
			}
			catch
			{
				throw new InvalidFileException();
			}
			//odczytaj info o ilo�ci bit�w
			ReadBitMask();
			ReadIdentifier();//odczytuje identifikator � je�li nie ma to oznacza, �e plik nie zawiera informacji i generuje wyj�tek
			//oraz rozmiar tekstu przechowywanego w obrazku
			int length=ReadTextLength();
			

			int position;

			StringBuilder txt=new StringBuilder(length);

			//przele� przez ca�y tekst
			for(int i=0;i<length;i++)
			{
				ushort znak=0;
				//ka�dy znak zajmuje bitsNeeded bit�w wi�c nale�y tyle odczyta�
				for(int j=0;j<bitsNeeded;j++)
				{//pobierz kolejny bit nale��cy do jednego znaku
					byte bit=GetBit((i*bitsNeeded)+j,out position);
					znak|=(ushort)(bit<<(bitsNeeded-(j+1)));//po zako�czeniu p�telki b�dzie tutaj indeks w tablicy znaki
				}
				//do��cz kolejn� odczytan� liter� do wiadomo�ci
				txt.Append((char)znak);
			}
			message=txt.ToString();
		}

		/// <summary>
		/// Okre�la r�ne w�a�ciwo�ci wiadomo�ci
		/// </summary>
		/// <param name="pixelCount">Ilo�� pikseli potrzebnych na zakodowanie informacji - wyj�ciowy</param>
		public void Oblicz(out int pixelCount)
		{
			pixelCount=(message.Length*bitsNeeded+16+9)/*na info o bitach i d�ugo�� tekstu*//(redBits+greenBits+blueBits);
		}

		/// <summary>
		/// Odczytuje z zakodowanego obrazka informacj� o ilo�ci bit�w ka�dego koloru na przechowywanie informacji. U�ywany przy dekodowaniu
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
			//zwi�kszamy o jeden bo ilo�� zapisana jest na 3 bitach czyli np 0 to 1 a 7 to 8 :-)
			blueBits++;
			redBits++;
			greenBits++;
		}
	}
}
