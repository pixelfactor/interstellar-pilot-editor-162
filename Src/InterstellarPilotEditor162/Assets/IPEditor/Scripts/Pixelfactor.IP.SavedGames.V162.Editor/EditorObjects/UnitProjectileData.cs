namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class UnitProjectileData
    {
        public EditorUnit SourceUnit { get; set; }
        public EditorUnit TargetUnit { get; set; }
        public double FireTime { get; set; }
        public float RemainingMovement { get; set; }
        public DamageType DamageType { get; set; }
    }
}
