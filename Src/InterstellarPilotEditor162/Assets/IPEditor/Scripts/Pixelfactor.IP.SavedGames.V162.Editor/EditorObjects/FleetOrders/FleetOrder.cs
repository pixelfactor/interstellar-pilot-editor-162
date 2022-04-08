using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders
{
    public class FleetOrder
    {
        public FleetOrderType OrderType { get; set; }

        public int Id { get; set; }

        public FleetOrderCompletionMode CompletionMode { get; set; }

        public bool AllowCombatInterception { get; set; }

        public FleetOrderCloakPreference CloakPreference { get; set; }

        /// <summary>
        /// Max sector distance from home base
        /// </summary>
        public int MaxJumpDistance { get; set; }

        /// <summary>
        /// Determines if after a period of inactivity (while order is active), the order is invalidated<br />
        /// </summary>
        public bool AllowTimeout { get; set; }

        /// <summary>
        /// The period of inactivity in seconds, after which the order will be invalidated
        /// </summary>
        public float TimeoutTime { get; set; }
    }
}
