using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.ActiveOrderTypes;
using System;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders
{
    public static class CreateActiveFleetOrderFromType
    {
        public static ActiveFleetOrder Create(FleetOrderType orderType)
        {
            switch (orderType)
            {
                case FleetOrderType.AttackTarget:
                    return new ActiveAttackTargetOrder();
                case FleetOrderType.UniverseTrade:
                    return new ActiveUniverseTradeOrder();
                case FleetOrderType.CollectCargo:
                    return new ActiveCollectCargoOrder();
                case FleetOrderType.Dock:
                    return new ActiveDockOrder();
                case FleetOrderType.ManualTrade:
                    return new ActiveManualTradeOrder();
                case FleetOrderType.Mine:
                    return new ActiveMineOrder();
                case FleetOrderType.MoveTo:
                    return new ActiveMoveToOrder();
                case FleetOrderType.Patrol:
                case FleetOrderType.PatrolPath:
                    return new ActivePatrolOrder();
                case FleetOrderType.RTB:
                    return new ActiveReturnToBaseOrder();
                case FleetOrderType.Scavenge:
                    return new ActiveScavengeOrder();
                case FleetOrderType.SellCargo:
                    return new ActiveSellCargoOrder();
                case FleetOrderType.Trade:
                    return new ActiveTradeOrder();
                case FleetOrderType.Wait:
                    return new ActiveWaitOrder();
                case FleetOrderType.AttackFleet:
                    return new ActiveAttackFleetOrder();
                case FleetOrderType.JoinFleet:
                    return new ActiveJoinFleetOrder();
                case FleetOrderType.DisposeCargo:
                    return new ActiveDisposeCargoOrder();
                case FleetOrderType.Protect:
                    return new ActiveProtectOrder();
                case FleetOrderType.UniverseBountyHunter:
                    return new ActiveUniverseBountyHunterOrder();
                case FleetOrderType.UniverseRoam:
                    return new ActiveUniverseRoamOrder();
                case FleetOrderType.ManualRepair:
                case FleetOrderType.RepairAtNearest:
                    return new ActiveRepairFleetOrder();
                case FleetOrderType.UniversePassengerTransport:
                    return new ActiveUniversePassengerTransportOrder();
                case FleetOrderType.Explore:
                    return new ActiveExploreOrder();
                case FleetOrderType.MoveToNearestFriendlyStation:
                    return new ActiveMoveToNearestFriendlyStationOrder();
                default:
                    throw new NotImplementedException($"Order type {(int)orderType}");
            }
        }
    }
}
