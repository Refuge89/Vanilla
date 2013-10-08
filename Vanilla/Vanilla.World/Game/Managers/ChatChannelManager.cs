﻿using System;
using System.Collections.Generic;
using Vanilla.World.Communication.Chat;
using Vanilla.World.Communication.Chat.Channel;
using Vanilla.World.Communication.Outgoing.World;
using Vanilla.World.Communication.Outgoing.World.Chat;
using Vanilla.World.Game.Constants.Game.Chat;
using Vanilla.World.Game.Constants.Game.Chat.Channel;
using Vanilla.World.Game.Handlers;
using Vanilla.World.Network;
using Vanilla.World.Tools;
using Vanilla.World.Tools.Database.Helpers;

namespace Vanilla.World.Game.Managers
{
    using Vanilla.Core.Opcodes;

    public class ChatChannelManager
    {
        public static void Boot()
        {
            WorldDataRouter.AddHandler<PCChannel>(WorldOpcodes.CMSG_JOIN_CHANNEL, OnJoinChannel);
            WorldDataRouter.AddHandler<PCChannel>(WorldOpcodes.CMSG_LEAVE_CHANNEL, OnLeaveChannel);
            WorldDataRouter.AddHandler<PCChannel>(WorldOpcodes.CMSG_CHANNEL_LIST, OnListChannel);
            ChatManager.ChatHandlers.Add(ChatMessageType.CHAT_MSG_CHANNEL, OnChannelMessage);
        }

        private static void OnListChannel(WorldSession session, PCChannel packet)
        {
            throw new NotImplementedException();
        }

        private static void OnLeaveChannel(WorldSession session, PCChannel packet)
        {
            DBChannels.LeaveChannel(session.Character.GUID, packet.ChannelName);
        }

        private static void OnJoinChannel(WorldSession session, PCChannel packet)
        {
            DBChannels.JoinChannel(session.Character.GUID, packet.ChannelName);
            session.sendPacket(new PSChannelNotify(ChatChannelNotify.CHAT_YOU_JOINED_NOTICE, (ulong)session.Character.GUID, packet.ChannelName));
        }

        //When channel gets a message!
        private static void OnChannelMessage(WorldSession session, PCMessageChat packet)
        {
            List<Character> inChannel = DBChannels.GetCharacters(packet.ChannelName);
            //inChannel.ForEach(c => WorldServer.Sessions.Find(s => s.Character == c).sendPacket(new PSMessageChat(ChatMessageType.CHAT_MSG_CHANNEL, ChatMessageLanguage.LANG_UNIVERSAL, (ulong)session.Character.GUID, packet.Message, packet.ChannelName)));;

            ServerPacket outPacket = new PSMessageChat(ChatMessageType.CHAT_MSG_CHANNEL, ChatMessageLanguage.LANG_UNIVERSAL, (ulong)session.Character.GUID, packet.Message, packet.ChannelName);

            Console.WriteLine(Helper.ByteArrayToHex(outPacket.Packet));

            WorldServer.TransmitToAll(outPacket);
        }
    }
}