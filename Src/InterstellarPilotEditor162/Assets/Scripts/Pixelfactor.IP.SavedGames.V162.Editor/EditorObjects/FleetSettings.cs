namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class FleetSettings
    {
        public bool NotifyWhenOrderComplete = false;

        /// <summary>
        /// When set to false, units won't intercept targets although they may still fire at them<br />
        /// When false, the equivalent setting on a fleet will not apply
        /// </summary>
        public bool AllowCombatInterception = true;

        public bool AllowAttack = true;

        /// <summary>
        /// Fleet will allow pilots to interecept targets that have a better score than this<br />
        /// Set the value very high if the group should ignore targets
        /// </summary>
        public float AttackTargetScoreThreshold = 13.0f;

        /// <summary>
        /// When true, controllers will collect cargo
        /// </summary>
        public bool ControllersCanCollectCargo = true;

        public bool ControllersCollectOnlyEquipment = true;

        /// <summary>
        /// Distance at which fleet members will be allowed to intercept targets
        /// </summary>
        public float TargetInterceptionLowerDistance = 1300.0f;

        /// <summary>
        /// Distance at which fleet members will be allowed to intercept targets
        /// </summary>
        public float TargetInterceptionUpperDistance = 1500.0f;

        /// <summary>
        /// Determines if the fleets unit's should be cloaked when not in combat
        /// </summary>
        public bool PreferCloak = false;

        /// <summary>
        /// Affects objectives where docking at a target is optional
        /// </summary>
        public bool PreferToDock = false;

        public bool RestrictMaxJumps = false;

        /// <summary>
        /// Defines how far this fleet can travel from its home base (if it is assigned)<br />
        /// Applies only if restrict max jumps is true
        /// </summary>
        public int MaxJumpDistance = 99;

        public bool DestroyWhenNoPilots = false;
    }
}
