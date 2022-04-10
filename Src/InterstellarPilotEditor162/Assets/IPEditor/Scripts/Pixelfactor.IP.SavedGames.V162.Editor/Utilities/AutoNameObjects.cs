using Pixelfactor.IP.SavedGames.V162.Editor.Assets.IPEditor.Scripts.PixelfactorIPSavedGamesV162Editor;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using System.Linq;
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
            AutoNameFleets(editorSavedGame);

            Debug.Log("Finished auto-naming objects");
        }

        private static void AutoNameFleets(EditorSavedGame editorSavedGame)
        {
            foreach (var editorFleet in editorSavedGame.GetComponentsInChildren<EditorFleet>())
            {
                editorFleet.gameObject.name = GetEditorFleetName(editorFleet, editorSavedGame);
                EditorUtility.SetDirty(editorFleet);
            }
        }

        private static string GetEditorFleetName(EditorFleet editorFleet, EditorSavedGame editorSavedGame)
        {
            var factionPostfix = "_NoFaction";
            if (editorFleet.Faction != null)
            {
                factionPostfix = $"_{(editorFleet.Faction != null ? editorFleet.Faction.CustomShortName : "NoFactionName")}";
            }

            if (!string.IsNullOrWhiteSpace(editorFleet.Designation))
            {
                return $"Fleet_{editorFleet.Designation}{factionPostfix}";
            }

            var name = GetEditorFleetNameFromContents(editorFleet);
            return $"Fleet_{name}{factionPostfix}";
        }

        private static string GetEditorFleetNameFromContents(EditorFleet editorFleet)
        {
            var units = editorFleet.GetComponentsInChildren<EditorUnit>();
            if (units.Length == 0)
            {
                return "Empty";
            }

            // Get the most common unit
            // TODO: It might be better here to get the most powerful unit
            var commonUnitGrouping = units.GroupBy(e => e.Class).OrderByDescending(e => e.Count()).First();
            var name = $"{commonUnitGrouping.First().Class.ToString()}";
            var count = commonUnitGrouping.Count();
            if (count > 1)
            {
                name += $"x{count}";
            }

            return name;
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
                    AutoNameUnit(editorUnit);
                    EditorUtility.SetDirty(editorSector);
                }
            }
        }

        public static void AutoNameUnit(EditorUnit editorUnit)
        {
            editorUnit.gameObject.name = GetEditorUnitName(editorUnit);
        }

        private static void AutoNameFactions(EditorSavedGame editorSavedGame)
        {
            foreach (var editorFaction in editorSavedGame.GetComponentsInChildren<EditorFaction>())
            {
                editorFaction.gameObject.name = GetEditorFactionName(editorFaction);
                EditorUtility.SetDirty(editorFaction);
            }
        }

        public static void AutoNameFactionRelation(EditorFactionRelation editorFactionRelation)
        {
            editorFactionRelation.gameObject.name = GetFactionRelationName(editorFactionRelation);
        }

        public static string GetFactionRelationName(EditorFactionRelation editorFactionRelation)
        {
            if (editorFactionRelation.OtherFaction == null)
            {
                return "FactionRelation_Invalid";
            }

            var targetFaction = !string.IsNullOrWhiteSpace(editorFactionRelation.OtherFaction.CustomShortName) ?
                editorFactionRelation.OtherFaction.CustomShortName : "NoName";
            return $"FactionRelation_{targetFaction}";
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
                    return GetWormholeObjectName(wormholeData);
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

        public static void AutoNameWormhole(EditorUnitWormholeData wormholeData)
        {
            wormholeData.gameObject.name = GetWormholeObjectName(wormholeData);
        }

        public static string GetWormholeObjectName(EditorUnitWormholeData wormholeData)
        {
            var targetSector = wormholeData.GetActualTargetSector();
            var targetSectorName = targetSector?.Name ?? "Nowhere";
            if (wormholeData.IsUnstable)
            {
                return $"UnstableWormhole_To_{targetSectorName}";
            }

            return $"Wormhole_To_{targetSectorName}";
        }
    }
}