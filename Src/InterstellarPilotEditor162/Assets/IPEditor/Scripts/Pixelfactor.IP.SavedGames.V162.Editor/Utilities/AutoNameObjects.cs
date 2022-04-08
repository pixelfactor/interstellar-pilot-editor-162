using Pixelfactor.IP.SavedGames.V162.Editor.Assets.IPEditor.Scripts.PixelfactorIPSavedGamesV162Editor;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities
{
    public class AutoNameObjects
    {
        /// <summary>
        /// 
        /// </summary>
        [MenuItem("IPEditor/Tools/Auto-name objects")]
        public static void AutoNameAllObjects()
        {
            var editorSavedGame = GameObject.FindObjectOfType<EditorSavedGame>();
            if (editorSavedGame == null)
            {
                EditorUtility.DisplayDialog("Auto-assign object ids", $"Cannot find a {nameof(EditorSavedGame)} type object in the current scene", "Ok");
                return;
            }

            AutoNameSectors(editorSavedGame);
            AutoNameUnits(editorSavedGame);
            AutoNameFactions(editorSavedGame);

            Debug.Log("Finished auto-naming objects");
        }

        private static void AutoNameSectors(EditorSavedGame editorSavedGame)
        {
            foreach (var editorSector in editorSavedGame.GetComponentsInChildren<EditorSector>())
            {
                editorSector.gameObject.name = $"Sector_{(!string.IsNullOrWhiteSpace(editorSector.Name) ? editorSector.Name : "Unnamed")}";
                EditorUtility.SetDirty(editorSector);
            }
        }

        private static void AutoNameUnits(EditorSavedGame editorSavedGame)
        {
            foreach (var editorSector in editorSavedGame.GetComponentsInChildren<EditorSector>())
            {
                foreach (var editorUnit in editorSector.GetComponentsInChildren<EditorUnit>())
                {
                    editorUnit.gameObject.name = GetEditorUnitName(editorUnit);
                    EditorUtility.SetDirty(editorSector);
                }
            }
        }

        private static void AutoNameFactions(EditorSavedGame editorSavedGame)
        {
            foreach (var editorFaction in editorSavedGame.GetComponentsInChildren<EditorFaction>())
            {
                editorFaction.gameObject.name = GetEditorFactionName(editorFaction);
                EditorUtility.SetDirty(editorFaction);
            }
        }

        private static string GetEditorFactionName(EditorFaction editorFaction)
        {
            return $"Faction_{(!string.IsNullOrWhiteSpace(editorFaction.CustomShortName) ? editorFaction.CustomShortName : "NoName")}";
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

            var factionPostfix = string.Empty;
            if (editorUnit.Faction != null)
            {
                factionPostfix = $"_{(editorUnit.Faction != null ? editorUnit.Faction.CustomShortName : "NoFactionName")}";
            }

            if (editorUnit.Class.IsCargo())
            {
                var cargo = editorUnit.GetComponent<EditorUnitCargoData>();
                if (cargo != null)
                {
                    return $"Cargo_{cargo.CargoClass}_{cargo.Quantity}{factionPostfix}";
                }
                else
                {
                    return "Cargo_MissingData";
                }
            }

            if (editorUnit.Class.IsShipOrStation())
            {
                if (editorUnit.Faction != null)
                {
                    return $"{editorUnit.Class.ToString()}{factionPostfix}";
                }

                return $"Abandoned_{editorUnit.Class.ToString()}";
            }

            return $"{editorUnit.Class.ToString()}";
        }
    }
}