using System;
using System.IO;
using VenditaVeicoliDLLProject;
using DatabaseInstructionDLL;
using System.Data.OleDb;

namespace ConsoleAppProject
{
    class Program
    {
        private static string resourcesDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources";//Percorso della cartella "resources".
        private static string DbPath = Path.Combine(resourcesDirectoryPath, cliDatabase.Properties.Resources.dbName);//Percorso del file contenente il database.
        private static string connStr = $"Provider=Microsoft.Ace.Oledb.12.0; Data Source={DbPath};";//Stringa di connessione completa al database access.
        private static string veicolo;
        private static string marca;
        private static string modello;
        private static string colore;
        private static int cilindrata;
        private static double potenza;
        private static DateTime immatricolazione;
        private static bool usata;
        private static bool kmZero;
        private static int kmPercorsi;
        private static string marcaSella;
        private static int numAirbag;
        private static int prezzo;
        private static string tab;
        private static string file = "C:\\Users\\Giulia\\Desktop\\info\\ultimo\\VenditaVeicoli\\resources\\table.txt";

        static void Main(string[] args)
        {
            UtilsDatabase u = new UtilsDatabase(connStr);
            //u.CreateTableCars();
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

            Console.WriteLine("*** SALONE VENDITA VEICOLI NUOVI E USATI ***");
            //Moto m = new Moto();
            //Console.WriteLine(m);

            //Auto a = new Auto();
            //Console.WriteLine(a);


            char scelta;
            do
            {
                menu();
                Console.Write("DIGITA LA TUA SCELTA ");
                scelta = Console.ReadKey().KeyChar;
                switch (scelta)
                {
                    case '1':
                        if (UtilsDatabase.first)
                        {
                            UtilsDatabase.CreateTableCars("cars");
                        }
                        else
                        {
                            Console.WriteLine("\nLa tabella cars è già esistente\n\n\n");
                        }
                        break;
                    case '2':
                        setParameters();
                        if (veicolo == "Moto")
                        {
                            UtilsDatabase.AddNewCar(veicolo, marca, modello, colore, cilindrata, potenza, immatricolazione, usata, kmZero, kmPercorsi, prezzo, marcaSella, 0);
                        }
                        else
                        {
                            UtilsDatabase.AddNewCar(veicolo, marca, modello, colore, cilindrata, potenza, immatricolazione, usata, kmZero, kmPercorsi, prezzo, "", numAirbag);
                        }
                        break;
                    case '3':
                        int id;
                        Console.WriteLine("\nId da eliminare: ");
                        object aus = Console.ReadLine();
                        if (Double.IsNaN(Convert.ToDouble(aus)))
                        {
                            Console.WriteLine("Input non valido");
                        }
                        else
                        {
                            id = Convert.ToInt32(aus);
                            UtilsDatabase.DeleteElement("cars", id);
                        }
                        break;
                    case '4':
                        DropTable("cars");
                        break;
                    case '5':
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
            using (StreamWriter sw = new StreamWriter(file))
            {
                sw.WriteLine(UtilsDatabase.first.ToString());
            }
        }

        private static void menu()
        {
            Console.WriteLine(" CAR SHOP - DB MANAGEMENT \n");
            Console.WriteLine("1 - CREAZIONE TABELLA Cars");
            Console.WriteLine("2 - AGGIUNGERE UN NUOVO ELEMENTO in Cars");
            Console.WriteLine("3 - ELIMINARE UN ELEMENTO da Cars");
            Console.WriteLine("4 - ELIMINARE LA TABELLA Cars");
            Console.WriteLine("5 - CLEAR CONSOLE");
            Console.WriteLine("\nX - FINE\n\n");
        }

        public static void setParameters()
        {
            if (UtilsDatabase.first)
            {
                Console.WriteLine("Non è stata ancora creata la tabella");
                UtilsDatabase.CreateTableCars("cars");
            }
            object aus;

            Console.Write("Auto o Moto? ");
            veicolo = Console.ReadLine();
            if (!((veicolo == "Moto") || (veicolo == "Auto")))
            {
                veicolo = "Moto";
                Console.WriteLine("Input invalido: impostato come valore di default " + veicolo);
            }

            Console.Write("Marca: ");
            marca = Console.ReadLine();

            Console.Write("Modello: ");
            modello = Console.ReadLine();

            Console.Write("Colore: ");
            colore = Console.ReadLine();

            Console.Write("Cilindrata: ");
            aus = Console.ReadLine();
            if (Double.IsNaN(Convert.ToDouble(aus)))
            {
                cilindrata = 1000;
                Console.WriteLine("Input non valido: impostato il valore di default di " + cilindrata);
            }
            else
            {
                cilindrata = Convert.ToInt32(aus);
            }

            Console.Write("Potenza: ");
            aus = Console.ReadLine();
            if (Double.IsNaN(Convert.ToDouble(aus)))
            {
                potenza = 1000;
                Console.WriteLine("Input non valido: impostato il valore di default di " + potenza);
            }
            else
            {
                potenza = Convert.ToDouble(aus);
            }

            Console.Write("Immatricolazione: ");
            immatricolazione = Convert.ToDateTime(Console.ReadLine());

            Console.Write("E' usata? ");
            aus = Console.ReadLine();
            if (aus.ToString().ToUpper() == "SI")
            {
                usata = true;
            }
            else if (aus.ToString().ToUpper() == "NO")
            {
                usata = false;
            }
            else
            {
                usata = false;
                Console.WriteLine("Input non valido: impostato il valore di default di " + usata);
            }
            //bool flag;
            //if (Boolean.TryParse(Console.ReadLine(), out flag))
            //{
            //    usata = Convert.ToBoolean(Console.ReadLine());
            //}

            //else
            //{
            //    usata = false;
            //    Console.WriteLine("Input non valido: impostato il valore di default di " + usata);
            //}

            Console.Write("E' KM 0? ");
            aus = Console.ReadLine();
            if (aus.ToString().ToUpper() == "SI")
            {
                kmZero = true;
            }
            else if (aus.ToString().ToUpper() == "NO")
            {
                kmZero = false;
            }
            else
            {
                kmZero = false;
                Console.WriteLine("Input non valido: impostato il valore di default di " + kmZero);
            }

            Console.Write("KM percorsi: ");
            aus = Console.ReadLine();
            if (Double.IsNaN(Convert.ToDouble(aus)))
            {
                kmPercorsi = 0;
                Console.WriteLine("Input non valido: impostato il valore di default di " + kmPercorsi);
            }
            else
            {
                kmPercorsi = Convert.ToInt32(aus);
            }

            Console.Write("Prezzo: ");
            aus = Console.ReadLine();
            if (Double.IsNaN(Convert.ToDouble(aus)))
            {
                prezzo = 1000;
                Console.WriteLine("Input non valido: impostato il valore di default di " + prezzo);
            }
            else
            {
                prezzo = Convert.ToInt32(aus);
            }

            if (veicolo == "Moto")
            {
                Console.Write("Marca della sella: ");
                marcaSella = Console.ReadLine();
                numAirbag = 0;
            }
            else
            {
                Console.Write("Numero airbag: ");
                aus = Console.ReadLine();
                if (Double.IsNaN(Convert.ToDouble(aus)))
                {
                    numAirbag = 4;
                    Console.WriteLine("Input non valido: impostato il valore di default di " + numAirbag);
                }
                else
                {
                    numAirbag = Convert.ToInt32(aus);
                }
                marcaSella = "/";
            }
        }

        private static void DropTable(string name)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    UtilsDatabase.first = true;
                    con.Open();
                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    string command = $"DROP TABLE {name}";
                    cmd.CommandText = command;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}