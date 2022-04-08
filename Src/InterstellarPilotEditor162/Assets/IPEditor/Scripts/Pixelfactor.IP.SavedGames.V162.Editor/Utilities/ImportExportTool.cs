using System.IO;
using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public class ImportExportTool : MonoBehaviour
    {
        [MenuItem("IPEditor/Validate and export")]
        public static void ValidateAndExport()
        {
            // Find the saved game
            var editorSavedGame = GameObject.FindObjectOfType<EditorSavedGame>();
            if (editorSavedGame == null)
            {
                Debug.LogError("No editor saved game found"); return;
            }

            try
            {
                Validator.Validate(editorSavedGame, true);
            }
            catch (System.Exception ex)
            {
                Debug.LogException(new System.Exception("Validation failed. Export will not continue.", ex));
                return;
            }

            var savedGame = SavedGameExporter.Export(editorSavedGame);

            // TODO: Pick a good name  - check doesn't exist
            var preferredPath = @"C:\Users\gsdat\AppData\LocalLow\pixelfactor\Interstellar Pilot\SaveGames";
            var fileName = "NewEditorSavedGame.dat";
            var path = Path.Combine(preferredPath, fileName);

            BinarySerialization.Writers.SaveGameWriter.WriteToPath(savedGame, path);

            Debug.Log($"Save file successfully exported to {Path.GetFullPath(fileName)}");
        }
    }
}
