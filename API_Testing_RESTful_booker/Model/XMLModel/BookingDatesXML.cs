using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace API_Testing_RESTful_booker.Model.XMLModel
{
	[XmlRoot(ElementName = "bookingdates")]
	public class BookingDatesXML
    {
		
		
			[XmlElement(ElementName = "checkin")]
			public string Checkin { get; set; }
			[XmlElement(ElementName = "checkout")]
			public string Checkout { get; set; }
		
	}
}
