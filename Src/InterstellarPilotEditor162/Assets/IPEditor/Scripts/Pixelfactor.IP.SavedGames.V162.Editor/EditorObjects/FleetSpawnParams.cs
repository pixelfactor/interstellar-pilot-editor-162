using System.Collections.Generic;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    /// <summary>
    /// This type was used in early version to artificially inject fleets into the game<br />
    /// It is still used by the <see cref="Entities.Jobs.JobTypes.DestroyFleetJob"/>
    /// </summary>
    public class FleetSpawnParams
    {
        public EditorFaction Faction { get; set; }

        public string FleetResourceName { get; set; }

        /// <summary>
        /// Optional home base for the spawned units
        /// </summary>
        public EditorUnit HomeBaseUnit { get; set; }

        /// <summary>
        /// Optional home sector for the spawned units
        /// </summary>
        public EditorSector HomeSector { get; set; }

        /// <summary>
        /// The designation given to all spawned units
        /// </summary>
        public string ShipDesignation { get; set; }

        /// <summary>
        /// Description of each unit to spawn
        /// </summary>
        public List<FleetSpawnParamsItem> Items = new List<FleetSpawnParamsItem>();

        /// <summary>
        /// Dock that the spawned units will be spawned at if assigned
        /// </summary>
        public EditorUnit TargetDockUnit { get; set; }

        /// <summary>
        /// Position to spawn at (ignored if TargetDock is assigned)
        /// </summary>
        public Vector3 TargetPosition { get; set; }

        /// <summary>
        /// Sector the spawned units spawn in (ignored if TargetDock is assigned)
        /// </summary>
        public EditorSector TargetSector { get; set; }
    }
}
