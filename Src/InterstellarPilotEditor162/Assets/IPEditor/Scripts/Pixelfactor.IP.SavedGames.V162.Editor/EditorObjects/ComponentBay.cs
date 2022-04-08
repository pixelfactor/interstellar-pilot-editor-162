using Pixelfactor.IP.SavedGames.V162.Model;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class ComponentBay
    {
        /// <summary>
        /// The id local to the ship this bay is placed on
        /// </summary>
        public int Id { get; set; }
        public ComponentBayType Type { get; set; }
        public string Name { get; set; }
    }
}
