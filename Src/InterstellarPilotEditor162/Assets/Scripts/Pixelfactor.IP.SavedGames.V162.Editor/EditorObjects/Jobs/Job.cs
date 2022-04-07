namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Jobs
{
    public class Job
    {
        public int Id { get; set; }
        public int JobDataResourceId { get; set; }
        public double ExpiryTime { get; set; }
        public int RewardCredits { get; set; }
        public int ProfitCredits { get; set; }
        public EditorFaction Faction { get; set; }
        /// <summary>
        /// This is the station that the job exists at
        /// </summary>
        public EditorUnit Unit { get; set; }
        public JobType JobType { get; set; }
    }
}
