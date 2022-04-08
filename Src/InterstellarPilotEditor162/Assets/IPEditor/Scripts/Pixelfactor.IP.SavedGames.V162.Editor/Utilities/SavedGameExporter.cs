using Pixelfactor.IP.SavedGames.V162.Editor.Assets.IPEditor.Scripts.PixelfactorIPSavedGamesV162Editor;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects;
using Pixelfactor.IP.SavedGames.V162.Editor.EditorObjects.FleetOrders.OrderTypes;
using Pixelfactor.IP.SavedGames.V162.Model;
using System.Linq;
using UnityEngine;

namespace Pixelfactor.IP.SavedGames.V162.Editor.Utilities
{
    public static class SavedGameExporter
    {
        public const float SECTOR_SIZE = 16000f;

        public static SavedGame Export(EditorSavedGame editorSavedGame)
        {
            var savedGame = new SavedGame();

            ExportSectors(editorSavedGame, savedGame);
            PositionSectorsForEngine(editorSavedGame, savedGame);
            SetSectorMapPositions(editorSavedGame, savedGame);
            ExportFactions(editorSavedGame, savedGame);
            ExportUnits(editorSavedGame, savedGame);
            ExportWormholes(editorSavedGame, savedGame);
            ExportFleets(editorSavedGame, savedGame);
            ExportPeople(editorSavedGame, savedGame);
            ExportPlayer(editorSavedGame, savedGame);
            ExportScenarioData(editorSavedGame, savedGame);
            ExportFleetSpawners(editorSavedGame, savedGame);
            AutoCreateFleetsWhereNeeded(editorSavedGame, savedGame);
            ExportHeader(editorSavedGame, savedGame);
            SeedFactionIntel(editorSavedGame, savedGame);

            return savedGame;

        }

        private static void ExportFleets(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            foreach (var editorSector in editorSavedGame.GetComponentsInChildren<EditorSector>())
            {
                var sector = savedGame.Sectors.Single(e => e.Id == editorSector.Id);
                if (sector == null)
                {
                    LogAndThrow("Expected to find sector", editorSector);
                }

                foreach (var editorFleet in editorSector.GetComponentsInChildren<EditorFleet>())
                {
                    if (editorFleet.Faction == null)
                    {
                        LogAndThrow("Fleets must have a faction", editorFleet);
                    }

                    var fleet = new Fleet
                    {
                        Id = editorFleet.Id,
                        ExcludeFromFactionAI = editorFleet.ExcludeFromFactionAI,
                        Faction = savedGame.Factions.FirstOrDefault(e => e.Id == editorFleet.Faction?.Id),
                        IsActive = true,
                        HomeBaseUnit = savedGame.Units.FirstOrDefault(e => e.Id == editorFleet.HomeBaseUnit?.Id),
                        Position = SectorLocalPositionToWorld(sector, editorFleet.transform.localPosition).ToVec3(),
                        Sector = sector,
                        Orders = new Model.FleetOrders.FleetOrderCollection(), // This collection will be auto-init by a newer version of the "model". For now we must do it.
                    };

                    var editorFleetSettings = editorFleet.GetComponentInChildren<EditorFleetSettings>();
                    if (editorFleetSettings != null)
                    {
                        fleet.FleetSettings = new FleetSettings
                        {
                            AllowAttack = editorFleetSettings.AllowAttack,
                            AllowCombatInterception = editorFleetSettings.AllowCombatInterception,
                            AttackTargetScoreThreshold = editorFleetSettings.AttackTargetScoreThreshold,
                            ControllersCanCollectCargo = editorFleetSettings.PilotsCanCollectCargo,
                            ControllersCollectOnlyEquipment = editorFleetSettings.PilotsCollectOnlyEquipment,
                            DestroyWhenNoPilots = true,
                            RestrictMaxJumps = editorFleetSettings.MaxJumpDistance > 0,
                            MaxJumpDistance = editorFleetSettings.MaxJumpDistance >= 0 ? editorFleetSettings.MaxJumpDistance : 99,
                            PreferCloak = editorFleetSettings.PreferCloak,
                            PreferToDock = editorFleetSettings.PreferToDock,
                            TargetInterceptionLowerDistance = editorFleetSettings.TargetInterceptionLowerDistance,
                            TargetInterceptionUpperDistance = editorFleetSettings.TargetInterceptionUpperDistance,
                        };
                    }

                    // Orders
                    var editorFleetOrders = editorFleet.GetComponentsInChildren<EditorFleetOrderBase>();
                    foreach (var editorFleetOrder in editorFleetOrders)
                    {
                        var fleetOrder = CreateFleetOrderFromEditorFleetOrder.CreateFleetOrder(editorFleetOrder, editorSavedGame, savedGame);
                        fleet.Orders.Orders.Add(fleetOrder);
                        fleet.Orders.QueuedOrders.Add(fleetOrder);
                    }

                    savedGame.Fleets.Add(fleet);
                }
            }
        }

