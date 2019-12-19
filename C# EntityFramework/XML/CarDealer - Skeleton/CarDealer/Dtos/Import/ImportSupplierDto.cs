using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Supplier")]
    public class ImportSupplierDto
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("IsImporter")]
        public bool IsImporter { get; set; }
    }
}
