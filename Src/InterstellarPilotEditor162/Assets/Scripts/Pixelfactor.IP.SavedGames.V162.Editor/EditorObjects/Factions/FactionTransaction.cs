using Pixelfactor.IP.SavedGames.V162.Model;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Factions
{
    /// <summary>
    /// Represents a recent change in credits. Should only be required by player faction
    /// </summary>
    public class FactionTransaction
    {
        public FactionTransactionType TransactionType { get; set; }
        public int Value { get; set; }
        public int CurrentBalance { get; set; }
        public EditorUnit LocationUnit { get; set; }
        public EditorFaction OtherFaction { get; set; }
        public CargoClass RelatedCargoClass { get; set; }
        public UnitClass RelatedUnitClass { get; set; }
        public double GameWorldTime { get; set; }
    }
}
