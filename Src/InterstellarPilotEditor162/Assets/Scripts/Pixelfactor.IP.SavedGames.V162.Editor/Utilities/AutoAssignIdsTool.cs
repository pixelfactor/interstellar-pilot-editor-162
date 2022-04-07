using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public class AutoAssignIdsTool
    {
        /// <summary>
        /// No id should be used less than this value.
        /// </summary>
        public static int BASE_ID = 100000;

        [MenuItem("IPEditor/AutoAssignIds")]
        public static void AutoAssignIds()
        {
            // Find the saved game
            var editorSavedGame = GameObject.FindObjectOfType<EditorSavedGame>();
            if (editorSavedGame == null)
            {
                Debug.LogError("No editor saved game found"); return;
            }

            var units = editorSavedGame.GetComponentsInChildren<EditorUnit>();
            foreach (var unit in units)
            {
                if (unit.Id < 0)
                {
                    unit.Id = NewUnitId(units);
                    EditorUtility.SetDirty(unit.gameObject);
                }
            }

            var factions = editorSavedGame.GetComponentsInChildren<EditorFaction>();
            foreach (var faction in factions)
            {
                if (faction.Id < 0)
                {
                    faction.Id = NewFactionId(factions);
                    EditorUtility.SetDirty(faction.gameObject);
                }
            }

            var sectors = editorSavedGame.GetComponentsInChildren<EditorSector>();
            foreach (var sector in sectors)
            {
                if (sector.Id < 0)
                {
                    sector.Id = NewSectorId(sectors);
                    EditorUtility.SetDirty(sector.gameObject);
                }
            }

            var people = editorSavedGame.GetComponentsInChildren<EditorPerson>();
            foreach (var person in people)
            {
                if (person.Id < 0)
                {
                    person.Id = NewPersonId(people);
                    EditorUtility.SetDirty(person.gameObject);
                }
            }

            Debug.Log("Finished auto-assigned ids");
        }

        private static int NewUnitId(IEnumerable<EditorUnit> units)
        {
            return Mathf.Max(BASE_ID, units.Select(e => e.Id).DefaultIfEmpty().Max()) + 1;
        }

        private static int NewFactionId(IEnumerable<EditorFaction> factions)
        {
            return Mathf.Max(BASE_ID, factions.Select(e => e.Id).DefaultIfEmpty().Max()) + 1;
        }

        private static int NewSectorId(IEnumerable<EditorSector> sectors)
        {
            return Mathf.Max(BASE_ID, sectors.Select(e => e.Id).DefaultIfEmpty().Max()) + 1;
        }

        private static int NewPersonId(IEnumerable<EditorPerson> people)
        {
            return Mathf.Max(BASE_ID, people.Select(e => e.Id).DefaultIfEmpty().Max()) + 1;
        }
    }
}
