using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities
{
    public class ValidatorTool : MonoBehaviour
    {
        [MenuItem("IPEditor/Export/Validate")]
        public static void Validate()
        {
            // Find the saved game
            var editorSavedGame = GameObject.FindObjectOfType<EditorSavedGame>();
            if (editorSavedGame == null)
            {
                Debug.LogError("No editor saved game found"); return;
            }

            Validator.Validate(editorSavedGame, false);

            Debug.Log("Validation complete");

        }
    }
}