        private static void ExportFleetSpawners(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            foreach (var editorSector in editorSavedGame.GetComponentsInChildren<EditorSector>())
            {
                var sector = savedGame.Sectors.Single(e => e.Id == editorSector.Id);

                foreach (var editorFleetSpawner in editorSector.GetComponentsInChildren<EditorFleetSpawner>())
                {
                    var editorShipTypes = editorFleetSpawner.GetComponentsInChildren<EditorFleetSpawnerItem>();
                    if (editorShipTypes.Length == 0)
                    {
                        Debug.LogWarning("Fleet spawner has no items", editorFleetSpawner);
                        return;
                    }

                    var fleetSpawner = new FleetSpawner
                    {
                        AllowRespawnInActiveScene = editorFleetSpawner.AllowRespawnInActiveScene,
                        FleetHomeBase = savedGame.Units.FirstOrDefault(e => e.Id == editorFleetSpawner.FleetHomeBase?.Id),
                        Position = (sector.Position.ToVector3() + editorFleetSpawner.transform.localPosition).ToVec3(),
                        FleetResourceName = editorFleetSpawner.FleetType.ToString(),
                        PilotResourceNames = new string[] { editorFleetSpawner.PilotType.ToString() }.ToList(),
                        MinGroupUnitCount = editorFleetSpawner.MinShipCount,
                        MaxGroupUnitCount = editorFleetSpawner.MaxShipCount,
                        MinTimeBeforeSpawn = editorFleetSpawner.MinTimeBeforeSpawn,
                        MaxTimeBeforeSpawn = editorFleetSpawner.MaxTimeBeforeSpawn,
                        OwnerFaction = savedGame.Factions.FirstOrDefault(e => e.Id == editorFleetSpawner.OwnerFaction?.Id),
                        UnitClasses = editorShipTypes.Select(e => e.UnitClass).ToList(),
                        NextSpawnTime = editorFleetSpawner.NextSpawnTime,
                        SpawnTimeRandomness = editorFleetSpawner.SpawnTimeRandomness,
                        RespawnWhenNoObjectives = editorFleetSpawner.RespawnWhenNoObjectives,
                        RespawnWhenNoPilots = editorFleetSpawner.RespawnWhenNoPilots,
                        Sector = sector,
                    };

                    var editorParentUnit = editorFleetSpawner.GetComponentInParent<EditorUnit>();
                    if (editorParentUnit != null)
                    {
                        fleetSpawner.SpawnDock = savedGame.Units.FirstOrDefault(e => e.Id == editorParentUnit.Id);
                    }

                    fleetSpawner.FleetHomeSector = fleetSpawner?.FleetHomeBase?.Sector;
                    savedGame.FleetSpawners.Add(fleetSpawner);
                }
            }
        }

        private static Vector3 SectorLocalPositionToWorld(Sector sector, Vector3 localPosition)
        {
            return sector.Position.ToVector3() + localPosition;
        }

