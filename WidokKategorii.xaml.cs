using System.Windows;
using System.Windows.Controls;

namespace Zadanie4_Tomasz_Ruszkowski
{
    /// <summary>
    /// Logika interakcji dla klasy WidokKategorii.xaml
    /// </summary>
    public partial class WidokKategorii : Window
    {
        Kategoria Kategoria { get; set; }
        DataGrid listaProduktów;
        public WidokKategorii(Kategoria kategoria)
        {
            DataContext = Kategoria = kategoria;
            InitializeComponent();
            listaProduktów = (DataGrid)FindName("ListaProduktów");
        }

        private void DodajProdukt(object sender, RoutedEventArgs e)
        {
            Kategoria.Produkty.Add(new());
        }

        private void UsuńProdukty(object sender, RoutedEventArgs e)
        {
            if (listaProduktów.SelectedItem is Produkt selectedProdukt)
            {
                Kategoria.Produkty.Remove(selectedProdukt);
            }
        }
    }
}
