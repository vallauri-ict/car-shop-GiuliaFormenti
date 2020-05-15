using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VenditaVeicoliDLLProject;
using System.IO;
using DatabaseInstructionDLL;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
//using OpenXmlUtilities;
using Color = DocumentFormat.OpenXml.Wordprocessing.Color;
//using OpenXmlExcel;

namespace WindowsFormsAppProject
{
    public partial class FormMain : Form
    {
        private static string resourcesDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources";//Percorso della cartella "resources".
        private static string DbPath = Path.Combine(resourcesDirectoryPath, "CarShop.accdb");//Percorso del file contenente il database.
        private static string connStr = $"Provider=Microsoft.Ace.Oledb.12.0; Data Source={DbPath};";//Stringa di connessione completa al database access.
        SerializableBindingList<Veicolo> bindingListVeicoli;
        private static string file = "C:\\Users\\Giulia\\Desktop\\info\\ultimo\\VenditaVeicoli\\resources\\table.txt";

        public FormMain()
        {
            InitializeComponent();
            bindingListVeicoli = new SerializableBindingList<Veicolo>();
            listBoxVeicoli.DataSource = bindingListVeicoli;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            leggiFile();
            caricaDatiDiTest();
        }

        private void caricaDatiDiTest()
        {

            UtilsDatabase u = new UtilsDatabase(connStr);
            //u.CreateTableCars();
            //UtilsDatabase.CreateTable("Auto");
            //UtilsDatabase.CreateTable("Moto");
            //UtilsDatabase.CreateTableCars("Moto");
            //UtilsDatabase.CreateTableCars("Auto");
            if (UtilsDatabase.first)
            {
                UtilsDatabase.CreateTableCars("cars");
                UtilsDatabase.AddNewCar("Moto", "Honda", "Dominator", "Nero", 1000, 120, DateTime.Now, false, false, 0, 12000, "Quintino", 0);
                UtilsDatabase.AddNewCar("Auto", "Jeep", "Compass", "Blu", 1000, 32, DateTime.Now, false, false, 0, 32500, "/", 8);
            }
            Moto m = new Moto();
            bindingListVeicoli.Add(m);
            m = new Moto("Honda", "Dominator", "Nero", 1000, 120, DateTime.Now, false, false, 0, "Quintino");
            bindingListVeicoli.Add(m);
            //UtilsDatabase.AddNewItem("Moto", "Honda", "Dominator", "Nero", 1000, 120, DateTime.Now, false, false, 0, 12000, 0, "Quintino");
            Auto a = new Auto("Jeep", "Compass", "Blu", 1000, 32, DateTime.Now, false, false, 0, 8);
            bindingListVeicoli.Add(a);
            //UtilsDatabase.AddNewItem("Auto", "Jeep", "Compass", "Blu", 1000, 32, DateTime.Now, false, false, 0, 32500, /*"",*/ 8, "");
        }

        private void leggiFile()
        {
            using (StreamReader sr = new StreamReader(file))
            {
                String line = sr.ReadToEnd();
                if (line == "true")
                {
                    UtilsDatabase.first = true;
                }
                else
                {
                    UtilsDatabase.first = false;
                }
            }
        }

        private void nuovoToolStripButton_Click(object sender, EventArgs e)
        {
            FormDialogAggiungiVeicolo dialogAggiungi = new FormDialogAggiungiVeicolo(bindingListVeicoli);
            dialogAggiungi.ShowDialog();
        }

        private void apriToolStripButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Apri..");
            /*FILE
             * bindingListaVeicoli.Clear();
            StreamReader sr = new StreamReader("Veicoli.txt");
            string[] dato = new string[11];
            string s;

            while (sr.Peek() > -1)
            {
                s = sr.ReadLine();
                dato = s.Split('|');
                if (dato[0] == "Moto: ")
                {
                    Moto m = new Moto(dato[1], dato[2], dato[3], Convert.ToInt32(dato[4]), Convert.ToDouble(dato[5]), Convert.ToDateTime(dato[6]), dato[7] == "No"? false : true, dato[8] == "Si"? true : false, Convert.ToInt32(dato[9]), dato[10]);
                    bindingListaVeicoli.Add(m);
                }
                else
                {
                    Auto a = new Auto(dato[1], dato[2], dato[3], Convert.ToInt32(dato[4]), Convert.ToDouble(dato[5]), Convert.ToDateTime(dato[6]), dato[7] == "No" ? false : true, dato[8] == "Si" ? true : false, Convert.ToInt32(dato[9]), Convert.ToInt32(dato[10]));
                    bindingListaVeicoli.Add(a);
                }
            }
            sr.Close();*/

