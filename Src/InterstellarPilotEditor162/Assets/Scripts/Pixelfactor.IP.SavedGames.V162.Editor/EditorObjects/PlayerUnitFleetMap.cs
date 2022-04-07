namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    /// <summary>
    /// Used by engine to keep track of what units the player has assigned to what fleet 
    /// </summary>
    public class PlayerUnitFleetMap
    {
        public EditorUnit Unit { get; set; }
        public Fleet Fleet { get; set; }
    }
}
