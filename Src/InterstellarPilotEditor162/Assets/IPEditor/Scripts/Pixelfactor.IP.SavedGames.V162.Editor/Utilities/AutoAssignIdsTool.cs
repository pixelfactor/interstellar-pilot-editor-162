﻿using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities
{
    public class AutoAssignIdsTool
    {
        /// <summary>
        /// No id should be used less than this value.
        /// </summary>
        public static int BASE_ID = 100000;

        [MenuItem("IPEditor/Tools/Auto-assign object Ids")]
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
                    EditorUtility.SetDirty(unit);
                }
            }

            var factions = editorSavedGame.GetComponentsInChildren<EditorFaction>();
            foreach (var faction in factions)
            {
                if (faction.Id < 0)
                {
                    faction.Id = NewFactionId(factions);
                    EditorUtility.SetDirty(faction);
                }
            }

            var sectors = editorSavedGame.GetComponentsInChildren<EditorSector>();
            foreach (var sector in sectors)
            {
                if (sector.Id < 0)
                {
                    sector.Id = NewSectorId(sectors);
                    EditorUtility.SetDirty(sector);
                }
            }

            var people = editorSavedGame.GetComponentsInChildren<EditorPerson>();
            foreach (var person in people)
            {
                if (person.Id < 0)
                {
                    person.Id = NewPersonId(people);
                    EditorUtility.SetDirty(person);
                }
            }

            var fleets = editorSavedGame.GetComponentsInChildren<EditorFleet>();
            foreach (var fleet in fleets)
            {
                if (fleet.Id < 0)
                {
                    fleet.Id = NewFleetId(fleets);
                    EditorUtility.SetDirty(fleet);
                }
            }

            var orders = editorSavedGame.GetComponentsInChildren<EditorFleetOrderCommon>();
            foreach (var order in orders)
            {
                if (order.Id < 0)
                {
                    order.Id = NewOrderId(orders);
                    EditorUtility.SetDirty(order);
                }
            }

            Debug.Log("Finished auto-assigned ids");
        }

        private static int NewOrderId(IEnumerable<EditorFleetOrderCommon> orders)
        {
            return Mathf.Max(BASE_ID, orders.Select(e => e.Id).DefaultIfEmpty().Max()) + 1;
        }

        private static int NewFleetId(IEnumerable<EditorFleet> fleets)
        {
            return Mathf.Max(BASE_ID, fleets.Select(e => e.Id).DefaultIfEmpty().Max()) + 1;
        }

        public static int NewUnitId(IEnumerable<EditorUnit> units)
        {
            return Mathf.Max(BASE_ID, units.Select(e => e.Id).DefaultIfEmpty().Max()) + 1;
        }

        public static int NewFactionId(IEnumerable<EditorFaction> factions)
        {
            return Mathf.Max(BASE_ID, factions.Select(e => e.Id).DefaultIfEmpty().Max()) + 1;
        }

        public static int NewSectorId(IEnumerable<EditorSector> sectors)
        {
            return Mathf.Max(BASE_ID, sectors.Select(e => e.Id).DefaultIfEmpty().Max()) + 1;
        }

        public static int NewPersonId(IEnumerable<EditorPerson> people)
        {
            return Mathf.Max(BASE_ID, people.Select(e => e.Id).DefaultIfEmpty().Max()) + 1;
        }
    }
}
