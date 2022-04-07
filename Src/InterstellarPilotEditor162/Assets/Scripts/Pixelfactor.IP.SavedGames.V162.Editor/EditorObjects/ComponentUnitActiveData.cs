using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    /// <summary>
    /// Some data about a ship when it is in the "active" sector.<br />
    /// </summary>
    public class ComponentUnitActiveData
    {
        public Vector3 Velocity { get; set; }
        public float CurrentTurn { get; set; }
    }
}
