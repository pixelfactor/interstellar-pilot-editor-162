using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes;
using System;

namespace Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders
{
    public static class CreateFleetOrderFromType
    {
        public static FleetOrder Create(FleetOrderType orderType)
        {
            switch (orderType)
            {
                case FleetOrderType.AttackTarget:
                    return new AttackTargetOrder();
                case FleetOrderType.UniverseTrade:
                    return new UniverseTradeOrder();
                case FleetOrderType.CollectCargo:
                    return new CollectCargoOrder();
                case FleetOrderType.Dock:
                    return new DockOrder();
                case FleetOrderType.ManualTrade:
                    return new ManualTradeOrder();
                case FleetOrderType.Mine:
                    return new MineOrder();
                case FleetOrderType.MoveTo:
                    return new MoveToOrder();
                case FleetOrderType.Patrol:
                    return new PatrolOrder();
                case FleetOrderType.PatrolPath:
                    return new PatrolPathOrder();
                case FleetOrderType.RTB:
                    return new ReturnToBaseOrder();
                case FleetOrderType.Scavenge:
                    return new ScavengeOrder();
                case FleetOrderType.SellCargo:
                    return new SellCargoOrder();
                case FleetOrderType.Trade:
                    return new TradeOrder();
                case FleetOrderType.Wait:
                    return new WaitOrder();
                case FleetOrderType.AttackFleet:
                    return new AttackFleetOrder();
                case FleetOrderType.JoinFleet:
                    return new JoinFleetOrder();
                case FleetOrderType.DisposeCargo:
                    return new DisposeCargoOrder();
                case FleetOrderType.Protect:
                    return new ProtectOrder();
                case FleetOrderType.UniverseBountyHunter:
                    return new UniverseBountyHunterOrder();
                case FleetOrderType.UniverseRoam:
                    return new UniverseRoamOrder();
                case FleetOrderType.ManualRepair:
                    return new ManualRepairFleetOrder();
                case FleetOrderType.UniversePassengerTransport:
                    return new UniversePassengerTransportOrder();
                case FleetOrderType.Explore:
                    return new ExploreOrder();
                case FleetOrderType.RepairAtNearest:
                    return new RepairAtNearestStationOrder();
                case FleetOrderType.MoveToNearestFriendlyStation:
                    return new MoveToNearestFriendlyStationOrder();
                default:
                    throw new NotImplementedException($"Order type {(int)orderType}");
            }
        }
    }
}
