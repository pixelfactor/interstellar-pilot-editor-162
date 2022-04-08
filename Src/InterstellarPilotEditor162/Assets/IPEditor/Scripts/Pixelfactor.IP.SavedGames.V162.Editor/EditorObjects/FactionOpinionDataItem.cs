namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    /// <summary>
    /// Determines what a faction thinks of another
    /// </summary>
    public class FactionOpinionDataItem
    {
        public EditorFaction OtherFaction { get; set; }

        /// <summary>
        /// 0 - 1, 0 = worst, 1 = best
        /// </summary>
        public float Opinion { get; set; }
    }
}
