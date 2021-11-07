using System;
using System.Xml;
using System.Windows.Forms;
using LiveSplit.Model;
using LiveSplit.UI;
using LiveSplit.UI.Components;

namespace LiveSplit.TeamSonicRacing
{
    class Component : LogicComponent
    {
        public override string ComponentName => "Team Sonic Racing";
        private Settings settings { get; set; }
        private TimerModel timer;
        private Timer update_timer;
        private SplitLogic SplitLogic;

        public Component(LiveSplitState state)
        {
            timer = new TimerModel { CurrentState = state };
            update_timer = new Timer() { Interval = 15, Enabled = true };
            settings = new Settings();
            update_timer.Tick += UpdateTimer_Tick;

            SplitLogic = new SplitLogic();
            SplitLogic.OnStartTrigger += OnStartTrigger;
            SplitLogic.OnGameTimeTrigger += OnGameTimeTrigger;
            SplitLogic.OnSplitTrigger_TeamAdventure += OnSplitTrigger_TeamAdventure;
            SplitLogic.OnSplitTrigger_SingleTracks += OnSplitTrigger_SingleTracks;
            SplitLogic.OnSplitTrigger_GrandPrix += OnSplitTrigger_GrandPrix;
        }

        public override void Dispose()
        {
            settings.Dispose();
            update_timer?.Dispose();
        }

        void UpdateTimer_Tick(object sender, EventArgs eventArgs)
        {
            try { SplitLogic.Update(timer); } catch { return; }
        }

        void OnStartTrigger(object sender, SplitLogic.StartTrigger type)
        {
            if (timer.CurrentState.CurrentPhase != TimerPhase.NotRunning) return;
            if (!settings.RunStart) return;
            switch (type)
            {
                case SplitLogic.StartTrigger.TeamAdventure:
                case SplitLogic.StartTrigger.Races:
                    timer.Start();
                    break;
            }
        }

        void OnGameTimeTrigger(object sender, double value)
        {
            timer.CurrentState.SetGameTime(TimeSpan.FromSeconds(value));
        }

