using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities.Factions
{
    public class FactionRelationTool
    {
        [MenuItem("IPEditor/Tools/Factions/Selected factions at permanent war")]
        public static void SetSelectedFactionsAtPermanentWarMenuItem()
        {
            var editorSavedGame = Util.FindSavedGameOrErrorOut();

            SetSelectedFactionsAtPermanentWar();

            Debug.Log("Finished setting selected factions at permanent war");
        }

        private static void SetSelectedFactionsAtPermanentWar()
        {
            var selectedFactions = GetSelectedFactionsOrThrow().ToList();
            if (selectedFactions.Count < 0)
            {
                Logging.LogAndThrow("Expected to have selected more than one faction");    
            }

            foreach (var faction in selectedFactions)
            {
                foreach (var otherFaction in selectedFactions)
                {
                    if (faction != otherFaction)
                    {
                        var relation = FindOrCreateFactionRelation(faction, otherFaction);
                        relation.Opinion = 0.0f;
                        relation.Neutrality = Model.Neutrality.Hostile;
                        relation.RestrictHostilityTimeout = true;
                        EditorUtility.SetDirty(relation);
                    }
                }
            }
        }

        public static IEnumerable<EditorFaction> GetSelectedFactionsOrThrow()
        {
            foreach (var obj in Selection.objects)
            {
                if (obj is GameObject gameObject)
                {
                    var editorFaction = gameObject.GetComponent<EditorFaction>();
                    if (editorFaction != null)
                    {
                        yield return editorFaction;
                    }
                    else
                    {
                        Logging.LogAndThrow("Must select factions");
                    }
                }
                else
                {
                    Logging.LogAndThrow("Selection is invalid");
                }
            }
        }

        public static EditorFactionRelation FindOrCreateFactionRelation(
            EditorFaction sourceEditorFaction,
            EditorFaction targetEditorFaction)
        {
            var relations = sourceEditorFaction.GetComponentsInChildren<EditorFactionRelation>();
            foreach (var relation in relations)
            {
                if (relation.OtherFaction == targetEditorFaction)
                {
                    return relation;
                }
            }

            // Create
            var newRelation = GameObjectHelper.Instantiate<EditorFactionRelation>(sourceEditorFaction);
            newRelation.OtherFaction = targetEditorFaction;
            AutoNameObjects.AutoNameFactionRelation(newRelation);
            return newRelation;
        }
    }
}
