using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders;
using System.Collections.Generic;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class EditorFleet
    {
        public int Id = -1;

        public EditorFaction Faction;

        public EditorUnit HomeBaseUnit;

        /// <summary>
        /// When true the parent faction won't' try to control
        /// </summary>
        public bool ExcludeFromFactionAI;
    }
}
