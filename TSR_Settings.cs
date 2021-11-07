using System;
using System.Windows.Forms;
using System.Xml;

namespace LiveSplit.TeamSonicRacing
{
    public partial class Settings : UserControl
    {
        public bool RunStart { get; set; }
        
        // Single Races
        public bool WispCircuit { get; set; }
        public bool MothersCanyon { get; set; }
        public bool DoctorsMine { get; set; }
        public bool OceanView { get; set; }
        public bool LostPalace { get; set; }
        public bool WhaleLagoon { get; set; }
        public bool IceMountain { get; set; }
        public bool FrozenJunkyard { get; set; }
        public bool HiddenVolcano { get; set; }
        public bool RouletteRoad { get; set; }
        public bool BingoParty { get; set; }
        public bool PinballHighway { get; set; }
        public bool SandRoad { get; set; }
        public bool BoosHouse { get; set; }
        public bool ClockworkPyramid { get; set; }
        public bool MarketStreet { get; set; }
        public bool SkyRoad { get; set; }
        public bool HauntedCastle { get; set; }
        public bool ThunderDeck { get; set; }
        public bool DarkArsenal { get; set; }
        public bool TurbineLoop { get; set; }

        // Grand Prix
        public bool GP1_1 { get; set; }
        public bool GP1_2 { get; set; }
        public bool GP1_3 { get; set; }
        public bool GP1_4 { get; set; }
        public bool GP2_1 { get; set; }
        public bool GP2_2 { get; set; }
        public bool GP2_3 { get; set; }
        public bool GP2_4 { get; set; }
        public bool GP3_1 { get; set; }
        public bool GP3_2 { get; set; }
        public bool GP3_3 { get; set; }
        public bool GP3_4 { get; set; }
        public bool GP4_1 { get; set; }
        public bool GP4_2 { get; set; }
        public bool GP4_3 { get; set; }
        public bool GP4_4 { get; set; }
        public bool GP5_1 { get; set; }
        public bool GP5_2 { get; set; }
        public bool GP5_3 { get; set; }
        public bool GP5_4 { get; set; }

        // Team Adventure
        public bool TA1_1 { get; set; }
        public bool TA1_2 { get; set; }
        public bool TA1_3 { get; set; }
        public bool TA1_4 { get; set; }
        public bool TA1_5 { get; set; }
        public bool TA1_6 { get; set; }
        public bool TA2_1 { get; set; }
        public bool TA2_2 { get; set; }
        public bool TA2_3 { get; set; }
        public bool TA2_4 { get; set; }
        public bool TA2_5 { get; set; }
        public bool TA2_6 { get; set; }
        public bool TA2_7 { get; set; }
        public bool TA3_1 { get; set; }
        public bool TA3_2 { get; set; }
        public bool TA3_3 { get; set; }
        public bool TA3_4 { get; set; }
        public bool TA3_5 { get; set; }
        public bool TA3_6 { get; set; }
        public bool TA3_7 { get; set; }
        public bool TA3_8 { get; set; }
        public bool TA3_9 { get; set; }
        public bool TA4_1 { get; set; }
        public bool TA4_2 { get; set; }
        public bool TA4_3 { get; set; }
        public bool TA4_4 { get; set; }
        public bool TA4_5 { get; set; }
        public bool TA4_6 { get; set; }
        public bool TA4_7 { get; set; }
        public bool TA4_8 { get; set; }
        public bool TA4_9 { get; set; }
        public bool TA5_1 { get; set; }
        public bool TA5_2 { get; set; }
        public bool TA5_3 { get; set; }
        public bool TA5_4 { get; set; }
        public bool TA5_5 { get; set; }
        public bool TA5_6 { get; set; }
        public bool TA5_7 { get; set; }
        public bool TA5_8 { get; set; }
        public bool TA5_9 { get; set; }
        public bool TA5_10 { get; set; }
        public bool TA6_1 { get; set; }
        public bool TA6_2 { get; set; }
        public bool TA6_3 { get; set; }
        public bool TA6_4 { get; set; }
        public bool TA6_5 { get; set; }
        public bool TA6_6 { get; set; }
        public bool TA6_7 { get; set; }
        public bool TA6_8 { get; set; }
        public bool TA6_9 { get; set; }
        public bool TA6_10 { get; set; }
        public bool TA6_11 { get; set; }
        public bool TA7_1 { get; set; }
        public bool TA7_2 { get; set; }
        public bool TA7_3 { get; set; }
        public bool TA7_4 { get; set; }
        public bool TA7_5 { get; set; }
        public bool TA7_6 { get; set; }
        public bool TA7_7 { get; set; }
        public bool TA7_8 { get; set; }
        public bool TA7_9 { get; set; }
        public bool TA7_10 { get; set; }
        public bool TA7_11 { get; set; }
        public bool TA7_12 { get; set; }


