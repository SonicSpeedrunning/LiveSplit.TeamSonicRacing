using System.Reflection;
using LiveSplit.TeamSonicRacing;
using LiveSplit.UI.Components;
using System;
using LiveSplit.Model;

[assembly: ComponentFactory(typeof(SonicTSRFactory))]

namespace LiveSplit.TeamSonicRacing
{
    public class SonicTSRFactory : IComponentFactory
    {
        public string ComponentName => "Team Sonic Racing Autosplitter";
        public string Description => "Automatic splitting and IGT calculation";
        public ComponentCategory Category => ComponentCategory.Control;
        public string UpdateName => this.ComponentName;
        public string UpdateURL => "https://raw.githubusercontent.com/SonicSpeedrunning/LiveSplit.TeamSonicRacing/master/";
        public Version Version => Assembly.GetExecutingAssembly().GetName().Version;
        public string XMLURL => this.UpdateURL + "Components/update.LiveSplit.TeamSonicRacing.xml";
        public IComponent Create(LiveSplitState state) { return new Component(state); }
    }
}
