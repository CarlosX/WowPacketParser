using System;
using System.Collections.Generic;
using WowPacketParser.Enums;
using WowPacketParser.Enums.Version;
using WowPacketParser.Misc;
using WowPacketParser.Store.Objects;
using Guid = WowPacketParser.Misc.Guid;

namespace WowPacketParser.Parsing.Parsers
{
    public static class MovementHandler
    {
        public static Vector4 CurrentPosition;

        public static uint CurrentMapId;

        public static int CurrentPhaseMask = 1;

        public static MovementInfo ReadMovementInfo(ref Packet packet, Guid guid)
        {
            if (ClientVersion.AddedInVersion(ClientVersionBuild.V4_2_0_14333))
                return ReadMovementInfo420(ref packet, guid, -1);

            return ReadMovementInfo(ref packet, guid, -1);
        }

        public static MovementInfo ReadMovementInfo(ref Packet packet, Guid guid, int index)
        {
            string prefix = index < 0 ? string.Empty : "[" + index + "] ";

            var info = new MovementInfo();
            info.Flags = packet.ReadEnum<MovementFlag>(prefix + "Movement Flags", TypeCode.Int32);

            var flagsTypeCode = ClientVersion.AddedInVersion(ClientVersionBuild.V3_0_2_9056) ? TypeCode.Int16 : TypeCode.Byte;
            var flags = packet.ReadEnum<MovementFlagExtra>(prefix + "Extra Movement Flags", flagsTypeCode);

            if (ClientVersion.AddedInVersion(ClientVersionBuild.V4_2_2_14545))
                if (packet.ReadGuid(prefix + "GUID 2") != guid)
                    packet.Writer.WriteLine("GUIDS NOT EQUAL"); // Fo debuggingz

            packet.ReadInt32(prefix + "Time");

            var pos = packet.ReadVector4(prefix + "Position");
            info.Position = new Vector3(pos.X, pos.Y, pos.Z);
            info.Orientation = pos.O;

            if (info.Flags.HasAnyFlag(MovementFlag.OnTransport))
            {
                if (ClientVersion.AddedInVersion(ClientVersionBuild.V3_1_0_9767))
                    packet.ReadPackedGuid(prefix + "Transport GUID");
                else
                    packet.ReadGuid(prefix + "Transport GUID");

                packet.ReadVector4(prefix + "Transport Position");
                packet.ReadInt32(prefix + "Transport Time");

                if (ClientVersion.AddedInVersion(ClientType.WrathOfTheLichKing))
                    packet.ReadByte(prefix + "Transport Seat");

                if (flags.HasAnyFlag(MovementFlagExtra.InterpolateMove))
                    packet.ReadInt32(prefix + "Transport Time");
            }

            if (info.Flags.HasAnyFlag(MovementFlag.Swimming | MovementFlag.Flying) ||
                flags.HasAnyFlag(MovementFlagExtra.AlwaysAllowPitching))
                packet.ReadSingle(prefix + "Swim Pitch");

            if (ClientVersion.RemovedInVersion(ClientType.Cataclysm))
                packet.ReadInt32(prefix + "Fall Time");

            if (info.Flags.HasAnyFlag(MovementFlag.Falling))
            {
                if (ClientVersion.AddedInVersion(ClientType.Cataclysm))
                    packet.ReadInt32(prefix + "Fall Time");

                packet.ReadSingle(prefix + "Fall Velocity");
                packet.ReadSingle(prefix + "Fall Sin angle");
                packet.ReadSingle(prefix + "Fall Cos angle");
                packet.ReadSingle(prefix + "Fall Speed");
            }

            if (info.Flags.HasAnyFlag(MovementFlag.SplineElevation))
                packet.ReadSingle(prefix + "Spline Elevation");

            return info;
        }

