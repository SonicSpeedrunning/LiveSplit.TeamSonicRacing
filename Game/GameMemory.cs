using LiveSplit.ComponentUtil;
using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace LiveSplit.TeamSonicRacing
{
    class Watchers : MemoryWatcherList
    {
        // General variables
        private MemoryWatcher<byte> GameMode1 { get; set; }
        private MemoryWatcher<byte> GameMode2 { get; set; }
        public GameMode GameMode => this.GameMode1.Current == 0 ? GameMode.TeamAdventure : this.GameMode2.Current == 0 ? GameMode.GrandPrix : this.GameMode2.Current == 1 ? GameMode.SingleRaces : GameMode.Undefined;

        // Story mode variables
        public MemoryWatcher<byte> TeamAdventureStart { get; set; }
        public MemoryWatcher<byte> RequiredLaps { get; set; }
        private MemoryWatcher<byte> Stars1 { get; set; }
        private MemoryWatcher<byte> Stars2 { get; set; }
        private MemoryWatcher<byte> Stars3 { get; set; }
        private MemoryWatcher<byte> Stars4 { get; set; }
        private MemoryWatcher<byte> Stars5 { get; set; }
        private MemoryWatcher<byte> Stars6 { get; set; }
        private MemoryWatcher<byte> Stars7 { get; set; }
        public FakeMemoryWatcher<int> Stars => new FakeMemoryWatcher<int>(
            this.Stars1.Old + this.Stars2.Old + this.Stars3.Old + this.Stars4.Old + this.Stars5.Old + this.Stars6.Old + this.Stars7.Old,
            this.Stars1.Current + this.Stars2.Current + this.Stars3.Current + this.Stars4.Current + this.Stars5.Current + this.Stars6.Current + this.Stars7.Current);

        public MemoryWatcher<float> TotalRaceTimeAdventure { get; set; }  // Used in place of the IGT in special cases

        // Other variables
        public MemoryWatcher<byte> RunStart { get; set; }
        public MemoryWatcher<byte> RaceRulings { get; set; }
        public MemoryWatcher<byte> RaceStatus { get; set; }
        public MemoryWatcher<byte> RaceCompleted { get; set; }
        public MemoryWatcher<float> IGT { get; set; }
        public MemoryWatcher<float> TotalRaceTime { get; set; }
        public MemoryWatcher<byte> AbortRace { get; set; }
        private MemoryWatcher<uint> Track { get; set; }
        public Tracks CurrentTrack => (Tracks)this.Track.Current;


        // Used for the last split in Team Adventure Mode
        public MemoryWatcher<byte> Credits { get; set; }
        public MemoryWatcher<byte> SkippedCredits { get; set; }
        public MemoryWatcher<byte> TeamAdventureTrac { get; set; }
        public TeamAdventureTracks TeamAdventureTrack => (TeamAdventureTracks)this.TeamAdventureTrac.Current;

        // Used in GP mode
        private MemoryWatcher<byte> GPINDEX { get; set; }
        private MemoryWatcher<byte> GPTRACK { get; set; }
        public GrandPrixTracks GrandPrixTrack => (GrandPrixTracks)(this.GPINDEX.Current * 10 + this.GPTRACK.Current);

        // Other variables
        public double ProgressIGT { get; set; }
        public double TotalIGT { get; set; }
        public double FrozenIGT { get; set; }
        public byte FinalSplit { get; set; }


        public Watchers(Process game)
        {
            var scanner = new SignatureScanner(game, game.MainModuleWow64Safe().BaseAddress, game.MainModuleWow64Safe().ModuleMemorySize);
            IntPtr ptr;

            // Basic checks
            if (!game.Is64Bit()) throw new Exception();
            ptr = scanner.Scan(new SigScanTarget("54 65 61 6D 20 53 6F 6E 69 63 20 52 61 63 69 6E 67")); if (ptr == IntPtr.Zero) throw new Exception();

            // TeamAdventureStart
            ptr = scanner.Scan(new SigScanTarget(1,
                "E8 ????????",      // call GameApp_PcDx11_x64Final.exe+1BCA80
                "48 8B F0",         // mov rsi,rax
                "33 FF"));          // xor edi,edi
            if (ptr == IntPtr.Zero) throw new Exception();
            ptr = ptr + game.ReadValue<int>(ptr) + 0x4 + 0x10;
            this.TeamAdventureStart = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x0)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // GameMode1 and GameMode2
            ptr = scanner.Scan(new SigScanTarget(1, "74 56 8D 4B 38")); if (ptr == IntPtr.Zero) throw new Exception();
            ptr = ptr + game.ReadValue<byte>(ptr) + 0x1 + 0x2;
            this.GameMode1 = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr))) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };
            this.GameMode2 = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr) + 0xC4)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // RequiredLaps
            ptr = scanner.Scan(new SigScanTarget(3, "4C 8B 15 ???????? 4D 85 D2 74 27")); if (ptr == IntPtr.Zero) throw new Exception();
            this.RequiredLaps = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x0, 0x110, 0x10)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };
            this.TotalRaceTime = new MemoryWatcher<float>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x0, 0x110, 0x30)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // Stars
            ptr = scanner.Scan(new SigScanTarget(1, "E8 ???????? 48 39 05")); if (ptr == IntPtr.Zero) throw new Exception();
            ptr = ptr + game.ReadValue<int>(ptr) + 0x4 + 0x3E + 0x3;
            this.Stars1 = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x48, 0x008, 0x22C)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };
            this.Stars2 = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x48, 0x040, 0x22C)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };
            this.Stars3 = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x48, 0x088, 0x22C)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };
            this.Stars4 = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x48, 0x0C8, 0x22C)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };
            this.Stars5 = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x48, 0x108, 0x22C)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };
            this.Stars6 = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x48, 0x148, 0x22C)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };
            this.Stars7 = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x48, 0x190, 0x22C)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };
            this.TeamAdventureTrac = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x11)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // TotalRaceTimeAdventure
            ptr = scanner.Scan(new SigScanTarget(1, "74 0E 83 7F 60 FF")); if (ptr == IntPtr.Zero) throw new Exception();
            ptr = ptr + game.ReadValue<byte>(ptr) + 0x1 + 0x3;
            this.TotalRaceTimeAdventure = new MemoryWatcher<float>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x38)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // RunStart
            ptr = scanner.Scan(new SigScanTarget(6, "4C 89 F2 48 8B 0D")); if (ptr == IntPtr.Zero) throw new Exception();
            this.RunStart = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x50, 0xD44)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // RaceRulings & Track
            ptr = scanner.Scan(new SigScanTarget(3, "48 8B 0D ???????? E8 ???????? 85 C0 75 28")); if (ptr == IntPtr.Zero) throw new Exception();
            this.RaceRulings = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x340)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };
            this.Track = new MemoryWatcher<uint>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x324)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // AbortRace
            ptr = scanner.Scan(new SigScanTarget(7, "48 83 EC 40 48 8B 05 ???????? 48 89 CB 83 B8")); if (ptr == IntPtr.Zero) throw new Exception();
            this.AbortRace = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr), 0x25C)) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // RaceStatus
            ptr = scanner.Scan(new SigScanTarget(1, "74 72 83 BE")); if (ptr == IntPtr.Zero) throw new Exception();
            ptr = ptr + game.ReadValue<byte>(ptr) + 0x1 + 0x2;
            this.RaceStatus = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr))) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // RaceCompleted
            ptr = scanner.Scan(new SigScanTarget(4, "73 12 83 3D")); if (ptr == IntPtr.Zero) throw new Exception();
            this.RaceCompleted = new MemoryWatcher<byte>(new DeepPointer(ptr + 5 + game.ReadValue<int>(ptr))) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // IGT
            ptr = scanner.Scan(new SigScanTarget(7, "41 8B D6 F3 0F 10 05")); if (ptr == IntPtr.Zero) throw new Exception();
            this.IGT = new MemoryWatcher<float>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr))) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // Credits
            ptr = scanner.Scan(new SigScanTarget(4, "45 89 84 8A")); if (ptr == IntPtr.Zero) throw new Exception();
            this.Credits = new MemoryWatcher<byte>(new DeepPointer(game.MainModuleWow64Safe().BaseAddress + 4 + game.ReadValue<int>(ptr))) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // SkippedCredits
            ptr = scanner.Scan(new SigScanTarget(3, "48 8B 05 ???????? 48 2B 05")); if (ptr == IntPtr.Zero) throw new Exception();
            this.SkippedCredits = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr))) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // GPINDEX
            ptr = scanner.Scan(new SigScanTarget(2, "39 1D ???????? 75 0A")); if (ptr == IntPtr.Zero) throw new Exception();
            this.GPINDEX = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr))) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };

            // GPTRACK
            ptr = scanner.Scan(new SigScanTarget(4, "41 5C 2B 05")); if (ptr == IntPtr.Zero) throw new Exception();
            this.GPTRACK = new MemoryWatcher<byte>(new DeepPointer(ptr + 4 + game.ReadValue<int>(ptr))) { FailAction = MemoryWatcher.ReadFailAction.SetZeroOrNull };


            this.ProgressIGT = 0;
            this.TotalIGT = 0;
            this.FrozenIGT = 0;
            this.FinalSplit = 0;

            this.AddRange(this.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance).Where(p => !p.GetIndexParameters().Any()).Select(p => p.GetValue(this, null) as MemoryWatcher).Where(p => p != null));
        }

    }

    enum GameMode
    {
        TeamAdventure,
        SingleRaces,
        GrandPrix,
        Undefined
    }

    enum GrandPrixTracks
    {
        Track1_1 = 00,
        Track1_2 = 01,
        Track1_3 = 02,
        Track1_4 = 03,
        Track2_1 = 10,
        Track2_2 = 11,
        Track2_3 = 12,
        Track2_4 = 13,
        Track3_1 = 20,
        Track3_2 = 21,
        Track3_3 = 22,
        Track3_4 = 23,
        Track4_1 = 30,
        Track4_2 = 31,
        Track4_3 = 32,
        Track4_4 = 33,
        Track5_1 = 40,
        Track5_2 = 41,
        Track5_3 = 42,
        Track5_4 = 43
    }

    enum Tracks : uint
    {
        WispCircuit = 0xBFE92AF2,
        MothersCanyon = 0x0E176D3B,
        DoctorsMine = 0x3575448B,
        OceanView = 0xD4257EBD,
        LostPalace = 0x630ED8F1,
        WhaleLagoon = 0x77D1156A,
        IceMountain = 0x2A13F66C,
        FrozenJunkyard = 0xB5078566,
        HiddenVolcano = 0x055DC68F,
        RouletteRoad = 0x17463C8D,
        BingoParty = 0x3240A224,
        PinballHighway = 0xDCA5E153,
        SandRoad = 0x12CE6A2D,
        BoosHouse = 0xEBC8CAB4,
        ClockworkPyramid = 0x6D41C70D,
        MarketStreet = 0x0FD3E260,
        SkyRoad = 0xC7AF1E91,
        HauntedCastle = 0x7547A64C,
        ThunderDeck = 0x6FB193FE,
        DarkArsenal = 0x967CB9A4,
        TurbineLoop = 0xABBD335E
    }

    enum TeamAdventureTracks : byte
    {
        Stage1_1 = 0x80,
        Stage1_2 = 0x84,
        Stage1_3 = 0x8C,
        Stage1_4 = 0x90,
        Stage1_5 = 0xE0,
        Stage1_6 = 0xE4,
        Stage2_1 = 0x9C,
        Stage2_2 = 0xA8,
        Stage2_3 = 0xB0,
        Stage2_4 = 0xB4,
        Stage2_5 = 0xA0,
        Stage2_6 = 0xA4,
        Stage2_7 = 0xDC,
        Stage3_1 = 0xC0,
        Stage3_2 = 0xC4,
        Stage3_3 = 0xCC,
        Stage3_4 = 0xD0,
        Stage3_5 = 0xD4,
        Stage3_6 = 0xD8,
        Stage3_7 = 0xCC,
        Stage3_8 = 0xD0,
        Stage3_9 = 0xD4,
        Stage4_1 = 0xE0,
        Stage4_2 = 0xE4,
        Stage4_3 = 0xE8,
        Stage4_4 = 0xF0,
        Stage4_5 = 0xF4,
        Stage4_6 = 0xC8,
        Stage4_7 = 0xB8,
        Stage4_8 = 0xBC,
        Stage4_9 = 0xC4,
        Stage5_1 = 0x00,
        Stage5_2 = 0x04,
        Stage5_3 = 0x08,
        Stage5_4 = 0x10,
        Stage5_5 = 0x14,
        Stage5_6 = 0xB0,
        Stage5_7 = 0xB4,
        Stage5_8 = 0xA0,
        Stage5_9 = 0xA8,
        Stage5_10 = 0xAC,
        Stage6_1 = 0x20,
        Stage6_2 = 0x24,
        Stage6_3 = 0x28,
        Stage6_4 = 0x2C,
        Stage6_5 = 0x34,
        Stage6_6 = 0x38,
        Stage6_7 = 0x9C,
        Stage6_8 = 0x98,
        Stage6_9 = 0x88,
        Stage6_10 = 0x8C,
        Stage6_11 = 0x94,
        Stage7_1 = 0x44,
        Stage7_2 = 0x48,
        Stage7_3 = 0x50,
        Stage7_4 = 0x54,
        Stage7_5 = 0x5C,
        Stage7_6 = 0x60,
        Stage7_7 = 0x78,
        Stage7_8 = 0x7C,
        Stage7_9 = 0x80,
        Stage7_10 = 0x68,
        Stage7_11 = 0x70,
        Stage7_12 = 0x74
    }

    class FakeMemoryWatcher<T>
    {
        public T Current { get; set; }
        public T Old { get; set; }
        public bool Changed { get; set; }

        public FakeMemoryWatcher(T old, T current)
        {
            this.Old = old;
            this.Current = current;
            this.Changed = !old.Equals(current);
        }
    }
}
