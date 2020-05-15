using System;
using System.IO;
using VenditaVeicoliDLLProject;
using DatabaseInstructionDLL;

namespace ConsoleAppProject
{
    class Program
    {
        private static string resourcesDirectoryPath = $"{Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName}\\resources";//Percorso della cartella "resources".
        private static string DbPath = Path.Combine(resourcesDirectoryPath, cliDatabase.Properties.Resources.dbName);//Percorso del file contenente il database.
        private static string connStr = $"Provider=Microsoft.Ace.Oledb.12.0; Data Source={DbPath};";//Stringa di connessione completa al database access.
        private static string veicolo;
        private static string marca;
        public static string modello;
        public static string colore;
        public static int cilindrata;
        public static double potenza;
        public static DateTime immatricolazione;
        public static bool usata;
        public static bool kmZero;
        public static int kmPercorsi;
        public static string marcaSella;
        public static int numAirbag;
        private static int prezzo;
        private static string tab;

        static void Main(string[] args)
        {
            UtilsDatabase u = new UtilsDatabase(connStr);
            //u.CreateTableCars();

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
                        UtilsDatabase.CreateTableCars("cars");
                        break;
                    case '2':
                        setParameters();
                        if (veicolo == "Moto")
                        {
                            UtilsDatabase.AddNewCar("cars", veicolo, marca, modello, colore, cilindrata, potenza, immatricolazione, usata, kmZero, kmPercorsi, prezzo, marcaSella);
                        }
                        else
                        {
                            UtilsDatabase.AddNewCar("cars", veicolo, marca, modello, colore, cilindrata, potenza, immatricolazione, usata, kmZero, kmPercorsi, prezzo, numAirbag.ToString());

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
                        UtilsDatabase.DropTable("cars");
                        break;
                    default:
                        break;
                }
            } while (scelta != 'X' && scelta != 'x');
        }

        private static void menu()
        {
            Console.Clear();
            Console.WriteLine(" CAR SHOP - DB MANAGEMENT \n");
            Console.WriteLine("1 - CREAZIONE TABELLA Cars");
            Console.WriteLine("2 - AGGIUNGERE UN NUOVO ELEMENTO in Cars");
            Console.WriteLine("3 - ELIMINARE UN ELEMENTO da Cars");
            Console.WriteLine("4 - ELIMINARE LA TABELLA Cars");
            Console.WriteLine("\nX - FINE\n\n");
        }

        public static void setParameters()
        {
            object aus;

            Console.Write("Auto o Moto? ");
            marca = Console.ReadLine();

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
            bool flag;
            if (Boolean.TryParse(Console.ReadLine(), out flag))
            {
                usata = Convert.ToBoolean(Console.ReadLine());
            }
                
            else
            {
                usata = false;
                Console.WriteLine("Input non valido: impostato il valore di default di " + usata);
            }

            Console.Write("E' KM 0? ");
            bool flag2;
            
            if (Boolean.TryParse(Console.ReadLine(), out flag2))
            {
                kmZero = Convert.ToBoolean(Console.ReadLine());
            }

            else
            {
                kmZero = true;
                Console.WriteLine("Input non valido: impostato il valore di default di " + kmZero);
            }

            Console.Write("KM percorsi: ");
            aus = Console.ReadLine();
            if (Double.IsNaN(Convert.ToDouble(aus)))
            {
                kmPercorsi = 1000;
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
            }
            else
            {
                Console.Write("Numero airbag: ");
                aus = Console.ReadLine();
                if (Double.IsNaN(Convert.ToDouble(aus)))
                {
                    numAirbag = 1000;
                    Console.WriteLine("Input non valido: impostato il valore di default di " + numAirbag);
                }
                else
                {
                    numAirbag = Convert.ToInt32(aus);
                }
            }
        }
    }
}