        public static MovementInfo ReadMovementInfo420(ref Packet packet, Guid guid, int index)
        {
            var info = new MovementInfo();

            info.Flags = packet.ReadEnum<MovementFlag>("Movement Flags", 30, index);

            packet.ReadEnum<MovementFlagExtra>("Extra Movement Flags", 12, index);

            var onTransport = packet.ReadBit("OnTransport", index);
            var hasInterpolatedMovement = false;
            var time3 = false;
            if (onTransport)
            {
                hasInterpolatedMovement = packet.ReadBit("HasInterpolatedMovement", index);
                time3 = packet.ReadBit("Time3", index);
            }

            var swimming = packet.ReadBit("Swimming", index);
            var interPolatedTurning = packet.ReadBit("InterPolatedTurning", index);

            var jumping = false;
            if (interPolatedTurning)
                jumping = packet.ReadBit("Jumping", index);

            var splineElevation = packet.ReadBit("SplineElevation", index);

            info.HasSplineData = packet.ReadBit("HasSplineData", index);

            packet.ResetBitReader(); // reset bitreader

            packet.ReadGuid("GUID 2", index);

            packet.ReadInt32("Time", index);
            var pos = packet.ReadVector4("Position", index);
            info.Position = new Vector3(pos.X, pos.Y, pos.Z);
            info.Orientation = pos.O;

            if (onTransport)
            {
                packet.ReadGuid("Transport GUID", index);
                packet.ReadVector4("Transport Position", index);
                packet.ReadByte("Transport Seat", index);
                packet.ReadInt32("Transport Time", index);
                if (hasInterpolatedMovement)
                    packet.ReadInt32("Transport Time 2", index);
                if (time3)
                    packet.ReadInt32("Transport Time 3", index);
            }
            if (swimming)
                packet.ReadSingle("Swim Pitch", index);

            if (interPolatedTurning)
            {
                packet.ReadInt32("Time Fallen", index);
                packet.ReadSingle("Fall Start Velocity", index);
                if (jumping)
                {
                    packet.ReadSingle("Jump Sin", index);
                    packet.ReadSingle("Jump Cos", index);
                    packet.ReadSingle("Jump Velocity", index);

                }
            }
            if (splineElevation)
                packet.ReadSingle("Spline Elevation", index);

            return info;
        }

        [Parser(Opcode.SMSG_MONSTER_MOVE)]
        [Parser(Opcode.SMSG_MONSTER_MOVE_TRANSPORT)]
        public static void HandleMonsterMove(Packet packet)
        {
            packet.ReadPackedGuid("GUID");

            if (packet.Opcode == Opcodes.GetOpcode(Opcode.SMSG_MONSTER_MOVE_TRANSPORT))
            {
                packet.ReadPackedGuid("Transport GUID");

                if (ClientVersion.AddedInVersion(ClientVersionBuild.V3_1_0_9767)) // no idea when this was added exactly
                    packet.ReadByte("Transport Seat");
            }

            if (ClientVersion.AddedInVersion(ClientVersionBuild.V3_1_0_9767)) // no idea when this was added exactly
                packet.ReadBoolean("Unk Boolean"); // Something to do with IsVehicleExitVoluntary ?

            var pos = packet.ReadVector3("Position");

            packet.ReadInt32("Move Ticks");

            var type = packet.ReadEnum<SplineType>("Spline Type", TypeCode.Byte);

            switch (type)
            {
                case SplineType.FacingSpot:
                {
                    packet.ReadVector3("Facing Spot");
                    break;
                }
                case SplineType.FacingTarget:
                {
                    packet.ReadGuid("Facing GUID");
                    break;
                }
                case SplineType.FacingAngle:
                {
                    packet.ReadSingle("Facing Angle");
                    break;
                }
                case SplineType.Stop:
                    return;
            }

            var flags = packet.ReadEnum<SplineFlag>("Spline Flags", TypeCode.Int32);

            if (flags.HasAnyFlag(SplineFlag.AnimationTier))
            {
                packet.ReadEnum<MovementAnimationState>("Animation State", TypeCode.Byte);
                packet.ReadInt32("Asynctime in ms"); // Async-time in ms
            }

            // Cannot find anything similar to this in 4.2.2 client
            if (ClientVersion.RemovedInVersion(ClientVersionBuild.V4_2_2_14545))
            {
                if (flags.HasAnyFlag(SplineFlag.Falling)) // Could be SplineFlag.UsePathSmoothing
                {
                    packet.ReadInt32("Unknown");
                    packet.ReadInt16("Unknown");
                    packet.ReadInt16("Unknown");
                }
            }

            packet.ReadInt32("Move Time");

            if (flags.HasAnyFlag(SplineFlag.Trajectory))
            {
                packet.ReadSingle("Vertical Speed");
                packet.ReadInt32("Unk Int32 2");
            }

            var waypoints = packet.ReadInt32("Waypoints");

            if (flags.HasAnyFlag(SplineFlag.Flying | SplineFlag.CatmullRom))
            {
                packet.ReadVector3("Waypoint", 0);

                for (var i = 1; i < waypoints; i++)
                    packet.ReadVector3("Waypoint", i);
            }
            else
            {
                var newpos = packet.ReadVector3("Waypoint Endpoint");

                var mid = new Vector3();
                mid.X = (pos.X + newpos.X) * 0.5f;
                mid.Y = (pos.Y + newpos.Y) * 0.5f;
                mid.Z = (pos.Z + newpos.Z) * 0.5f;

                for (var i = 1; i < waypoints; i++)
                {
                    var vec = packet.ReadPackedVector3();
                    vec.X += mid.X;
                    vec.Y += mid.Y;
                    vec.Z += mid.Z;

                    packet.Writer.WriteLine("[" + i + "]" + " Waypoint: " + vec);
                }
            }
        }

