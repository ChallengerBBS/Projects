using System.Xml.Serialization;

namespace ProductShop.Dtos.Export
{
    [XmlType("User")]
   public  class ExportUserAndProductDto
    {
        [XmlElement("firstName")]
        public string FirstName { get; set; }

        [XmlElement("lastName")]

        public string LastName { get; set; }

        [XmlElement("age")]

        public int? Age { get; set; }

        [XmlElement("SoldProducts")]

        public SoldProductsDto SoldProductsDto { get; set; }
    }

    public class SoldProductsDto
    {
        [XmlElement("count")]

        public int Count { get; set; }

        [XmlArray("products")]
        public ProductDto[] ProductDto { get; set; }
    }
}
