namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class FactionRelationDataItem
    {
        public EditorFaction OtherFaction { get; set; }

        public bool PermanentPeace { get; set; }

        public bool RestrictHostilityTimeout { get; set; }
        public Neutrality Neutrality { get; set; }

        /// <summary>
        /// Fixed time when make peace
        /// </summary>
        public double HostilityEndTime { get; set; }

        /// <summary>
        /// Determines when to make war
        /// </summary>
        public float RecentDamageReceived { get; set; }
    }
}
