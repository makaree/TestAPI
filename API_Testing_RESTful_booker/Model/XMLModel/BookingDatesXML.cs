using System.Xml.Serialization;

namespace API_Testing_RESTful_booker.Model.XMLModel
{
	/// <summary>
	/// This class defines different data types present in BookingDate in XML format.
	/// </summary>
	[XmlRoot(ElementName = "bookingdates")]
	public class BookingDatesXML
	{
		[XmlElement(ElementName = "checkin")]
		public string Checkin { get; set; }
		[XmlElement(ElementName = "checkout")]
		public string Checkout { get; set; }
	}
}