        [Parser(Opcode.SMSG_NEW_WORLD)]
        [Parser(Opcode.SMSG_LOGIN_VERIFY_WORLD)]
        public static void HandleEnterWorld(Packet packet)
        {
            var mapId = packet.ReadEntryWithName<Int32>(StoreNameType.Map, "Map ID");

            CurrentMapId = (uint)mapId;

            var position = packet.ReadVector4();
            packet.Writer.WriteLine("Position: " + position);
            CurrentPosition = position;

            UpdateHandler.Objects[CurrentMapId] = new Dictionary<Guid, WoWObject>();

            if (packet.Opcode != Opcodes.GetOpcode(Opcode.SMSG_LOGIN_VERIFY_WORLD))
                return;

            Player chInfo;
            if (!CharacterHandler.Characters.TryGetValue(SessionHandler.LoginGuid, out chInfo))
                return;

            SessionHandler.LoggedInCharacter = chInfo;
        }

        [Parser(Opcode.SMSG_LOGIN_SETTIMESPEED)]
        public static void HandleLoginSetTimeSpeed(Packet packet)
        {
            packet.ReadPackedTime("Game Time");
            packet.ReadSingle("Game Speed");

            if (ClientVersion.AddedInVersion(ClientVersionBuild.V3_1_2_9901))
                packet.ReadInt32("Unk Int32");
        }

        [Parser(Opcode.SMSG_BINDPOINTUPDATE)]
        public static void HandleBindPointUpdate(Packet packet)
        {
            packet.ReadVector3("Position");

            packet.ReadEntryWithName<Int32>(StoreNameType.Map, "Map ID");

            packet.ReadInt32("Zone ID");
        }

        [Parser(Opcode.MSG_MOVE_TELEPORT_ACK)]
        public static void HandleTeleportAck(Packet packet)
        {
            if (packet.Direction == Direction.ServerToClient)
            {
                var guid = packet.ReadPackedGuid();
                packet.Writer.WriteLine("GUID: " + guid);

                var counter = packet.ReadInt32();
                packet.Writer.WriteLine("Movement Counter: " + counter);

                ReadMovementInfo(ref packet, guid);
            }
            else
            {
                var guid = packet.ReadPackedGuid();
                packet.Writer.WriteLine("GUID: " + guid);

                var flags = (MovementFlag)packet.ReadInt32();
                packet.Writer.WriteLine("Move Flags: " + flags);

                var time = packet.ReadInt32();
                packet.Writer.WriteLine("Time: " + time);
            }
        }