        /// <summary>
        /// Npc factions rely on the faction intel database. Without it they will have a hard time navigating<br />
        /// This could be built up in the editor. But because I am lazy, just have all factions discover eachother.
        /// </summary>
        /// <param name="editorSavedGame"></param>
        /// <param name="savedGame"></param>
        private static void SeedFactionIntel(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            // Npc factions rely on the faction intel database. Without it they will have a hard time navigating
            // This could be built up in the editor
            foreach (var faction in savedGame.Factions)
            {
                if (faction.Intel == null)
                {
                    faction.Intel = new Model.FactionIntel();
                }

                foreach (var unit in savedGame.Units)
                {
                    if (unit.IsStation() && unit.Faction?.FactionType != FactionType.Bandit)
                    {
                        faction.Intel.Units.Add(unit);
                    }
                }
            }
        }

        private static void ExportWormholes(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            foreach (var editorSector in editorSavedGame.GetComponentsInChildren<EditorSector>())
            {
                foreach (var editorWormholeData in editorSector.GetComponentsInChildren<EditorUnitWormholeData>())
                {
                    var editorUnit = editorWormholeData.GetComponentInParent<EditorUnit>();
                    if (editorUnit == null)
                    {
                        LogAndThrow("Wormhole must be child of a unit", editorWormholeData);
                    }

                    if (editorWormholeData.TargetWormholeUnit == null)
                    {
                        LogAndThrow("Wormhole must have a target", editorWormholeData);
                    }

                    var unit = savedGame.Units.FirstOrDefault(e => e.Id == editorUnit.Id);
                    if (unit == null)
                    {
                        LogAndThrow("Unit already exist in the saved game", editorWormholeData);
                    }

                    var targetUnit = savedGame.Units.FirstOrDefault(e =>
                        e.Id == editorWormholeData.TargetWormholeUnit.Id);

                    unit.WormholeData = new UnitWormholeData
                    {
                        TargetWormholeUnit = targetUnit
                    };
                }
            }
        }

        /// <summary>
        /// Used to set up the universe map
        /// </summary>
        /// <param name="editorSavedGame"></param>
        /// <param name="savedGame"></param>
        private static void SetSectorMapPositions(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            // TODO: 
            foreach (var editorSector in editorSavedGame.GetComponentsInChildren<EditorSector>())
            {
                var multiplier = 0.02f;
                var sector = savedGame.Sectors.Single(e => e.Id == editorSector.Id);
                sector.MapPosition = new Vec3
                {
                    X = editorSector.transform.position.x * multiplier,
                    Z = editorSector.transform.position.z * multiplier
                };
            }
        }

        private static void PositionSectorsForEngine(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            // Fix up to ensure that all sectors are positioned in their own grid cell without any overlapping
            var gridCellDimensions = 8;
            var maxSectors = gridCellDimensions * gridCellDimensions;
            var gridSize = gridCellDimensions * SECTOR_SIZE;
            var basePosition = new Vector3(-gridSize / 2.0f, 0.0f, -gridSize / 2.0f);

            for (int i = 0; i < savedGame.Sectors.Count; i++)
            {
                var sector = savedGame.Sectors[i];
                var yCell = i / gridCellDimensions;
                var xCell = i % gridCellDimensions;

                sector.Position = new Vector3(
                    basePosition.x + (xCell * SECTOR_SIZE),
                    0.0f,
                    basePosition.z + (yCell * SECTOR_SIZE)).ToVec3();
            }
        }

        private static void ExportScenarioData(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            savedGame.ScenarioData = new Model.ScenarioData
            {

                HasRandomEvents = editorSavedGame.RandomEventsEnabled,
                NextRandomEventTime = 240d
            };
        }

        private static void ExportHeader(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            savedGame.Header = new Model.Header
            {
                Credits = savedGame.Player?.Faction?.Credits ?? 0,
                GlobalSaveNumber = 1,
                SaveNumber = 1,
                HavePlayer = savedGame.Player != null,
                IsAutoSave = false,
                PlayerName = savedGame.Player?.Person?.CustomName,
                PlayerSectorName = savedGame.Player?.Person?.CurrentUnit?.Sector?.Name ?? null,
                ScenarioInfoId = 9952, // Don't change this. It's the ID of the 'sandbox' scenario. Using other scenarios is completely unsupported,
                TimeStamp = System.DateTime.Now,
                Version = new System.Version(1, 6, 2)
            };
        }