        public Settings()
        {
            InitializeComponent();

            // General settings
            chkrunStart.DataBindings.Add("Checked", this, "RunStart", false, DataSourceUpdateMode.OnPropertyChanged);
           
            // Single Races
            chkWispCircuit.DataBindings.Add("Checked", this, "WispCircuit", false, DataSourceUpdateMode.OnPropertyChanged);
            chkMothersCanyon.DataBindings.Add("Checked", this, "MothersCanyon", false, DataSourceUpdateMode.OnPropertyChanged);
            chkDoctorsMine.DataBindings.Add("Checked", this, "DoctorsMine", false, DataSourceUpdateMode.OnPropertyChanged);
            chkOceanView.DataBindings.Add("Checked", this, "OceanView", false, DataSourceUpdateMode.OnPropertyChanged);
            chkLostPalace.DataBindings.Add("Checked", this, "LostPalace", false, DataSourceUpdateMode.OnPropertyChanged);
            chkWhaleLagoon.DataBindings.Add("Checked", this, "WhaleLagoon", false, DataSourceUpdateMode.OnPropertyChanged);
            chkIceMountain.DataBindings.Add("Checked", this, "IceMountain", false, DataSourceUpdateMode.OnPropertyChanged);
            chkFrozenJunkyard.DataBindings.Add("Checked", this, "FrozenJunkyard", false, DataSourceUpdateMode.OnPropertyChanged);
            chkHiddenVolcano.DataBindings.Add("Checked", this, "HiddenVolcano", false, DataSourceUpdateMode.OnPropertyChanged);
            chkRouletteRoad.DataBindings.Add("Checked", this, "RouletteRoad", false, DataSourceUpdateMode.OnPropertyChanged);
            chkBingoParty.DataBindings.Add("Checked", this, "BingoParty", false, DataSourceUpdateMode.OnPropertyChanged);
            chkPinballHighway.DataBindings.Add("Checked", this, "PinballHighway", false, DataSourceUpdateMode.OnPropertyChanged);
            chkSandRoad.DataBindings.Add("Checked", this, "SandRoad", false, DataSourceUpdateMode.OnPropertyChanged);
            chkBoosHouse.DataBindings.Add("Checked", this, "BoosHouse", false, DataSourceUpdateMode.OnPropertyChanged);
            chkClockworkPyramid.DataBindings.Add("Checked", this, "ClockworkPyramid", false, DataSourceUpdateMode.OnPropertyChanged);
            chkMarketStreet.DataBindings.Add("Checked", this, "MarketStreet", false, DataSourceUpdateMode.OnPropertyChanged);
            chkSkyRoad.DataBindings.Add("Checked", this, "SkyRoad", false, DataSourceUpdateMode.OnPropertyChanged);
            chkHauntedCastle.DataBindings.Add("Checked", this, "HauntedCastle", false, DataSourceUpdateMode.OnPropertyChanged);
            chkThunderDeck.DataBindings.Add("Checked", this, "ThunderDeck", false, DataSourceUpdateMode.OnPropertyChanged);
            chkDarkArsenal.DataBindings.Add("Checked", this, "DarkArsenal", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTurbineLoop.DataBindings.Add("Checked", this, "TurbineLoop", false, DataSourceUpdateMode.OnPropertyChanged);
            
            // Grand Prix
            chkGP1_1.DataBindings.Add("Checked", this, "GP1_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP1_2.DataBindings.Add("Checked", this, "GP1_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP1_3.DataBindings.Add("Checked", this, "GP1_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP1_4.DataBindings.Add("Checked", this, "GP1_4", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP2_1.DataBindings.Add("Checked", this, "GP2_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP2_2.DataBindings.Add("Checked", this, "GP2_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP2_3.DataBindings.Add("Checked", this, "GP2_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP2_4.DataBindings.Add("Checked", this, "GP2_4", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP3_1.DataBindings.Add("Checked", this, "GP3_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP3_2.DataBindings.Add("Checked", this, "GP3_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP3_3.DataBindings.Add("Checked", this, "GP3_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP3_4.DataBindings.Add("Checked", this, "GP3_4", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP4_1.DataBindings.Add("Checked", this, "GP4_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP4_2.DataBindings.Add("Checked", this, "GP4_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP4_3.DataBindings.Add("Checked", this, "GP4_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP4_4.DataBindings.Add("Checked", this, "GP4_4", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP5_1.DataBindings.Add("Checked", this, "GP5_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP5_2.DataBindings.Add("Checked", this, "GP5_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP5_3.DataBindings.Add("Checked", this, "GP5_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkGP5_4.DataBindings.Add("Checked", this, "GP5_4", false, DataSourceUpdateMode.OnPropertyChanged);

            // Team Adventure
            chkTA1_1.DataBindings.Add("Checked", this, "TA1_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA1_2.DataBindings.Add("Checked", this, "TA1_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA1_3.DataBindings.Add("Checked", this, "TA1_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA1_4.DataBindings.Add("Checked", this, "TA1_4", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA1_5.DataBindings.Add("Checked", this, "TA1_5", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA1_6.DataBindings.Add("Checked", this, "TA1_6", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA2_1.DataBindings.Add("Checked", this, "TA2_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA2_2.DataBindings.Add("Checked", this, "TA2_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA2_3.DataBindings.Add("Checked", this, "TA2_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA2_4.DataBindings.Add("Checked", this, "TA2_4", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA2_5.DataBindings.Add("Checked", this, "TA2_5", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA2_6.DataBindings.Add("Checked", this, "TA2_6", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA2_7.DataBindings.Add("Checked", this, "TA2_7", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA3_1.DataBindings.Add("Checked", this, "TA3_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA3_2.DataBindings.Add("Checked", this, "TA3_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA3_3.DataBindings.Add("Checked", this, "TA3_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA3_4.DataBindings.Add("Checked", this, "TA3_4", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA3_5.DataBindings.Add("Checked", this, "TA3_5", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA3_6.DataBindings.Add("Checked", this, "TA3_6", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA3_7.DataBindings.Add("Checked", this, "TA3_7", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA3_8.DataBindings.Add("Checked", this, "TA3_8", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA3_9.DataBindings.Add("Checked", this, "TA3_9", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA4_1.DataBindings.Add("Checked", this, "TA4_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA4_2.DataBindings.Add("Checked", this, "TA4_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA4_3.DataBindings.Add("Checked", this, "TA4_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA4_4.DataBindings.Add("Checked", this, "TA4_4", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA4_5.DataBindings.Add("Checked", this, "TA4_5", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA4_6.DataBindings.Add("Checked", this, "TA4_6", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA4_7.DataBindings.Add("Checked", this, "TA4_7", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA4_8.DataBindings.Add("Checked", this, "TA4_8", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA4_9.DataBindings.Add("Checked", this, "TA4_9", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA5_1.DataBindings.Add("Checked", this, "TA5_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA5_2.DataBindings.Add("Checked", this, "TA5_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA5_3.DataBindings.Add("Checked", this, "TA5_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA5_4.DataBindings.Add("Checked", this, "TA5_4", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA5_5.DataBindings.Add("Checked", this, "TA5_5", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA5_6.DataBindings.Add("Checked", this, "TA5_6", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA5_7.DataBindings.Add("Checked", this, "TA5_7", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA5_8.DataBindings.Add("Checked", this, "TA5_8", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA5_9.DataBindings.Add("Checked", this, "TA5_9", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA5_10.DataBindings.Add("Checked", this, "TA5_10", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA6_1.DataBindings.Add("Checked", this, "TA6_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA6_2.DataBindings.Add("Checked", this, "TA6_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA6_3.DataBindings.Add("Checked", this, "TA6_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA6_4.DataBindings.Add("Checked", this, "TA6_4", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA6_5.DataBindings.Add("Checked", this, "TA6_5", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA6_6.DataBindings.Add("Checked", this, "TA6_6", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA6_7.DataBindings.Add("Checked", this, "TA6_7", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA6_8.DataBindings.Add("Checked", this, "TA6_8", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA6_9.DataBindings.Add("Checked", this, "TA6_9", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA6_10.DataBindings.Add("Checked", this, "TA6_10", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA6_11.DataBindings.Add("Checked", this, "TA6_11", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_1.DataBindings.Add("Checked", this, "TA7_1", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_2.DataBindings.Add("Checked", this, "TA7_2", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_3.DataBindings.Add("Checked", this, "TA7_3", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_4.DataBindings.Add("Checked", this, "TA7_4", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_5.DataBindings.Add("Checked", this, "TA7_5", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_6.DataBindings.Add("Checked", this, "TA7_6", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_7.DataBindings.Add("Checked", this, "TA7_7", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_8.DataBindings.Add("Checked", this, "TA7_8", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_9.DataBindings.Add("Checked", this, "TA7_9", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_10.DataBindings.Add("Checked", this, "TA7_10", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_11.DataBindings.Add("Checked", this, "TA7_11", false, DataSourceUpdateMode.OnPropertyChanged);
            chkTA7_12.DataBindings.Add("Checked", this, "TA7_12", false, DataSourceUpdateMode.OnPropertyChanged);

            // Default Values
            RunStart = true;
            WispCircuit = MothersCanyon = DoctorsMine = OceanView = LostPalace = WhaleLagoon = IceMountain = FrozenJunkyard = HiddenVolcano = RouletteRoad = BingoParty = PinballHighway = SandRoad = BoosHouse = ClockworkPyramid = MarketStreet = SkyRoad = HauntedCastle = ThunderDeck = DarkArsenal = TurbineLoop = true;
            GP1_1 = GP1_2 = GP1_3 = GP1_4 = GP2_1 = GP2_2 = GP2_3 = GP2_4 = GP3_1 = GP3_2 = GP3_3 = GP3_4 = GP4_1 = GP4_2 = GP4_3 = GP4_4 = GP5_1 = GP5_2 = GP5_3 = GP5_4 = true;
            TA1_1 = TA1_2 = TA1_3 = TA1_4 = TA1_5 = TA1_6 = TA2_1 = TA2_2 = TA2_3 = TA2_4 = TA2_5 = TA2_6 = TA2_7 = TA3_1 = TA3_2 = TA3_3 = TA3_4 = TA3_5 = TA3_6 = TA3_7 = TA3_8 = TA3_9 =
                TA4_1 = TA4_2 = TA4_3 = TA4_4 = TA4_5 = TA4_6 = TA4_7 = TA4_8 = TA4_9 = TA5_1 = TA5_2 = TA5_3 = TA5_4 = TA5_5 = TA5_6 = TA5_7 = TA5_8 = TA5_9 = TA5_10 = TA6_1 = TA6_2 = TA6_3 =
                TA6_4 = TA6_5 = TA6_6 = TA6_7 = TA6_8 = TA6_9 = TA6_10 = TA6_11 = TA7_1 = TA7_2 = TA7_3 = TA7_4 = TA7_5 = TA7_6 = TA7_7 = TA7_8 = TA7_9 = TA7_10 = TA7_11 = TA7_12 = true;
    }

        public XmlNode GetSettings(XmlDocument doc)
        {
            XmlElement settingsNode = doc.CreateElement("settings");
            settingsNode.AppendChild(ToElement(doc, "RunStart", RunStart));
            settingsNode.AppendChild(ToElement(doc, "WispCircuit", WispCircuit));
            settingsNode.AppendChild(ToElement(doc, "MothersCanyon", MothersCanyon));
            settingsNode.AppendChild(ToElement(doc, "DoctorsMine", DoctorsMine));
            settingsNode.AppendChild(ToElement(doc, "OceanView", OceanView));
            settingsNode.AppendChild(ToElement(doc, "LostPalace", LostPalace));
            settingsNode.AppendChild(ToElement(doc, "WhaleLagoon", WhaleLagoon));
            settingsNode.AppendChild(ToElement(doc, "IceMountain", IceMountain));
            settingsNode.AppendChild(ToElement(doc, "FrozenJunkyard", FrozenJunkyard));
            settingsNode.AppendChild(ToElement(doc, "HiddenVolcano", HiddenVolcano));
            settingsNode.AppendChild(ToElement(doc, "RouletteRoad", RouletteRoad));
            settingsNode.AppendChild(ToElement(doc, "BingoParty", BingoParty));
            settingsNode.AppendChild(ToElement(doc, "PinballHighway", PinballHighway));
            settingsNode.AppendChild(ToElement(doc, "SandRoad", SandRoad));
            settingsNode.AppendChild(ToElement(doc, "BoosHouse", BoosHouse));
            settingsNode.AppendChild(ToElement(doc, "ClockworkPyramid", ClockworkPyramid));
            settingsNode.AppendChild(ToElement(doc, "MarketStreet", MarketStreet));
            settingsNode.AppendChild(ToElement(doc, "SkyRoad", SkyRoad));
            settingsNode.AppendChild(ToElement(doc, "HauntedCastle", HauntedCastle));
            settingsNode.AppendChild(ToElement(doc, "ThunderDeck", ThunderDeck));
            settingsNode.AppendChild(ToElement(doc, "DarkArsenal", DarkArsenal));
            settingsNode.AppendChild(ToElement(doc, "TurbineLoop", TurbineLoop));
            settingsNode.AppendChild(ToElement(doc, "GP1_1", GP1_1));
            settingsNode.AppendChild(ToElement(doc, "GP1_2", GP1_2));
            settingsNode.AppendChild(ToElement(doc, "GP1_3", GP1_3));
            settingsNode.AppendChild(ToElement(doc, "GP1_4", GP1_4));
            settingsNode.AppendChild(ToElement(doc, "GP2_1", GP2_1));
            settingsNode.AppendChild(ToElement(doc, "GP2_2", GP2_2));
            settingsNode.AppendChild(ToElement(doc, "GP2_3", GP2_3));
            settingsNode.AppendChild(ToElement(doc, "GP2_4", GP2_4));
            settingsNode.AppendChild(ToElement(doc, "GP3_1", GP3_1));
            settingsNode.AppendChild(ToElement(doc, "GP3_2", GP3_2));
            settingsNode.AppendChild(ToElement(doc, "GP3_3", GP3_3));
            settingsNode.AppendChild(ToElement(doc, "GP3_4", GP3_4));
            settingsNode.AppendChild(ToElement(doc, "GP4_1", GP4_1));
            settingsNode.AppendChild(ToElement(doc, "GP4_2", GP4_2));
            settingsNode.AppendChild(ToElement(doc, "GP4_3", GP4_3));
            settingsNode.AppendChild(ToElement(doc, "GP4_4", GP4_4));
            settingsNode.AppendChild(ToElement(doc, "GP5_1", GP5_1));
            settingsNode.AppendChild(ToElement(doc, "GP5_2", GP5_2));
            settingsNode.AppendChild(ToElement(doc, "GP5_3", GP5_3));
            settingsNode.AppendChild(ToElement(doc, "GP5_4", GP5_4));
            settingsNode.AppendChild(ToElement(doc, "TA1_1", TA1_1));
            settingsNode.AppendChild(ToElement(doc, "TA1_2", TA1_2));
            settingsNode.AppendChild(ToElement(doc, "TA1_3", TA1_3));
            settingsNode.AppendChild(ToElement(doc, "TA1_4", TA1_4));
            settingsNode.AppendChild(ToElement(doc, "TA1_5", TA1_5));
            settingsNode.AppendChild(ToElement(doc, "TA1_6", TA1_6));
            settingsNode.AppendChild(ToElement(doc, "TA2_1", TA2_1));
            settingsNode.AppendChild(ToElement(doc, "TA2_2", TA2_2));
            settingsNode.AppendChild(ToElement(doc, "TA2_3", TA2_3));
            settingsNode.AppendChild(ToElement(doc, "TA2_4", TA2_4));
            settingsNode.AppendChild(ToElement(doc, "TA2_5", TA2_5));
            settingsNode.AppendChild(ToElement(doc, "TA2_6", TA2_6));
            settingsNode.AppendChild(ToElement(doc, "TA2_7", TA2_7));
            settingsNode.AppendChild(ToElement(doc, "TA3_1", TA3_1));
            settingsNode.AppendChild(ToElement(doc, "TA3_2", TA3_2));
            settingsNode.AppendChild(ToElement(doc, "TA3_3", TA3_3));
            settingsNode.AppendChild(ToElement(doc, "TA3_4", TA3_4));
            settingsNode.AppendChild(ToElement(doc, "TA3_5", TA3_5));
            settingsNode.AppendChild(ToElement(doc, "TA3_6", TA3_6));
            settingsNode.AppendChild(ToElement(doc, "TA3_7", TA3_7));
            settingsNode.AppendChild(ToElement(doc, "TA3_8", TA3_8));
            settingsNode.AppendChild(ToElement(doc, "TA3_9", TA3_9));
            settingsNode.AppendChild(ToElement(doc, "TA4_1", TA4_1));
            settingsNode.AppendChild(ToElement(doc, "TA4_2", TA4_2));
            settingsNode.AppendChild(ToElement(doc, "TA4_3", TA4_3));
            settingsNode.AppendChild(ToElement(doc, "TA4_4", TA4_4));
            settingsNode.AppendChild(ToElement(doc, "TA4_5", TA4_5));
            settingsNode.AppendChild(ToElement(doc, "TA4_6", TA4_6));
            settingsNode.AppendChild(ToElement(doc, "TA4_7", TA4_7));
            settingsNode.AppendChild(ToElement(doc, "TA4_8", TA4_8));
            settingsNode.AppendChild(ToElement(doc, "TA4_9", TA4_9));
            settingsNode.AppendChild(ToElement(doc, "TA5_1", TA5_1));
            settingsNode.AppendChild(ToElement(doc, "TA5_2", TA5_2));
            settingsNode.AppendChild(ToElement(doc, "TA5_3", TA5_3));
            settingsNode.AppendChild(ToElement(doc, "TA5_4", TA5_4));
            settingsNode.AppendChild(ToElement(doc, "TA5_5", TA5_5));
            settingsNode.AppendChild(ToElement(doc, "TA5_6", TA5_6));
            settingsNode.AppendChild(ToElement(doc, "TA5_7", TA5_7));
            settingsNode.AppendChild(ToElement(doc, "TA5_8", TA5_8));
            settingsNode.AppendChild(ToElement(doc, "TA5_9", TA5_9));
            settingsNode.AppendChild(ToElement(doc, "TA5_10", TA5_10));
            settingsNode.AppendChild(ToElement(doc, "TA6_1", TA6_1));
            settingsNode.AppendChild(ToElement(doc, "TA6_2", TA6_2));
            settingsNode.AppendChild(ToElement(doc, "TA6_3", TA6_3));
            settingsNode.AppendChild(ToElement(doc, "TA6_4", TA6_4));
            settingsNode.AppendChild(ToElement(doc, "TA6_5", TA6_5));
            settingsNode.AppendChild(ToElement(doc, "TA6_6", TA6_6));
            settingsNode.AppendChild(ToElement(doc, "TA6_7", TA6_7));
            settingsNode.AppendChild(ToElement(doc, "TA6_8", TA6_8));
            settingsNode.AppendChild(ToElement(doc, "TA6_9", TA6_9));
            settingsNode.AppendChild(ToElement(doc, "TA6_10", TA6_10));
            settingsNode.AppendChild(ToElement(doc, "TA6_11", TA6_11));
            settingsNode.AppendChild(ToElement(doc, "TA7_1", TA7_1));
            settingsNode.AppendChild(ToElement(doc, "TA7_2", TA7_2));
            settingsNode.AppendChild(ToElement(doc, "TA7_3", TA7_3));
            settingsNode.AppendChild(ToElement(doc, "TA7_4", TA7_4));
            settingsNode.AppendChild(ToElement(doc, "TA7_5", TA7_5));
            settingsNode.AppendChild(ToElement(doc, "TA7_6", TA7_6));
            settingsNode.AppendChild(ToElement(doc, "TA7_7", TA7_7));
            settingsNode.AppendChild(ToElement(doc, "TA7_8", TA7_8));
            settingsNode.AppendChild(ToElement(doc, "TA7_9", TA7_9));
            settingsNode.AppendChild(ToElement(doc, "TA7_10", TA7_10));
            settingsNode.AppendChild(ToElement(doc, "TA7_11", TA7_11));
            settingsNode.AppendChild(ToElement(doc, "TA7_12", TA7_12));
            return settingsNode;
        }

        public void SetSettings(XmlNode settings)
        {
            RunStart = ParseBool(settings, "RunStart", true);
            WispCircuit = ParseBool(settings, "WispCircuit", true);
            MothersCanyon = ParseBool(settings, "MothersCanyon", true);
            DoctorsMine = ParseBool(settings, "DoctorsMine", true);
            OceanView = ParseBool(settings, "OceanView", true);
            LostPalace = ParseBool(settings, "LostPalace", true);
            WhaleLagoon = ParseBool(settings, "WhaleLagoon", true);
            IceMountain = ParseBool(settings, "IceMountain", true);
            FrozenJunkyard = ParseBool(settings, "FrozenJunkyard", true);
            HiddenVolcano = ParseBool(settings, "HiddenVolcano", true);
            RouletteRoad = ParseBool(settings, "RouletteRoad", true);
            BingoParty = ParseBool(settings, "BingoParty", true);
            PinballHighway = ParseBool(settings, "PinballHighway", true);
            SandRoad = ParseBool(settings, "SandRoad", true);
            BoosHouse = ParseBool(settings, "BoosHouse", true);
            ClockworkPyramid = ParseBool(settings, "ClockworkPyramid", true);
            MarketStreet = ParseBool(settings, "MarketStreet", true);
            SkyRoad = ParseBool(settings, "SkyRoad", true);
            HauntedCastle = ParseBool(settings, "HauntedCastle", true);
            ThunderDeck = ParseBool(settings, "ThunderDeck", true);
            DarkArsenal = ParseBool(settings, "DarkArsenal", true);
            TurbineLoop = ParseBool(settings, "TurbineLoop", true);
            GP1_1 = ParseBool(settings, "GP1_1", true);
            GP1_2 = ParseBool(settings, "GP1_2", true);
            GP1_3 = ParseBool(settings, "GP1_3", true);
            GP1_4 = ParseBool(settings, "GP1_4", true);
            GP2_1 = ParseBool(settings, "GP2_1", true);
            GP2_2 = ParseBool(settings, "GP2_2", true);
            GP2_3 = ParseBool(settings, "GP2_3", true);
            GP2_4 = ParseBool(settings, "GP2_4", true);
            GP3_1 = ParseBool(settings, "GP3_1", true);
            GP3_2 = ParseBool(settings, "GP3_2", true);
            GP3_3 = ParseBool(settings, "GP3_3", true);
            GP3_4 = ParseBool(settings, "GP3_4", true);
            GP4_1 = ParseBool(settings, "GP4_1", true);
            GP4_2 = ParseBool(settings, "GP4_2", true);
            GP4_3 = ParseBool(settings, "GP4_3", true);
            GP4_4 = ParseBool(settings, "GP4_4", true);
            GP5_1 = ParseBool(settings, "GP5_1", true);
            GP5_2 = ParseBool(settings, "GP5_2", true);
            GP5_3 = ParseBool(settings, "GP5_3", true);
            GP5_4 = ParseBool(settings, "GP5_4", true);
            TA1_1 = ParseBool(settings, "TA1_1", true);
            TA1_2 = ParseBool(settings, "TA1_2", true);
            TA1_3 = ParseBool(settings, "TA1_3", true);
            TA1_4 = ParseBool(settings, "TA1_4", true);
            TA1_5 = ParseBool(settings, "TA1_5", true);
            TA1_6 = ParseBool(settings, "TA1_6", true);
            TA2_1 = ParseBool(settings, "TA2_1", true);
            TA2_2 = ParseBool(settings, "TA2_2", true);
            TA2_3 = ParseBool(settings, "TA2_3", true);
            TA2_4 = ParseBool(settings, "TA2_4", true);
            TA2_5 = ParseBool(settings, "TA2_5", true);
            TA2_6 = ParseBool(settings, "TA2_6", true);
            TA2_7 = ParseBool(settings, "TA2_7", true);
            TA3_1 = ParseBool(settings, "TA3_1", true);
            TA3_2 = ParseBool(settings, "TA3_2", true);
            TA3_3 = ParseBool(settings, "TA3_3", true);
            TA3_4 = ParseBool(settings, "TA3_4", true);
            TA3_5 = ParseBool(settings, "TA3_5", true);
            TA3_6 = ParseBool(settings, "TA3_6", true);
            TA3_7 = ParseBool(settings, "TA3_7", true);
            TA3_8 = ParseBool(settings, "TA3_8", true);
            TA3_9 = ParseBool(settings, "TA3_9", true);
            TA4_1 = ParseBool(settings, "TA4_1", true);
            TA4_2 = ParseBool(settings, "TA4_2", true);
            TA4_3 = ParseBool(settings, "TA4_3", true);
            TA4_4 = ParseBool(settings, "TA4_4", true);
            TA4_5 = ParseBool(settings, "TA4_5", true);
            TA4_6 = ParseBool(settings, "TA4_6", true);
            TA4_7 = ParseBool(settings, "TA4_7", true);
            TA4_8 = ParseBool(settings, "TA4_8", true);
            TA4_9 = ParseBool(settings, "TA4_9", true);
            TA5_1 = ParseBool(settings, "TA5_1", true);
            TA5_2 = ParseBool(settings, "TA5_2", true);
            TA5_3 = ParseBool(settings, "TA5_3", true);
            TA5_4 = ParseBool(settings, "TA5_4", true);
            TA5_5 = ParseBool(settings, "TA5_5", true);
            TA5_6 = ParseBool(settings, "TA5_6", true);
            TA5_7 = ParseBool(settings, "TA5_7", true);
            TA5_8 = ParseBool(settings, "TA5_8", true);
            TA5_9 = ParseBool(settings, "TA5_9", true);
            TA5_10 = ParseBool(settings, "TA5_10", true);
            TA6_1 = ParseBool(settings, "TA6_1", true);
            TA6_2 = ParseBool(settings, "TA6_2", true);
            TA6_3 = ParseBool(settings, "TA6_3", true);
            TA6_4 = ParseBool(settings, "TA6_4", true);
            TA6_5 = ParseBool(settings, "TA6_5", true);
            TA6_6 = ParseBool(settings, "TA6_6", true);
            TA6_7 = ParseBool(settings, "TA6_7", true);
            TA6_8 = ParseBool(settings, "TA6_8", true);
            TA6_9 = ParseBool(settings, "TA6_9", true);
            TA6_10 = ParseBool(settings, "TA6_10", true);
            TA6_11 = ParseBool(settings, "TA6_11", true);
            TA7_1 = ParseBool(settings, "TA7_1", true);
            TA7_2 = ParseBool(settings, "TA7_2", true);
            TA7_3 = ParseBool(settings, "TA7_3", true);
            TA7_4 = ParseBool(settings, "TA7_4", true);
            TA7_5 = ParseBool(settings, "TA7_5", true);
            TA7_6 = ParseBool(settings, "TA7_6", true);
            TA7_7 = ParseBool(settings, "TA7_7", true);
            TA7_8 = ParseBool(settings, "TA7_8", true);
            TA7_9 = ParseBool(settings, "TA7_9", true);
            TA7_10 = ParseBool(settings, "TA7_10", true);
            TA7_11 = ParseBool(settings, "TA7_11", true);
            TA7_12 = ParseBool(settings, "TA7_12", true);
        }

        static bool ParseBool(XmlNode settings, string setting, bool default_ = false)
        {
            bool val;
            return settings[setting] != null ? (Boolean.TryParse(settings[setting].InnerText, out val) ? val : default_) : default_;
        }

        static XmlElement ToElement<T>(XmlDocument document, string name, T value)
        {
            XmlElement str = document.CreateElement(name);
            str.InnerText = value.ToString();
            return str;
        }
    }
}