        void OnSplitTrigger_TeamAdventure(object sender, TeamAdventureTracks type)
        {
            if (timer.CurrentState.CurrentPhase != TimerPhase.Running) return;
            timer.Split();
            /*
            switch (type)
            {
                case TeamAdventureTracks.Stage1_1: if (settings.TA1_1) timer.Split(); break;
                case TeamAdventureTracks.Stage1_2: if (settings.TA1_2) timer.Split(); break;
                case TeamAdventureTracks.Stage1_3: if (settings.TA1_3) timer.Split(); break;
                case TeamAdventureTracks.Stage1_4: if (settings.TA1_4) timer.Split(); break;
                case TeamAdventureTracks.Stage1_5: if (settings.TA1_5) timer.Split(); break;
                case TeamAdventureTracks.Stage1_6: if (settings.TA1_6) timer.Split(); break;
                case TeamAdventureTracks.Stage2_1: if (settings.TA2_1) timer.Split(); break;
                case TeamAdventureTracks.Stage2_2: if (settings.TA2_2) timer.Split(); break;
                case TeamAdventureTracks.Stage2_3: if (settings.TA2_3) timer.Split(); break;
                case TeamAdventureTracks.Stage2_4: if (settings.TA2_4) timer.Split(); break;
                case TeamAdventureTracks.Stage2_5: if (settings.TA2_5) timer.Split(); break;
                case TeamAdventureTracks.Stage2_6: if (settings.TA2_6) timer.Split(); break;
                case TeamAdventureTracks.Stage2_7: if (settings.TA2_7) timer.Split(); break;
                case TeamAdventureTracks.Stage3_1: if (settings.TA3_1) timer.Split(); break;
                case TeamAdventureTracks.Stage3_2: if (settings.TA3_2) timer.Split(); break;
                case TeamAdventureTracks.Stage3_3: if (settings.TA3_3) timer.Split(); break;
                case TeamAdventureTracks.Stage3_4: if (settings.TA3_4) timer.Split(); break;
                case TeamAdventureTracks.Stage3_5: if (settings.TA3_5) timer.Split(); break;
                case TeamAdventureTracks.Stage3_6: if (settings.TA3_6) timer.Split(); break;
                case TeamAdventureTracks.Stage3_7: if (settings.TA3_7) timer.Split(); break;
                case TeamAdventureTracks.Stage3_8: if (settings.TA3_8) timer.Split(); break;
                case TeamAdventureTracks.Stage3_9: if (settings.TA3_9) timer.Split(); break;
                case TeamAdventureTracks.Stage4_1: if (settings.TA4_1) timer.Split(); break;
                case TeamAdventureTracks.Stage4_2: if (settings.TA4_2) timer.Split(); break;
                case TeamAdventureTracks.Stage4_3: if (settings.TA4_3) timer.Split(); break;
                case TeamAdventureTracks.Stage4_4: if (settings.TA4_4) timer.Split(); break;
                case TeamAdventureTracks.Stage4_5: if (settings.TA4_5) timer.Split(); break;
                case TeamAdventureTracks.Stage4_6: if (settings.TA4_6) timer.Split(); break;
                case TeamAdventureTracks.Stage4_7: if (settings.TA4_7) timer.Split(); break;
                case TeamAdventureTracks.Stage4_8: if (settings.TA4_8) timer.Split(); break;
                case TeamAdventureTracks.Stage4_9: if (settings.TA4_9) timer.Split(); break;
                case TeamAdventureTracks.Stage5_1: if (settings.TA5_1) timer.Split(); break;
                case TeamAdventureTracks.Stage5_2: if (settings.TA5_2) timer.Split(); break;
                case TeamAdventureTracks.Stage5_3: if (settings.TA5_3) timer.Split(); break;
                case TeamAdventureTracks.Stage5_4: if (settings.TA5_4) timer.Split(); break;
                case TeamAdventureTracks.Stage5_5: if (settings.TA5_5) timer.Split(); break;
                case TeamAdventureTracks.Stage5_6: if (settings.TA5_6) timer.Split(); break;
                case TeamAdventureTracks.Stage5_7: if (settings.TA5_7) timer.Split(); break;
                case TeamAdventureTracks.Stage5_8: if (settings.TA5_8) timer.Split(); break;
                case TeamAdventureTracks.Stage5_9: if (settings.TA5_9) timer.Split(); break;
                case TeamAdventureTracks.Stage5_10: if (settings.TA5_10) timer.Split(); break;
                case TeamAdventureTracks.Stage6_1: if (settings.TA6_1) timer.Split(); break;
                case TeamAdventureTracks.Stage6_2: if (settings.TA6_2) timer.Split(); break;
                case TeamAdventureTracks.Stage6_3: if (settings.TA6_3) timer.Split(); break;
                case TeamAdventureTracks.Stage6_4: if (settings.TA6_4) timer.Split(); break;
                case TeamAdventureTracks.Stage6_5: if (settings.TA6_5) timer.Split(); break;
                case TeamAdventureTracks.Stage6_6: if (settings.TA6_6) timer.Split(); break;
                case TeamAdventureTracks.Stage6_7: if (settings.TA6_7) timer.Split(); break;
                case TeamAdventureTracks.Stage6_8: if (settings.TA6_8) timer.Split(); break;
                case TeamAdventureTracks.Stage6_9: if (settings.TA6_9) timer.Split(); break;
                case TeamAdventureTracks.Stage6_10: if (settings.TA6_10) timer.Split(); break;
                case TeamAdventureTracks.Stage6_11: if (settings.TA6_11) timer.Split(); break;
                case TeamAdventureTracks.Stage7_1: if (settings.TA7_1) timer.Split(); break;
                case TeamAdventureTracks.Stage7_2: if (settings.TA7_2) timer.Split(); break;
                case TeamAdventureTracks.Stage7_3: if (settings.TA7_3) timer.Split(); break;
                case TeamAdventureTracks.Stage7_4: if (settings.TA7_4) timer.Split(); break;
                case TeamAdventureTracks.Stage7_5: if (settings.TA7_5) timer.Split(); break;
                case TeamAdventureTracks.Stage7_6: if (settings.TA7_6) timer.Split(); break;
                case TeamAdventureTracks.Stage7_7: if (settings.TA7_7) timer.Split(); break;
                case TeamAdventureTracks.Stage7_8: if (settings.TA7_8) timer.Split(); break;
                case TeamAdventureTracks.Stage7_9: if (settings.TA7_9) timer.Split(); break;
                case TeamAdventureTracks.Stage7_10: if (settings.TA7_10) timer.Split(); break;
                case TeamAdventureTracks.Stage7_11: if (settings.TA7_11) timer.Split(); break;
                case TeamAdventureTracks.Stage7_12: if (settings.TA7_12) timer.Split(); break;
            }
            */
        }