            //JSON
            Utils.DeserializeJson(bindingListVeicoli, @".\Veicoli.json");
        }

        private void salvaToolStripButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Salva..");
            /*FILE
             * StreamWriter sw = new StreamWriter("Veicoli.txt", false);
            string s = null;
            foreach (var item in bindingListaVeicoli)
            {
                if (item == (item as Moto))
                {
                    s = "Moto: | " + item.Marca + " | " + item.Modello + " | " + item.Colore + " | " + Convert.ToInt32(item.Cilindrata) + " | " + Convert.ToDouble(item.PotenzaKw) + " | " + Convert.ToDateTime(item.Immatricolazione) + " | " + Convert.ToBoolean(item.IsUsato) + " | " + Convert.ToBoolean(item.IsKmZero) + " | " + Convert.ToInt32(item.KmPercorsi) + " | " + (item as Moto).MarcaSella;
                    sw.WriteLine(s);
                }
                else
                {
                    s = "Auto: | " + item.Marca + " | " + item.Modello + " | " + item.Colore + " | " + Convert.ToInt32(item.Cilindrata) + " | " + Convert.ToDouble(item.PotenzaKw) + " | " + Convert.ToDateTime(item.Immatricolazione) + " | " + Convert.ToBoolean(item.IsUsato) + " | " + Convert.ToBoolean(item.IsKmZero) + " | " + Convert.ToInt32(item.KmPercorsi) + " | " + (item as Auto).NumAirbag;
                    sw.WriteLine(s);
                }
            }
            sw.Close();
            MessageBox.Show("Dati salvati! :)");*/

            //CSV
            Utils.SerializeToCsv(bindingListVeicoli, @".\Veicoli.csv");

            //XML
            Utils.SerializeToXml(bindingListVeicoli, @".\Veicoli.xml");

