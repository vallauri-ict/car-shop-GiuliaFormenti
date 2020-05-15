using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;

namespace DatabaseInstructionDLL
{
    public class UtilsDatabase
    {
        public static string connStr;

        public UtilsDatabase(string con)
        {
            connStr = con;
        }

        public static void CreateTableCars(string name)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    //Creo la tabella
                    try
                    {
                        cmd.CommandText = $@"CREATE TABLE {name}(
                                            id int identity(1,1) NOT NULL PRIMARY KEY,
                                            type VARCHAR(255) NOT NULL, marca VARCHAR(255) NOT NULL,
                                            modello VARCHAR(255) NOT NULL, colore VARCHAR(255) NOT NULL,
                                            cilindrata INT NOT NULL, potenza INT NOT NULL,
                                            immatricolazione DATE NOT NULL, usata VARCHAR(255) NOT NULL,
                                            kmZero VARCHAR(255) NOT NULL, kmPercorsi VARCHAR(255) NOT NULL,
                                            prezzo INT marcaSella VARCHAR(255), numAirbag INT)";
                        cmd.ExecuteNonQuery();
                    }
                    catch (OleDbException exc)
                    {
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }
                }
            }
        }

        public static void AddNewCar(string name, string type, string marca, string modello, string colore, int cilindrata, double potenza, DateTime immatricolazine, bool usata, bool kmZero, int kmFatti, double prezzo, string extra)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;

                    int nAirbag = 0;
                    //string badQuery = "INSERT INTO cars(type, name, price) VALUES(" + type + ", " + carName + ", " + carPrice + ")";
                    string query = "";
                    if (type == "Moto")
                    {
                        query = $"INSERT INTO {name}(type, marca, modello, colore, cilindrata, potenza, immatricolazione, usata, kmZero, kmPercorsi, prezzo, marcaSella) VALUES(@type, @marca, @modello, @colore, @cilindrata, @potenza, @immatricolazione, @usata, @kmZero, @kmPercorsi, @prezzo, @extra)";
                    }
                    else
                    {
                        nAirbag = Convert.ToInt32(extra);
                        query = $"INSERT INTO {name}(type, marca, modello, colore, cilindrata, potenza, immatricolazione, usata, kmZero, kmPercorsi, prezzo, numAirbag) VALUES(@type, @marca, @modello, @colore, @cilindrata, @potenza, @immatricolazione, @usata, @kmZero, @kmPercorsi, @prezzo, @nAirbag)";
                    }
                    cmd.CommandText = query;

                    string used = usata ? "Si" : "No";
                    string km0 = kmZero ? "Si" : "No";
                    cmd.Parameters.Add(new OleDbParameter("@type", OleDbType.VarChar, 255)).Value = type;
                    cmd.Parameters.Add(new OleDbParameter("@marca", OleDbType.VarChar, 255)).Value = marca;
                    cmd.Parameters.Add(new OleDbParameter("@modello", OleDbType.VarChar, 255)).Value = modello;
                    cmd.Parameters.Add(new OleDbParameter("@colore", OleDbType.VarChar, 255)).Value = colore;
                    cmd.Parameters.Add("@displacement", OleDbType.Integer).Value = cilindrata;
                    cmd.Parameters.Add("@powerKw", OleDbType.Integer).Value = potenza;
                    cmd.Parameters.Add(new OleDbParameter("@matriculation", OleDbType.Date)).Value = immatricolazine.ToShortDateString();
                    cmd.Parameters.Add(new OleDbParameter("@isUsed", OleDbType.VarChar, 255)).Value = used;
                    cmd.Parameters.Add(new OleDbParameter("@isKm0", OleDbType.VarChar, 255)).Value = km0;
                    cmd.Parameters.Add("@kmFatti", OleDbType.Integer).Value = kmFatti;
                    cmd.Parameters.Add("@price", OleDbType.Double).Value = prezzo;
                    if (type == "Auto")
                        cmd.Parameters.Add("@numAirbag", OleDbType.Integer).Value = nAirbag;
                    else
                        cmd.Parameters.Add("@marcaSella", OleDbType.VarChar, 255).Value = extra;
                    cmd.Prepare();

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("\n\nCar inserted");
                    System.Threading.Thread.Sleep(3000);
                }
            }
        }
        public static void DropTable(string name)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;
                    string command = $"DROP TABLE {name}";
                    cmd.CommandText = command;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void DeleteElement(string name, int id)
        {
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand($"DELETE FROM {name} WHERE id={id}", con);

                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}