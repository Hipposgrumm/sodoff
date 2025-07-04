namespace sodoff.Util;
public class ClientVersion {
    public const uint Min_SoD   = 0xa0000000;
    public const uint MaM       = 0x80000000;
    public const uint Max_OldJS = 0x0fffffff; // x <= Max_OldJS <=> x in [MB, EMD, SS, WoJS, Lands, ...]
    public const uint MB        = 0x08000000;
    public const uint EMD       = 0x04000000;
    public const uint SS        = 0x02000000;
    public const uint WoJS      = 0x01000000;
    public const uint WoJS_AdvLand    = 0x01000100; // World of JumpStart -- Adventureland
    public const uint WoJS_FutureLand = 0x01000200; // World of JumpStart -- Futureland
    public const uint WoJS_MarineLand = 0x01000300; // World of JumpStart -- Marineland
    public const uint WoJS_StoryLand  = 0x01000400; // World of JumpStart -- Storyland
    public const uint WoJS_NewAvatar  = 0x01010000; // World of JumpStart with new avatars (e.g. 1.21)

    public static uint GetGameID(uint gameVersion) {
        if (gameVersion > ClientVersion.Max_OldJS)
            return gameVersion & 0xf0000000;
        else
            return gameVersion & 0x0f000000;
    }

    public static uint GetGameID(string apiKey) {
        return GetGameID(GetVersion(apiKey));
    }

    public static uint GetVersion(string apiKey) {
        if (
            apiKey == "b99f695c-7c6e-4e9b-b0f7-22034d799013" || // PC / Windows
            apiKey == "515af675-bec7-4c42-ba64-7bfaf198d8ea" || // Android
            apiKey == "1e7ccc3a-4adb-4736-b843-7b3da5140a43"    // iOS
        ) {
            return 0xa3a31a0a;
        } else if (
            apiKey.EndsWith("7c6e-4e9b-b0f7-22034d799013")
        ) {
            return Convert.ToUInt32(apiKey.Substring(0, 8), 16);
        } else if (
            apiKey == "e20150cc-ff70-435c-90fd-341dc9161cc3"
        ) {
            return MaM;
        } else if (
            apiKey == "6738196d-2a2c-4ef8-9b6e-1252c6ec7325"
        ) {
            return MB;
        } else if (
            apiKey == "dd602cf1-cc98-4738-9a0a-56dde3026947"
        ) {
            return EMD;
        } else if (
            apiKey == "34b0ae13-eccc-4d64-b6d0-733d2562080e"
        ) {
            return SS;
        } else if (
            apiKey == "15a1a21a-4a95-46f5-80e2-58574da65875"
        ) {
            return WoJS_NewAvatar;
        } else if (
            apiKey == "1552008f-4a95-46f5-80e2-58574da65875"
        ) {
            return WoJS;
        } else if (
            apiKey == "b4e0f71a-1cda-462a-97b3-0b355e87e0c8"
        ) {
            return WoJS_AdvLand;
        } else if (
            apiKey == "4fb5e29f-64e7-4cbb-8554-6f6c54b57597"
        ) {
            return WoJS_FutureLand;
        } else if (
            apiKey == "dc37ef0d-e1f8-4718-8239-73e68424e384"
        ) {
            return WoJS_MarineLand;
        } else if (
            apiKey == "bd69b6b9-a921-4741-a2a0-92fc40cc2e58"
        ) {
            return WoJS_StoryLand;
        }
        Console.WriteLine($"Unknown apiKey value: {apiKey}");
        return 0;
    }
}
