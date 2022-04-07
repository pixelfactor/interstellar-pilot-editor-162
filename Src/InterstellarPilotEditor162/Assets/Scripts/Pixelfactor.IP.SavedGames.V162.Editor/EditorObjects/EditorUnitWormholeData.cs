using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class EditorUnitWormholeData : MonoBehaviour
    {
        /// <summary>
        /// For stable wormholes, points to the other wormhole that this connects to.
        /// </summary>
        public EditorUnit TargetWormholeUnit;

        /// <summary>
        /// Don't change for existing wormholes - changing this will cause carnage
        /// </summary>
        public bool IsUnstable = false;

        public double UnstableNextChangeTargetTime;

        /// <summary>
        /// The target of the wormhole when it is unstable<br />
        /// TODO: Not yet implemented
        /// </summary>
        public Transform UnstableTarget;

        void OnDrawGizmosSelected()
        {
            if (this.TargetWormholeUnit != null)
            {
                // Draws a blue line from this transform to the target
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(transform.position, this.TargetWormholeUnit.transform.position);
            }
        }
    }
}
