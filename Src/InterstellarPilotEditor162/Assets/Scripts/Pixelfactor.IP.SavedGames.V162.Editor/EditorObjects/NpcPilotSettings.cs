namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class NpcPilotSettings
    {
        public bool UsesCloak { get; set; }

        public float UseCloakPreference { get; set; }

        public float EnterCombatCloakedProbability { get; set; }

        public float RestrictedWeaponPreference { get; set; }

        /// <summary>
        /// 0 - 1, 1 = best. Not used so often in 1.6.x
        /// </summary>
        public float CombatEfficiency { get; set; }

        /// <summary>
        /// When true, npc will not run out of ammo
        /// </summary>
        public bool CheatAmmo { get; set; }
    }
}
