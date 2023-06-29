using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Zadanie4_Tomasz_Ruszkowski
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WidokListyKategorii : Window
    {
        string read_path = "D:\\Pulpit\\zadanie1\\Zadanie4_Tomasz_Ruszkowski\\Produkty.xml";
        string save_path = "D:\\Pulpit\\zadanie1\\Zadanie4_Tomasz_Ruszkowski\\Produkty_save.xml";

        ListBox listaKategorii;
        ObservableCollection<Kategoria> kategorie = new ObservableCollection<Kategoria>();
        public WidokListyKategorii()
        {
            DataContext = kategorie;
            InitializeComponent();
            listaKategorii = (ListBox)FindName("ListaKategorii");
        }

        private void OtwórzKategorię(object sender, RoutedEventArgs e)
        {
            Kategoria wybranaKategoria = (Kategoria)listaKategorii.SelectedItem;
            if (wybranaKategoria != null)
                new WidokKategorii(
                    wybranaKategoria
                    )
                    .Show()
                    ;
        }
        private void DodajKategorię(object sender, RoutedEventArgs e)
        {
            Kategoria nowaKategoria = new Kategoria();
            kategorie.Add(nowaKategoria);
            new WidokKategorii(
                nowaKategoria
                )
                .Show()
                ;
        }
        private void UsuńKategorię(object sender, RoutedEventArgs e)
        {

            Kategoria usuwanaKategoria = (Kategoria)listaKategorii.SelectedItem;
            kategorie.Remove(usuwanaKategoria);
        }

        private void Zapisz(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializator = new XmlSerializer(typeof(ObservableCollection<Kategoria>));
            TextWriter strumieńZapisu = new StreamWriter(save_path);
            serializator.Serialize(strumieńZapisu, kategorie);
        }

        private void Wczytaj(object sender, RoutedEventArgs e)
        {
            XmlSerializer serializator = new XmlSerializer(typeof(ObservableCollection<Kategoria>));
            FileStream plik = new FileStream(read_path, FileMode.Open);
            ObservableCollection<Kategoria> wczytane = (ObservableCollection<Kategoria>)serializator.Deserialize(plik);
            kategorie.Clear();
            foreach (Kategoria kategoria in wczytane)
                kategorie.Add(kategoria);
            plik.Close();
        }
    }
}