        [Parser(Opcode.MSG_MOVE_START_FORWARD)]
        [Parser(Opcode.MSG_MOVE_START_BACKWARD)]
        [Parser(Opcode.MSG_MOVE_STOP)]
        [Parser(Opcode.MSG_MOVE_START_STRAFE_LEFT)]
        [Parser(Opcode.MSG_MOVE_START_STRAFE_RIGHT)]
        [Parser(Opcode.MSG_MOVE_STOP_STRAFE)]
        [Parser(Opcode.MSG_MOVE_START_ASCEND)]
        [Parser(Opcode.MSG_MOVE_START_DESCEND)]
        [Parser(Opcode.MSG_MOVE_STOP_ASCEND)]
        [Parser(Opcode.MSG_MOVE_JUMP)]
        [Parser(Opcode.MSG_MOVE_START_TURN_LEFT)]
        [Parser(Opcode.MSG_MOVE_START_TURN_RIGHT)]
        [Parser(Opcode.MSG_MOVE_STOP_TURN)]
        [Parser(Opcode.MSG_MOVE_START_PITCH_UP)]
        [Parser(Opcode.MSG_MOVE_START_PITCH_DOWN)]
        [Parser(Opcode.MSG_MOVE_STOP_PITCH)]
        [Parser(Opcode.MSG_MOVE_SET_RUN_MODE)]
        [Parser(Opcode.MSG_MOVE_SET_WALK_MODE)]
        [Parser(Opcode.MSG_MOVE_TELEPORT)]
        [Parser(Opcode.MSG_MOVE_SET_FACING)]
        [Parser(Opcode.MSG_MOVE_SET_PITCH)]
        [Parser(Opcode.MSG_MOVE_TOGGLE_COLLISION_CHEAT)]
        [Parser(Opcode.MSG_MOVE_GRAVITY_CHNG)]
        [Parser(Opcode.MSG_MOVE_ROOT)]
        [Parser(Opcode.MSG_MOVE_UNROOT)]
        [Parser(Opcode.MSG_MOVE_START_SWIM)]
        [Parser(Opcode.MSG_MOVE_STOP_SWIM)]
        [Parser(Opcode.MSG_MOVE_START_SWIM_CHEAT)]
        [Parser(Opcode.MSG_MOVE_STOP_SWIM_CHEAT)]
        [Parser(Opcode.MSG_MOVE_HEARTBEAT)]
        [Parser(Opcode.MSG_MOVE_FALL_LAND)]
        [Parser(Opcode.MSG_MOVE_UPDATE_CAN_FLY)]
        [Parser(Opcode.MSG_MOVE_UPDATE_CAN_TRANSITION_BETWEEN_SWIM_AND_FLY)]
        [Parser(Opcode.MSG_MOVE_KNOCK_BACK)]
        [Parser(Opcode.MSG_MOVE_HOVER)]
        [Parser(Opcode.MSG_MOVE_FEATHER_FALL)]
        [Parser(Opcode.MSG_MOVE_WATER_WALK)]
        [Parser(Opcode.CMSG_MOVE_FALL_RESET)]
        [Parser(Opcode.CMSG_MOVE_SET_FLY)]
        [Parser(Opcode.CMSG_MOVE_CHNG_TRANSPORT)]
        [Parser(Opcode.CMSG_MOVE_NOT_ACTIVE_MOVER)]
        [Parser(Opcode.CMSG_DISMISS_CONTROLLED_VEHICLE)]
        public static void HandleMovementMessages(Packet packet)
        {
            Guid guid;
            if (ClientVersion.AddedInVersion(ClientVersionBuild.V3_2_0_10192) ||
                packet.Direction == Direction.ServerToClient)
                guid = packet.ReadPackedGuid("GUID");
            else
                guid = new Guid();

            ReadMovementInfo(ref packet, guid);
            if (packet.Opcode == Opcodes.GetOpcode(Opcode.MSG_MOVE_KNOCK_BACK))
            {
                packet.ReadSingle("Sin Angle");
                packet.ReadSingle("Cos Angle");
                packet.ReadSingle("Speed");
                packet.ReadSingle("Velocity");
            }
        }

