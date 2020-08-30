using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace API_Testing_RESTful_booker.Model.XMLModel
{
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
