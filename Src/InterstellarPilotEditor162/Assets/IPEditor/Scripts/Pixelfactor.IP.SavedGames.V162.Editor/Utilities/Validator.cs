using Pixelfactor.IP.SavedGames.V162.Editor.Assets.IPEditor.Scripts.PixelfactorIPSavedGamesV162Editor;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using System.Linq;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities
{
    public static class Validator
    {
        public static void Validate(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            ValidateDuplicateIds(editorSavedGame, throwOnError);
            ValidateDuplicatePilotNames(editorSavedGame);
            ValidateDuplicateShipNames(editorSavedGame);
        }

        public static void ValidateDuplicateShipNames(EditorSavedGame editorSavedGame)
        {
            var shipGroups = editorSavedGame.GetComponentsInChildren<EditorComponentUnitData>()
                .Where(e =>
                {
                    var unit = e.GetComponentInParent<EditorUnit>();
                    return unit.Class.IsShipOrStation() && !unit.Class.IsTurret() && !string.IsNullOrWhiteSpace(unit.Name);
                }).GroupBy(e => e.GetComponentInParent<EditorUnit>().Name).Where(e => e.Count() > 1);
            foreach (var shipGroup in shipGroups)
            {
                foreach (var ship in shipGroup)
                {
                    Debug.LogWarning($"Duplicate ship name detected: {ship.GetComponentInParent<EditorUnit>().Name}", ship);
                }
            }
        }

        public static void ValidateDuplicatePilotNames(EditorSavedGame editorSavedGame)
        {
            var people = editorSavedGame.GetComponentsInChildren<EditorPerson>()
                .Where(e => !string.IsNullOrWhiteSpace(e.CustomName)).GroupBy(e => e.CustomName).Where(e => e.Count() > 1);
            foreach (var personGroup in people)
            {
                foreach (var person in personGroup)
                {
                    Debug.LogWarning("Duplicate person name detected", person);
                }
            }
        }
        private static void ValidateDuplicateIds(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            ValidateMessageIds(editorSavedGame, throwOnError);
            ValidateUnitIds(editorSavedGame, throwOnError);
            ValidateFactionIds(editorSavedGame, throwOnError);
            ValidatePersonIds(editorSavedGame, throwOnError);
            ValidateSectorIds(editorSavedGame, throwOnError);
            ValidateFleetIds(editorSavedGame, throwOnError);

            ValidateDuplicateSectors(editorSavedGame, throwOnError);
            ValidateDuplicateFactions(editorSavedGame, throwOnError);
            ValidateDuplicatePeople(editorSavedGame, throwOnError);
            ValidateDuplicateUnits(editorSavedGame, throwOnError);
            ValidateDuplicateMessageIds(editorSavedGame, throwOnError);
        }

        private static void ValidateMessageIds(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            foreach (var message in editorSavedGame.GetComponentsInChildren<EditorPlayerMessage>())
            {
                if (message.Id < 0)
                {
                    OnError("All messages require a valid (>0) id", message, throwOnError);
                }
            }
        }

        private static void ValidateFleetIds(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            foreach (var fleet in editorSavedGame.GetComponentsInChildren<EditorFleet>())
            {
                if (fleet.Id < 0)
                {
                    OnError("All fleets require a valid (>0) id", fleet, throwOnError);
                }
            }
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

        private static void ValidateDuplicateMessageIds(EditorSavedGame editorSavedGame, bool throwOnError)
        {
            var units = editorSavedGame.GetComponentsInChildren<EditorPlayerMessage>();
            var duplicates = units.Where(e => e.Id > -1).GroupBy(e => e.Id).Where(e => e.Count() > 1);
            if (duplicates.Any())
            {
                OnError("Duplicate message ids found", duplicates.First().First(), throwOnError);
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
