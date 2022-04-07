using Pixelfactor.IP.SavedGames.V162.Model;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    /// <summary>
    /// Represents factory progress at a station e.g. production of alloys at the refinery
    /// </summary>
    public class ComponentUnitFactoryItemData
    {
        public ComponentUnitFactoryItemState State { get; set; }
        public float ProductionElapsed { get; set; }
    }
}
