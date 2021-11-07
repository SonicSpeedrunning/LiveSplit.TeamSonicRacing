using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using LiveSplit.Model;

namespace LiveSplit.TeamSonicRacing
{
    class SplitLogic
    {
        private Process game;
        private Watchers watchers;

        public delegate void StartTriggerEventHandler(object sender, StartTrigger type);
        public event StartTriggerEventHandler OnStartTrigger;

        public delegate void GameTimeTriggerEventHandler(object sender, double value);
        public event GameTimeTriggerEventHandler OnGameTimeTrigger;

        public delegate void SplitTriggerTeamAdventureEventHandler(object sender, TeamAdventureTracks type);
        public event SplitTriggerTeamAdventureEventHandler OnSplitTrigger_TeamAdventure;

        public delegate void SplitTriggerSingleTrackEventHandler(object sender, Tracks type);
        public event SplitTriggerSingleTrackEventHandler OnSplitTrigger_SingleTracks;

        public delegate void SplitTriggerGrandPrixEventHandler(object sender, GrandPrixTracks type);
        public event SplitTriggerGrandPrixEventHandler OnSplitTrigger_GrandPrix;

        public void Update(TimerModel timer)
        {
            if (game == null || game.HasExited) { if (!HookGameProcess()) return; }
            if (timer.CurrentState.IsGameTimePaused == false) timer.CurrentState.IsGameTimePaused = true;
            watchers.UpdateAll(game);
            if (timer.CurrentState.CurrentPhase == TimerPhase.NotRunning) ResetInternalVars();
            Update();
            Start();
            GameTime();
            Split();
        }

        void ResetInternalVars()
        {
            watchers.TotalIGT = 0;
            watchers.ProgressIGT = 0;
            watchers.FinalSplit = 0;
            watchers.FrozenIGT = 0;
        }

        void Update()
        {
            // During a race, the IGT is calculated by the game (not by LiveSplit) and is added to the total
            if (watchers.RaceCompleted.Current == 0)
            {
                watchers.ProgressIGT = (Math.Truncate(100 * watchers.IGT.Current) / 100) + watchers.TotalIGT;

                if (watchers.AbortRace.Current == 1 && watchers.AbortRace.Old == 0) watchers.FrozenIGT = watchers.ProgressIGT;
                if (watchers.IGT.Old != 0 && watchers.IGT.Current == 0 && watchers.RaceStatus.Old == 6)
                {
                    watchers.TotalIGT = watchers.FrozenIGT;
                    watchers.ProgressIGT = watchers.TotalIGT;
                    watchers.FrozenIGT = 0;
                }
            }

            // The moment you complete a race, the game picks your total racing time and saves it into a different address
            // Also, the game truncates the time to the second decimal. We're going to do the same for consistency purposes
            if (watchers.RaceCompleted.Current == 1 && watchers.RaceCompleted.Old == 0) {
                if (watchers.GameMode == GameMode.TeamAdventure && watchers.RequiredLaps.Current == 255)
                {
                    watchers.TotalIGT += Math.Truncate(100 * watchers.TotalRaceTimeAdventure.Current) / 100;
                }
                else
                {
                    watchers.TotalIGT += Math.Truncate(100 * watchers.TotalRaceTime.Current) / 100;
                }
                watchers.ProgressIGT = watchers.TotalIGT;
            }
        }

        void Start()
        {
            switch (watchers.GameMode)
            {
                case GameMode.TeamAdventure:
                    if (watchers.TeamAdventureStart.Current == 1 && watchers.TeamAdventureStart.Changed && watchers.Stars.Current == 0) this.OnStartTrigger?.Invoke(this, StartTrigger.TeamAdventure);
                    break;
                case GameMode.GrandPrix:
                case GameMode.SingleRaces:
                    if (watchers.RunStart.Current == 1 && watchers.RunStart.Changed) this.OnStartTrigger?.Invoke(this, StartTrigger.Races);
                    break;
            }
        }

        void GameTime()
        {
            this.OnGameTimeTrigger?.Invoke(this, watchers.ProgressIGT);
        }

        void Split()
        {
            switch(watchers.GameMode)
            {
                case GameMode.TeamAdventure:
                    if (watchers.TeamAdventureTrack == TeamAdventureTracks.Stage7_6)
                    {
                        if (watchers.FinalSplit == 0 && (watchers.Credits.Current == 4 || watchers.SkippedCredits.Current == 8))
                        {
                            watchers.FinalSplit = 1;
                        }
                        if (watchers.FinalSplit == 1)
                        {
                            watchers.FinalSplit = 2;
                            this.OnSplitTrigger_TeamAdventure?.Invoke(this, TeamAdventureTracks.Stage7_6);
                        }
                    }
                    else
                    {
                        if (watchers.Stars.Current > watchers.Stars.Old) this.OnSplitTrigger_TeamAdventure?.Invoke(this, watchers.TeamAdventureTrack);
                    }
                    // if (watchers.RaceCompleted.Current == 1 && watchers.RaceCompleted.Changed) this.OnSplitTrigger_TeamAdventure?.Invoke(this, SplitTrigger.FinalSplit);
                    break;
                case GameMode.GrandPrix: if (watchers.RaceCompleted.Current == 1 && watchers.RaceCompleted.Changed) this.OnSplitTrigger_GrandPrix?.Invoke(this, watchers.GrandPrixTrack); break;
                case GameMode.SingleRaces: if (watchers.RaceCompleted.Current == 1 && watchers.RaceCompleted.Changed) this.OnSplitTrigger_SingleTracks?.Invoke(this, watchers.CurrentTrack); break;
            }
        }

        public enum StartTrigger
        {
            TeamAdventure,
            Races
        }

        bool HookGameProcess()
        {
            foreach (var process in new string[] { "GameApp_PcDx11_x64Final" })
            {
                game = Process.GetProcessesByName(process).OrderByDescending(x => x.StartTime).FirstOrDefault(x => !x.HasExited);
                if (game == null) continue;
                try { watchers = new Watchers(game); } catch { game = null; return false; }
                return true;
            }
            return false;
        }

    }
}
