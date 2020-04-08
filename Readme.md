![](https://media.discordapp.net/attachments/696160463192326154/697373861871878214/nfstools.png)


# GlobalLib

GlobalLib is a fast, open-source and powerful for processing BIN data Global files of Black Box Need for Speed games.

## Features
- Very high performance in both loading and saving
- Full Global files support:
  - GlobalA.bun
  - GlobalB.lzc
  - English(Global).bin
  - Labels(Global).bin
- Loading, editing and saving of most of the blocks:
  - Materials
  - CarTypeInfos
  - Preset Rides
  - Preset Skins
  - FEng Groups (FNG)
  - Texture Packs (TPK)
  - String Arrays (STR)
  - CarParts
  - CarSkins
  - Sun Infos
  - Tracks
  - Slot Types
  - GCareer
- Easy to integrate into software, access any roots, collections, properties
- Built-in extensibility: abstract primitive classes ``Collectable`` and ``SubPart`` can be overriden with custom implementations and used in collection-oriented and generic ``Root`` class.
- Ability to use existing class templates to load other files (FrontB1, InGame, TrackMaps, etc)
- Supports following Legacy Need for Speed games:
  - Need for Speed: Carbon
  - Need for Speed: Most Wanted (2005)
  - Need for Speed: Underground 2
  - Need for Speed: Underground 1 (in progress)

## Motivation
A number of factors played their role in decision to make this library:
- The lack of support of the Global files, which are almost, if not the most, important files of the games.
- The existence of solely closed source tools as opposed to open source ones
- Need for a framework similar to [VaultLib](https://github.com/NFSTools/VaultLib "VaultLib") that is focused on BIN data.
- Great desire to learn and explore.
