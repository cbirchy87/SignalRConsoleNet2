using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SN2UI.Models
{
    internal class EventModel
    {
        public DateTime eventTime { get; set; }
        public int eventType { get; set; }
        public int eventSubType { get; set; }
        public string tokenType { get; set; }
        public int tokenNumber { get; set; }
        public int userId { get; set; }
        public object userName { get; set; }
        public int deviceId { get; set; }
        public string areaName { get; set; }
        public object details { get; set; }
        public string notificationType { get; set; }
    }
}
