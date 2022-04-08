using System;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class Header
    {
        /// <summary>
        /// The "save" version. Not guaranteed to be the same as the game version but normally close.
        /// </summary>
        public Version Version { get; set; }

        public bool IsAutoSave { get; set; }

        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Determines what unity scene to load up - don't change
        /// </summary>
        public int ScenarioInfoId { get; set; }

        /// <summary>
        /// The number of times saved since the game was installed
        /// </summary>
        public int GlobalSaveNumber { get; set; }

        /// <summary>
        /// The number of times saved within this specific game
        /// </summary>
        public int SaveNumber { get; set; }

        /// <summary>
        /// Whether the game has a player. Almost always yes. If so, additional info is saved
        /// </summary>
        public bool HavePlayer { get; set; }

        /// <summary>
        /// The sector the player is in<br />
        /// Header info only - does not affect the loaded game
        /// </summary>
        public string PlayerSectorName { get; set; }

        /// <summary>
        /// Header info only - does not affect the loaded game
        /// </summary>
        public string PlayerName { get; set; }

        /// <summary>
        /// Header info only - does not affect the loaded game
        /// </summary>
        public int Credits { get; set; }
    }
}
