using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using System.Linq;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor
{
    public static class Validator
    {
        public static void Validate(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            ValidateDuplicateIds(editorSavedGame, throwOnError);
        }

        private static void ValidateDuplicateIds(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            ValidateUnitIds(editorSavedGame, throwOnError);
            ValidateFactionIds(editorSavedGame, throwOnError);
            ValidatePersonIds(editorSavedGame, throwOnError);
            ValidateSectorIds(editorSavedGame, throwOnError);

            ValidateDuplicateSectors(editorSavedGame, throwOnError);
            ValidateDuplicateFactions(editorSavedGame, throwOnError);
            ValidateDuplicatePeople(editorSavedGame, throwOnError);
            ValidateDuplicateUnits(editorSavedGame, throwOnError);
        }

        private static void ValidateUnitIds(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            foreach (var unit in editorSavedGame.GetComponentsInChildren<EditorUnit>())
            {
                if (unit.Id < 0)
                {
                    OnError("All units require a valid (>0) id", unit, throwOnError);
                }
            }
        }

        private static void ValidateFactionIds(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            foreach (var faction in editorSavedGame.GetComponentsInChildren<EditorFaction>())
            {
                if (faction.Id < 0)
                {
                    OnError("All factions require a valid (>0) id", faction, throwOnError);
                }
            }
        }

        private static void ValidateSectorIds(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            foreach (var sector in editorSavedGame.GetComponentsInChildren<EditorSector>())
            {
                if (sector.Id < 0)
                {
                    OnError("All sectors require a valid (>0) id", sector, throwOnError);
                }
            }
        }

        private static void ValidatePersonIds(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            foreach (var person in editorSavedGame.GetComponentsInChildren<EditorPerson>())
            {
                if (person.Id < 0)
                {
                    OnError("All people require a valid (>0) id", person, throwOnError);
                }
            }
        }

        private static void ValidateDuplicateSectors(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            var sectors = editorSavedGame.GetComponentsInChildren<EditorSector>();
            var duplicates = sectors.GroupBy(e => e.Id).Where(e => e.Count() > 1);
            if (duplicates.Any())
            {
                OnError("Duplicate sector ids found", duplicates.First().First(), throwOnError);
            }
        }

        private static void ValidateDuplicatePeople(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            var people = editorSavedGame.GetComponentsInChildren<EditorPerson>();
            var duplicates = people.GroupBy(e => e.Id).Where(e => e.Count() > 1);
            if (duplicates.Any())
            {
                OnError("Duplicate person ids found", duplicates.First().First(), throwOnError);
            }
        }

        private static void ValidateDuplicateUnits(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            var units = editorSavedGame.GetComponentsInChildren<EditorUnit>();
            var duplicates = units.Where(e => e.Id > -1).GroupBy(e => e.Id).Where(e => e.Count() > 1);
            if (duplicates.Any())
            {
                OnError("Duplicate unit ids found", duplicates.First().First(), throwOnError);
            }
        }

        private static void ValidateDuplicateFactions(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            var factions = editorSavedGame.GetComponentsInChildren<EditorFaction>();
            var duplicates = factions.GroupBy(e => e.Id).Where(e => e.Count() > 1);
            if (duplicates.Any())
            {
                OnError("Duplicate faction ids found", duplicates.First().First(), throwOnError);
            }
        }

        private static void OnError(string message, Object context, bool throwOnError)
        {
            Debug.LogError(message, context);
            if (throwOnError)
            {
                throw new System.Exception("Validation throwing due to error");
            }
        }
    }
}
