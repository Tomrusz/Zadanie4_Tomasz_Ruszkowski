using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace Zadanie4_Tomasz_Ruszkowski
{
    public class Kategoria
    {
        public string Nazwa { get; set; }
        public ObservableCollection<Produkt> Produkty { get; set; } = new();
    }
}