        [Parser(Opcode.MSG_MOVE_SET_WALK_SPEED)]
        [Parser(Opcode.MSG_MOVE_SET_RUN_SPEED)]
        [Parser(Opcode.MSG_MOVE_SET_RUN_BACK_SPEED)]
        [Parser(Opcode.MSG_MOVE_SET_SWIM_SPEED)]
        [Parser(Opcode.MSG_MOVE_SET_SWIM_BACK_SPEED)]
        [Parser(Opcode.MSG_MOVE_SET_TURN_RATE)]
        [Parser(Opcode.MSG_MOVE_SET_FLIGHT_SPEED)]
        [Parser(Opcode.MSG_MOVE_SET_FLIGHT_BACK_SPEED)]
        [Parser(Opcode.MSG_MOVE_SET_PITCH_RATE)]
        public static void HandleMovementSetSpeed(Packet packet)
        {
            var guid = packet.ReadPackedGuid("GUID");
            ReadMovementInfo(ref packet, guid);
            packet.ReadSingle("Speed");
        }

        [Parser(Opcode.CMSG_FORCE_RUN_SPEED_CHANGE_ACK)]
        [Parser(Opcode.CMSG_FORCE_RUN_BACK_SPEED_CHANGE_ACK)]
        [Parser(Opcode.CMSG_FORCE_SWIM_SPEED_CHANGE_ACK)]
        [Parser(Opcode.CMSG_FORCE_SWIM_BACK_SPEED_CHANGE_ACK)]
        [Parser(Opcode.CMSG_FORCE_WALK_SPEED_CHANGE_ACK)]
        [Parser(Opcode.CMSG_FORCE_TURN_RATE_CHANGE_ACK)]
        [Parser(Opcode.CMSG_FORCE_FLIGHT_SPEED_CHANGE_ACK)]
        [Parser(Opcode.CMSG_FORCE_FLIGHT_BACK_SPEED_CHANGE_ACK)]
        public static void HandleSpeedChangeMessage(Packet packet)
        {
            var guid = packet.ReadPackedGuid();
            packet.Writer.WriteLine("GUID: " + guid);

            var counter = packet.ReadInt32();
            packet.Writer.WriteLine("Movement Counter: " + counter);

            ReadMovementInfo(ref packet, guid);

            var newSpeed = packet.ReadSingle();
            packet.Writer.WriteLine("New Speed: " + newSpeed);
        }

        [Parser(Opcode.MSG_MOVE_SET_COLLISION_HGT)]
        [Parser(Opcode.SMSG_MOVE_SET_COLLISION_HGT)]
        [Parser(Opcode.CMSG_MOVE_SET_COLLISION_HGT_ACK)]
        public static void HandleCollisionMovements(Packet packet)
        {
            var guid = packet.ReadPackedGuid();
            packet.Writer.WriteLine("GUID: " + guid);

            if (packet.Opcode != Opcodes.GetOpcode(Opcode.MSG_MOVE_SET_COLLISION_HGT))
            {
                var counter = packet.ReadInt32();
                packet.Writer.WriteLine("Movement Counter: " + counter);
            }

            if (packet.Opcode != Opcodes.GetOpcode(Opcode.SMSG_MOVE_SET_COLLISION_HGT))
                ReadMovementInfo(ref packet, guid);

            var unk = packet.ReadSingle();
            packet.Writer.WriteLine("Collision Height: " + unk);
        }

        [Parser(Opcode.CMSG_SET_ACTIVE_MOVER)]
        [Parser(Opcode.SMSG_MOUNTSPECIAL_ANIM)]
        public static void HandleSetActiveMover(Packet packet)
        {
            var guid = packet.ReadGuid();
            packet.Writer.WriteLine("GUID: " + guid);
        }

