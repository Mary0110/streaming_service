using System;
using System.Collections.Generic;

namespace streaming_service
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public uint RoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
