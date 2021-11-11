using System;
namespace Ddd.DTOs.Audits
{
	public class AddAuditRequest
	{
		public string EventName { get; set; }
		public int EventId { get; set; }
		public string EventDescription { get; set; }
		public AddAuditRequest(string eventName, int id, string eventDescription)
		{
			EventName = eventName;
			EventId = id;
			EventDescription = eventDescription;
		}
	}
}
