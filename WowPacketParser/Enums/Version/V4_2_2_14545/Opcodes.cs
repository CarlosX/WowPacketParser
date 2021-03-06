using System.Collections.Generic;

namespace WowPacketParser.Enums.Version//.V4_2_2_14545
{
    public static partial class Opcodes
    {
        private static Dictionary<Opcode, int> _V4_2_2_opcodes = new Dictionary<Opcode, int>
        {
            {Opcode.CMSG_ACCEPT_LEVEL_GRANT, 0xDC4B},
            {Opcode.CMSG_ADD_FRIEND, 0x5C57},
            {Opcode.CMSG_ADD_IGNORE, 0xCEEA},
            {Opcode.CMSG_ADD_VOICE_IGNORE, 0xA7A},
            {Opcode.CMSG_AREATRIGGER, 0x5862},
            {Opcode.CMSG_AREA_SPIRIT_HEALER_QUERY, 0xDC7E},
            {Opcode.CMSG_ARENA_TEAM_DISBAND, 0x4A5A},
            {Opcode.CMSG_ARENA_TEAM_INVITE, 0x4862},
            {Opcode.CMSG_ARENA_TEAM_LEADER, 0x8F3},
            {Opcode.CMSG_ARENA_TEAM_LEAVE, 0x48EB},
            {Opcode.CMSG_ARENA_TEAM_QUERY, 0x872},
            {Opcode.CMSG_ARENA_TEAM_REMOVE, 0xCE5E},
            {Opcode.CMSG_AUCTION_LIST_ITEMS, 0xDC5F},
            {Opcode.CMSG_AUCTION_PLACE_BID, 0x8E76},
            {Opcode.CMSG_AUCTION_REMOVE_ITEM, 0xCEC3},
            {Opcode.CMSG_AUCTION_SELL_ITEM, 0xCE6},
            {Opcode.CMSG_AUTH_SESSION, 0x1019},
            {Opcode.CMSG_AUTOEQUIP_ITEM, 0x8E66},
            {Opcode.CMSG_AUTO_DECLINE_GUILD_INVITES, 0x586F},
            {Opcode.CMSG_BATTLEFIELD_LIST, 0x32A4},
            {Opcode.CMSG_BUG, 0x1A77},
            {Opcode.CMSG_BUYBACK_ITEM, 0xDEE6},
            {Opcode.CMSG_BUY_BANK_SLOT, 0x487F},
            {Opcode.CMSG_CALENDAR_ADD_EVENT, 0x1CF3},
            {Opcode.CMSG_CALENDAR_EVENT_INVITE, 0x1EDA},
            {Opcode.CMSG_CALENDAR_UPDATE_EVENT, 0x5CD2},
            {Opcode.CMSG_CANCEL_AUTO_REPEAT_SPELL, 0x5CEE},
            {Opcode.CMSG_CANCEL_CAST, 0x5A73},
            {Opcode.CMSG_CANCEL_CHANNELLING, 0xC8FE},
            {Opcode.CMSG_CANCEL_GROWTH_AURA, 0xDEF7},
            {Opcode.CMSG_CANCEL_MOUNT_AURA, 0xD8F3},
            {Opcode.CMSG_CANCEL_TRADE, 0x35A5},
            {Opcode.CMSG_CAST_SPELL, 0x5E4E},
            {Opcode.CMSG_CHAR_CREATE, 0x1AC6},
            {Opcode.CMSG_CHAR_CUSTOMIZE, 0xDECF},
            {Opcode.CMSG_CHAR_DELETE, 0x1ED3},
            {Opcode.CMSG_CHAR_ENUM, 0x4A8B},
            {Opcode.CMSG_CHAR_FACTION_CHANGE, 0xCCEE},
            {Opcode.CMSG_CHAR_RACE_CHANGE, 0xDC57},
            {Opcode.CMSG_CHAR_RENAME, 0x5E6F},
            {Opcode.CMSG_CLEAR_CHANNEL_WATCH, 0x9CC2},
            {Opcode.CMSG_COMMENTATOR_ENABLE, 0x1CF7},
            {Opcode.CMSG_COMMENTATOR_ENTER_INSTANCE, 0x8EF6},
            {Opcode.CMSG_COMMENTATOR_EXIT_INSTANCE, 0x4C7B},
            {Opcode.CMSG_COMMENTATOR_GET_MAP_INFO, 0xDEE7},
            {Opcode.CMSG_COMMENTATOR_GET_PLAYER_INFO, 0x9EF3},
            {Opcode.CMSG_COMMENTATOR_INSTANCE_COMMAND, 0x5CEB},
            {Opcode.CMSG_COMMENTATOR_SKIRMISH_QUEUE_COMMAND, 0x9C4E},
            {Opcode.CMSG_COMPLETE_CINEMATIC, 0x1A6F},
            {Opcode.CMSG_CONTACT_LIST, 0xCECF},
            {Opcode.CMSG_CORPSE_MAP_POSITION_QUERY, 0xDC7F},
            {Opcode.CMSG_CREATURE_QUERY, 0x5A7E},
            {Opcode.CMSG_DANCE_QUERY, 0x5C5E},
            {Opcode.CMSG_DEL_FRIEND, 0xC852},
            {Opcode.CMSG_DEL_IGNORE, 0x8ADA},
            {Opcode.CMSG_DEL_VOICE_IGNORE, 0x8C73},
            {Opcode.CMSG_DESTROYITEM, 0x4E7A},
            {Opcode.CMSG_EMOTE, 0x9843},
            {Opcode.CMSG_EQUIPMENT_SET_DELETE, 0x9CF2},
            {Opcode.CMSG_EQUIPMENT_SET_SAVE, 0x5E5F},
            {Opcode.CMSG_EQUIPMENT_SET_USE, 0x4853},
            {Opcode.CMSG_GAMEOBJECT_QUERY, 0xCEFF},
            {Opcode.CMSG_GAMEOBJ_USE, 0x9A4A},
            {Opcode.CMSG_GET_MAIL_LIST, 0xB284},
            {Opcode.CMSG_GET_MIRRORIMAGE_DATA, 0xDAF3},
            {Opcode.CMSG_GMTICKET_SYSTEMSTATUS, 0x4A7A},
            {Opcode.CMSG_GMTICKET_UPDATETEXT, 0x8A7B},
            {Opcode.CMSG_GOSSIP_HELLO, 0xAD3},
            {Opcode.CMSG_GOSSIP_SELECT_OPTION, 0x984E},
            {Opcode.CMSG_GRANT_LEVEL, 0x1CD6},
            {Opcode.CMSG_GROUP_ASSISTANT_LEADER, 0xC8CA},
            {Opcode.CMSG_GROUP_CHANGE_SUB_GROUP, 0x1AD2},
            {Opcode.CMSG_GROUP_RAID_CONVERT, 0xC85A},
            {Opcode.CMSG_GROUP_SET_LEADER, 0xCEC7},
            {Opcode.CMSG_GROUP_SWAP_SUB_GROUP, 0x5AD7},
            {Opcode.CMSG_GUILD_BANKER_ACTIVATE, 0x4E77},
            {Opcode.CMSG_GUILD_BANK_QUERY_TAB, 0xDE46},
            {Opcode.CMSG_GUILD_BANK_SWAP_ITEMS, 0x85B},
            {Opcode.CMSG_GUILD_INFO, 0xCE76},
            {Opcode.CMSG_GUILD_INVITE, 0x8C67},
            {Opcode.CMSG_GUILD_QUERY, 0x8E57},
            {Opcode.CMSG_GUILD_RANK, 0x8D50},
            {Opcode.CMSG_GUILD_ROSTER, 0x9952},
            {Opcode.CMSG_GUILD_SET_NOTE, 0x9958},
            {Opcode.CMSG_GUILDFINDER_JOIN, 0x68C5},
            {Opcode.CMSG_INSPECT, 0x9A7B},
            {Opcode.CMSG_INSTANCE_LOCK_WARNING_RESPONSE, 0x8CF7},
            {Opcode.CMSG_ITEM_QUERY_SINGLE, 0x8E2},
            {Opcode.CMSG_ITEM_REFUND, 0xCC3},
            {Opcode.CMSG_ITEM_REFUND_INFO, 0x1C7E},
            {Opcode.CMSG_ITEM_TEXT_QUERY, 0x4AEB},
            {Opcode.CMSG_JOIN_CHANNEL, 0x3441},
            {Opcode.CMSG_KEEP_ALIVE, 0xC87A},
            {Opcode.CMSG_LEARN_PREVIEW_TALENTS, 0xDEE3},
            {Opcode.CMSG_LEARN_PREVIEW_TALENTS_PET, 0x9AFB},
            {Opcode.CMSG_LEARN_TALENT, 0x98F3},
            {Opcode.CMSG_LEAVE_BATTLEFIELD, 0x1AE7},
            {Opcode.CMSG_LFG_SET_ROLES, 0x4843},
            {Opcode.CMSG_LFG_TELEPORT, 0x8C7A},
            {Opcode.CMSG_LIST_INVENTORY, 0xDCFE},
            {Opcode.CMSG_LOAD_SCREEN, 0x0888},
            {Opcode.CMSG_LOGOUT_CANCEL, 0xA76},
            {Opcode.CMSG_LOGOUT_REQUEST, 0x4C7A},
            {Opcode.CMSG_LOOT, 0x0A5E},
            {Opcode.CMSG_LOOT_RELEASE, 0x4A6A},
            {Opcode.CMSG_MAIL_CREATE_TEXT_ITEM, 0x886E},
            {Opcode.CMSG_MAIL_DELETE, 0x4CCF},
            {Opcode.CMSG_MAIL_RETURN_TO_SENDER, 0x587E},
            {Opcode.CMSG_MAIL_TAKE_ITEM, 0xCC2},
            {Opcode.CMSG_MAIL_TAKE_MONEY, 0x4CD6},
            {Opcode.CMSG_MEETINGSTONE_INFO, 0xCA5B},
            {Opcode.CMSG_MESSAGECHAT_ADDON, 0x24D9},
            {Opcode.CMSG_MESSAGECHAT_CHANNEL, 0x7459},
            {Opcode.CMSG_MESSAGECHAT_EMOTE, 0x6449},
            {Opcode.CMSG_MESSAGECHAT_GUILD, 0x60C1},
            {Opcode.CMSG_MESSAGECHAT_PARTY, 0x24C9},
            {Opcode.CMSG_MESSAGECHAT_SAY, 0x2459},
            {Opcode.CMSG_MESSAGECHAT_WHISPER, 0x70D9},
            {Opcode.CMSG_MESSAGECHAT_YELL, 0x70C1},
            {Opcode.CMSG_NAME_QUERY, 0x586A},
            {Opcode.CMSG_NEXT_CINEMATIC_CAMERA, 0x8E63},
            {Opcode.CMSG_NPC_TEXT_QUERY, 0x5C63},
            {Opcode.CMSG_OFFER_PETITION, 0xC8DE},
            {Opcode.CMSG_OPENING_CINEMATIC, 0xD8D2},
            {Opcode.CMSG_OPEN_ITEM, 0x88C7},
            {Opcode.CMSG_PAGE_TEXT_QUERY, 0x8A5F},
            {Opcode.CMSG_PETITION_BUY, 0x8E4E},
            {Opcode.CMSG_PETITION_QUERY, 0xCEF3},
            {Opcode.CMSG_PETITION_SHOW_SIGNATURES, 0x1E66},
            {Opcode.CMSG_PETITION_SIGN, 0x4A5E},
            {Opcode.CMSG_PET_ACTION, 0x1AEA},
            {Opcode.CMSG_PET_LEARN_TALENT, 0x48E6},
            {Opcode.CMSG_PET_NAME_QUERY, 0xDA76},
            {Opcode.CMSG_PING, 0x1008},
            {Opcode.CMSG_PLAYED_TIME, 0x5A56},
            {Opcode.CMSG_PLAYER_LOGIN, 0x0898},
            {Opcode.CMSG_PLAYER_LOGOUT, 0x1CEE},
            {Opcode.CMSG_PLAY_DANCE, 0x5857},
            {Opcode.CMSG_PUSHQUESTTOPARTY, 0xA47},
            {Opcode.CMSG_QUERY_QUESTS_COMPLETED, 0x98DF},
            {Opcode.CMSG_QUERY_TIME, 0x18FE},
            {Opcode.CMSG_QUESTGIVER_ACCEPT_QUEST, 0x8CD3},
            {Opcode.CMSG_QUESTGIVER_CANCEL, 0xC86A},
            {Opcode.CMSG_QUESTGIVER_CHOOSE_REWARD, 0x18F3},
            {Opcode.CMSG_QUESTGIVER_COMPLETE_QUEST, 0xCCE3},
            {Opcode.CMSG_QUESTGIVER_QUERY_QUEST, 0x8CE7},
            {Opcode.CMSG_QUESTGIVER_REQUEST_REWARD, 0xD8E7},
            {Opcode.CMSG_QUESTGIVER_STATUS_MULTIPLE_QUERY, 0xC8DB},
            {Opcode.CMSG_QUESTGIVER_STATUS_QUERY, 0x88C6},
            {Opcode.CMSG_QUESTLOG_REMOVE_QUEST, 0x8EFF},
            {Opcode.CMSG_QUEST_CONFIRM_ACCEPT, 0xC63},
            {Opcode.CMSG_QUEST_QUERY, 0xCE7F},
            {Opcode.CMSG_RANDOMIZE_CHAR_NAME, 0x8A99},
            {Opcode.CMSG_READY_FOR_ACCOUNT_DATA_TIMES, 0xCCDB},
            {Opcode.CMSG_REALM_SPLIT, 0xDC66},
            {Opcode.CMSG_RECLAIM_CORPSE, 0x88DB},
            {Opcode.CMSG_REDIRECTION_AUTH_PROOF, 0x1039},
            {Opcode.CMSG_REPAIR_ITEM, 0xCF3},
            {Opcode.CMSG_REPOP_REQUEST, 0x8872},
            {Opcode.CMSG_REQUEST_PARTY_MEMBER_STATS, 0x987E},
            {Opcode.CMSG_REQUEST_PET_INFO, 0x9A47},
            {Opcode.CMSG_REQUEST_VEHICLE_EXIT, 0xCC6},
            {Opcode.CMSG_REQUEST_VEHICLE_NEXT_SEAT, 0xCAD6},
            {Opcode.CMSG_REQUEST_VEHICLE_PREV_SEAT, 0x1AE2},
            {Opcode.CMSG_RESET_INSTANCES, 0x9EEA},
            {Opcode.CMSG_RETURN_TO_GRAVEYARD, 0x91A4},
            {Opcode.CMSG_SELF_RES, 0xCCFE},
            {Opcode.CMSG_SELL_ITEM, 0x5EE3},
            {Opcode.CMSG_SETSHEATHED, 0xCA5F},
            {Opcode.CMSG_SET_ACTIONBAR_TOGGLES, 0x584F},
            {Opcode.CMSG_SET_ALLOW_LOW_LEVEL_RAID1, 0xC863},
            {Opcode.CMSG_SET_ALLOW_LOW_LEVEL_RAID2, 0x4CE7},
            {Opcode.CMSG_SET_CONTACT_NOTES, 0x1AF3},
            {Opcode.CMSG_SET_PLAYER_DECLINED_NAMES, 0xC847},
            {Opcode.CMSG_SET_PRIMARY_TALENT_TREE, 0x185E},
            {Opcode.CMSG_SET_SAVED_INSTANCE_EXTEND, 0x8E62},
            {Opcode.CMSG_SET_SELECTION, 0x4C4E},
            {Opcode.CMSG_SET_TAXI_BENCHMARK_MODE, 0x1EFF},
            {Opcode.CMSG_SET_TITLE, 0xCE63},
            {Opcode.CMSG_SHOWING_CLOAK, 0x8AE3},
            {Opcode.CMSG_SHOWING_HELM, 0xCEFA},
            {Opcode.CMSG_SPELLCLICK, 0xC8F2},
            {Opcode.CMSG_SPIRIT_HEALER_ACTIVATE, 0x5AEB},
            {Opcode.CMSG_STANDSTATECHANGE, 0x9EC6},
            {Opcode.CMSG_SUMMON_RESPONSE, 0xD84E},
            {Opcode.CMSG_SWAP_INV_ITEM, 0x5CE7},
            {Opcode.CMSG_SWAP_ITEM, 0xDED6},
            {Opcode.CMSG_TAXINODE_STATUS_QUERY, 0x98E3},
            {Opcode.CMSG_TELEPORT_TO_UNIT, 0x8C72},
            {Opcode.CMSG_TOGGLE_PVP, 0x8ECA},
            {Opcode.CMSG_TEXT_EMOTE, 0x08D3},
            {Opcode.CMSG_TIME_SYNC_RESP, 0x07A5},
            {Opcode.CMSG_TRAINER_BUY_SPELL, 0xAF7},
            {Opcode.CMSG_TRAINER_LIST, 0xCC7F},
            {Opcode.CMSG_TURN_IN_PETITION, 0x9C67},
            {Opcode.CMSG_UNLEARN_SKILL, 0xAC3},
            {Opcode.CMSG_UPDATE_ACCOUNT_DATA, 0x4AFE},
            {Opcode.CMSG_VERIFY_CONNECTIVITY_RESPONSE, 0x4C52},
            {Opcode.CMSG_WARDEN_DATA, 0x5847},
            {Opcode.CMSG_WHO, 0x9AD7},
            {Opcode.CMSG_WHOIS, 0xCCE6},
            {Opcode.CMSG_WORLD_STATE_UI_TIMER_UPDATE, 0x58F6},
            {Opcode.CMSG_ZONEUPDATE, 0x4AE2},
            //{Opcode.MSG_GUILD_BANK_MONEY_WITHDRAWN, 0xDE77},
            {Opcode.MSG_MOVE_JUMP, 0x9225},
            {Opcode.MSG_MOVE_SET_FACING, 0x02a4},
            {Opcode.MSG_MOVE_SET_PITCH, 0xA7A5},
            {Opcode.MSG_MOVE_SET_RUN_MODE, 0x21A4},
            {Opcode.MSG_MOVE_SET_WALK_MODE, 0x24A4},
            {Opcode.MSG_MOVE_START_ASCEND, 0x0624},
            {Opcode.MSG_MOVE_START_DESCEND, 0x2624},
            {Opcode.MSG_MOVE_STOP_ASCEND, 0x1125},
            {Opcode.MSG_MOVE_START_BACKWARD, 0x10A5},
            {Opcode.MSG_MOVE_START_FORWARD, 0xA0A4},
            {Opcode.MSG_MOVE_START_PITCH_UP, 0x9524},
            {Opcode.MSG_MOVE_START_PITCH_DOWN, 0x2025},
            {Opcode.MSG_MOVE_START_TURN_LEFT, 0x01A5},
            {Opcode.MSG_MOVE_START_TURN_RIGHT, 0xB6A4},
            {Opcode.MSG_MOVE_START_STRAFE_LEFT, 0xA024},
            {Opcode.MSG_MOVE_START_STRAFE_RIGHT, 0x9125},
            {Opcode.MSG_MOVE_START_SWIM, 0x85A4},
            {Opcode.MSG_MOVE_STOP, 0xA3A4},
            {Opcode.MSG_MOVE_STOP_PITCH, 0x8425},
            {Opcode.MSG_MOVE_STOP_TURN, 0x90A4},
            {Opcode.MSG_MOVE_STOP_STRAFE, 0x0125},
            {Opcode.MSG_MOVE_STOP_SWIM, 0xB424},
            {Opcode.MSG_LIST_STABLED_PETS, 0x88CA},
            {Opcode.MSG_PETITION_DECLINE, 0x98E7},
            {Opcode.MSG_PETITION_RENAME, 0x4857},
            {Opcode.MSG_QUERY_NEXT_MAIL_TIME, 0xCEE6},
            {Opcode.MSG_QUEST_PUSH_RESULT, 0x1863},
            {Opcode.MSG_RAID_READY_CHECK, 0x584E},
            {Opcode.MSG_RAID_READY_CHECK_CONFIRM, 0x584E},
            {Opcode.MSG_RANDOM_ROLL, 0x4C57},
            {Opcode.MSG_SET_DUNGEON_DIFFICULTY, 0xC4F},
            {Opcode.MSG_SET_RAID_DIFFICULTY, 0x1A5A},
            {Opcode.MSG_TABARDVENDOR_ACTIVATE, 0x98EB},
            {Opcode.SMSG_ACTION_BUTTONS, 0x8A6B},
            {Opcode.SMSG_ACCOUNT_DATA_TIMES, 0x5EE2},
            {Opcode.SMSG_ACTIVATETAXIREPLY, 0x8E4F},
            {Opcode.SMSG_ADDON_INFO, 0x9863},
            {Opcode.SMSG_ARENA_TEAM_CHANGE_FAILED_QUEUED, 0x4A4E},
            {Opcode.SMSG_AURA_UPDATE, 0x4C66},
            {Opcode.SMSG_AURA_UPDATE_ALL, 0x18EE},
            {Opcode.SMSG_AUTH_CHALLENGE, 0x1181},
            {Opcode.SMSG_AUTH_RESPONSE, 0x8867},
            {Opcode.SMSG_BATTLEFIELD_LIST, 0xB64E},
            {Opcode.SMSG_BREAK_TARGET, 0xE7E},
            {Opcode.SMSG_CAST_FAILED, 0x1AEB},
            {Opcode.SMSG_CHANNEL_NOTIFY, 0x9C7F},
            {Opcode.SMSG_CHAR_CREATE, 0x4C5B},
            {Opcode.SMSG_CHAR_DELETE, 0x48CE},
            {Opcode.SMSG_CHAR_ENUM, 0xA05C},
            {Opcode.SMSG_CHAT_WRONG_FACTION, 0xE66},
            {Opcode.SMSG_CLIENTCACHE_VERSION, 0x88F2},
            {Opcode.SMSG_COMBAT_LOG_MULTIPLE, 0x5C56},
            {Opcode.SMSG_COMPRESSED_CHAR_ENUM, 0x380A},
            {Opcode.SMSG_COMPRESSED_GUILD_ROSTER, 0x5A29},
            {Opcode.SMSG_COMPRESSED_UPDATE_OBJECT, 0x1CC3},
            {Opcode.SMSG_CONTACT_LIST, 0x0A6B},
            {Opcode.SMSG_CORPSE_NOT_IN_INSTANCE, 0xCACB},
            {Opcode.SMSG_CORPSE_RECLAIM_DELAY, 0xCD46},
            {Opcode.SMSG_CREATURE_QUERY_RESPONSE, 0xD847},
            {Opcode.SMSG_CRITERIA_UPDATE, 0xD87F},
            {Opcode.SMSG_DB_REPLY, 0x76EC},
            {Opcode.SMSG_DESTROY_OBJECT, 0x486B},
            {Opcode.SMSG_DUEL_WINNER, 0xDA52},
            {Opcode.SMSG_EMOTE, 0xC67},
            {Opcode.SMSG_EQUIPMENT_SET_LIST, 0x18DF},
            {Opcode.SMSG_FEATURE_SYSTEM_STATUS, 0x70CE},
            {Opcode.SMSG_FISH_ESCAPED, 0x9C66},
            {Opcode.SMSG_FISH_NOT_HOOKED, 0x18C3},
            {Opcode.SMSG_GAMEOBJECT_QUERY_RESPONSE, 0xCCF7},
            {Opcode.SMSG_GMTICKET_SYSTEMSTATUS, 0x9C7E},
            {Opcode.SMSG_GM_MESSAGECHAT, 0x8E5E}, // Not confirmed
            {Opcode.SMSG_GODMODE, 0xDEEE},
            {Opcode.SMSG_GOSSIP_MESSAGE, 0xCCEB},
            {Opcode.SMSG_GOSSIP_POI, 0x1866},
            {Opcode.SMSG_GUILD_COMMAND_RESULT, 56023},
            {Opcode.SMSG_GUILD_BANK_LIST, 0x5EFB},
            {Opcode.SMSG_GUILD_EVENT, 0x8AC2},
            {Opcode.SMSG_GUILD_QUERY_RESPONSE, 0xCA66},
            {Opcode.SMSG_GUILD_RANK, 0xA6EC},
            {Opcode.SMSG_GUILD_ROSTER, 0x664C},
            {Opcode.SMSG_GUILD_SET_NOTE, 0xB6CE},
            {Opcode.SMSG_INIT_CURRENCY, 0x227E},
            {Opcode.SMSG_INIT_WORLD_STATES, 0x9EDA},
            {Opcode.SMSG_INITIAL_SPELLS, 0x88FE},
            {Opcode.SMSG_ITEM_PUSH_RESULT, 0x8EFB},
            {Opcode.SMSG_INVALID_PROMOTION_CODE, 0xD8FE},
            {Opcode.SMSG_LEARNED_DANCE_MOVES, 0x0E52},
            {Opcode.SMSG_LFGUILD_RECRUIT_DATA, 0xE0CE}, // Made up name
            {Opcode.SMSG_LFG_PLAYER_INFO, 0xC85F},
            {Opcode.SMSG_LIST_INVENTORY, 0x264C},
            {Opcode.SMSG_LOGIN_VERIFY_WORLD, 0xC86E},
            {Opcode.SMSG_LOG_XPGAIN, 0x4E7E},
            {Opcode.SMSG_LOGOUT_COMPLETE, 0xCC6B},
            {Opcode.SMSG_LOGOUT_RESPONSE, 0x886A},
            {Opcode.SMSG_LOOT_RESPONSE, 0x0842},
            {Opcode.SMSG_MESSAGECHAT, 0x5E52},
            {Opcode.SMSG_MONSTER_MOVE, 0x4C53},
            {Opcode.SMSG_MONSTER_MOVE_TRANSPORT, 0x88FB},
            {Opcode.SMSG_MOTD, 0xCA4B},
            {Opcode.SMSG_NAME_QUERY_RESPONSE, 0x9CE6},
            {Opcode.SMSG_NEW_TAXI_PATH, 0xC8FF}, // Might be 0x98CF
            {Opcode.SMSG_NPC_TEXT_UPDATE, 0x4C72},
            {Opcode.SMSG_PAGE_TEXT_QUERY_RESPONSE, 0x18D2},
            {Opcode.SMSG_PET_NAME_QUERY_RESPONSE, 0xDCD3},
            {Opcode.SMSG_PET_LEARNED_SPELL, 0xDC5E},
            {Opcode.SMSG_PET_REMOVED_SPELL, 0x18F6}, // Should actually be called UNLEARNED_SPELL
            {Opcode.SMSG_PET_SPELLS, 0x5A43},
            {Opcode.SMSG_PETITION_QUERY_RESPONSE, 0xCAEE},
            {Opcode.SMSG_PETITION_SHOWLIST, 0x8ED7},
            {Opcode.SMSG_PETITION_SHOW_SIGNATURES, 0x4E4A},
            {Opcode.SMSG_PETITION_SIGN_RESULTS, 0x5EE6},
            {Opcode.SMSG_PLAYERBINDERROR, 0x5A4F},
            {Opcode.SMSG_PLAY_SOUND, 0x4ACF},
            {Opcode.SMSG_PONG, 0x0380},
            {Opcode.SMSG_POWER_UPDATE, 0x487E},
            {Opcode.SMSG_QUESTGIVER_QUEST_COMPLETE, 0x24EE},
            {Opcode.SMSG_QUESTGIVER_QUEST_DETAILS, 0xCE5F},
            {Opcode.SMSG_QUESTGIVER_QUEST_FAILED, 0xD8FF},
            {Opcode.SMSG_QUESTGIVER_QUEST_LIST, 0xDEF6},
            {Opcode.SMSG_QUESTGIVER_REQUEST_ITEMS, 0x9CEE},
            {Opcode.SMSG_QUESTGIVER_STATUS, 0xC846},
            {Opcode.SMSG_QUESTGIVER_STATUS_MULTIPLE, 0xDCFF},
            {Opcode.SMSG_QUESTLOG_FULL, 0x4EDE},
            {Opcode.SMSG_QUESTUPDATE_COMPLETE, 0x9CD6},
            {Opcode.SMSG_QUESTUPDATE_FAILED, 0x9EF6},
            {Opcode.SMSG_QUEST_QUERY_RESPONSE, 0x9E56},
            {Opcode.SMSG_RANDOMIZE_CHAR_NAME, 0xF0DC},
            {Opcode.SMSG_REALM_SPLIT, 0x1AF2},
            {Opcode.SMSG_REDIRECT_CLIENT, 0x0180},
            {Opcode.SMSG_REFER_A_FRIEND_FAILURE, 0x4867},
            {Opcode.SMSG_SERVER_MESSAGE, 0xC873},
            {Opcode.SMSG_SET_PHASE_SHIFT, 0x204C},
            {Opcode.SMSG_SET_FLAT_SPELL_MODIFIER, 0x88D3}, // unsure: can be 0x98FE
            {Opcode.SMSG_SET_PCT_SPELL_MODIFIER, 0x98FE}, // unsure: can be 0x88D3
            {Opcode.SMSG_SHOWTAXINODES, 0x8CFB},
            {Opcode.SMSG_SPELL_FAILED_OTHER, 0xCE4A},
            {Opcode.SMSG_SPELL_FAILURE, 0x9A66},
            {Opcode.SMSG_SPELL_GO, 0x0A53},
            {Opcode.SMSG_SPELL_START, 0xCE43},
            {Opcode.SMSG_STANDSTATE_UPDATE, 0x4E52},
            {Opcode.SMSG_TEXT_EMOTE, 0x9E5A},
            {Opcode.SMSG_TIME_SYNC_REQ, 0x1009},
            {Opcode.SMSG_TITLE_EARNED, 0x1AFA},
            {Opcode.SMSG_TAXINODE_STATUS, 0x8CFB},
            {Opcode.SMSG_TOGGLE_XP_GAIN, 0x8A5B},
            {Opcode.SMSG_TRAINER_LIST, 0xC84E},
            {Opcode.SMSG_TRIGGER_CINEMATIC, 0xCE5B},
            {Opcode.SMSG_TURN_IN_PETITION_RESULTS, 0x08DB},
            {Opcode.SMSG_TUTORIAL_FLAGS, 0x1A46},
            {Opcode.SMSG_UPDATE_ACCOUNT_DATA_COMPLETE, 0x5E53},
            {Opcode.SMSG_UPDATE_OBJECT, 0x1EE7},
            {Opcode.SMSG_WARDEN_DATA ,0x484F},
            {Opcode.SMSG_WEATHER, 0x4ECE},
            {Opcode.SMSG_WHO, 0x4C7F},

            // Unsure
            /*
                {Opcode.SMSG_SET_PROFICIENCY, 0x9C5F},
                {Opcode.SMSG_LEVELUP_INFO, 0x9A73},
            */
            // Tests
            {Opcode.TEST_422_41036, 0xA04C},
        };
    }
}