        private static void ExportPlayer(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            var editorPlayers = editorSavedGame.GetComponentsInChildren<EditorPlayer>();
            if (editorPlayers.Count() > 1)
            {
                throw new System.Exception("More than one player object found");
            }

            var editorPlayer = editorPlayers.SingleOrDefault();

            if (editorPlayer == null)
            {
                throw new System.Exception("A player object is required");
            }

            var player = new Player
            {
                Person = savedGame.People.FirstOrDefault(e => e.Id == editorPlayer.Person?.Id),
            };

            if (player.Person == null)
            {
                LogAndThrow("A player object is missing a person reference", editorPlayer);
            }

            if (player.Faction == null)
            {
                LogAndThrow("A player object's person object must have a faction", editorPlayer.Person);
            }

            if (string.IsNullOrWhiteSpace(editorPlayer.Person.CustomName))
            {
                Debug.LogWarning("Player person should have a name", editorPlayer.Person);
            }

            var editorMessages = editorPlayer.GetComponentsInChildren<EditorPlayerMessage>();
            foreach (var editorMessage in editorMessages)
            {
                var message = new PlayerMessage
                {
                    AllowDelete = editorMessage.AllowDelete,
                    EngineTimeStamp = editorMessage.EngineTimeStamp,
                    FromText = editorMessage.FromText,
                    Id = editorMessage.Id,
                    MessageTemplateId = editorMessage.MessageTemplateId,
                    MessageText = editorMessage.MessageText,
                    Opened = editorMessage.Opened,
                    SenderUnit = savedGame.Units.FirstOrDefault(e => e.Id == editorMessage.SenderUnit?.Id),
                    SubjectUnit = savedGame.Units.FirstOrDefault(e => e.Id == editorMessage.SenderUnit?.Id),
                    SubjectText = editorMessage.SubjectText,
                    ToText = editorMessage.ToText,
                };

                if (editorMessage.ShowTime >= 0.0f)
                {
                    player.DelayedMessages.Add(new Model.PlayerDelayedMessage
                    {
                        Message = message,
                        ShowTime = editorMessage.ShowTime
                    });
                }
                else
                {
                    player.Messages.Add(message);
                }
            }

            savedGame.Player = player;
        }

