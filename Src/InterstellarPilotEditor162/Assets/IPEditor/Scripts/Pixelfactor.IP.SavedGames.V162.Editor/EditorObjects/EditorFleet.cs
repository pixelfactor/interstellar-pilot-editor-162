using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class EditorFleet : MonoBehaviour
    {
        public int Id = -1;

        public EditorFaction Faction;

        public EditorUnit HomeBaseUnit;

        /// <summary>
        /// When true the parent faction won't' try to control
        /// </summary>
        public bool ExcludeFromFactionAI;

        /// <summary>
        /// Use this to give the ships a custom name
        /// </summary>
        public string Designation;
    }
}
