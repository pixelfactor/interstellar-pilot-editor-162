namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class FactionCustomSettings
    {
        /// <summary>
        /// Defines if faction is a "freelancer" or not
        /// </summary>
        public bool PreferSingleShip { get; set; }

        public bool RepairShips { get; set; }

        public bool UpgradeShips { get; set; }

        public float RepairMinHullDamage { get; set; }

        public int RepairMinCreditsBeforeRepair { get; set; }

        public float PreferenceToPlaceBounty { get; set; }

        public float LargeShipPreference { get; set; }

        /// <summary>
        /// Artificial credit bonus
        /// </summary>
        public int DailyIncome { get; set; }

        public bool HostileWithAll { get; set; }

        /// <summary>
        /// Should ideally be 1-6 in 1.6.2
        /// </summary>
        public int MinFleetUnitCount { get; set; }

        /// <summary>
        /// Should ideally be 1-6 in 1.6.2
        /// </summary>
        public int MaxFleetUnitCount { get; set; }

        public float OffensiveStance { get; set; }

        public bool AllowOtherFactionToUseDocks { get; set; }

        public float PreferenceToBuildTurrets { get; set; }

        public float PreferenceToBuildStations { get; set; }


        public bool IgnoreStationCreditsReserve { get; set; }

    }
}
