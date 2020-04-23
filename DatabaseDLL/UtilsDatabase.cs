using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DatabaseDLL
{
    public class UtilsDatabase
    {
        public static string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=CarShop.accdb";
        //static void Main(string[] args)
        //{
        //    char scelta;
        //    do
        //    {
        //        menu();
        //        Console.Write("DIGITA LA TUA SCELTA ");
        //        scelta = Console.ReadKey().KeyChar;
        //        switch (scelta)
        //        {
        //            case '1':
        //                CreateTableCars();
        //                break;
        //            case '2':
        //                AddNewCar("BMW", 36600);
        //                break;
        //            case '3':
        //                //ListCars();
        //                break;
        //            default:
        //                break;
        //        }
        //    } while (scelta != 'X' && scelta != 'x');
        //}

        //private static void menu()
        //{
        //    Console.Clear();
        //    Console.WriteLine(" CAR SHOP - DB MANAGEMENT \n");
        //    Console.WriteLine("1 - CREATE TABLE: Cars");
        //    Console.WriteLine("2 - ADD NEW ITEM: Cars");
        //    Console.WriteLine("3 - LIST: Cars");
        //    Console.WriteLine("4 - ...");
        //    Console.WriteLine("5 - ...");
        //    Console.WriteLine("\nX - FINE LAVORO\n\n");
        //}

        public static void CreateTableCars()
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    //cmd.CommandText = "DROP TABLE IF EXIST cars";
                    //cmd.ExecuteNonQuery();

                    //Creo la tabella
                    try
                    {
                        cmd.CommandText = @"CREATE TABLE cars(
                                            id int identity(1,1) NOT NULL PRIMARY KEY,
                                            type VARCHAR(255) NOT NULL,
                                            name VARCHAR(255) NOT NULL,
                                            price INT
                                            )";
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }

                    //Creata la tabella inserisco i dati
                    cmd.CommandText = "INSERT INTO cars(type, name, price) VALUES('Auto', 'Audi', 52642)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(type, name, price) VALUES('Auto', 'Mercedes', 57127)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(type, name, price) VALUES('Auto', 'Skoda', 9000)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(type, name, price) VALUES('Auto', 'Volvo', 29000)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(type, name, price) VALUES('Auto', 'Bentley', 350000)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(type, name, price) VALUES('Auto', 'Citroen', 21000)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(type, name, price) VALUES('Auto', 'Hummer', 41400)";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "INSERT INTO cars(type, name, price) VALUES('Auto', 'Volkswagen', 21600)";
                    cmd.ExecuteNonQuery();

                    Console.WriteLine("\n\nCars created with test data :)");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }

        public static void AddNewCar(string type, string carName, int carPrice)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    string badQuery = "INSERT INTO cars(type, name, price) VALUES("+ type + ", " + carName + ", " + carPrice + ")";
                    string query = "INSERT INTO cars(type, name, price) VALUES(@type, @name, @price)";
                    cmd.CommandText = query;

                    cmd.Parameters.Add(new OleDbParameter("@type", OleDbType.VarChar, 255)).Value = type;
                    cmd.Parameters.Add(new OleDbParameter("@name", OleDbType.VarChar, 255)).Value = carName;
                    cmd.Parameters.Add("@price", OleDbType.Integer).Value = carPrice;
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("\n\nCar inserted :)");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }
    }
}
