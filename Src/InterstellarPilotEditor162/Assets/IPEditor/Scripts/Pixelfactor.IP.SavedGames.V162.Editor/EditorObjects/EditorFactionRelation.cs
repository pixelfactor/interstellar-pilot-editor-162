using Pixelfactor.IP.SavedGames.V162.Model;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class EditorFactionRelation : MonoBehaviour
    {
        public EditorFaction OtherFaction;

        public bool PermanentPeace = false;

        /// <summary>
        /// When true, the factions will never automatically declare peace
        /// </summary>
        public bool RestrictHostilityTimeout = false;
        public Neutrality Neutrality = Neutrality.Neutral;

        /// <summary>
        /// Fixed time when make peace. Only applies when <see cref="RestrictHostilityTimeout"/> is false
        /// </summary>
        public double HostilityEndTime = -1;

        /// <summary>
        /// Determines when to make war
        /// </summary>
        public float RecentDamageReceived = 0f;

        /// <summary>
        /// 0 - 1, 0 = worst, 1 = best
        /// </summary>
        public float Opinion = 0.5f;
    }
}
