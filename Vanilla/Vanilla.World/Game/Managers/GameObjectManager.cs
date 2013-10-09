﻿namespace Vanilla.World.Game.Managers
{
    using System.Collections.Generic;
    using System.Linq;

    using Vanilla.Core.Opcodes;
    using Vanilla.World.Communication.Incoming.World.GameObject;
    using Vanilla.World.Database.Models;
    using Vanilla.World.Game.Constants;
    using Vanilla.World.Game.Constants.Game.World.Entity;
    using Vanilla.World.Game.Entitys;
    using Vanilla.World.Game.Handlers;
    using Vanilla.World.Network;

    public delegate void ProcessGameObjectUseCallback(WorldSession Session, GOEntity gameObject);

    public class GameObjectManager
    {
        public static Dictionary<GameObjectType, ProcessGameObjectUseCallback> GameObjectUseHandlers;

        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCGameObjectUse>(WorldOpcodes.CMSG_GAMEOBJ_USE, OnGameObjectUsePacket);
            GameObjectUseHandlers = new Dictionary<GameObjectType, ProcessGameObjectUseCallback>();

            GameObjectUseHandlers.Add(GameObjectType.GAMEOBJECT_TYPE_CHAIR, OnUseChair);
        }

        private static void OnGameObjectUsePacket(WorldSession session, PCGameObjectUse packet)
        {
            GOEntity gameObject = VanillaWorld.GameObjectComponent.Entitys.First(go => go.GUID == packet.GUID);

            GameObjectTemplate template = gameObject.GameObjectTemplate;

            if (gameObject != null && GameObjectUseHandlers.ContainsKey((GameObjectType)template.Type))
            {
                GameObjectUseHandlers[(GameObjectType)template.Type](session, gameObject);
            }
        }

        private static void OnUseChair(WorldSession session, GOEntity gameObject)
        {
            GameObject go = gameObject.GameObject;

            session.Entity.TeleportTo(session.Character.Map, go.PositionX, go.PositionY, go.PositionZ, go.Orientation);
            session.Entity.SetStandState(UnitStandStateType.UNIT_STAND_STATE_SIT_CHAIR);
        }
    }
}