        private static void LogAndThrow(string error, UnityEngine.Object context)
        {
            Debug.LogError(error, context);
            throw new System.Exception("A critical error occured while exporting and the operation cannot continue.");
        }
        private static void ExportPeople(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            foreach (var editorPerson in editorSavedGame.GetComponentsInChildren<EditorPerson>())
            {
                var person = new Person
                {
                    IsMale = editorPerson.IsMale,
                    Id = editorPerson.Id,
                    CustomName = editorPerson.CustomName,
                    Faction = savedGame.Factions.FirstOrDefault(e => e.Id == editorPerson.Faction?.Id),
                    Kills = editorPerson.Kills,
                };

                if (string.IsNullOrEmpty(person.CustomName))
                {
                    person.GeneratedFirstNameId = -1;
                    person.GeneratedLastNameId = -1;
                }

                // Link any pilot
                var editorUnit = editorPerson.GetComponentInParent<EditorUnit>();
                if (editorUnit != null)
                {
                    person.CurrentUnit = savedGame.Units.FirstOrDefault(e => e.Id == editorUnit.Id);

                    var editorComponentUnit = editorUnit.GetComponentInChildren<EditorComponentUnitData>();
                    if (editorComponentUnit != null)
                    {
                        person.CurrentUnit.ComponentUnitData.People.Add(person);
                    }

                    if (editorComponentUnit != null && editorComponentUnit.Pilot == editorPerson)
                    {
                        if (person.Faction == null)
                        {
                            LogAndThrow("Pilot must always have a faction", editorPerson);
                        }

                        person.IsPilot = true;

                        if (person.CurrentUnit.Faction != person.Faction)
                        {
                            Debug.LogWarning("Person set to be a pilot of a unit that has a different faction. Unit faction will be changed to match pilot", editorPerson);
                            person.CurrentUnit.Faction = person.Faction;
                        }
                    }

                }

                // Init any Npc pilot
                var editorNpcPilot = editorPerson.GetComponent<EditorNpcPilot>();
                if (editorNpcPilot != null)
                {
                    person.NpcPilot = new NpcPilot
                    {
                        AllowUseCloak = editorNpcPilot.AllowUseCloak,
                        DestroyWhenNotPilotting = true,
                        DestroyWhenNoUnit = true,
                        Person = person
                    };

                    // Find fleet
                    var editorFleet = editorNpcPilot.GetComponentInParent<EditorFleet>();
                    if (editorFleet != null)
                    {
                        var fleet = savedGame.Fleets.FirstOrDefault(e => e.Id == editorFleet.Id);
                        if (fleet == null)
                        {
                            LogAndThrow("Expecting to find a fleet", editorPerson);
                        }

                        if (fleet.Faction != person.Faction)
                        {
                            LogAndThrow("Fleet has a different faction to pilot. This is not supported", editorPerson);
                        }

                        person.NpcPilot.Fleet = fleet;
                        person.NpcPilot.Fleet.Npcs.Add(person.NpcPilot);
                    }
                }

                savedGame.People.Add(person);
            }
        }

        /// <summary>
        /// There's a bug in the engine where, if the npc pilot doesn't have a fleet, the faction won't create one for it. So the npc will be left idle
        /// So create one automatically here
        /// </summary>
        /// <param name="editorSavedGame"></param>
        /// <param name="savedGame"></param>
        private static void AutoCreateFleetsWhereNeeded(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            foreach (var person in savedGame.People)
            {
                if (person.IsPilot && person.NpcPilot != null && person.NpcPilot.Fleet == null)
                {
                    person.NpcPilot.Fleet = new Fleet
                    {
                        Faction = person.Faction,
                        Id = savedGame.Fleets.Select(e => e.Id).DefaultIfEmpty().Max() + 1,
                        Position = person.CurrentUnit.Position,
                        Sector = person.CurrentUnit.Sector,
                        Orders = new Model.FleetOrders.FleetOrderCollection(), // This collection will be auto-init by a newer version of the "model". For now we must do it.
                        IsActive = true, // Again, should be autoset by model
                    };

                    savedGame.Fleets.Add(person.NpcPilot.Fleet);
                    person.NpcPilot.Fleet.Npcs.Add(person.NpcPilot);
                }
            }
        }

        private static void ExportUnits(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            foreach (var editorSector in editorSavedGame.GetComponentsInChildren<EditorSector>())
            {
                foreach (var editorUnit in editorSector.GetComponentsInChildren<EditorUnit>())
                {
                    var unit = new Unit
                    {
                        Id = editorUnit.Id,
                        Class = editorUnit.Class,
                        Faction = savedGame.Factions.FirstOrDefault(e => e.Id == editorUnit.Faction?.Id),
                        RpProvision = editorUnit.RpProvision,
                        Name = editorUnit.Name,
                        Sector = savedGame.Sectors.FirstOrDefault(e => e.Id == editorSector.Id),
                    };

                    unit.Rotation = editorUnit.transform.localRotation.ToVec4();
                    if (unit.Sector != null)
                    {
                        // Get position local to sector (allowing nested units in the heirachy)
                        var localSectorPosition = editorUnit.transform.position - editorSector.transform.position;

                        // Constrain Y
                        if (unit.IsShipOrStation())
                        {
                            localSectorPosition.y = 0.0f;
                        }

                        // HACK: Planets are draw a bit weirdly in the engine with a different camera. Scale down the location position
                        if (unit.Class.ToString().StartsWith("Planet"))
                        {
                            localSectorPosition /= 1000.0f;
                        }

                        // The position in the model is a global position
                        unit.Position = (unit.Sector.Position.ToVector3() +
                            localSectorPosition).ToVec3();
                    };

                    ExportComponentData(editorUnit, unit);

                    ExportCargoContainerData(editorUnit, unit);

                    savedGame.Units.Add(unit);
                }
            }
        }

