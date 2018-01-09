ResolutionBuddy
===============

This is a C# library for choosing a random item from a collection of weighted items.

To use, install the nuget package at https://www.nuget.org/packages/WeightedRandomizer.dmanning23/

An example where this library might be used, say you have a dragon and want it to randomly choose a hero to attack:
1. a tank with aggro
2. a DPS fighter standing next to him
3. or a healer hiding behind them

```
//create the bag
var bag = new WeightedBag<Hero>();
//add the tank with a weight +5 for aggro status
bag.AddItem(tank, 6);
//add the DPS with a weight +2 for being nearby
bag.AddItem(dps, 3);
//add the healer
bag.AddItem(healer, 1);

//the target is %60 chance of being the tank, 30% the dps, or 10% the healer
var target = bag.NextItem();
```

Now say the dragon targets the tank and kills him in one next. Next round to choose a target, just don't add the tank:
```
//Make sure to clear the bag when reusing it with a new collection of items
bag.Clear();
//add the DPS with a weight +2 for being nearby
bag.AddItem(dps, 3);
//add the healer
bag.AddItem(healer, 1);

//This time the target is %75 chance to choose the dps, and 25% the healer
var target = bag.NextItem();
```