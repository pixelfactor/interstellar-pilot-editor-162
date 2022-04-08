using System.Collections.Generic;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    /// <summary>
    /// Used by some scenarios to have fleets patrol, mainly because the at the time of creating the scenarios, factions could not generate patrol routes dynamically.<br />
    /// This mechanism is not used when generating a custom universe, though there is no reason why it couldn't be.
    /// </summary>
    public class EditorSectorPatrolPath : MonoBehaviour
    {
        public int Id = -1;
        public bool IsLoop = true;
    }
}
