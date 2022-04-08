using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class EditorFactionCustomSettings : MonoBehaviour
    {
        /// <summary>
        /// Defines if faction is a "freelancer" or not
        /// </summary>
        public bool PreferSingleShip = false;

        public bool RepairShips = true;

        public bool UpgradeShips = true;

        public float RepairMinHullDamage = 0.2f;

        public int RepairMinCreditsBeforeRepair = 2000;

        public float PreferenceToPlaceBounty = 0.5f;

        public float LargeShipPreference = 0.25f;

        /// <summary>
        /// Artificial credit bonus
        /// </summary>
        public int DailyIncome = 0;

        public bool HostileWithAll = false;

        /// <summary>
        /// Should ideally be 1-6 in 1.6.2
        /// </summary>
        public int MinFleetUnitCount = 1;

        /// <summary>
        /// Should ideally be 1-6 in 1.6.2
        /// </summary>
        public int MaxFleetUnitCount = 6;

        public float OffensiveStance = 0.5f;

        public bool AllowOtherFactionToUseDocks = true;

        public float PreferenceToBuildTurrets = 0.5f;

        public float PreferenceToBuildStations = 0.5f;


        public bool IgnoreStationCreditsReserve = false;

    }
}
