using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public class EditorSavedGame : MonoBehaviour
    {
        public bool RandomEventsEnabled = true;

        /// <summary>
        /// The distance from sector origin<br />
        /// Applies when connecting sectors
        /// </summary>
        public float PreferredWormholeDistance = 2000.0f;
    }
}
