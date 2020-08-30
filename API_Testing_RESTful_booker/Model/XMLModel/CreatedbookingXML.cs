using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace API_Testing_RESTful_booker.Model.XMLModel
{
	[XmlRoot(ElementName = "created-booking")]
	public class CreatedbookingXML
	{
		[XmlElement(ElementName = "bookingid")]
		public string Bookingid { get; set; }
		[XmlElement(ElementName = "booking")]
		public BookingXML Booking { get; set; }
	}
}
