namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class UnitHealthData
    {
        /// <summary>
        /// Do not use!
        /// </summary>
        public bool IsDestroyed { get; set; }

        /// <summary>
        /// Used for triggers / scripting
        /// </summary>
        public float TotalDamagedReceived { get; set; }

        /// <summary>
        /// Current health of the unit. Any value up to the max health defined by the unit class
        /// </summary>
        public float Health { get; set; }
    }
}