        [Parser(Opcode.SMSG_SUMMON_REQUEST)]
        public static void HandleSummonRequest(Packet packet)
        {
            packet.ReadGuid("Summoner GUID");
            packet.ReadInt32("Unk int 1");
            packet.ReadInt32("Unk int 2");
        }

        [Parser(Opcode.CMSG_SUMMON_RESPONSE)]
        public static void HandleSummonResponse(Packet packet)
        {
            packet.ReadGuid("Summoner GUID");
            packet.ReadBoolean("Accept");
        }

        [Parser(Opcode.SMSG_FORCE_MOVE_ROOT)]
        [Parser(Opcode.SMSG_FORCE_MOVE_UNROOT)]
        [Parser(Opcode.SMSG_MOVE_WATER_WALK)]
        [Parser(Opcode.SMSG_MOVE_LAND_WALK)]
        public static void HandleSetMovementMessages(Packet packet)
        {
            var guid = packet.ReadPackedGuid();
            packet.Writer.WriteLine("GUID: " + guid);

            var counter = packet.ReadInt32();
            packet.Writer.WriteLine("Movement Counter: " + counter);
        }

        [Parser(Opcode.CMSG_MOVE_KNOCK_BACK_ACK)]
        [Parser(Opcode.CMSG_MOVE_WATER_WALK_ACK)]
        [Parser(Opcode.CMSG_MOVE_HOVER_ACK)]
        public static void HandleSpecialMoveAckMessages(Packet packet)
        {
            var guid = packet.ReadPackedGuid();
            packet.Writer.WriteLine("GUID: " + guid);

            var unk1 = packet.ReadInt32();
            packet.Writer.WriteLine("Unk Int32 1: " + unk1);

            ReadMovementInfo(ref packet, guid);

            if (packet.Opcode == Opcodes.GetOpcode(Opcode.CMSG_MOVE_KNOCK_BACK_ACK))
                return;

            var unk2 = packet.ReadInt32();
            packet.Writer.WriteLine("Unk Int32 2: " + unk2);
        }

        [Parser(Opcode.SMSG_SET_PHASE_SHIFT)]
        public static void HandlePhaseShift(Packet packet)
        {
            var phaseMask = packet.ReadInt32();
            packet.Writer.WriteLine("Phase Mask: 0x" + phaseMask.ToString("X8"));
            CurrentPhaseMask = phaseMask;
        }

        [Parser(Opcode.SMSG_SET_PHASE_SHIFT, ClientVersionBuild.V4_0_6a_13623)]
        public static void HandlePhaseShift406(Packet packet)
        {
            packet.ReadGuid("GUID");
            for (var i = 0; i < 4; ++i)
            {
                var count = packet.ReadUInt32("Count of bytes: {0}", i + 1);
                if (count > 0)
                {
                    byte[] bytes1 = packet.ReadBytes((int)count);
                    packet.Writer.WriteLine("Bytes: " + bytes1);
                }
            }

            packet.ReadUInt32("Flag"); // can be 0, 4 or 8, 8 = normal world, others are unknown
        }

