using System.Collections.Generic;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.Jobs
{
    /// <summary>
    /// A job that the player has accepted and is attempting
    /// </summary>
    public class ActiveJob
    {
        /// <summary>
        /// Determines if the job was generated during gameplay (like at job boards) or at compile-time (like scenarios)
        /// </summary>
        public bool IsDynamicGenerated { get; set; }
        public int Id { get; set; }
        public int StageIndex { get; set; }
        public bool IsActive { get; set; }
        public bool IsFinished { get; set; }
        public bool CompletionSuccess { get; set; }
        public bool ShowInJournal { get; set; }
        public EditorFaction OwnerFaction { get; set; }
        public EditorFaction MissionGiverFaction { get; set; }
        public float CompletionOpinionChange { get; set; }
        public float FailureOpinionChange { get; set; }
        public double StartTime { get; set; }
        public int RewardCredits { get; set; }
        public JobDataIds JobDataId { get; set; }
        public JobType JobType { get; set; }
        public List<ActiveJobObjective> Objectives = new List<ActiveJobObjective>();
    }
}
