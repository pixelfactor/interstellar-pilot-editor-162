using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using Pixelfactor.IP.SavedGames.V162.Model;
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
            SetSelectedFactionsAtPermanentWar();

            Debug.Log("Finished setting selected factions at permanent war");
        }

        [MenuItem("IPEditor/Tools/Factions/Selected factions at permanent alliance")]
        public static void SetSelectedFactionsAtPermanentAllianceMenuItem()
        {
            SetSelectedFactionsAtPermanentAlliance();

            Debug.Log("Finished setting selected factions at permanent alliance");
        }

        private static void SetSelectedFactionsAtPermanentWar()
        {
            SetSelectedFactionsAtPermanentSetting(Neutrality.Hostile, 0.0f);
        }

        private static void SetSelectedFactionsAtPermanentAlliance()
        {
            SetSelectedFactionsAtPermanentSetting(Neutrality.Allied, 1.0f);
        }

        private static void SetSelectedFactionsAtPermanentSetting(Neutrality neutrality, float opinion)
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
                        relation.Opinion = opinion;
                        relation.Neutrality = neutrality;
                        relation.RestrictHostilityTimeout = true;

                        if (neutrality == Neutrality.Allied)
                        {
                            relation.PermanentPeace = true;
                        }

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
