namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class PassengerGroup
    {
        public int Id { get; set; }
        public EditorUnit Unit { get; set; }
        public EditorUnit SourceUnit { get; set; }
        public EditorUnit DestinationUnit { get; set; }
        public int PassengerCount { get; set; }
        public double ExpiryTime { get; set; }
        public int Revenue { get; set; }
    }
}
