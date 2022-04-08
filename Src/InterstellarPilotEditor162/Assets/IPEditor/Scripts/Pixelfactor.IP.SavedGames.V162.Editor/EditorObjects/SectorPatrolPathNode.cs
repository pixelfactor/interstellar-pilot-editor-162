using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    /// <summary>
    /// A node on a <see cref="EditorSectorPatrolPath" />
    /// </summary>
    public class SectorPatrolPathNode
    {
        public Vector3 Position { get; set; }
        public int Order { get; set; }
    }
}
