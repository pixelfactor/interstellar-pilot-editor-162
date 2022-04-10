using Pixelfactor.IP.SavedGames.V162.Model;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    /// <summary>
    /// Sector/room within the universe
    /// </summary>
    public class EditorSector : MonoBehaviour
    {
        public int Id;

        /// <summary>
        /// The unity scene to load to represent the sector
        /// </summary>
        public SectorResourceNames Resource;

        public string Name;

        public string Description;

        /// <summary>
        /// Determines the distance of the wormholes from the sector origin. Should be ~1.0
        /// </summary>
        public float WormholeDistanceMultiplier = 1.0f;

        /// <summary>
        /// Something to do with the appearance of asteroid clusters
        /// </summary>
        public int RandomSeed = -1;

        /// <summary>
        /// Skybox rotation
        /// </summary>
        public Vector3 BackgroundRotation;

        public Vector3 LightRotation = new Vector3(45.0f, 45.0f, 0.0f);

        void OnDrawGizmosSelected()
        {
            if (SelectionHelper.IsSelected(this) || SelectionHelper.IsSelected(this.transform.parent))
            {
                GUIStyle style = new GUIStyle();
                style.fontSize = 18;
                style.alignment = TextAnchor.MiddleCenter;
                DrawString.Draw(this.gameObject.name, this.transform.position, new Color(0.3f, 0.3f, 1.0f), style, new Vector3(0.0f, -100.0f, 0.0f));
            }
        }
    }
}