        [Parser(Opcode.SMSG_SET_PHASE_SHIFT, ClientVersionBuild.V4_2_2_14545)]
        public static void HandlePhaseShift422(Packet packet)
        {
            byte[] bytes = { 0, 0, 0, 0, 0, 0, 0, 0 };

            var guidFlag = packet.ReadEnum<BitMask>("Guid Mask Flags",TypeCode.Byte);

            if (guidFlag.HasFlag(BitMask.Byte0))
                bytes[0] = packet.ReadByte();

            if (guidFlag.HasFlag(BitMask.Byte4))
                bytes[4] = packet.ReadByte();

            var count = packet.ReadUInt32();
            if (count > 0)
            {
                int num = (int)count - 2;
                packet.ReadEntryWithName<Int16>(StoreNameType.Map, "Map Swap 1");
                if (num > 0)
                {
                    packet.Writer.Write("Bytes: 0x");
                    byte[] bytes1 = packet.ReadBytes(num);
                    for (var i = 0; i < num; ++i)
                        packet.Writer.Write(bytes1[i].ToString("X2"));
                    packet.Writer.WriteLine();
                }
            }

            if (guidFlag.HasFlag(BitMask.Byte3))
                bytes[3] = packet.ReadByte();

            packet.ReadUInt32("Flag?");

            if (guidFlag.HasFlag(BitMask.Byte2))
                bytes[2] = packet.ReadByte();

            count = packet.ReadUInt32();
            if (count > 0)
            {
                int num = (int)count - 2;
                packet.ReadUInt16("Current Mask");
                if (num > 0)
                {
                    packet.Writer.Write("Bytes: 0x");
                    byte[] bytes1 = packet.ReadBytes(num);
                    for (var i = 0; i < num; ++i)
                        packet.Writer.Write(bytes1[i].ToString("X2"));
                    packet.Writer.WriteLine();
                }
            }

            if (!guidFlag.HasFlag(BitMask.Byte2))
                bytes[6] = packet.ReadByte();

            count = packet.ReadUInt32();
            if (count > 0)
            {
                int num = (int)count - 2;
                packet.ReadEntryWithName<Int16>(StoreNameType.Map, "Map Swap 2");
                if (num > 0)
                {
                    packet.Writer.Write("Bytes: 0x");
                    byte[] bytes1 = packet.ReadBytes(num);
                    for (var i = 0; i < num; ++i)
                        packet.Writer.Write(bytes1[i].ToString("X2"));
                    packet.Writer.WriteLine();
                }
            }

            if (guidFlag.HasFlag(BitMask.Byte7))
                bytes[7] = packet.ReadByte();

                        count = packet.ReadUInt32();
            if (count > 0)
            {
                int num = (int)count - 2;
                packet.ReadEntryWithName<Int16>(StoreNameType.Map, "Map Swap 3");
                if (num > 0)
                {
                    packet.Writer.Write("Bytes: 0x");
                    byte[] bytes1 = packet.ReadBytes(num);
                    for (var i = 0; i < num; ++i)
                        packet.Writer.Write(bytes1[i].ToString("X2"));
                    packet.Writer.WriteLine();
                }
            }

            if (guidFlag.HasFlag(BitMask.Byte1))
                bytes[1] = packet.ReadByte();

            if (guidFlag.HasFlag(BitMask.Byte5))
                bytes[5] = packet.ReadByte();

            ulong tmp = 0;
            for (var i = 7; i > 0; --i)
            {
                if (bytes[i] > 0)
                    bytes[i] ^= 1;
                tmp += bytes[i];
                tmp <<= 8;
            }
            var guid = new Guid(tmp);
            packet.Writer.WriteLine("GUID: " + guid);
        }

        [Parser(Opcode.SMSG_TRANSFER_PENDING)]
        public static void HandleTransferPending(Packet packet)
        {
            packet.ReadEntryWithName<Int32>(StoreNameType.Map, "Map ID");

            if (!packet.CanRead())
                return;

            packet.ReadInt32("Transport Entry");
            packet.ReadEntryWithName<Int32>(StoreNameType.Map, "Transport Map ID");
        }

        [Parser(Opcode.SMSG_TRANSFER_ABORTED)]
        public static void HandleTransferAborted(Packet packet)
        {
            packet.ReadEntryWithName<Int32>(StoreNameType.Map, "Map ID");

            var reason = packet.ReadEnum<TransferAbortReason>("Reason", TypeCode.Byte);

            switch (reason)
            {
                case TransferAbortReason.DifficultyUnavailable:
                {
                    packet.ReadEnum<MapDifficulty>("Difficulty", TypeCode.Byte);
                    break;
                }
                case TransferAbortReason.InsufficientExpansion:
                {
                    packet.ReadEnum<ClientType>("Expansion", TypeCode.Byte);
                    break;
                }
                case TransferAbortReason.UniqueMessage:
                {
                    packet.ReadByte("Message ID");
                    break;
                }
            }
        }

