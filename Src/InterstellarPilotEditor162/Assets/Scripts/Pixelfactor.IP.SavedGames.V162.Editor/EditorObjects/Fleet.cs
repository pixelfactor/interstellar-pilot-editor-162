using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders;
using System.Collections.Generic;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class Fleet
    {
        public int Id { get; set; }

        public Vector3 Position { get; set; }

        public Vector4 Rotation { get; set; }

        public EditorSector Sector { get; set; }

        public EditorFaction Faction { get; set; }

        public EditorUnit HomeBaseUnit { get; set; }

        /// <summary>
        /// When true the parent faction won't' try to control
        /// </summary>
        public bool ExcludeFromFactionAI { get; set; }

        /// <summary>
        /// Optional custom settings
        /// </summary>
        public FleetSettings FleetSettings { get; set; }

        /// <summary>
        /// Note: Due to a massive bug in the way 1.6.x loads a save game, fleet orders in the save file can be ignored when game loads <em>if the order involves another fleet</em><br />
        /// E.g. The attack fleet order will sometimes break when loaded
        /// </summary>
        public FleetOrderCollection Orders { get; set; }

        public bool IsActive { get; set; }

        /// <summary>
        /// The npcs inside this fleet (pilots)
        /// </summary>
        public List<NpcPilot> Npcs { get; set; } = new List<NpcPilot>();
    }
}
