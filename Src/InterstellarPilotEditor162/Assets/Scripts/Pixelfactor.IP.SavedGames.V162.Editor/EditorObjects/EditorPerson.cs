using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class EditorPerson : MonoBehaviour
    {
        public bool IsMale = true;

        public int Id = -1;

        /// <summary>
        /// Use this OR the generated name ids
        /// </summary>
        public string CustomName;

        public EditorFaction Faction;
        public int Kills;
    }
}
