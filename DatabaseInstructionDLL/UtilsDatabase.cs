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
        public static bool ok = true;

        public UtilsDatabase(string con)
        {
            connStr = con;
        }

        public static void CreateTableCars(string name = "cars")
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
                        ok = true;
                        cmd.CommandText = $@"CREATE TABLE {name}(
                                            id INT identity(1,1) NOT NULL PRIMARY KEY,
                                            type VARCHAR(255) NOT NULL, marca VARCHAR(255) NOT NULL,
                                            modello VARCHAR(255) NOT NULL, colore VARCHAR(255),
                                            cilindrata INT, potenza INT,
                                            immatricolazione DATE, usato VARCHAR(255),
                                            kmZero VARCHAR(255), kmPercorsi VARCHAR(255),
                                            prezzo INT, marcaSella VARCHAR(255), numAirbag INT);";
                        cmd.ExecuteNonQuery();
                        //string command = $@"CREATE TABLE {tableName}(
                        //        id INT identity(1,1) NOT NULL PRIMARY KEY,
                        //        marca VARCHAR(255) NOT NULL, modello VARCHAR(255) NOT NULL,
                        //        colore VARCHAR(255), cilindrata INT, potenzaKw INT,
                        //        immatricolazione DATE, usato VARCHAR(255), kmZero VARCHAR(255),
                        //        kmPercorsi INT, prezzo MONEY,";
                    }
                    catch (OleDbException exc)
                    {
                        ok = false;
                        Console.WriteLine("\n\n" + exc.Message);
                        System.Threading.Thread.Sleep(3000);
                        return;
                    }
                }
            }
        }
        //public static void CreateTable(string tableName)
        //{
        //    if (first)
        //    {
        //        first = false;
        //        CreateTable("Auto");
        //        CreateTable("Moto");
        //    }
        //    if (connStr != null)
        //    {
        //        string command = "";
        //        OleDbConnection con = new OleDbConnection(connStr);
        //        using (con)
        //        {
        //            con.Open();

        //            OleDbCommand cmd = new OleDbCommand();
        //            cmd.Connection = con;

        //            // identity(1,1) auto-increment 
        //            try
        //            {
        //                command = $@"CREATE TABLE {tableName}(
        //                        id INT identity(1,1) NOT NULL PRIMARY KEY,
        //                        marca VARCHAR(255) NOT NULL, modello VARCHAR(255) NOT NULL,
        //                        colore VARCHAR(255), cilindrata INT, potenzaKw INT,
        //                        immatricolazione DATE, usato VARCHAR(255), kmZero VARCHAR(255),
        //                        kmPercorsi INT, prezzo MONEY,";
        //                if (tableName == "Auto") command += " numAirbag INT,";
        //                else command += " marcaSella VARCHAR(255))";
        //                cmd.CommandText = command;
        //                cmd.ExecuteNonQuery();
        //                ok1 = "ok";
        //            }
        //            catch (OleDbException ex)
        //            {
        //                Console.WriteLine($"\n\n{ex.Message}");
        //                System.Threading.Thread.Sleep(3000);
        //                return;
        //            }
        //        }
        //    }
        //}

        //public static void AddNewItem(string tableName, string brand, string model, string color, int displacement, double powerKw, DateTime matriculation, bool isUsed, bool isKm0, int kmDone, double price, int numAirbag, string saddleBrand)
        //{
        //    if (connStr != null)
        //    {
        //        OleDbConnection con = new OleDbConnection(connStr);
        //        using (con)
        //        {
        //            con.Open();

        //            OleDbCommand cmd = new OleDbCommand();
        //            cmd.Connection = con;
        //            string command = string.Empty;
        //            if (tableName == "Auto")
        //            {
        //                command = $"INSERT INTO {tableName}(marca, modello, colore, cilindrata, potenzaKw, immatricolazione, usato, kmZero, kmPercorsi, prezzo, numAirbag) VALUES(@brand, @model, @color, @displacement, @powerKw, @matriculation, @isUsed, @isKm0, @kmDone, @price, @numAirbag)";
        //                ok2 = "ok";
        //            }
        //            else
        //            {
        //                command = $"INSERT INTO {tableName}(marca, modello, colore, cilindrata, potenzaKw, immatricolazione, usato, kmZero, kmPercorsi, prezzo, marcaSella) VALUES(@brand, @model, @color, @displacement, @powerKw, @matriculation, @isUsed, @isKm0, @kmDone, @price, @saddleBrand)";
        //                ok3 = "ok";
        //            }
        //            cmd.CommandText = command;

        //            string used = isUsed ? "Si" : "No";
        //            string km0 = isKm0 ? "Si" : "No";
        //            cmd.Parameters.Add(new OleDbParameter("@brand", OleDbType.VarChar, 255)).Value = brand;
        //            cmd.Parameters.Add(new OleDbParameter("@model", OleDbType.VarChar, 255)).Value = model;
        //            cmd.Parameters.Add(new OleDbParameter("@color", OleDbType.VarChar, 255)).Value = color;
        //            cmd.Parameters.Add("@displacement", OleDbType.Integer).Value = displacement;
        //            cmd.Parameters.Add("@powerKw", OleDbType.Integer).Value = powerKw;
        //            cmd.Parameters.Add(new OleDbParameter("@matriculation", OleDbType.Date)).Value = matriculation.ToShortDateString();
        //            cmd.Parameters.Add(new OleDbParameter("@isUsed", OleDbType.VarChar, 255)).Value = used;
        //            cmd.Parameters.Add(new OleDbParameter("@isKm0", OleDbType.VarChar, 255)).Value = km0;
        //            cmd.Parameters.Add("@kmDone", OleDbType.Integer).Value = kmDone;
        //            cmd.Parameters.Add("@price", OleDbType.Double).Value = price;
        //            if (tableName == "Auto")
        //                cmd.Parameters.Add("@numAirbag", OleDbType.Integer).Value = numAirbag;
        //            else
        //                cmd.Parameters.Add(new OleDbParameter("@saddleBrand", OleDbType.VarChar, 255)).Value = saddleBrand;
        //            cmd.Prepare();

        //            cmd.ExecuteNonQuery();
        //        }

        //    }
        //}


        public static void AddNewCar(string type, string brand, string modello, string colore, int cilindrata, double potenza, DateTime immatricolazine, bool usato, bool kmZero, int kmPercorsi, double prezzo, string marcaSella, int numAirbag,/*string extra,*/ string name = "cars")
        {
            //id = cont++;
            if (connStr != null)
            {
                OleDbConnection con = new OleDbConnection(connStr);
                using (con)
                {
                    con.Open();

                    OleDbCommand cmd = new OleDbCommand();
                    cmd.Connection = con;


                    //string badQuery = "INSERT INTO cars(type, name, price) VALUES(" + type + ", " + carName + ", " + carPrice + ")";
                    string query = "";
                    //if (type == "Moto")
                    //{
                    //    query = $"INSERT INTO {name}(type, marca, modello, colore, cilindrata, potenza, immatricolazione, usata, kmZero, kmPercorsi, prezzo, marcaSella) VALUES(@type, @marca, @modello, @colore, @cilindrata, @potenza, @immatricolazione, @usata, @kmZero, @kmPercorsi, @prezzo, @extra)";
                    //}
                    //else
                    //{
                    //    nAirbag = Convert.ToInt32(extra);
                    //    query = $"INSERT INTO {name}(type, marca, modello, colore, cilindrata, potenza, immatricolazione, usata, kmZero, kmPercorsi, prezzo, numAirbag) VALUES(@type, @marca, @modello, @colore, @cilindrata, @potenza, @immatricolazione, @usata, @kmZero, @kmPercorsi, @prezzo, @nAirbag)";
                    //}
                    //cmd.CommandText = query;

                    //string used = usato ? "Si" : "No";
                    //string km0 = kmZero ? "Si" : "No";
                    //cmd.Parameters.Add(new OleDbParameter("@type", OleDbType.VarChar, 255)).Value = type;
                    ////cmd.Parameters.Add(new OleDbParameter("@marca", OleDbType.VarChar, 255)).Value = marca;
                    //cmd.Parameters.Add(new OleDbParameter("@modello", OleDbType.VarChar, 255)).Value = modello;
                    //cmd.Parameters.Add(new OleDbParameter("@colore", OleDbType.VarChar, 255)).Value = colore;
                    //cmd.Parameters.Add("@displacement", OleDbType.Integer).Value = cilindrata;
                    //cmd.Parameters.Add("@powerKw", OleDbType.Integer).Value = potenza;
                    //cmd.Parameters.Add(new OleDbParameter("@matriculation", OleDbType.Date)).Value = immatricolazine.ToShortDateString();
                    //cmd.Parameters.Add(new OleDbParameter("@isUsed", OleDbType.VarChar, 255)).Value = used;
                    //cmd.Parameters.Add(new OleDbParameter("@isKm0", OleDbType.VarChar, 255)).Value = km0;
                    //cmd.Parameters.Add("@kmFatti", OleDbType.Integer).Value = kmFatti;
                    //cmd.Parameters.Add("@price", OleDbType.Double).Value = prezzo;
                    //if (type == "Auto")
                    //    cmd.Parameters.Add("@numAirbag", OleDbType.Integer).Value = nAirbag;
                    //else
                    //    cmd.Parameters.Add("@marcaSella", OleDbType.VarChar, 255).Value = extra;





                    //int numAirbag = 0;
                    //string marcaSella = "";
                    if (type == "Auto")
                    {
                        //numAirbag = Convert.ToInt32(extra);
                        //marcaSella = "/";
                        //query = $"INSERT INTO {name}(type, marca, modello, colore, cilindrata, potenzaKw, immatricolazione, usato, kmZero, kmPercorsi, prezzo, marcaSella, numAirbag) VALUES(@type, @marca, @modello, @colore, @cilindrata, @potenza, @immatricolazione, @usato, @kmZero, @kmPercorsi, @prezzo, @marcaSella, @numAirbag)";
                        query = $"INSERT INTO {name}(type, marca, modello, colore, cilindrata, potenza, immatricolazione, usato, kmZero, kmPercorsi, prezzo, marcaSella, numAirbag)" +
                            " VALUES(@type, @marca, @modello, @colore, @cilindrata, @potenza, @immatricolazine, @usato, @kmZero, @kmPercorsi, @prezzo, @marcaSella, @numAirbag);";
                    }
                    else
                    {
                        //numAirbag = 0;
                        //marcaSella = extra.ToString();
                        //query = $"INSERT INTO {name}(type, marca, modello, colore, cilindrata, potenzaKw, immatricolazione, usato, kmZero, kmPercorsi, prezzo, marcaSella, numAirbag) VALUES(@type, @marca, @modello, @colore, @cilindrata, @potenza, @immatricolazione, @usato, @kmZero, @kmPercorsi, @prezzo, @marcaSella, @numAirbag)";
                        query = $"INSERT INTO {name}(type, marca, modello, colore, cilindrata, potenza, immatricolazione, usato, kmZero, kmPercorsi, prezzo, marcaSella, numAirbag)" +
                            " VALUES(@type, @marca, @modello, @colore, @cilindrata, @potenza, @immatricolazine, @usato, @kmZero, @kmPercorsi, @prezzo, @marcaSella, @numAirbag);";
                    }
                    cmd.CommandText = query;

                    string used = usato ? "Si" : "No";
                    string km0 = kmZero ? "Si" : "No";
                    //cmd.Parameters.Add("@id", OleDbType.Integer).Value = id;
                    cmd.Parameters.Add(new OleDbParameter("@type", OleDbType.VarChar, 255)).Value = type;
                    cmd.Parameters.Add(new OleDbParameter("@marca", OleDbType.VarChar, 255)).Value = brand;
                    cmd.Parameters.Add(new OleDbParameter("@modello", OleDbType.VarChar, 255)).Value = modello;
                    cmd.Parameters.Add(new OleDbParameter("@colore", OleDbType.VarChar, 255)).Value = colore;
                    cmd.Parameters.Add("@cilindrata", OleDbType.Integer).Value = cilindrata;
                    cmd.Parameters.Add("@potenza", OleDbType.Integer).Value = potenza;
                    cmd.Parameters.Add(new OleDbParameter("@immatricolazione", OleDbType.Date)).Value = immatricolazine.ToShortDateString();
                    cmd.Parameters.Add(new OleDbParameter("@usato", OleDbType.VarChar, 255)).Value = used;
                    cmd.Parameters.Add(new OleDbParameter("@kmZero", OleDbType.VarChar, 255)).Value = km0;
                    cmd.Parameters.Add("@kmPercorsi", OleDbType.Integer).Value = kmPercorsi;
                    cmd.Parameters.Add("@prezzo", OleDbType.Double).Value = prezzo;
                    cmd.Parameters.Add(new OleDbParameter("@marcaSella", OleDbType.VarChar, 255)).Value = marcaSella;
                    cmd.Parameters.Add("@numAirbag", OleDbType.Integer).Value = numAirbag;

                    //if (type == "Auto")
                    //    cmd.Parameters.Add("@numAirbag", OleDbType.Integer).Value = numAirbag;
                    //else
                    //    cmd.Parameters.Add(new OleDbParameter("@extra", OleDbType.VarChar, 255)).Value = extra;

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