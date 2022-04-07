using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes
{
    public class ActiveScavengeOrder : ActiveFleetOrder
    {
        public EditorUnit TractorTargetUnit { get; set; }
        public bool AutoFindCargoEnabled { get; set; }
        public bool AutoTractorCargoEnabled { get; set; }
        public bool IsRoaming { get; set; }
        public double RoamExpireTime { get; set; }
        public Vector3 LastKnownCargoPosition { get; set; }
        public bool HadCargoTarget { get; set; }
    }
}
