using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Koder
{
	/// <summary>
	/// G³ówna klasa reprezentuj¹ca okno programu. Obs³uguje wszystkie zdarzenia
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Pole grupuj¹ce 1
		/// </summary>
		private System.Windows.Forms.GroupBox groupBox1;
		/// <summary>
		/// Pole grupuj¹ce 2
		/// </summary>
		private System.Windows.Forms.GroupBox groupBox2;
		/// <summary>
		/// Zak³adki
		/// </summary>
		private System.Windows.Forms.TabControl tabControl1;
		/// <summary>
		/// Zak³adka Tekst
		/// </summary>
		private System.Windows.Forms.TabPage tabPage1;
		/// <summary>
		/// Zak³adka Iloœæ bitów
		/// </summary>
		private System.Windows.Forms.TabPage tabPage2;
		/// <summary>
		/// Pasek stanu
		/// </summary>
		private System.Windows.Forms.StatusBar statusBar1;
		/// <summary>
		/// Menu g³ówne
		/// </summary>
		private System.Windows.Forms.MainMenu mainMenu1;
		/// <summary>
		/// Menu Plik
		/// </summary>
		private System.Windows.Forms.MenuItem mnuFile;
		/// <summary>
		/// Menu Nowy
		/// </summary>
		private System.Windows.Forms.MenuItem mnuNew;
		/// <summary>
		/// Menu Otwórz
		/// </summary>
		private System.Windows.Forms.MenuItem mnuOpen;
		/// <summary>
		/// Obrazek oryginalny
		/// </summary>
		private System.Windows.Forms.PictureBox picOrygina³;
		/// <summary>
		/// Obrazek zmodyfikowany
		/// </summary>
		private System.Windows.Forms.PictureBox picModified;
		/// <summary>
		/// Zak³adka Obrazek
		/// </summary>
		private System.Windows.Forms.TabPage tabPage3;
		/// <summary>
		/// Przycisk Przegl¹daj
		/// </summary>
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Pole tekstowe Orygina³
		/// </summary>
		private System.Windows.Forms.TextBox txtFile;
		/// <summary>
		/// Okno dialogowe Otwórz
		/// </summary>
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		/// <summary>
		/// Etykieta Orygina³
		/// </summary>
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Etykieta Wynik
		/// </summary>
		private System.Windows.Forms.Label Label2;
		/// <summary>
		/// Przycisk Przegl¹daj
		/// </summary>
		private System.Windows.Forms.Button button2;
		/// <summary>
		/// Pole tekstowe Wynik
		/// </summary>
		private System.Windows.Forms.TextBox txtFileModified;
		/// <summary>
		/// Okno dialogowe Zapisz
		/// </summary>
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		/// <summary>
		/// Przycisk Z pliku...
		/// </summary>
		private System.Windows.Forms.Button btnTextFromFile;
		/// <summary>
		/// Pole tekstowe Wiadomoœæ
		/// </summary>
		private System.Windows.Forms.TextBox txtTekst;
		/// <summary>
		/// Suwak Czerwony
		/// </summary>
		private System.Windows.Forms.TrackBar trkRed;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label label3;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label label4;
		/// <summary>
		/// Suwak Zielony
		/// </summary>
		private System.Windows.Forms.TrackBar trkGreen;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label label5;
		/// <summary>
		/// Suwak Niebieski
		/// </summary>
		private System.Windows.Forms.TrackBar trkBlue;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label label6;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label label7;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label label8;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label label9;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label label10;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label label11;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label lblRed;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label lblGreen;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label lblBlue;
		/// <summary>
		/// Okno dialogowe Otwórz
		/// </summary>
		private System.Windows.Forms.OpenFileDialog openFileDialog2;
		/// <summary>
		/// Pozycja Separator w menu
		/// </summary>
		private System.Windows.Forms.MenuItem menuItem1;
		/// <summary>
		/// Menu Zamknij
		/// </summary>
		private System.Windows.Forms.MenuItem mnuClose;
		/// <summary>
		/// Przycisk Koduj
		/// </summary>
		private System.Windows.Forms.Button btnKoduj;
		/// <summary>
		/// Zak³adka Info
		/// </summary>
		private System.Windows.Forms.TabPage tabPage4;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label label12;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label lblPixelCount;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label label13;
		/// <summary>
		/// Etykieta
		/// </summary>
		private System.Windows.Forms.Label lblCharsCount;
		/// <summary>
		/// Komponent ToolTip
		/// </summary>
		private System.Windows.Forms.ToolTip toolTip1;
		private System.Windows.Forms.MenuItem mnuWidok;
		private System.Windows.Forms.MenuItem mnuNatural;
		private System.Windows.Forms.MenuItem mnuSkaluj;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.StatusBarPanel sbpInputChars;
		private System.Windows.Forms.ErrorProvider errorProvider1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label lblPicSize;
		/// <summary>
		/// Pomocniczy obiekt reprezentuj¹cy wszystkie obiekty na formie
		/// </summary>
		private System.ComponentModel.IContainer components;

		/// <summary>
		/// Konstruktor bezparamterowy. Tworzy wszystkie obiekty w oknie
		/// </summary>
		public Form1()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Zwalnia wszystkie u¿ywane zasoby
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.panel1 = new System.Windows.Forms.Panel();
			this.picOrygina³ = new System.Windows.Forms.PictureBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.picModified = new System.Windows.Forms.PictureBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.btnKoduj = new System.Windows.Forms.Button();
			this.btnTextFromFile = new System.Windows.Forms.Button();
			this.txtTekst = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.Label2 = new System.Windows.Forms.Label();
			this.button2 = new System.Windows.Forms.Button();
			this.txtFileModified = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.txtFile = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.lblBlue = new System.Windows.Forms.Label();
			this.lblGreen = new System.Windows.Forms.Label();
			this.lblRed = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.trkBlue = new System.Windows.Forms.TrackBar();
			this.label4 = new System.Windows.Forms.Label();
			this.trkGreen = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.trkRed = new System.Windows.Forms.TrackBar();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.lblPicSize = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.lblCharsCount = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.lblPixelCount = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.sbpInputChars = new System.Windows.Forms.StatusBarPanel();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.mnuFile = new System.Windows.Forms.MenuItem();
			this.mnuNew = new System.Windows.Forms.MenuItem();
			this.mnuOpen = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.mnuClose = new System.Windows.Forms.MenuItem();
			this.mnuWidok = new System.Windows.Forms.MenuItem();
			this.mnuNatural = new System.Windows.Forms.MenuItem();
			this.mnuSkaluj = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
			this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.errorProvider1 = new System.Windows.Forms.ErrorProvider();
			this.groupBox1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage3.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trkBlue)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkGreen)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trkRed)).BeginInit();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.sbpInputChars)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox1.Controls.Add(this.panel1);
			this.groupBox1.Location = new System.Drawing.Point(8, 0);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(248, 248);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Orygina³";
			// 
			// panel1
			// 
			this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel1.AutoScroll = true;
			this.panel1.Controls.Add(this.picOrygina³);
			this.panel1.Location = new System.Drawing.Point(8, 16);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(232, 224);
			this.panel1.TabIndex = 0;
			// 
			// picOrygina³
			// 
			this.picOrygina³.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.picOrygina³.Location = new System.Drawing.Point(8, 8);
			this.picOrygina³.Name = "picOrygina³";
			this.picOrygina³.Size = new System.Drawing.Size(96, 112);
			this.picOrygina³.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picOrygina³.TabIndex = 0;
			this.picOrygina³.TabStop = false;
			this.toolTip1.SetToolTip(this.picOrygina³, "Wyœwietla orginalny obrazek");
			// 
			// groupBox2
			// 
			this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.groupBox2.Controls.Add(this.panel2);
			this.groupBox2.Location = new System.Drawing.Point(272, 0);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(256, 248);
			this.groupBox2.TabIndex = 1;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Zmodyfikowany";
			// 
			// panel2
			// 
			this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.panel2.AutoScroll = true;
			this.panel2.Controls.Add(this.picModified);
			this.panel2.Location = new System.Drawing.Point(8, 16);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(240, 224);
			this.panel2.TabIndex = 0;
			// 
			// picModified
			// 
			this.picModified.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.picModified.Location = new System.Drawing.Point(8, 8);
			this.picModified.Name = "picModified";
			this.picModified.Size = new System.Drawing.Size(104, 120);
			this.picModified.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.picModified.TabIndex = 0;
			this.picModified.TabStop = false;
			this.toolTip1.SetToolTip(this.picModified, "Wyœwietla obrazek z zakodowan¹ informacj¹");
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Location = new System.Drawing.Point(8, 256);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(520, 128);
			this.tabControl1.TabIndex = 2;
			this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.btnKoduj);
			this.tabPage1.Controls.Add(this.btnTextFromFile);
			this.tabPage1.Controls.Add(this.txtTekst);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(512, 102);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Tekst";
			// 
			// btnKoduj
			// 
			this.btnKoduj.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnKoduj.Location = new System.Drawing.Point(416, 40);
			this.btnKoduj.Name = "btnKoduj";
			this.btnKoduj.Size = new System.Drawing.Size(80, 24);
			this.btnKoduj.TabIndex = 2;
			this.btnKoduj.Text = "&Koduj";
			this.toolTip1.SetToolTip(this.btnKoduj, "Rozpoczyna ukrywanie informacji w obrazku");
			this.btnKoduj.Click += new System.EventHandler(this.btnKoduj_Click);
			// 
			// btnTextFromFile
			// 
			this.btnTextFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnTextFromFile.Location = new System.Drawing.Point(416, 8);
			this.btnTextFromFile.Name = "btnTextFromFile";
			this.btnTextFromFile.Size = new System.Drawing.Size(80, 24);
			this.btnTextFromFile.TabIndex = 1;
			this.btnTextFromFile.Text = "&Z pliku...";
			this.toolTip1.SetToolTip(this.btnTextFromFile, "Kliknij, aby zakodowaæ tekst z pliku tekstowego");
			this.btnTextFromFile.Click += new System.EventHandler(this.btnTextFromFile_Click);
			// 
			// txtTekst
			// 
			this.txtTekst.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtTekst.Location = new System.Drawing.Point(8, 8);
			this.txtTekst.MaxLength = 0;
			this.txtTekst.Multiline = true;
			this.txtTekst.Name = "txtTekst";
			this.txtTekst.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtTekst.Size = new System.Drawing.Size(384, 88);
			this.txtTekst.TabIndex = 0;
			this.txtTekst.Text = "";
			this.toolTip1.SetToolTip(this.txtTekst, "Wpisz tutaj wiadomoœæ do zakodowania");
			this.txtTekst.TextChanged += new System.EventHandler(this.txtTekst_TextChanged);
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.Label2);
			this.tabPage3.Controls.Add(this.button2);
			this.tabPage3.Controls.Add(this.txtFileModified);
			this.tabPage3.Controls.Add(this.label1);
			this.tabPage3.Controls.Add(this.button1);
			this.tabPage3.Controls.Add(this.txtFile);
			this.tabPage3.Location = new System.Drawing.Point(4, 22);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Size = new System.Drawing.Size(512, 102);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Obrazek";
			// 
			// Label2
			// 
			this.Label2.Location = new System.Drawing.Point(8, 56);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(56, 16);
			this.Label2.TabIndex = 5;
			this.Label2.Text = "Wynik:";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button2
			// 
			this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button2.Location = new System.Drawing.Point(424, 56);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(80, 24);
			this.button2.TabIndex = 4;
			this.button2.Text = "Przegl¹daj...";
			this.toolTip1.SetToolTip(this.button2, "Umo¿liwia wskazanie pliku wynikowego");
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// txtFileModified
			// 
			this.txtFileModified.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFileModified.Location = new System.Drawing.Point(72, 56);
			this.txtFileModified.Name = "txtFileModified";
			this.txtFileModified.Size = new System.Drawing.Size(328, 20);
			this.txtFileModified.TabIndex = 3;
			this.txtFileModified.Text = "";
			this.toolTip1.SetToolTip(this.txtFileModified, "Œcie¿ka do pliku wynikowego");
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Orygina³:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.CausesValidation = false;
			this.button1.Location = new System.Drawing.Point(424, 8);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(80, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Przegl¹daj...";
			this.toolTip1.SetToolTip(this.button1, "Umo¿liwia wskazanie pliku z obrazkiem");
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtFile
			// 
			this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.txtFile.Location = new System.Drawing.Point(72, 8);
			this.txtFile.Name = "txtFile";
			this.txtFile.Size = new System.Drawing.Size(328, 20);
			this.txtFile.TabIndex = 0;
			this.txtFile.Text = "";
			this.toolTip1.SetToolTip(this.txtFile, "Œcie¿ka do bitmapy, w której chcemy ukryæ wiadomoœæ");
			this.txtFile.Validating += new System.ComponentModel.CancelEventHandler(this.txtFile_Validating);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.lblBlue);
			this.tabPage2.Controls.Add(this.lblGreen);
			this.tabPage2.Controls.Add(this.lblRed);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.label10);
			this.tabPage2.Controls.Add(this.label9);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.trkBlue);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.trkGreen);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Controls.Add(this.trkRed);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(512, 102);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Iloœæ bitów";
			// 
			// lblBlue
			// 
			this.lblBlue.AutoSize = true;
			this.lblBlue.Location = new System.Drawing.Point(448, 8);
			this.lblBlue.Name = "lblBlue";
			this.lblBlue.Size = new System.Drawing.Size(10, 16);
			this.lblBlue.TabIndex = 14;
			this.lblBlue.Text = "1";
			// 
			// lblGreen
			// 
			this.lblGreen.AutoSize = true;
			this.lblGreen.Location = new System.Drawing.Point(288, 8);
			this.lblGreen.Name = "lblGreen";
			this.lblGreen.Size = new System.Drawing.Size(10, 16);
			this.lblGreen.TabIndex = 13;
			this.lblGreen.Text = "1";
			// 
			// lblRed
			// 
			this.lblRed.AutoSize = true;
			this.lblRed.Location = new System.Drawing.Point(136, 8);
			this.lblRed.Name = "lblRed";
			this.lblRed.Size = new System.Drawing.Size(10, 16);
			this.lblRed.TabIndex = 12;
			this.lblRed.Text = "1";
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(456, 72);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(10, 16);
			this.label11.TabIndex = 11;
			this.label11.Text = "8";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(304, 72);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(10, 16);
			this.label10.TabIndex = 10;
			this.label10.Text = "8";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(152, 72);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(10, 16);
			this.label9.TabIndex = 9;
			this.label9.Text = "8";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(352, 72);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(10, 16);
			this.label8.TabIndex = 8;
			this.label8.Text = "1";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(200, 72);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(10, 16);
			this.label7.TabIndex = 7;
			this.label7.Text = "1";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(40, 72);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(10, 16);
			this.label6.TabIndex = 6;
			this.label6.Text = "1";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.Color.Blue;
			this.label5.Location = new System.Drawing.Point(387, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(50, 16);
			this.label5.TabIndex = 5;
			this.label5.Text = "Niebieski";
			// 
			// trkBlue
			// 
			this.trkBlue.LargeChange = 4;
			this.trkBlue.Location = new System.Drawing.Point(348, 32);
			this.trkBlue.Maximum = 8;
			this.trkBlue.Minimum = 1;
			this.trkBlue.Name = "trkBlue";
			this.trkBlue.Size = new System.Drawing.Size(128, 42);
			this.trkBlue.TabIndex = 4;
			this.toolTip1.SetToolTip(this.trkBlue, "Ten suwak umo¿liwia okreœlenie iloœci bitów koloru niebieskiego na przechowanie i" +
				"nformacji");
			this.trkBlue.Value = 1;
			this.trkBlue.Scroll += new System.EventHandler(this.trkBlue_Scroll);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.Color.Green;
			this.label4.Location = new System.Drawing.Point(236, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(41, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Zielony";
			// 
			// trkGreen
			// 
			this.trkGreen.LargeChange = 4;
			this.trkGreen.Location = new System.Drawing.Point(192, 32);
			this.trkGreen.Maximum = 8;
			this.trkGreen.Minimum = 1;
			this.trkGreen.Name = "trkGreen";
			this.trkGreen.Size = new System.Drawing.Size(128, 42);
			this.trkGreen.TabIndex = 2;
			this.toolTip1.SetToolTip(this.trkGreen, "Ten suwak umo¿liwia okreœlenie iloœci bitów koloru zielonego na przechowanie info" +
				"rmacji");
			this.trkGreen.Value = 1;
			this.trkGreen.Scroll += new System.EventHandler(this.trkGreen_Scroll);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(73, 8);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(55, 16);
			this.label3.TabIndex = 1;
			this.label3.Text = "Czerwony";
			// 
			// trkRed
			// 
			this.trkRed.LargeChange = 4;
			this.trkRed.Location = new System.Drawing.Point(36, 32);
			this.trkRed.Maximum = 8;
			this.trkRed.Minimum = 1;
			this.trkRed.Name = "trkRed";
			this.trkRed.Size = new System.Drawing.Size(128, 42);
			this.trkRed.TabIndex = 0;
			this.toolTip1.SetToolTip(this.trkRed, "Ten suwak umo¿liwia okreœlenie iloœci bitów koloru czerwonego na przechowanie inf" +
				"ormacji");
			this.trkRed.Value = 1;
			this.trkRed.Scroll += new System.EventHandler(this.trkRed_Scroll);
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.lblPicSize);
			this.tabPage4.Controls.Add(this.label16);
			this.tabPage4.Controls.Add(this.lblCharsCount);
			this.tabPage4.Controls.Add(this.label13);
			this.tabPage4.Controls.Add(this.lblPixelCount);
			this.tabPage4.Controls.Add(this.label12);
			this.tabPage4.Location = new System.Drawing.Point(4, 22);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Size = new System.Drawing.Size(512, 102);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Info";
			// 
			// lblPicSize
			// 
			this.lblPicSize.AutoSize = true;
			this.lblPicSize.Location = new System.Drawing.Point(112, 56);
			this.lblPicSize.Name = "lblPicSize";
			this.lblPicSize.Size = new System.Drawing.Size(19, 16);
			this.lblPicSize.TabIndex = 5;
			this.lblPicSize.Text = "----";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(8, 56);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(95, 16);
			this.label16.TabIndex = 4;
			this.label16.Text = "Wymiary obrazka:";
			// 
			// lblCharsCount
			// 
			this.lblCharsCount.AutoSize = true;
			this.lblCharsCount.Location = new System.Drawing.Point(104, 32);
			this.lblCharsCount.Name = "lblCharsCount";
			this.lblCharsCount.Size = new System.Drawing.Size(10, 16);
			this.lblCharsCount.TabIndex = 3;
			this.lblCharsCount.Text = "0";
			this.toolTip1.SetToolTip(this.lblCharsCount, "Iloœæ znaków w tekœcie");
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(8, 32);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(82, 16);
			this.label13.TabIndex = 2;
			this.label13.Text = "Liczba znaków:";
			// 
			// lblPixelCount
			// 
			this.lblPixelCount.AutoSize = true;
			this.lblPixelCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(238)));
			this.lblPixelCount.Location = new System.Drawing.Point(152, 8);
			this.lblPixelCount.Name = "lblPixelCount";
			this.lblPixelCount.Size = new System.Drawing.Size(20, 16);
			this.lblPixelCount.TabIndex = 1;
			this.lblPixelCount.Text = "----";
			this.toolTip1.SetToolTip(this.lblPixelCount, "Iloœæ pixeli potrzebnych do zakodowania wiadomoœci");
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(8, 8);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(144, 16);
			this.label12.TabIndex = 0;
			this.label12.Text = "Liczba pikseli wymaganych:";
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 389);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.sbpInputChars});
			this.statusBar1.ShowPanels = true;
			this.statusBar1.Size = new System.Drawing.Size(544, 22);
			this.statusBar1.TabIndex = 3;
			this.statusBar1.Text = "Gotów";
			// 
			// sbpInputChars
			// 
			this.sbpInputChars.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents;
			this.sbpInputChars.Text = "Wpisano: 0 znaków";
			this.sbpInputChars.ToolTipText = "D³ugoœæ wiadomoœci";
			this.sbpInputChars.Width = 112;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.mnuFile,
																					  this.mnuWidok,
																					  this.menuItem2});
			// 
			// mnuFile
			// 
			this.mnuFile.Index = 0;
			this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.mnuNew,
																					this.mnuOpen,
																					this.menuItem1,
																					this.mnuClose});
			this.mnuFile.Text = "&Plik";
			// 
			// mnuNew
			// 
			this.mnuNew.Index = 0;
			this.mnuNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.mnuNew.Text = "&Nowy";
			this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
			// 
			// mnuOpen
			// 
			this.mnuOpen.Index = 1;
			this.mnuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.mnuOpen.Text = "&Otwórz...";
			this.mnuOpen.Click += new System.EventHandler(this.mnuOpen_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 2;
			this.menuItem1.Text = "-";
			// 
			// mnuClose
			// 
			this.mnuClose.Index = 3;
			this.mnuClose.Text = "Za&mknij";
			this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
			// 
			// mnuWidok
			// 
			this.mnuWidok.Index = 1;
			this.mnuWidok.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mnuNatural,
																					 this.mnuSkaluj});
			this.mnuWidok.Text = "&Widok";
			// 
			// mnuNatural
			// 
			this.mnuNatural.Checked = true;
			this.mnuNatural.Index = 0;
			this.mnuNatural.RadioCheck = true;
			this.mnuNatural.Text = "Wielkoœæ &naturalna";
			this.mnuNatural.Click += new System.EventHandler(this.mnuNatural_Click);
			// 
			// mnuSkaluj
			// 
			this.mnuSkaluj.Index = 1;
			this.mnuSkaluj.RadioCheck = true;
			this.mnuSkaluj.Text = "&Skaluj";
			this.mnuSkaluj.Click += new System.EventHandler(this.mnuSkaluj_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 2;
			this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem3});
			this.menuItem2.Text = "Pomo&c";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 0;
			this.menuItem3.Text = "&O programie...";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// openFileDialog1
			// 
			this.openFileDialog1.Filter = "Bitmapy (*.bmp)|*.bmp|Wszystkie pliki (*.*)|*.*||";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "wynik.bmp";
			// 
			// openFileDialog2
			// 
			this.openFileDialog2.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*||";
			// 
			// errorProvider1
			// 
			this.errorProvider1.ContainerControl = this;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(544, 411);
			this.Controls.Add(this.statusBar1);
			this.Controls.Add(this.tabControl1);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Menu = this.mainMenu1;
			this.Name = "Form1";
			this.Text = "Koder";
			this.groupBox1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.groupBox2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage3.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trkBlue)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkGreen)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trkRed)).EndInit();
			this.tabPage4.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.sbpInputChars)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Punkt wejœcia aplikacji
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		/// <summary>
		/// Obs³uga klikniêcia przycisku Przegl¹daj
		/// </summary>
		/// <param name="sender">Przycisk, który wygenerowa³ zdarzenie</param>
		/// <param name="e">Nieu¿ywany</param>
		private void button1_Click(object sender, System.EventArgs e)
		{
			DialogResult res=openFileDialog1.ShowDialog(this);
			if(res==DialogResult.OK)
			{
				txtFile.Text=openFileDialog1.FileName;
				picOrygina³.Image=Image.FromFile(txtFile.Text);
			}
		}

		/// <summary>
		/// Obs³uga klikniêcia przycisku Przegl¹daj
		/// </summary>
		/// <param name="sender">Przycisk, który wygenerowa³ zdarzenie</param>
		/// <param name="e">Nieu¿ywany</param>
		private void button2_Click(object sender, System.EventArgs e)
		{
			DialogResult res=saveFileDialog1.ShowDialog(this);
			if(res==DialogResult.OK)
			{
				txtFileModified.Text=saveFileDialog1.FileName;
			}
		}
		
		/// <summary>
		/// Obs³uga klikniêcia pozycji Nowy w menu Plik
		/// </summary>
		/// <param name="sender">Pozycja w menu, która wygenerowa³a zdarzenie</param>
		/// <param name="e">Nieu¿ywany</param>
		private void mnuNew_Click(object sender, System.EventArgs e)
		{
			ResetControls();
			EnableControls(true);
		}

		/// <summary>
		/// Ustawia kontrolki w stan pocz¹tkowy
		/// </summary>
		private void ResetControls()
		{
			//zresetuj wszystkie pola
			txtFile.Text="";
			txtFileModified.Text="";
			txtTekst.Text="";
			picOrygina³.Image=picModified.Image=null;
			trkRed.Value=trkBlue.Value=trkGreen.Value=1;
			lblRed.Text=lblGreen.Text=lblBlue.Text="1";
		}

		/// <summary>
		/// Obs³uga suwaka czerwonego
		/// </summary>
		/// <param name="sender">Suwak generuj¹cy zdarzenie</param>
		/// <param name="e">Nieu¿ywany</param>
		private void trkRed_Scroll(object sender, System.EventArgs e)
		{
			lblRed.Text=trkRed.Value.ToString();
		}

		/// <summary>
		/// Obs³uga suwaka zielonego
		/// </summary>
		/// <param name="sender">Suwak generuj¹cy zdarzenie</param>
		/// <param name="e">Nieu¿ywany</param>
		private void trkGreen_Scroll(object sender, System.EventArgs e)
		{
			lblGreen.Text=trkGreen.Value.ToString();
		}

		/// <summary>
		/// Obs³uga suwaka blue
		/// </summary>
		/// <param name="sender">Suwak generuj¹cy zdarzenie</param>
		/// <param name="e">Nieu¿ywany</param>
		private void trkBlue_Scroll(object sender, System.EventArgs e)
		{
			lblBlue.Text=trkBlue.Value.ToString();
		}

		/// <summary>
		/// Obs³uga klikniêcia przycisku Z pliku...
		/// </summary>
		/// <param name="sender">Przycisk generuj¹cy zdarzenie</param>
		/// <param name="e">Nieu¿ywany</param>
		private void btnTextFromFile_Click(object sender, System.EventArgs e)
		{
			//otwiera okno dialogowe Otwórz
			DialogResult res=openFileDialog2.ShowDialog();
			if(res==DialogResult.OK)
			{//jeœli klikniêto ok
				StreamReader file;
				try
				{
					//otwórz plik
					file=new  StreamReader(openFileDialog2.FileName);
					string tmp=file.ReadToEnd();//przeczytaj ca³¹ zawartoœæ
					txtTekst.Text=tmp;//wstaw do pola tekstowego
					file.Close();
				}
				catch
				{//wyst¹pi³ b³¹d podczas otwierania pliku
					MessageBox.Show("Nie uda³o siê otworzyæ pliku: "+ openFileDialog2.FileName,"B³¹d otwarcia pliku",MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
				
			}
		}

		/// <summary>
		/// Obs³uga pozycji Zamknij w menu Plik
		/// </summary>
		/// <param name="sender">Pozycja Zamknij menu</param>
		/// <param name="e">Nieu¿ywane</param>
		private void mnuClose_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// Obs³uga przycisku Koduj, który rozpoczyna ukrywanie tekstu w obrazku
		/// </summary>
		/// <param name="sender">Przycisk Koduj</param>
		/// <param name="e">Nieu¿ywane</param>
		private void btnKoduj_Click(object sender, System.EventArgs e)
		{
			//sprawdzonko
			if(txtTekst.Text=="" || txtFile.Text=="" || txtFileModified.Text=="")
			{
				MessageBox.Show("Nie wszystkie pola zosta³y uzupe³nione","Brak danych",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			//czy wybrano obrazek
			if(picOrygina³.Image==null)
			{
				MessageBox.Show("Musisz wybraæ plik z bitmap¹, do której wiadomoœæ ma byæ zakodowana","Brak danych",MessageBoxButtons.OK,MessageBoxIcon.Information);
				return;
			}
			//utwórz obiekt klasy Koder która zajmuje siê ukrywaniem informacji
			Koder kod=new Koder(txtTekst.Text,picOrygina³.Image,trkRed.Value,trkGreen.Value,trkBlue.Value);
			int pixelCount=0;
			//oblicz czy obrazek jest wystarczaj¹co du¿y aby pomieœciæ informacjiê
			kod.Oblicz(out pixelCount);
			if(pixelCount>kod.Wynik.Height*kod.Wynik.Width)
			{//obrazek jest za ma³y
				MessageBox.Show("Wybrany obrazek jest za ma³y aby przechowaæ ca³¹ informacjê. Nale¿y wybraæ wiêkszy lub zwiêkszyæ iloœæ bitów na wiadomoœæ.","B³¹d",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			//jeœli wszystko jest ok to zakoduj
			kod.Koduj();
			//zapisz zakodowan¹ bitmapê na dysku
			kod.Wynik.Save(txtFileModified.Text);
			//wyœwietl zakodowan¹ bitmapê
			picModified.Image =kod.Wynik;
		
		}

		/// <summary>
		/// Obs³uga menu Otwórz w menu Plik
		/// </summary>
		/// <param name="sender">Pozycja menu Otwórz</param>
		/// <param name="e">Nieu¿ywane</param>
		private void mnuOpen_Click(object sender, System.EventArgs e)
		{
			DialogResult res=openFileDialog1.ShowDialog(this);
			if(res==DialogResult.OK)
			{
				ResetControls();//przywróc stan pocz¹tkowy kontrolek
				EnableControls(false);

				Koder kod=new Koder();
				try
				{
					kod.Odczytaj(openFileDialog1.FileName);
				}
				catch(InvalidFileException)
				{
					MessageBox.Show("Podana bitmapa nie zawiera informacji ukrytych!","B³¹d",MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
				trkRed.Value=kod.redBits;
				trkGreen.Value=kod.greenBits;
				trkBlue.Value=kod.blueBits;
				lblRed.Text=kod.redBits.ToString();
				lblGreen.Text=kod.greenBits.ToString();
				lblBlue.Text=kod.blueBits.ToString();
				picModified.Image =kod.Wynik;
				txtTekst.Text=kod.Message;
			}
		}

		/// <summary>
		/// Powoduje dostêpnoœæ lub niedostêpnoœæ kontrolek, zwi¹zanych z ukrywaniem informacji
		/// </summary>
		/// <param name="bEnable">Jest true gdy kontolki maj¹ byæ dostêpne</param>
		private void EnableControls(bool bEnable)
		{
			btnTextFromFile.Enabled=bEnable;
			btnKoduj.Enabled=bEnable;
			trkRed.Enabled=bEnable;
			trkGreen.Enabled=bEnable;
			trkBlue.Enabled=bEnable;
			txtFile.Enabled=bEnable;
			button1.Enabled=bEnable;
			txtFileModified.Enabled=bEnable;
			button2.Enabled=bEnable;

		}
		/// <summary>
		/// Funkcja sprawdzaj¹ca poprawnoœæ wprowadzonej nazwy pliku obrazka. Generowane jest gdy pole tekstowe traci fokus
		/// </summary>
		/// <param name="sender">Pole tekstowe generuj¹ce zdarzenie</param>
		/// <param name="e">Umo¿liwia utrzymanie fokusu na danym polu tekstowym</param>
		private void txtFile_Validating(object sender, System.ComponentModel.CancelEventArgs e)
		{//sprawdŸ czy wpisany plik istnieje
			if(File.Exists(txtFile.Text))
			{//jeœli istnieje to sprawdŸ rozsze¿enie
				if(Path.GetExtension(txtFile.Text)!=".bmp")
				{//nie jest bmp wiêc wyœwietl b³¹d
					errorProvider1.SetError(txtFile,"Podany plik nie jest bitmap¹.");
					e.Cancel=true;
					return;
				}

				try
				{//jest bmp wiêc spróbuj wyœwietliæ obrazek
					picOrygina³.Image=Image.FromFile(txtFile.Text);			
					//uda³o siê - jest Ok
					errorProvider1.SetError(txtFile,"");
				}
				catch
				{//obrazka nie uda³o siê wczytaæ
					errorProvider1.SetError(txtFile,"Nie uda³o siê otworzyæ podanego pliku.");
				}
				

			}
			else
			{//plik nie istnieje
				errorProvider1.SetError(txtFile,"Podany plik nie istnieje!");
				e.Cancel=true;
			}

			
		}

		/// <summary>
		/// Funkcja obs³uguj¹ca prze³¹czanie siê miêdzy zak³adkami
		/// </summary>
		/// <param name="sender">Reprezentuje zak³adki</param>
		/// <param name="e">Nieu¿ywane</param>
		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(tabControl1.SelectedIndex==3)/*info*/
			{//jeœli wybrano zak³adkê info to wyœwietl podsumowanie
				int pixelCount;
				Koder kod=new Koder(txtTekst.Text,picOrygina³.Image,trkRed.Value,trkGreen.Value,trkBlue.Value);
				kod.Oblicz(out pixelCount);
				if(kod.Wynik!=null)
				{
					lblPixelCount.Text=pixelCount.ToString();
					lblCharsCount.Text=txtTekst.Text.Length.ToString();
					lblPicSize.Text=kod.Wynik.Width.ToString() + "x" + kod.Wynik.Height.ToString();
				}
			}
		}

		private void mnuNatural_Click(object sender, System.EventArgs e)
		{
			mnuNatural.Checked=true;
			mnuSkaluj.Checked=false;
			picModified.SizeMode=picOrygina³.SizeMode=PictureBoxSizeMode.AutoSize;
			panel1.AutoScroll=panel2.AutoScroll=true;
		}

		private void mnuSkaluj_Click(object sender, System.EventArgs e)
		{
			mnuNatural.Checked=false;
			mnuSkaluj.Checked=true;
			
			picModified.SizeMode=picOrygina³.SizeMode=PictureBoxSizeMode.StretchImage;
			picOrygina³.Size =panel1.Size;
			panel1.AutoScroll=panel2.AutoScroll=false;
			picModified.Size=panel2.Size;
		}


		private void txtTekst_TextChanged(object sender, System.EventArgs e)
		{
			sbpInputChars.Text="Wpisano: "+(txtTekst.Text.Length).ToString()+" znaków";
		}


		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			About about=new About();
			about.ShowDialog();
		}

	}
}
