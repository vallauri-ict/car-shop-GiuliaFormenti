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
using DatabaseDLL;

namespace WindowsFormsAppProject
{
    public partial class FormMain : Form
    {
        SerializableBindingList<Veicolo> bindingListVeicoli;

        public FormMain()
        {
            InitializeComponent();
            bindingListVeicoli = new SerializableBindingList<Veicolo>();
            listBoxVeicoli.DataSource = bindingListVeicoli;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            caricaDatiDiTest();
        }

        private void caricaDatiDiTest()
        {
            UtilsDatabase.CreateTableCars();
            Moto m = new Moto();
            bindingListVeicoli.Add(m);
            m = new Moto("Honda", "Dominator", "Nero", 1000, 120, DateTime.Now, false, false, 0, "Quintino");
            bindingListVeicoli.Add(m);
            UtilsDatabase.AddNewCar("Moto", "Honda", 12000);
            Auto a = new Auto("Jeep", "Compass", "Blu", 1000, 32, DateTime.Now, false, false, 0, 8);
            bindingListVeicoli.Add(a);
            UtilsDatabase.AddNewCar("Auto", "Jeep", 32500);
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
    }
}