using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace VenditaVeicoliDLLProject
{
    [Serializable]
    public class SerializableBindingList<T> : BindingList<T> { }

    public class Utils
    {
        //***********************CSV*******************//
        public static IEnumerable<string> ToCsv<T>(IEnumerable<T> objectlist, string separator = "|")
        {
            foreach (var o in objectlist)
            {
                FieldInfo[] fields = o.GetType().GetFields();
                PropertyInfo[] properties = o.GetType().GetProperties();

                yield return string.Join(separator, fields.Select(f => (f.GetValue(o) ?? "").ToString())
                    .Concat(properties.Select(p => (p.GetValue(o, null) ?? "").ToString())).ToArray());
            }
        }

        public static string ToCsvString<T>(IEnumerable<T> objectlist, string separator = "|")
        {
            StringBuilder csvdata = new StringBuilder();
            foreach (var o in objectlist)
            {
                FieldInfo[] fields = o.GetType().GetFields();
                PropertyInfo[] properties = o.GetType().GetProperties();

                csvdata.AppendLine(string.Join(separator, fields.Select(f => (f.GetValue(o) ?? "").ToString())
                    .Concat(properties.Select(p => (p.GetValue(o, null) ?? "").ToString())).ToArray()));
            }
            return csvdata.ToString();
        }

        public static void SerializeToCsv<T>(IEnumerable<T> objectlist, string pathName, string separator = "|")
        {
            IEnumerable<string> dataToSave = Utils.ToCsv(objectlist, separator);
            File.WriteAllLines(pathName, dataToSave);
        }

        //***********************XML*******************//
        public static void SerializeToXml<T>(SerializableBindingList<T> objectlist, string pathName)
        {
            XmlSerializer x = new XmlSerializer(typeof(SerializableBindingList<T>));
            TextWriter writer = new StreamWriter(pathName);
            x.Serialize(writer, objectlist);
        }

        //***********************JSON*******************//
        public static void SerializeToJson<T>(IEnumerable<T> objectlist, string pathName)
        {
            string json = JsonConvert.SerializeObject(objectlist, Formatting.Indented);
            File.WriteAllText(pathName, json);

            //string jsonString = JsonSerializer.Serialize(weatherForecast);
            //File.WriteAllText(fileName, jsonString);
        }
        
        public static void DeserializeJson(SerializableBindingList<Veicolo> lista, string fileName)
        {
            lista.Clear();
            string json = File.ReadAllText(fileName);
            object[] veicoli = JsonConvert.DeserializeObject<object[]>(json);
            for (int i = 0; i < veicoli.Length; i++)
            {
                Moto moto = new Moto();
                Auto auto = new Auto();
                string veicolo = veicoli[i].ToString();
                if (veicolo.Contains("MarcaSella"))
                {
                    JsonConvert.PopulateObject(veicolo, moto);
                    lista.Add(moto);
                }
                else
                {
                    JsonConvert.PopulateObject(veicolo, auto);
                    lista.Add(auto);
                }
            }
        }

        //HTML
        public static void CreateHtml(SerializableBindingList<Veicolo> lista, string pathName, string skeletonPathName = @".\www\index - skeleton.html")
        {
            string html = File.ReadAllText(skeletonPathName);
            html = html.Replace("{{head-title}}", "AUTOVALLAURI");
            html = html.Replace("{{body-title}}", "SALONE AUTOVALLAURI - VEICOLI NUOVI E USATI");
            html = html.Replace("{{body-subtitle}}", "Le migliori occasioni al miglior prezzo!");
            

            string aus = "<h3> LISTA DEI VEICOLI DISPONIBILI: </h3>";
            foreach (var item in lista)
            {
                creaCorpo(item, ref aus);
            }
            html = html.Replace("{{main-content}}", aus);
            //File.Delete(skeletonPathName); non lo togliamo qui(ma quando faremo la pubblicazione) perchè se voglio riaprire il sito un'altra volta non lo trova più
            File.WriteAllText(pathName, html);
        }

        private static void creaCorpo(Veicolo item, ref string html)
        {
            string veicolo = string.Empty;
            string param = string.Empty;
            if (item is Moto)
            {
                veicolo = "moto.jpg";
                param = (item as Moto).MarcaSella;
            }
            else
            {
                veicolo = "auto.jpg";
                param = (item as Auto).NumAirbag.ToString();
            }

            html += "<div class = \"veicolo\">";
            html += $"<img src = \"img/{veicolo}\">";
            html += "<p class = \"titolo\">" + item.Marca + " " + item.Modello;
            html += "<br><p class = \"didascalia\">" + item.Colore + " " + item.Cilindrata + " " + item.Immatricolazione.ToShortDateString() + " " + item.KmPercorsi + "km percorsi " + item.PotenzaKw + "Kw";
            if (item.IsKmZero == true)
            {
                html += " Km 0";
            }
            else
            {
                html += "";
            }
            if (item.IsUsato == true)
            {
                html += " Usata";
            }
            else
            {
                html += " Nuova";
            }
            html += "</p>";
            html += "</p>";
            html += "</div>";
        }
    }
}
