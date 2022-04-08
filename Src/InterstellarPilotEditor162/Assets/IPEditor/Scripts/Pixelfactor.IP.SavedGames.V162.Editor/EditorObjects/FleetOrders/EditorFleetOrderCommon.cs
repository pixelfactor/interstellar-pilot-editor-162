using Pixelfactor.IP.SavedGames.V162.Model.FleetOrders;
using Pixelfactor.IP.SavedGames.V162.Model.FleetOrders.Models;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders
{
    public class EditorFleetOrderCommon : MonoBehaviour
    {
        public virtual FleetOrderType OrderType
        {
            get { return FleetOrderType.None; }
        }

        public int Id = -1;

        public FleetOrderCompletionMode CompletionMode = FleetOrderCompletionMode.Destroy;

        public bool AllowCombatInterception = true;

        public FleetOrderCloakPreference CloakPreference = FleetOrderCloakPreference.OnlyIfAllCanCloak;

        /// <summary>
        /// Max sector distance from home base
        /// </summary>
        public int MaxJumpDistance = -1;

        /// <summary>
        /// Determines if after a period of inactivity (while order is active), the order is invalidated<br />
        /// </summary>
        public bool AllowTimeout = true;

        /// <summary>
        /// The period of inactivity in seconds, after which the order will be invalidated
        /// </summary>
        public float TimeoutTime = 240f;
    }
}