        [Parser(Opcode.SMSG_FLIGHT_SPLINE_SYNC)]
        public static void HandleFlightSplineSync(Packet packet)
        {
            packet.ReadSingle("Duration modifier");
            packet.ReadPackedGuid("GUID");
        }

        [Parser(Opcode.SMSG_CLIENT_CONTROL_UPDATE)]
        public static void HandleClientControlUpdate(Packet packet)
        {
            packet.ReadPackedGuid("GUID");
            packet.ReadByte("AllowMove");
        }

        [Parser(Opcode.SMSG_MOVE_KNOCK_BACK)]
        public static void HandleMoveKnockBack(Packet packet)
        {
            packet.ReadPackedGuid("GUID");
            packet.ReadUInt32("Counter");
            packet.ReadSingle("X direction");
            packet.ReadSingle("Y direction");
            packet.ReadSingle("Horizontal Speed");
            packet.ReadSingle("Vertical Speed");
        }

        [Parser(Opcode.MSG_MOVE_TIME_SKIPPED)]
        public static void HandleMoveTimeSkipped(Packet packet)
        {
            packet.ReadPackedGuid("Guid");
            packet.ReadInt32("Time");
        }

        [Parser(Opcode.SMSG_SPLINE_MOVE_ROOT)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_UNROOT)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_GRAVITY_ENABLE)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_GRAVITY_DISABLE)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_FEATHER_FALL)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_NORMAL_FALL)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_SET_HOVER)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_UNSET_HOVER)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_WATER_WALK)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_LAND_WALK)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_START_SWIM)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_STOP_SWIM)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_SET_RUN_MODE)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_SET_WALK_MODE)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_SET_FLYING)]
        [Parser(Opcode.SMSG_SPLINE_MOVE_UNSET_FLYING)]
        public static void HandleSplineMovementMessages(Packet packet)
        {
            packet.ReadPackedGuid("GUID");
        }

        [Parser(Opcode.SMSG_SPLINE_SET_WALK_SPEED)]
        [Parser(Opcode.SMSG_SPLINE_SET_RUN_SPEED)]
        [Parser(Opcode.SMSG_SPLINE_SET_SWIM_SPEED)]
        [Parser(Opcode.SMSG_SPLINE_SET_FLIGHT_SPEED)]
        [Parser(Opcode.SMSG_SPLINE_SET_RUN_BACK_SPEED)]
        [Parser(Opcode.SMSG_SPLINE_SET_SWIM_BACK_SPEED)]
        [Parser(Opcode.SMSG_SPLINE_SET_FLIGHT_BACK_SPEED)]
        [Parser(Opcode.SMSG_SPLINE_SET_TURN_RATE)]
        [Parser(Opcode.SMSG_SPLINE_SET_PITCH_RATE)]
        public static void HandleSplineMovementSetSpeed(Packet packet)
        {
            packet.ReadPackedGuid("GUID");
            packet.ReadSingle("Amount");
        }

        [Parser(Opcode.SMSG_COMPRESSED_MOVES)]
        public static void HandleCompressedMoves(Packet packet)
        {
            var pkt = packet.Inflate(packet.ReadInt32());
            packet.Writer.WriteLine("{"); // To be able to see what is inside this packet.
            packet.Writer.WriteLine();

            while (pkt.CanRead())
            {
                var size = pkt.ReadByte();
                var opc = pkt.ReadInt16();
                var data = pkt.ReadBytes(size - 2);

                var newPacket = new Packet(data, opc, pkt.Time, pkt.Direction, pkt.Number, packet.Writer);
                Statistics.Total += 1;
                Handler.Parse(newPacket);
            }

            packet.Writer.WriteLine("}");
            packet.ReadToEnd();
        }
    }
}
