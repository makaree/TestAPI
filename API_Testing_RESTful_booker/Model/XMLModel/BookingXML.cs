using System.Xml.Serialization;

namespace API_Testing_RESTful_booker.Model.XMLModel
{
	/// <summary>
	/// This class defines different data types present in Booking in XML format
	/// </summary>
	[XmlRoot(ElementName = "booking")]
	public class BookingXML
	{
		[XmlElement(ElementName = "firstname")]
		public string Firstname { get; set; }
		[XmlElement(ElementName = "lastname")]
		public string Lastname { get; set; }
		[XmlElement(ElementName = "totalprice")]
		public string Totalprice { get; set; }
		[XmlElement(ElementName = "depositpaid")]
		public string Depositpaid { get; set; }
		[XmlElement(ElementName = "bookingdates")]
		public BookingDatesXML Bookingdates { get; set; }
		[XmlElement(ElementName = "additionalneeds")]
		public string Additionalneeds { get; set; }
	}
}
