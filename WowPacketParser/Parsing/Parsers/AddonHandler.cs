using System;
using WowPacketParser.Enums;
using WowPacketParser.Misc;

namespace WowPacketParser.Parsing.Parsers
{
    public static class AddonHandler
    {
        private static int _addonCount;

        public static void ReadClientAddonsList(ref Packet packet)
        {
            var decompCount = packet.ReadInt32();
            packet = packet.Inflate(decompCount);

            if (ClientVersion.AddedInVersion(ClientVersionBuild.V3_0_8_9464))
            {
                var count = packet.ReadInt32("Addons Count");
                _addonCount = count;

                for (var i = 0; i < count; i++)
                {
                    packet.ReadCString("Name", i);
                    packet.ReadBoolean("Enabled", i);
                    packet.ReadInt32("CRC", i);
                    packet.ReadInt32("Unk Int32", i);
                }

                packet.ReadTime("Time");
            }
            else
            {
                int count = 0;

                while (packet.GetPosition() != packet.GetLength())
                {
                    packet.ReadCString("Name");
                    packet.ReadBoolean("Enabled");
                    packet.ReadInt32("CRC");
                    packet.ReadInt32("Unk Int32");

                    count++;
                }

                _addonCount = count;
            }
        }

        [Parser(Opcode.SMSG_ADDON_INFO)]
        public static void HandleServerAddonsList(Packet packet)
        {
            for (var i = 0; i < _addonCount; i++)
            {
                packet.ReadByte("Addon State");

                var sendCrc = packet.ReadBoolean("Use CRC");

                if (sendCrc)
                {
                    var usePublicKey = packet.ReadBoolean("Use Public Key");

                    if (usePublicKey)
                    {
                        var pubKey = packet.ReadChars(256);
                        packet.Writer.Write("Public Key: ");

                        foreach (var t in pubKey)
                            packet.Writer.Write(t);
                    }

                    packet.ReadInt32("Unk Int32");
                }

                var unkByte2 = packet.ReadBoolean("Use URL File");

                if (!unkByte2)
                    continue;

                packet.ReadCString("Addon URL File");
            }

            if (ClientVersion.AddedInVersion(ClientVersionBuild.V3_0_8_9464))
            {
                var bannedCount = packet.ReadInt32("Banned Addons Count");

                for (var i = 0; i < bannedCount; i++)
                {
                    packet.ReadInt32("ID");

                    var unkStr2 = packet.ReadBytes(16);
                    packet.Writer.WriteLine("Unk Hash 1: " + Utilities.ByteArrayToHexString(unkStr2));

                    var unkStr3 = packet.ReadBytes(16);
                    packet.Writer.WriteLine("Unk Hash 2: " + Utilities.ByteArrayToHexString(unkStr3));

                    packet.ReadInt32("Unk Int32 3");

                    if (ClientVersion.AddedInVersion(ClientVersionBuild.V3_3_3a_11723))
                        packet.ReadInt32("Unk Int32 4");
                }
            }
        }
    }
}
