using System.Collections.Generic;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class FactionIntel
    {
        public List<EditorSector> Sectors { get; set; } = new List<EditorSector>();
        public List<EditorUnit> Units { get; set; } = new List<EditorUnit>();
    }
}