        /// <summary>
        /// Applies if the unit is a cargo container
        /// </summary>
        /// <param name="editorUnit"></param>
        /// <param name="unit"></param>
        /// <exception cref="NotImplementedException"></exception>
        private static void ExportCargoContainerData(EditorUnit editorUnit, Unit unit)
        {
            var editorCargoContainerData = editorUnit.GetComponentInChildren<EditorUnitCargoData>();
            if (editorCargoContainerData != null)
            {
                if (unit.Class != UnitClass.Cargo_Container &&
                    unit.Class != UnitClass.Cargo_Ice &&
                    unit.Class != UnitClass.Cargo_Rock)
                {
                    LogAndThrow("This type of unit does not support being a cargo container", editorCargoContainerData);
                }

                if (!System.Enum.IsDefined(typeof(CargoClass), editorCargoContainerData.CargoClass))
                {
                    LogAndThrow("Unknown cargo type", editorCargoContainerData);
                }

                if (editorCargoContainerData.Quantity < 0)
                {
                    LogAndThrow("Invalid cargo quantity", editorCargoContainerData);
                }

                unit.CargoData = new UnitCargoData
                {
                    CargoClass = editorCargoContainerData.CargoClass,
                    Expires = editorCargoContainerData.Expires,
                    ExpiryTime = editorCargoContainerData.ExpiryTime,
                    Quantity = editorCargoContainerData.Quantity
                };
            }
        }

        /// <summary>
        /// Applies to ships and stations
        /// </summary>
        /// <param name="editorUnit"></param>
        /// <param name="unit"></param>
        private static void ExportComponentData(EditorUnit editorUnit, Unit unit)
        {
            var editorComponentData = editorUnit.GetComponentInChildren<EditorComponentUnitData>();
            if (editorComponentData != null)
            {
                unit.ComponentUnitData = new ComponentUnitData
                {
                    ShipNameIndex = -1,
                    CapacitorCharge = editorComponentData.CapacitorCharge >= 0.0f ? editorComponentData.CapacitorCharge : null,
                    IsUnderConstruction = editorComponentData.IsUnderConstruction,
                    ConstructionProgress = editorComponentData.ConstructionProgress,
                    StationUnitClassNumber = editorComponentData.StationUnitClassNumber,
                    IsCloaked = editorComponentData.IsCloaked,
                    EngineThrottle = editorComponentData.EngineThrottle >= 0.0f ? editorComponentData.EngineThrottle : null,
                };

                // If there's no unit name assigned in the editor, give the name a random value from the library
                if (string.IsNullOrWhiteSpace(unit.Name))
                {
                    const int maxShipNames = 1272;  // Don't touch
                    unit.ComponentUnitData.ShipNameIndex = Random.Range(0, maxShipNames);
                }

                var editorCargoDataItmes = editorComponentData.GetComponentsInChildren<EditorComponentUnitCargoDataItem>();
                if (editorCargoDataItmes.Length > 0)
                {
                    unit.ComponentUnitData.CargoData = new ComponentUnitCargoData();
                    foreach (var item in editorCargoDataItmes)
                    {
                        if (!System.Enum.IsDefined(typeof(CargoClass), item.CargoClass))
                        {
                            LogAndThrow("Unknown cargo type", item);
                        }

                        if (item.Quantity < 0)
                        {
                            LogAndThrow("Invalid cargo quantity", item);
                        }

                        if (item.Quantity > 0)
                        {
                            unit.ComponentUnitData.CargoData.Items.Add(new ComponentUnitCargoDataItem
                            {
                                CargoClass = item.CargoClass,
                                Quantity = item.Quantity
                            });
                        }
                    }
                }

                unit.ComponentUnitData.CustomShipName = unit.Name;
            }
        }

