﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rice.Server.Core;

namespace Rice.Server.Packets.Game
{
    public static class Shop
    {
        [RicePacket(405, RiceServer.ServerType.Game)]
        public static void BuyItem(RicePacket packet)
        {

            // 0 = ItemID
            // 1 = Unknown
            // 2 = Quantity
            int itemID = packet.Reader.ReadInt16();
            int unknown = packet.Reader.ReadInt16();
            int quantity = packet.Reader.ReadInt16();

            Log.WriteLine("{0} {1} {2}", itemID, unknown, quantity);


            // 0 = itemID
            // 1 = Price
            // 2 = Quantity
            var ack = new RicePacket(406);
            ack.Writer.Write(itemID);
            ack.Writer.Write(17500);
            ack.Writer.Write(quantity);
            packet.Sender.Send(ack);
        }
        
        /*
        public static void DeleteItem(int itemID, int invenID, int count)
        {
            Console.WriteLine("Deleting {0}", itemID);
            Program.GameProxy.SendServer(Packet.Build(403, itemID, invenID, count));
        }

        public static void SellItem(int itemID, int amount, int invenID)
        {
            Console.WriteLine("Selling {0}", itemID);
            Program.GameProxy.SendServer(Packet.Build(407, itemID, amount, invenID));
        }

        public static void AuctionItem(int itemID, int amount, int invenID)
        {
            Console.WriteLine("Auctioning {0}", itemID);
            Program.GameProxy.SendServer(Packet.Build(582, itemID, invenID, amount, 9999)); 
        }

        public static void AuctionCancel(int auctionID)
        {
            Console.WriteLine("Cancelling {0}", auctionID);
            Program.GameProxy.SendServer(Packet.Build(584, auctionID));
        }*/
    }
}
