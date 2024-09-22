using System.IO;
using Terraria.ID;
using Terraria;
using LuneWoL.Common.LWoLPlayers;

namespace LuneWoL
{
    public partial class LuneWoL
    {
        internal enum MessageType : byte
        {
            dedsec
        }

        public override void HandlePacket(BinaryReader librarian, int whoAmI)
        {
            MessageType _11vidsdotcom = (MessageType)librarian.ReadByte();

            if (_11vidsdotcom == MessageType.dedsec)
            {
                byte thenumber = librarian.ReadByte();
                LWoLPlayer lWoLPlayer = Main.player[thenumber].GetModPlayer<LWoLPlayer>();
                lWoLPlayer.MistaWhiteImInFortnite(librarian);

                if (Main.netMode == NetmodeID.Server)
                {
                    lWoLPlayer.SyncPlayer(-1, whoAmI, false);
                }
            }
        }
    }
}
