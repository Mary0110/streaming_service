using System;
using System.Collections.Generic;

namespace streaming_service
{
    public partial class Device
    {
        public Device()
        {
            Sessions = new HashSet<Session>();
        }

        public uint DeviceId { get; set; }
        public string DeviceName { get; set; } = null!;
        public string DeviceType { get; set; } = null!;

        public virtual ICollection<Session> Sessions { get; set; }
    }
}
