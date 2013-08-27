﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Milkshake.Network;
using Milkshake.Tools.Extensions;
using Milkshake.Game.Entitys;

namespace Milkshake.Communication.Outgoing.World.Entity
{
	public class PSCreatureQueryResponce : ServerPacket
	{
		public PSCreatureQueryResponce(uint entry, UnitEntity entity) : base(WorldOpcodes.SMSG_CREATURE_QUERY_RESPONSE)
		{
			Write((UInt32)entry);
			this.WriteCString(entity.Name);
			this.WriteNullByte(3); // Name2,3,4

			if (entity.Template.subname == "\\N")
			{
				this.WriteNullByte(1);
			}
			else
			{
				this.WriteCString(entity.Template.subname);
			}
			Write((UInt32)entity.Template.type_flags);
			Write((UInt32)entity.Template.type);
			Write((UInt32)entity.Template.family);
			Write((UInt32)entity.Template.rank);
			this.WriteNullUInt(1);

			Write((UInt32)entity.Template.PetSpellDataId);
			Write((UInt32)entity.TEntry.modelid);
			Write((UInt16)entity.Template.Civilian);
		}
	}
}
