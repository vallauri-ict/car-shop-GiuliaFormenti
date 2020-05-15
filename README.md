# car-shop-GiuliaFormenti

Questo è il progetto per la gestione di un autosalone.
E' composto da varie parti:
- cliDatabase
- DatabaseInstructionDLL
- VenditaVeicoliDLLProject
- WindowsFormsAppProject

# cliDatabase
E' un'applicazione console che permette la gestione del database da linea di comando.
Presenta un menù con diverse voci:
- **CREAZIONE TABELLA**
- **AGGIUNGERE UN NUOVO ELEMENTO**
- **ELIMINARE UN ELEMENTO**
- **ELIMINARE LA TABELLA**
- **CLEAR CONSOLE**, che consente di pulire la console dai comandi eseguiti in precedenza lasciando solamente il menù
 ```cs
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
    ```

E' presente il sottoprogramma **DropTable(string name)**, per la rimozione di una tabella, qui presente in modo da non poter essere direttamente richiamato dall'utente.
private static void DropTable(string name)

Intoltre vi è il sottoprogramma **setParameters()** che permette di inserire i vari parametri aggiungendo valori di default in presenza di errori.

# DatabaseInstructionDLL
E' una DLL che contiene la classe **UtilsDatabase.cs**, dove sono presenti i vari sottoprogrammi per gestire il database:
- **CreateTableCars(string name = "cars")** per creare la tabella
- **AddNewCar(string type, string brand, string modello, string colore, int cilindrata, double potenza, DateTime immatricolazine, bool usato, bool kmZero, int kmPercorsi, double prezzo, string marcaSella, int numAirbag, string name = "cars")** che aggiunge un nuovo veicolo al database
- **DeleteElement(string name, int id)** per eliminare un record del database dato l'id

# VenditaVeicoliDLLProject
E' una DLL che contiene diverse classi:
- **Veicoli.cs** che deifinisce un oggetto veicolo
- **Auto.cs** che eredita da veicolo e definisce un oggetto auto con l'aggiunta del campo **numAirbag** esclusivo per le auto
- **Moto.cs** che eredita da veicolo e definisce un oggetto moto con l'aggiunta del campo **marcaSella** esclusivo per le moto
- **Utils.cs** per la gestione di CSV, XML, e JSON
- **ClsOpenXmlUtilities** per la gestione di file Word e Excel(non ancora)

# WindowsFormsAppProject
Contiene due form:
- **FormMain.cs**, dove è presente un toolStripMenu con vari pulsanti:
 - **Nuovo** che apre la form modale **FormDialogAggiungiVeicolo.cs**
 - **Apri** che mostra nella listBox della form i veicoli presenti nella lista
 - **Salva** che salva i dati in formato CSV, XML e JSON
 - **Stampa** che mostra il volantino dell'autosalone
 - **Word** per la creazione di un documento Word
 - **Excel** per la creazione di un file Excel
- **FormDialogAggiungiVeicolo.cs**, una form modale che permette di aggiungere un veicolo alla lista

###### Creato da Giulia Formenti 4B INF
