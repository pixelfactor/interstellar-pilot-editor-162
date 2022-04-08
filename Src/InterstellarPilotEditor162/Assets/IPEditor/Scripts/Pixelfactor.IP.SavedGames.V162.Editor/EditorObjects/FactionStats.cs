using System.Collections.Generic;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class FactionStats
    {
        public int TotalShipsClaimed { get; set; }
        public Dictionary<int, int> UnitsDestroyedByClassId { get; set; } = new Dictionary<int, int>();
        public Dictionary<int, int> UnitLostByClassId { get; set; } = new Dictionary<int, int>();
        public int ScratchcardsScratched { get; set; }
        public int HighestScratchcardWin { get; set; }
    }
}