        void OnSplitTrigger_SingleTracks(object sender, Tracks type)
        {
            if (timer.CurrentState.CurrentPhase != TimerPhase.Running) return;
            switch (type)
            {
                case Tracks.WispCircuit: if (settings.WispCircuit) timer.Split(); break;
                case Tracks.MothersCanyon: if (settings.MothersCanyon) timer.Split(); break;
                case Tracks.DoctorsMine: if (settings.DoctorsMine) timer.Split(); break;
                case Tracks.OceanView: if (settings.OceanView) timer.Split(); break;
                case Tracks.WhaleLagoon: if (settings.WhaleLagoon) timer.Split(); break;
                case Tracks.LostPalace: if (settings.LostPalace) timer.Split(); break;
                case Tracks.IceMountain: if (settings.IceMountain) timer.Split(); break;
                case Tracks.FrozenJunkyard: if (settings.FrozenJunkyard) timer.Split(); break;
                case Tracks.HiddenVolcano: if (settings.HiddenVolcano) timer.Split(); break;
                case Tracks.RouletteRoad: if (settings.RouletteRoad) timer.Split(); break;
                case Tracks.BingoParty: if (settings.BingoParty) timer.Split(); break;
                case Tracks.PinballHighway: if (settings.PinballHighway) timer.Split(); break;
                case Tracks.SandRoad: if (settings.SandRoad) timer.Split(); break;
                case Tracks.BoosHouse: if (settings.BoosHouse) timer.Split(); break;
                case Tracks.ClockworkPyramid: if (settings.ClockworkPyramid) timer.Split(); break;
                case Tracks.MarketStreet: if (settings.MarketStreet) timer.Split(); break;
                case Tracks.SkyRoad: if (settings.SkyRoad) timer.Split(); break;
                case Tracks.HauntedCastle: if (settings.HauntedCastle) timer.Split(); break;
                case Tracks.ThunderDeck: if (settings.ThunderDeck) timer.Split(); break;
                case Tracks.DarkArsenal: if (settings.DarkArsenal) timer.Split(); break;
                case Tracks.TurbineLoop: if (settings.TurbineLoop) timer.Split(); break;
            }
        }

        void OnSplitTrigger_GrandPrix(object sender, GrandPrixTracks type)
        {
            if (timer.CurrentState.CurrentPhase != TimerPhase.Running) return;
            switch (type)
            {
                case GrandPrixTracks.Track1_1: if (settings.GP1_1) timer.Split(); break;
                case GrandPrixTracks.Track1_2: if (settings.GP1_2) timer.Split(); break;
                case GrandPrixTracks.Track1_3: if (settings.GP1_3) timer.Split(); break;
                case GrandPrixTracks.Track1_4: if (settings.GP1_4) timer.Split(); break;
                case GrandPrixTracks.Track2_1: if (settings.GP2_1) timer.Split(); break;
                case GrandPrixTracks.Track2_2: if (settings.GP2_2) timer.Split(); break;
                case GrandPrixTracks.Track2_3: if (settings.GP2_3) timer.Split(); break;
                case GrandPrixTracks.Track2_4: if (settings.GP2_4) timer.Split(); break;
                case GrandPrixTracks.Track3_1: if (settings.GP3_1) timer.Split(); break;
                case GrandPrixTracks.Track3_2: if (settings.GP3_2) timer.Split(); break;
                case GrandPrixTracks.Track3_3: if (settings.GP3_3) timer.Split(); break;
                case GrandPrixTracks.Track3_4: if (settings.GP3_4) timer.Split(); break;
                case GrandPrixTracks.Track4_1: if (settings.GP4_1) timer.Split(); break;
                case GrandPrixTracks.Track4_2: if (settings.GP4_2) timer.Split(); break;
                case GrandPrixTracks.Track4_3: if (settings.GP4_3) timer.Split(); break;
                case GrandPrixTracks.Track4_4: if (settings.GP4_4) timer.Split(); break;
                case GrandPrixTracks.Track5_1: if (settings.GP5_1) timer.Split(); break;
                case GrandPrixTracks.Track5_2: if (settings.GP5_2) timer.Split(); break;
                case GrandPrixTracks.Track5_3: if (settings.GP5_3) timer.Split(); break;
                case GrandPrixTracks.Track5_4: if (settings.GP5_4) timer.Split(); break;
            }
        }

        public override XmlNode GetSettings(XmlDocument document) { return this.settings.GetSettings(document); }

        public override Control GetSettingsControl(LayoutMode mode) { return this.settings; }

        public override void SetSettings(XmlNode settings) { this.settings.SetSettings(settings); }

        public override void Update(IInvalidator invalidator, LiveSplitState state, float width, float height, LayoutMode mode) { }
    }
}
