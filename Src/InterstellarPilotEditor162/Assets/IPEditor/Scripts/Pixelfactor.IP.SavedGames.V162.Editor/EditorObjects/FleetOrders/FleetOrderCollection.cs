using System.Collections.Generic;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders
{
    public class FleetOrderCollection
    {
        /// <summary>
        /// This collection should contain both queued, current and inactive objectives. Some scenarios give fleets disabled objectives that are later enabled.
        /// </summary>
        public List<FleetOrder> Orders { get; set; } = new List<FleetOrder>();

        public List<FleetOrder> QueuedOrders { get; set; } = new List<FleetOrder>();

        /// <summary>
        /// What the fleet is currently doing.. move to, dock etc
        /// </summary>
        public ActiveFleetOrder CurrentOrder { get; set; }
    }
}
