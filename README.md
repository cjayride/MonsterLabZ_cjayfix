# MonsterLabZ (Valheim 1.0 fix)

Explore Valheim with new monsters to fight. This is a community patch of **MonsterLabZFix 3.0.12** so the plugin loads on current Valheim.

Original mod: https://thunderstore.io/c/valheim/p/MonsterLabZ/MonsterLabZ/

Previous restore: https://thunderstore.io/c/valheim/p/MonsterLabZFix/MonsterLabZ/

All credits go to the original author **DefendYourBase**. Creatures, locations, and assets belong to them. Do not treat this as a new content pack.

## What 3.0.15 changes

Spider hit and death sounds, including Frigga and spider eggs, use `MonsterLabZ.cfg` under **Spider Sounds**. `Volume = 0.35` is 35% volume. `1` is full volume. Idle, alert, attack, and footstep sounds are unchanged.

`HitAreaSFX.Damage`, `ML_PlantGrow.Grow`, and `Ship.UpdateWaterForce` call the current `EffectList.Create` method.

## What 3.0.13 fixes

Valheim 1.0 added `float GetHoverOffset()` to the `Hoverable` interface. `MonsterLabZ.ML_PlantGrow` did not implement it, so the type failed to load:

```
The script 'MonsterLabZ.ML_PlantGrow' could not be instantiated!
VTable setup of type MonsterLabZ.ML_PlantGrow failed
```

That blocked prefab registration. This build adds `GetHoverOffset()` (returns `0`).

## Install

Install on **client and dedicated server**. Remove any other MonsterLabZ / MonsterLabZFix DLL first so you only have one copy.

A handful of creatures spawn by default. Configure the rest with Spawn That or the official BepInEx Configuration Manager.

https://valheim.thunderstore.io/package/Azumatt/Official_BepInEx_ConfigurationManager/

## Notes

- `Missing prefab hash` on an **old world** can continue after this fix if leftover objects were saved when the plugin was broken. A new world is the clean test.
- This package is a compatibility patch. If the original author updates MonsterLabZ for 1.0, switch back to that.
