using Pixelfactor.IP.SavedGames.V162.Editor.Assets.IPEditor.Scripts.PixelfactorIPSavedGamesV162Editor;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public class AutoNameObjects
    {
        /// <summary>
        /// 
        /// </summary>
        [MenuItem("IPEditor/Auto-name objects")]
        public static void AutoNameAllObjects()
        {
            var editorSavedGame = GameObject.FindObjectOfType<EditorSavedGame>();
            if (editorSavedGame == null)
            {
                EditorUtility.DisplayDialog("Auto-assign object ids", $"Cannot find a {nameof(EditorSavedGame)} type object in the current scene", "Ok");
                return;
            }

            foreach (var editorSector in editorSavedGame.GetComponentsInChildren<EditorSector>())
            {
                editorSector.gameObject.name = $"Sector_{(!string.IsNullOrWhiteSpace(editorSector.Name) ? editorSector.Name : "Unnamed")}";
                EditorUtility.SetDirty(editorSector);

                foreach (var editorUnit in editorSector.GetComponentsInChildren<EditorUnit>())
                {
                    editorUnit.gameObject.name = GetEditorUnitName(editorUnit);
                    EditorUtility.SetDirty(editorSector);
                }
            }

            Debug.Log("Finished auto-naming objects");
        }

        private static string GetEditorUnitName(EditorUnit editorUnit)
        {
            if (editorUnit.Class.IsWormhole())
            {
                var wormholeData = editorUnit.GetComponent<EditorUnitWormholeData>();
                if (wormholeData != null)
                {
                    var targetSector = wormholeData.GetActualTargetSector();
                    var targetSectorName = targetSector?.Name ?? "Nowhere";
                    if (wormholeData.IsUnstable)
                    {
                        return $"UnstableWormhole_To_{targetSectorName}";
                    }

                    return $"Wormhole_To_{targetSectorName}";
                }

                return $"Wormhole_MissingData";
            }

            if (editorUnit.Faction != null)
            { 
                return editorUnit.gameObject.name = $"{editorUnit.Class.ToString()}_Faction_{(editorUnit.Faction != null ? editorUnit.Faction.CustomShortName : "NoName")}";
            }

            return editorUnit.gameObject.name = $"{editorUnit.Class.ToString()}";
        }
    }
}