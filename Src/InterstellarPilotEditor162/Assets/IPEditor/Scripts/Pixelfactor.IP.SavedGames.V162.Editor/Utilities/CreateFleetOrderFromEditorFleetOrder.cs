using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.Models;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes;
using Pixelfactor.IP.SavedGames.V162.Model;
using Pixelfactor.IP.SavedGames.V162.Model.FleetOrders;
using Pixelfactor.IP.SavedGames.V162.Model.FleetOrders.Models;
using Pixelfactor.IP.SavedGames.V162.Model.FleetOrders.OrderTypes;
using System.Linq;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities
{
    public static class CreateFleetOrderFromEditorFleetOrder
    {
        /// <summary>
        /// Creates the fleet order type used in the save model, from the editor version
        /// </summary>
        /// <param name="editorFleetOrder"></param>
        /// <param name="editorSavedGame"></param>
        /// <param name="savedGame"></param>
        /// <returns></returns>
        public static FleetOrder CreateFleetOrder(EditorFleetOrderBase editorFleetOrder, EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            // Set common stuff
            var editorCommonOrderStuff = editorFleetOrder.GetComponent<EditorFleetOrderCommon>();

            if (editorCommonOrderStuff.Id < 0)
            {
                Logging.LogAndThrow("Objective must have a valid (>=0) Id", editorCommonOrderStuff);
            }

            switch (editorFleetOrder)
            {
                case EditorAttackFleetOrder editorAttackOrder:
                    {
                        var o = CreateFleetOrderOfType<AttackFleetOrder>(editorFleetOrder);
                        o.Target = savedGame.Fleets.FirstOrDefault(e => e.Id == editorAttackOrder.Target?.Id);
                        o.AttackPriority = editorAttackOrder.AttackPriority;

                        return o;
                    }
                case EditorCollectCargoOrder editorCollectCargoOrder:
                    {
                        var o = CreateFleetOrderOfType<CollectCargoOrder>(editorFleetOrder);
                        o.MaxCargoDistance = editorCollectCargoOrder.MaxCargoDistance;
                        o.CompleteWhenCargoFull = editorCollectCargoOrder.CompleteWhenCargoFull;
                        o.CollectOwnerMode = editorCollectCargoOrder.CollectOwnerMode;
                        o.OresOnly = editorCollectCargoOrder.OresOnly;

                        return o;
                    }

                case EditorScavengeOrder editorScavengeOrder:
                    {
                        var o = CreateFleetOrderOfType<ScavengeOrder>(editorFleetOrder);
                        o.MaxCargoDistance = editorScavengeOrder.MaxCargoDistance;
                        o.CompleteWhenCargoFull = editorScavengeOrder.CompleteWhenCargoFull;
                        o.CollectOwnerMode = editorScavengeOrder.CollectOwnerMode;
                        o.RoamMaxTime = editorScavengeOrder.RoamMaxTime;

                        return o;
                    }
                case EditorMineOrder editorMineOrder:
                    {
                        var o = CreateFleetOrderOfType<MineOrder>(editorFleetOrder);
                        o.MaxCargoDistance = editorMineOrder.MaxCargoDistance;
                        o.CompleteWhenCargoFull = editorMineOrder.CompleteWhenCargoFull;
                        o.CollectOwnerMode = editorMineOrder.CollectOwnerMode;
                        o.ManualMineTarget = savedGame.Units.FirstOrDefault(e => e.Id == editorMineOrder.ManualMineTarget?.Id);

                        return o;
                    }
                case EditorDockOrder editorDockOrder:
                    {
                        var o = CreateFleetOrderOfType<DockOrder>(editorFleetOrder);
                        o.TargetDock = savedGame.Units.FirstOrDefault(e => e.Id == editorDockOrder.TargetDock?.Id);

                        return o;
                    }
                case EditorPatrolOrder editorPatrolOrder:
                    {
                        var o = CreateFleetOrderOfType<PatrolOrder>(editorFleetOrder);

                        o.PathDirection = editorPatrolOrder.PathDirection;
                        o.IsLooping = editorPatrolOrder.IsLooping;

                        var editorPatrolPathNodes = editorPatrolOrder.GetComponentsInChildren<EditorPatrolPathNode>();
                        foreach (var editorPatrolPathNode in editorPatrolPathNodes)
                        {
                            if (editorPatrolPathNode.Target == null)
                            {
                                Logging.LogAndThrow("Editor patrol path node does not have a target", editorPatrolPathNode);
                            }

                            var editorSector = editorPatrolPathNode.Target.GetComponentInParent<EditorSector>();
                            if (editorSector == null)
                            {
                                Logging.LogAndThrow("Editor patrol path node must be a child of a sector", editorPatrolPathNode);
                            }

                            var node = new PatrolPathNode();
                            node.Sector = savedGame.Sectors.FirstOrDefault(e => e.Id == editorSector.Id);
                            node.Position = (node.Sector.Position.ToVector3() + editorPatrolPathNode.Target.transform.localPosition).ToVec3();
                            o.Nodes.Add(node);
                        }

                        o.IsLoop = editorPatrolOrder.IsLoop;

                        return o;
                    }
                case EditorPatrolPathOrder editorPatrolPathOrder:
                    {
                        var o = CreateFleetOrderOfType<PatrolPathOrder>(editorFleetOrder);

                        o.PathDirection = editorPatrolPathOrder.PathDirection;
                        o.IsLooping = editorPatrolPathOrder.IsLooping;
                        o.PatrolPath = savedGame.PatrolPaths.FirstOrDefault(e => e.Id == editorPatrolPathOrder.PatrolPath?.Id);

                        if (o.PatrolPath == null)
                        {
                            Logging.LogAndThrow("Patrol path order is missing a patrol path", editorPatrolPathOrder);
                        }

                        return o;
                    }

                case EditorWaitOrder editorWaitOrder:
                    {
                        // If only all the orders were this simple
                        var o = CreateFleetOrderOfType<WaitOrder>(editorFleetOrder);
                        o.WaitTime = editorWaitOrder.WaitTime;

                        return o;
                    }

                case EditorAttackTargetOrder editorAttackTargetOrder:
                    {
                        var o = CreateFleetOrderOfType<AttackTargetOrder>(editorFleetOrder);
                        o.TargetUnit = savedGame.Units.FirstOrDefault(e => e.Id == editorAttackTargetOrder.TargetUnit?.Id);
                        o.AttackPriority = editorAttackTargetOrder.AttackPriority;

                        return o;
                    }
                case EditorManualTradeOrder editorManualTradeOrder:
                    {
                        var o = CreateFleetOrderOfType<ManualTradeOrder>(editorFleetOrder);
                        o.MinBuyQuantity = editorManualTradeOrder.MinBuyQuantity;
                        o.MinBuyCargoPercentage = editorManualTradeOrder.MinBuyCargoPercentage;
                        
                        var editorCustomTradeRoute = editorManualTradeOrder.GetComponentInChildren<EditorCustomTradeRoute>();
                        if (editorCustomTradeRoute == null)
                        {
                            Logging.LogAndThrow("Manual trade order should have a trade route", editorManualTradeOrder);
                        }

                        o.CustomTradeRoute = new CustomTradeRoute
                        {
                            BuyLocation = savedGame.Units.FirstOrDefault(e => e.Id == editorCustomTradeRoute.BuyLocation?.Id),
                            SellLocation = savedGame.Units.FirstOrDefault(e => e.Id == editorCustomTradeRoute.SellLocation?.Id),
                            BuyPriceMultiplier = editorCustomTradeRoute.BuyPriceMultiplier,
                            CargoClass = editorCustomTradeRoute.CargoClass
                        };

                        return o;
                    }
                case EditorUniverseTradeOrder editorUniverseTradeOrder:
                    {
                        var o = CreateFleetOrderOfType<UniverseTradeOrder>(editorFleetOrder);
                        o.MinBuyQuantity = editorUniverseTradeOrder.MinBuyQuantity;
                        o.MinBuyCargoPercentage = editorUniverseTradeOrder.MinBuyCargoPercentage;

                        var editorSpecificCargoTypes = editorUniverseTradeOrder.GetComponentsInChildren<EditorTradeOrderCargoClass>();

                        o.TradeOnlySpecificCargoClasses = editorSpecificCargoTypes.Any();
                        foreach (var editorCargoClass in editorSpecificCargoTypes)
                        {
                            if (!System.Enum.IsDefined(typeof(CargoClass), editorCargoClass.CargoClass))
                            {
                                Logging.LogAndThrow("Unknown cargo class", editorCargoClass);
                            }

                            o.TradeSpecificCargoClasses.Add(editorCargoClass.CargoClass);
                        }

                        return o;
                    }
                case EditorJoinFleetOrder editorJoinFleetOrder:
                    {
                        var o = CreateFleetOrderOfType<JoinFleetOrder>(editorFleetOrder);
                        o.TargetFleet = savedGame.Fleets.FirstOrDefault(e => e.Id == editorJoinFleetOrder.TargetFleet?.Id);

                        if (o.TargetFleet == null)
                        {
                            Logging.LogAndThrow("Join fleet order should have a target fleet", editorJoinFleetOrder);
                        }

                        return o;
                    }

                case EditorMoveToOrder editorMoveToOrder:
                    {
                        var o = CreateFleetOrderOfType<MoveToOrder>(editorFleetOrder);
                        o.CompleteOnReachTarget = editorMoveToOrder.CompleteOnReachTarget;
                        o.ArrivalThreshold = editorMoveToOrder.ArrivalThreshold;
                        o.MatchTargetOrientation = editorMoveToOrder.MatchTargetOrientation;

                        if (editorMoveToOrder.Target == null)
                        {
                            Logging.LogAndThrow("Move to order needs a target", editorMoveToOrder);
                        }

                        o.Target = GetSectorTarget(savedGame, editorMoveToOrder.Target);

                        return o;
                    }

                case EditorProtectOrder editorProtectOrder:
                    {
                        var o = CreateFleetOrderOfType<ProtectOrder>(editorFleetOrder);
                        o.CompleteOnReachTarget = editorProtectOrder.CompleteOnReachTarget;
                        o.ArrivalThreshold = editorProtectOrder.ArrivalThreshold;
                        o.MatchTargetOrientation = editorProtectOrder.MatchTargetOrientation;

                        if (editorProtectOrder.Target == null)
                        {
                            Logging.LogAndThrow("Protect needs a target", editorProtectOrder);
                        }

                        o.Target = GetSectorTarget(savedGame, editorProtectOrder.Target);

                        return o;
                    }

                case EditorSellCargoOrder editorSellCargoOrder:
                    {
                        var o = CreateFleetOrderOfType<SellCargoOrder>(editorFleetOrder);
                        o.FreeUnitsCompleteThreshold = editorSellCargoOrder.FreeUnitsCompleteThreshold;
                        o.MinBuyPriceMultiplier = editorSellCargoOrder.MinBuyPriceMultiplier;
                        o.CompleteWhenNoBuyerFound = editorSellCargoOrder.CompleteWhenNoBuyerFound;
                        o.CompleteWhenNoCargoToSell = editorSellCargoOrder.CompleteWhenNoCargoToSell;
                        o.ManualBuyerUnit = savedGame.Units.FirstOrDefault(e => e.Id == editorSellCargoOrder.ManualBuyerUnit?.Id);
                        o.CustomSellCargoTime = editorSellCargoOrder.CustomSellCargoTime;
                        o.SellEquipment = editorSellCargoOrder.SellEquipment;

                        var editorSpecificCargoTypes = editorSellCargoOrder.GetComponentsInChildren<EditorTradeOrderCargoClass>();

                        o.SellOnlyListedCargos = editorSpecificCargoTypes.Any();
                        foreach (var editorCargoClass in editorSpecificCargoTypes)
                        {
                            if (!System.Enum.IsDefined(typeof(CargoClass), editorCargoClass.CargoClass))
                            {
                                Logging.LogAndThrow("Unknown cargo class", editorCargoClass);
                            }

                            o.SellCargoClasses.Add(editorCargoClass.CargoClass);
                        }

                        return o;
                    }
                case EditorReturnToBaseOrder:
                    return CreateFleetOrderOfType<ReturnToBaseOrder>(editorFleetOrder);
                case EditorDisposeCargoOrder:
                    return CreateFleetOrderOfType<DisposeCargoOrder>(editorFleetOrder);
                case EditorUniversePassengerTransportOrder:
                    return CreateFleetOrderOfType<UniversePassengerTransportOrder>(editorFleetOrder);
                case EditorUniverseBountyHunterOrder:
                    return CreateFleetOrderOfType<UniverseBountyHunterOrder>(editorFleetOrder);
                case EditorUniverseRoamOrder:
                    return CreateFleetOrderOfType<UniverseRoamOrder>(editorFleetOrder);
                case EditorExploreOrder:
                    return CreateFleetOrderOfType<ExploreOrder>(editorFleetOrder);
                case EditorManualRepairFleetOrder editorManualRepairFleetOrder:
                    {
                        var o = CreateFleetOrderOfType<ManualRepairFleetOrder>(editorFleetOrder);
                        o.InsufficientCreditsMode = editorManualRepairFleetOrder.InsufficientCreditsMode;
                        o.RepairLocationUnit = savedGame.Units.FirstOrDefault(e => e.Id == editorManualRepairFleetOrder.RepairLocationUnit?.Id);
                        return o;
                    }
                case EditorRepairAtNearestStationOrder editorRepairAtNearestStationOrder:
                    {
                        var o = CreateFleetOrderOfType<RepairAtNearestStationOrder>(editorFleetOrder);
                        o.InsufficientCreditsMode = editorRepairAtNearestStationOrder.InsufficientCreditsMode;
                        return o;
                    }
                case EditorMoveToNearestFriendlyStationOrder editorMoveToNearestFriendlyStationOrder:
                    {
                        var o = CreateFleetOrderOfType<MoveToNearestFriendlyStationOrder>(editorFleetOrder);
                        o.CompleteOnReachTarget = editorMoveToNearestFriendlyStationOrder.CompleteOnReachTarget;
                        return o;
                    }
                default:
                    {
                        Debug.LogErrorFormat("Unknown order type {0}", editorFleetOrder.GetType().Name);
                        return null;
                    }
            }
        }

        private static SectorTarget GetSectorTarget(SavedGame savedGame, Transform transformTarget)
        {
            var editorSector = transformTarget.GetComponentInParent<EditorSector>();
            if (editorSector == null)
            {
                Logging.LogAndThrow("Sector target should be in a sector", transformTarget);
            }

            var target = new SectorTarget();
            target.Sector = savedGame.Sectors.FirstOrDefault(e => e.Id == editorSector.Id);
            if (target.Sector == null)
            {
                Logging.LogAndThrow("Expecting a sector here", transformTarget);
            }

            target.Position = (target.Sector.Position.ToVector3() + transformTarget.localPosition).ToVec3();
            var targetUnit = transformTarget.GetComponent<EditorUnit>();
            if (targetUnit != null)
            {
                target.TargetUnit = savedGame.Units.FirstOrDefault(e => e.Id == targetUnit.Id);
            }

            var targetFleet = transformTarget.GetComponent<EditorFleet>();
            if (targetFleet != null)
            {
                target.TargetFleet = savedGame.Fleets.FirstOrDefault(e => e.Id == targetFleet.Id);
            }

            return target;
        }

        public static T CreateFleetOrderOfType<T>(EditorFleetOrderBase editorFleetOrderBase) where T : FleetOrder, new()
        {
            var editorFleetOrderCommon = editorFleetOrderBase.GetComponent<EditorFleetOrderCommon>();
            return new T
            {
                AllowCombatInterception = editorFleetOrderCommon.AllowCombatInterception,
                AllowTimeout = editorFleetOrderCommon.AllowTimeout,
                CloakPreference = editorFleetOrderCommon.CloakPreference,
                CompletionMode = editorFleetOrderCommon.CompletionMode,
                Id = editorFleetOrderCommon.Id,
                MaxJumpDistance = editorFleetOrderCommon.MaxJumpDistance,
                TimeoutTime = editorFleetOrderCommon.TimeoutTime,
            };
        }
    }
}
