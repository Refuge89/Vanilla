﻿using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Network;

namespace Vanilla.World.Communication.Outgoing.Logout
{
    using Vanilla.Core.Opcodes;

    class PSLogoutComplete : ServerPacket
    {
        public PSLogoutComplete() : base((WorldOpcodes) WorldOpcodes.SMSG_LOGOUT_COMPLETE)
        {
            Write((byte)0);
        }
    }
}
