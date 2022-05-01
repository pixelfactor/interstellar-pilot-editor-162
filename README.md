# The (experimental) editor for Interstellar Pilot v1.6.2

This Unity3D project allows creation of simple scenarios to be played with v1.6.2 of Interstellar Pilot (IP).

## Disclaimer
Loading modified IP .dat files on your device is done at your own risk. Whilst there is little chance that this editor will create a .dat file that can damage your device, this is still done at your own risk and we (Pixelfactor Ltd) take no responsibility for damage.
Any .dat files received from third-party sources should be treated with caution. Loading third-party .dat files in IP may cause the application to run in a way that was unintended, for example using more resources or battery power. Third-party .dat files may contain inappropriate material and/or views not shared by Pixelfactor Ltd.

## Quick start

- Download Unity3D if required (https://unity.com/download) - only version 2021.2.16f1 has been tested but anything near this version should work
- Clone/fork this repo
- Open the project in Unity
- Unity will complain that scripts are broken. Press 'Ignore' (don't enter safe mode). The reason this happens is because the project relies on external libraries delivered via Nuget which won't be in place yet.
- At the top menu use Nuget -> Restore Packages
- Close and reopen Unity
- Open the scene "Assets/IPEditor/SampleScenes/1. EmptySectorWithPlayerSample.unity"
- Using the IPEditor menu item, select IPEditor->Export->Quick Export
- The Console will display the location of the exported .dat file
- The .dat file can then be placed in the location that IP expects. On android this is typically 'Android\data\com.pixelfactor.interstellarpilot\files\SaveGames'
- Then customize your own start. A fuller scenario exists in "Assets/IPEditor/SampleScenes/AssaultOnStarbase13"

## More about this project
The project allows placement and linking of IP objects (sectors, ships, stations etc etc), which can then be exported into a .dat file, which will work with IP (v1.6.2 only).

The .dat file was never intended to be used to store custom scenarios, it is a binary representation of a scenario _in-progress_. However it is still possible with this editor to use the .dat file for the purpose of storing a customized universe and to setup NPCs for a 'sort-of scenario'.

This project has been made possible with the following projects, which have been stripped from the IP codebase:

https://github.com/pixelfactor/Pixelfactor.IP.SavedGames.V162.Model
https://github.com/pixelfactor/Pixelfactor.IP.SavedGames.V162.BinarySerialization

The Model is a complete representation of everything in the save file format. The Binary serialization project allows the Model to be converted into the .dat format. Both these projects are also experimental. These projects are referenced via a Nuget extension (https://github.com/GlitchEnzo/NuGetForUnity).

## FAQ

- Q. Why can't I _see_ the ships in the editor?
- A. 1. Time constraints mean coloured cubes must suffice, 2. Pixelfactor are not licensed to _redistribute_ artwork/models used in IP


## Future of this project
The 1.6.2 save file format is now obsolete and will be replaced with v1.7 or Interstellar Pilot. The 1.6.2 format has many limitations that will be overcome. As the 1.6.2 format is at a dead-end, so too is this editor, which will be replaced with a fuller and supported 1.7 version editor. 

There will be no upgrade path for 1.6.2 .dat files to 1.7. 

I make this project open-source in the hope that somebody may enjoy creating a custom universe for v1.6.2. And if you do manage this, please show this off to me at support@pixelfactor.com.

## Supported with this editor

### Sectors
 - Naming
 - Placement for the universe map
 - Background choices
 - Light directino
 
### Factions
 - Faction naming
 - Other attributes e.g. personality, daily income, faction type
 - Opinions / relations to other factions (hostile / allied)

### Ships / Stations
 - Naming
 - Cargo hold
 - Abandonded ships/stations
 - Component mods
 
### Pilots
 - Naming
 - Custom pilot settings
 
### Fleets
 - orders 
 - Custom fleet settings
 - The following have been verified to be working after export: Attack target, protect, move, patrol, wait, trade, mine. Others may or may not work.

### Cargo containers (in space)
### Wormholes (there is a handy tool in the menu to connect two sectors)
### Universe map - this is generated based on the position of sectors
### Player messages
### Planets - it is a bit of trial and error to get the right look though
### Asteroid Clusters

## Not supported
(Most of these items are not supported because they have not been coded into the exporter (SavedGameExporter.cs). There is no technical reason why they can't be supported, there just wasn't time)

- Loading a .dat file (this is an objective for 1.7 editor version)
- Docked ships
- Stations under construction
- Faction intel (currently the exporter will automatically give all NPC factions full intel)
- Faction transactions
- Faction stats
- Faction leaders
- Damaged units / damaged shields
- Unstable wormholes
- Moons
- Unit capacitor charge values
- 'Active' Unit data - data for a ship that is the active sector. Things like velocity and turn
- Current HUD target
- Player waypoints
- Bounty boards
- Passenger groups
- Job Board
- Missions
- Projectiles / Missiles

## Can *never* be supported with v1.6.2

- Triggers and actions such as those within tutorials and scenario sections of IP
- Custom ship designs
- Sector light colour, ambience

## Known Issues

- The exported save game will always appear as a 'Sandbox' in IP
- New factions will spawn in the loaded game. This cannot be disabled.