            //JSON
            Utils.SerializeToJson(bindingListVeicoli, @".\Veicoli.json");
        }

        private void stampaToolStripButton_Click(object sender, EventArgs e)
        {
            string homepagePath = @".\www\index.html";
            Utils.CreateHtml(bindingListVeicoli, homepagePath);
            System.Diagnostics.Process.Start(homepagePath);
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            using (StreamWriter sw = new StreamWriter("table.txt"))
            {
                sw.WriteLine(UtilsDatabase.first.ToString());
            }
        }

        private void wordToolStripMenu_Click(object sender, EventArgs e)
        {
            try
            {
                string filepath = "C:\\Users\\Giulia\\Desktop\\info\\ultimo\\VenditaVeicoli\\resources\\fileWord.docx";
                string msg = "Lista veicoli disponibili:";
                using (WordprocessingDocument doc = WordprocessingDocument.Create(filepath,
                                    DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
                {
                    // Add a main document part. 
                    MainDocumentPart mainPart = doc.AddMainDocumentPart();

                    // Create the document structure and add some text.
                    mainPart.Document = new Document();
                    Body body = mainPart.Document.AppendChild(new Body());

                    // Define the styles
                    //addHeading1Style(mainPart, "FF0000", "Arial", "28");
                    ClsOpenXmlUtilities.AddStyle(mainPart, "MyHeading1", "Titolone", "0000FF", "Verdana", 28, false, true, true);
                    ClsOpenXmlUtilities.AddStyle(mainPart, "MyTypeScript", "Macchina da scrivere", "333333", "Consolas", 12, true, false, false);

                    // Add heading
                    Paragraph headingPar = ClsOpenXmlUtilities.CreateParagraphWithStyle("MyHeading1", JustificationValues.Center);
                    ClsOpenXmlUtilities.AddTextToParagraph(headingPar, "AUTOSALONE AUTO E MOTO");
                    body.AppendChild(headingPar);

                    //Add MyTypeScript
                    Paragraph typeScriptPar = ClsOpenXmlUtilities.CreateParagraphWithStyle("MyTypeScript", JustificationValues.Center);
                    ClsOpenXmlUtilities.AddTextToParagraph(typeScriptPar, "AUTOSALONE AUTO E MOTO - VENDITA VEICOLI NUOVI E USATI");
                    body.AppendChild(typeScriptPar);

                    // Add simple text
                    Paragraph para = body.AppendChild(new Paragraph());
                    Run run = para.AppendChild(new Run());
                    // String msg contains the text, "Hello, Word!"
                    run.AppendChild(new Text(msg));

                    // Add heading
                    //headingPar = ClsOpenXmlUtilities.createHeading("Testo con stili");
                    //body.AppendChild(headingPar);

                    // Append a paragraph with styles
                    //Paragraph newPar = createParagraphWithStyles();
                    //body.AppendChild(newPar);

                    // Append a table
                    //Table myTable = ClsOpenXmlUtilities.createTable(3, 3, "ok");
                    //body.Append(myTable);

                    // Append bullet list
                    ClsOpenXmlUtilities.createBulletNumberingPart(mainPart, "-");
                    string[] veicoli = new string[bindingListVeicoli.Count];
                    int v = 0;
                    foreach (var item in bindingListVeicoli)
                    {
                        veicoli[v++] = item.Marca + " " + item.Modello;
                    }
                    List<Paragraph> bulletList = ClsOpenXmlUtilities.createList(bindingListVeicoli.Count, veicoli, "bullet", "0", "100", "200");/*createBulletList(4, "yes");*/
                    foreach (Paragraph paragraph in bulletList)
                    {
                        body.Append(paragraph);
                    }

                    // Append numbered list
                    //List<Paragraph> numberedList = ClsOpenXmlUtilities.createList(3, "numbered", "numbered", "0", "100", "240");/*createNumberedList();*/
                    //foreach (Paragraph paragraph in numberedList)
                    //{
                    //    body.Append(paragraph);
                    //}

                    // Append image
                    //ClsOpenXmlUtilities.InsertPicture(doc, "panorama.jpg");
                }
                MessageBox.Show("Il documento è pronto!");
                System.Diagnostics.Process.Start(filepath);
            }
            catch (Exception)
            {
                MessageBox.Show("Problemi col documento. Se è aperto da un altro programma, chiudilo e riprova...");
            }
        }

        private Paragraph createParagraphWithStyles()
        {
            Paragraph p = new Paragraph();
            // Set the paragraph properties
            ParagraphProperties pp = new ParagraphProperties(new ParagraphStyleId() { Val = "Titolo1" });
            pp.Justification = new Justification() { Val = JustificationValues.Center };
            // Add paragraph properties to your paragraph
            p.Append(pp);

            // Run 1
            Run r1 = new Run();
            Text t1 = new Text("Pellentesque ") { Space = SpaceProcessingModeValues.Preserve };
            // The Space attribute preserve white space before and after your text
            r1.Append(t1);
            p.Append(r1);

            // Run 2 - Bold
            Run r2 = new Run();
            RunProperties rp2 = new RunProperties();
            rp2.Bold = new Bold();
            // Always add properties first
            r2.Append(rp2);
            Text t2 = new Text("grassetto ") { Space = SpaceProcessingModeValues.Preserve };
            r2.Append(t2);
            p.Append(r2);

            // Run 3
            Run r3 = new Run();
            Text t3 = new Text("rhoncus ") { Space = SpaceProcessingModeValues.Preserve };
            r3.Append(t3);
            p.Append(r3);

            // Run 4 – Italic
            Run r4 = new Run();
            RunProperties rp4 = new RunProperties();
            rp4.Italic = new Italic();
            // Always add properties first
            r4.Append(rp4);
            Text t4 = new Text("italico") { Space = SpaceProcessingModeValues.Preserve };
            r4.Append(t4);
            p.Append(r4);

            // Run 5
            Run r5 = new Run();
            Text t5 = new Text(", sit ") { Space = SpaceProcessingModeValues.Preserve };
            r5.Append(t5);
            p.Append(r5);

            // Run 6 – Italic , bold and underlined
            Run r6 = new Run();
            RunProperties rp6 = new RunProperties();
            rp6.Italic = new Italic();
            rp6.Bold = new Bold();
            rp6.Underline = new Underline() { Val = UnderlineValues.WavyDouble };
            // Always add properties first
            r6.Append(rp6);
            Text t6 = new Text("grasseto, italico, sottolineato ") { Space = SpaceProcessingModeValues.Preserve };
            r6.Append(t6);
            p.Append(r6);

            // Run 7
            Run r7 = new Run();
            Text t7 = new Text("faucibus arcu ") { Space = SpaceProcessingModeValues.Preserve };
            r7.Append(t7);
            p.Append(r7);

            // Run 8 – Red color
            Run r8 = new Run();
            RunProperties rp8 = new RunProperties();
            rp8.Color = new Color() { Val = "FF0000" };
            // Always add properties first
            r8.Append(rp8);
            Text t8 = new Text("rosso ") { Space = SpaceProcessingModeValues.Preserve };
            r8.Append(t8);
            p.Append(r8);

            // Run 9
            Run r9 = new Run();
            Text t9 = new Text("pharetra. Maecenas quis erat quis eros iaculis placerat ut at mauris.") { Space = SpaceProcessingModeValues.Preserve };
            r9.Append(t9);
            p.Append(r9);

            // return the new paragraph
            return p;
        }
    }
}