using System;
using System.Collections.Generic;
using System.Text;

namespace VenditaVeicoliDLLProject
{
    [Serializable()]

    public class Auto : Veicolo
    {
        private int numAirbag;

        public Auto() : base("Mercedes", "GLX", "GRIGIO", 2000, 175.20, DateTime.Now, false, false, 0)
        {
            //Creazione di una moto di default al richiamo del costruttore vuoto
            NumAirbag = 6;
        }

        public Auto(string marca, string modello, string colore, int cilindrata, double potenzaKw, DateTime immatricolazione, bool isUsato, bool isKmZero, int kmPercorsi, int numAirbag)
            :base(marca, modello, colore, cilindrata, potenzaKw, immatricolazione, isUsato, isKmZero, kmPercorsi)
        {
            this.NumAirbag = numAirbag;
        }

        public int NumAirbag { get => numAirbag; set => numAirbag = value; }

        public override string ToString()
        {
            //
            //string retVal = $"Auto: {this.Marca} {this.Modello} ({this.Colore})";
            //retVal = "Marca: " + this.Marca;
            //retVal += " - Modello: " + this.Modello;
            //retVal += " (" + this.Colore + ")";
            return $"Auto: {base.ToString()} - {this.NumAirbag} Airbag";//return this.Marca + " " + this.Modello; UGUALE A return Marca + " " + Modello;
        }
    }
}
