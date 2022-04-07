namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects
{
    public class NpcPilot
    {
        public Fleet Fleet { get; set; }
        public bool AllowUseCloak { get; set; }
        public bool DestroyWhenNoUnit { get; set; }
        public bool DestroyWhenNotPilotting { get; set; }
        public EditorPerson Person { get; set; }
    }
}
