# 3.0.15
* Spider hit and death sounds, including Frigga and spider eggs, can be turned down in `MonsterLabZ.cfg` under Spider Sounds. Default volume is 0.35.
* `HitAreaSFX`, plant growth, and ship wave impact now call the current `EffectList.Create` method.

# 3.0.14
* Readme file update.

# 3.0.13
* Valheim 1.0 fix: `MonsterLabZ.ML_PlantGrow` now implements `Hoverable.GetHoverOffset()`, which stops `VTable setup of type MonsterLabZ.ML_PlantGrow failed` / `The script 'MonsterLabZ.ML_PlantGrow' could not be instantiated!`
* This was the cause of prefabs failing to register and the repeating `Missing prefab hash` warnings.

# 3.0.12
* patch 0.221.10

# 3.0.11
* translations encoding fixed
* link to original mod added

# 3.0.10
* Initial fixed version release
