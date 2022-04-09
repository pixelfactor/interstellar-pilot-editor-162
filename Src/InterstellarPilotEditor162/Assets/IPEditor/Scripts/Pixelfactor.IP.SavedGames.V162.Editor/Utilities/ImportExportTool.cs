using System.IO;
using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities
{
    public class ImportExportTool : MonoBehaviour
    {
        [MenuItem("IPEditor/Export/Fix, validate and export")]
        public static void FixUpValidateAndExportMenuItem()
        {
            var editorSavedGame = Util.FindSavedGameOrErrorOut();

            FixUpUnitOwnership.SetFleetChildrenToSameFaction(editorSavedGame);
            FixUpUnitOwnership.SetUnitFactionsToPilotFactions(editorSavedGame);
            AutoAssignIdsTool.AutoAssignIds(editorSavedGame);

            ValidateAndExport(editorSavedGame);
        }

        [MenuItem("IPEditor/Export/Validate and export")]
        public static void ValidateAndExportMenuItem()
        {
            var editorSavedGame = Util.FindSavedGameOrErrorOut();

            ValidateAndExport(editorSavedGame);
        }

        private static void ValidateAndExport(EditorSavedGame editorSavedGame)
        {
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
