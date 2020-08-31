using System.Xml.Serialization;

namespace API_Testing_RESTful_booker.Model.XMLModel
{
	/// <summary>
	/// This class defines different data types present in Create Booking in XML format
	/// </summary>
	[XmlRoot(ElementName = "created-booking")]
	public class CreatedbookingXML
	{
		[XmlElement(ElementName = "bookingid")]
		public string Bookingid { get; set; }
		[XmlElement(ElementName = "booking")]
		public BookingXML Booking { get; set; }
	}
}
