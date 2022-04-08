using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    /// <summary>
    /// A message that shows up after a certain amount of time
    /// </summary>
    public class PlayerDelayedMessage : MonoBehaviour
    {
        /// <summary>
        /// The scenario time in seconds when to show the message
        /// </summary>
        public double ShowTime;
    }
}
