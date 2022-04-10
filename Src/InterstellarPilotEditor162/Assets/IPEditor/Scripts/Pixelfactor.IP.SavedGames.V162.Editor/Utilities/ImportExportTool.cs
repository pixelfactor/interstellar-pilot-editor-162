using System.IO;
using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities
{
    public class ImportExportTool : MonoBehaviour
    {
        [MenuItem("IPEditor/Export/Quick Export")]
        public static void FixUpValidateAndExportMenuItem()
        {
            var editorSavedGame = Util.FindSavedGameOrErrorOut();

            FixUpUnitOwnership.SetFleetChildrenToSameFaction(editorSavedGame);
            FixUpUnitOwnership.SetUnitFactionsToPilotFactions(editorSavedGame);

            // Blitz all ids to ensure uniqueness
            AutoAssignIdsTool.ClearAllIds(editorSavedGame);
            AutoAssignIdsTool.AutoAssignIds(editorSavedGame);

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

            // TODO: Move path to settings
            var preferredPath = @"";
            var fileName = "NewEditorSavedGame.dat";
            var path = Path.Combine(preferredPath, fileName);

            BinarySerialization.Writers.SaveGameWriter.WriteToPath(savedGame, path);

            Debug.Log($"Save file successfully exported to {Path.GetFullPath(fileName)}");
        }
    }
}
