using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using System;
using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities
{

    public class FixUpUnitOwnership : MonoBehaviour
    {
        [MenuItem("IPEditor/Tools/Units/Set unit factions to pilot factions")]
        public static void SetUnitFactionsToPilotFactionsMenuItem()
        {
            var editorSavedGame = Util.FindSavedGameOrErrorOut();

            SetUnitFactionsToPilotFactions(editorSavedGame);

            Debug.Log("Finished set unit factions to pilot factions");
        }

        [MenuItem("IPEditor/Tools/Fleets/Set fleet children to same faction")]
        public static void SetFleetChildrenToSameFactionMenuItem()
        {
            var editorSavedGame = Util.FindSavedGameOrErrorOut();

            SetFleetChildrenToSameFaction(editorSavedGame);

            Debug.Log("Finished set fleet children to same faction");
        }

        public static void SetFleetChildrenToSameFaction(EditorSavedGame editorSavedGame)
        {
            foreach (var editorFleet in editorSavedGame.GetComponentsInChildren<EditorFleet>())
            {
                if (editorFleet.Faction != null)
                {
                    foreach (var editorUnit in editorFleet.GetComponentsInChildren<EditorUnit>())
                    {
                        if (editorUnit.Faction != editorFleet.Faction)
                        {
                            editorUnit.Faction = editorFleet.Faction;
                            EditorUtility.SetDirty(editorUnit);
                        }
                    }

                    foreach (var editorPerson in editorFleet.GetComponentsInChildren<EditorPerson>())
                    {
                        if (editorPerson.Faction != editorFleet.Faction)
                        {
                            editorPerson.Faction = editorFleet.Faction;
                            EditorUtility.SetDirty(editorPerson);
                        }
                    }
                }
            }
        }

        public static void SetUnitFactionsToPilotFactions(EditorSavedGame editorSavedGame)
        {
            foreach (var editorSector in editorSavedGame.GetComponentsInChildren<EditorSector>())
            {
                foreach (var editorUnit in editorSector.GetComponentsInChildren<EditorUnit>())
                {
                    var editorPerson = editorUnit.GetComponentInChildren<EditorPerson>();
                    if (editorPerson != null && editorPerson.Faction != null && editorPerson.Faction != editorUnit.Faction)
                    {
                        editorUnit.Faction = editorPerson.Faction;
                        EditorUtility.SetDirty(editorUnit);
                    }
                }
            }
        }
    }
}
