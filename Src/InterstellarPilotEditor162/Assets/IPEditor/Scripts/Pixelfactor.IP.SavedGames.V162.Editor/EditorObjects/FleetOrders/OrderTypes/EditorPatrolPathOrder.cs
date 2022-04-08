using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes
{
    [RequireComponent(typeof(EditorFleetOrderCommon))]
    public class EditorPatrolPathOrder : EditorFleetOrderBase
    {
        public int PathDirection = 1;

        /// <summary>
        /// Determines if the objective path is repeated after reaching either end
        /// Setting this to true is the same as using AIObjective.ObjectiveCompleteMode.Repeat
        /// </summary>
        public bool IsLooping = true;

        public EditorSectorPatrolPath PatrolPath;
    }
}
