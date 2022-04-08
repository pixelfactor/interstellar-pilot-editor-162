using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities
{
    public static class Util
    {
        public static EditorSavedGame FindSavedGameOrErrorOut()
        {
            var editorSavedGame = GameObject.FindObjectOfType<EditorSavedGame>();
            if (editorSavedGame == null)
            {
                EditorUtility.DisplayDialog("IP Editor", $"Cannot find a {nameof(EditorSavedGame)} type object in the current scene", "Ok");
                return null;
            }

            return editorSavedGame;
        }
    }
}