        private static void ExportSectors(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            foreach (var editorSector in editorSavedGame.GetComponentsInChildren<EditorSector>())
            {
                savedGame.Sectors.Add(new Sector
                {
                    Id = editorSector.Id,
                    ResourceName = editorSector.Resource.ToString(),
                    Name = editorSector.Name,
                    Description = editorSector.Description,
                    GateDistanceMultiplier = editorSector.GateDistanceMultiplier,
                    RandomSeed = editorSector.RandomSeed,
                    BackgroundRotation = editorSector.BackgroundRotation.ToVec3(),
                    LightRotation = editorSector.LightRotation.ToVec3()
                });
            }
        }

        public static void ExportFactions(EditorSavedGame editorSavedGame, SavedGame savedGame)
        {
            var factions = editorSavedGame.GetComponentsInChildren<EditorFaction>();
            foreach (var editorFaction in factions)
            {
                var faction = new Faction
                {
                    Id = editorFaction.Id,
                    CustomName = editorFaction.CustomName,
                    CustomShortName = editorFaction.CustomShortName,
                    Credits = editorFaction.Credits,
                    Description = editorFaction.Description,
                    IsCivilian = editorFaction.IsCivilian,
                    FactionType = editorFaction.FactionType,
                    Aggression = editorFaction.Aggression,
                    Virtue = editorFaction.Virtue,
                    Greed = editorFaction.Greed,
                    TradeEfficiency = editorFaction.TradeEfficiency,
                    DynamicRelations = editorFaction.DynamicRelations,
                    ShowJobBoards = editorFaction.ShowJobBoards,
                    CreateJobs = editorFaction.CreateJobs,
                    RequisitionPointMultiplier = editorFaction.RequisitionPointMultiplier,
                    MinNpcCombatEfficiency = editorFaction.MinNpcCombatEfficiency,
                    MaxNpcCombatEfficiency = editorFaction.MaxNpcCombatEfficiency,
                    AdditionalRpProvision = editorFaction.AdditionalRpProvision,
                    TradeIllegalGoods = editorFaction.TradeIllegalGoods,
                };

                var editorFactionSettings = editorFaction.GetComponentInChildren<EditorFactionCustomSettings>();
                if (editorFactionSettings != null)
                {
                    faction.CustomSettings = new FactionCustomSettings
                    {
                        AllowOtherFactionToUseDocks = editorFactionSettings.AllowOtherFactionToUseDocks,
                        DailyIncome = editorFactionSettings.DailyIncome,
                        HostileWithAll = editorFactionSettings.HostileWithAll,
                        IgnoreStationCreditsReserve = editorFactionSettings.IgnoreStationCreditsReserve,
                        LargeShipPreference = editorFactionSettings.LargeShipPreference,
                        MinFleetUnitCount = editorFactionSettings.MinFleetUnitCount,
                        MaxFleetUnitCount = editorFactionSettings.MaxFleetUnitCount,
                        OffensiveStance = editorFactionSettings.OffensiveStance,
                        PreferenceToBuildStations = editorFactionSettings.PreferenceToBuildStations,
                        PreferenceToBuildTurrets = editorFactionSettings.PreferenceToBuildTurrets,
                        PreferenceToPlaceBounty = editorFactionSettings.PreferenceToPlaceBounty,
                        PreferSingleShip = editorFactionSettings.PreferSingleShip,
                        RepairMinCreditsBeforeRepair = editorFactionSettings.RepairMinCreditsBeforeRepair,
                        RepairMinHullDamage = editorFactionSettings.RepairMinHullDamage,
                        RepairShips = editorFactionSettings.RepairShips,
                        UpgradeShips = editorFactionSettings.UpgradeShips,
                    };
                }

                faction.HasCustomName = !string.IsNullOrWhiteSpace(editorFaction.CustomName);

                savedGame.Factions.Add(faction);
            }
        }
    }
}
