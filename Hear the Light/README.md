# First3DGame
My first 3D unity game. Third person camera some inspiration from harvest moon and zelda. 

## Gameplay
A farming simulator, dundgeon crawling (mines), building up town, exploring w/puzzles. 

Unlockables: 
Citizens
Buying new land
Achievements = //TODO goal
Stamina upgrades
New areas (need costume for exploring desert, arctic, etc)
Tools (sprinklers, autofeeders, auto bring animals inside/out)
Marriage, kids 

## Story
You're an addict (gambling) and you hear a mysterious voice directing your attention to a small town with an add for a farmer. Feeling you have nothing left to lose you ask a family member for money and you end up in the town accepting the vacant position. Throughout the game the mysterious voice leads you to explore new areas to find out who the voice is and why they called out to you. 


## Fixits - TODO 
# Water
Having a small problem when my character is in view with water there is white outline drawn around my character.how can I solve this ? Please and thank you.
1
Daniel Ilett
Daniel Ilett
4 days ago
That issue is to do with the way the shader draws intersection foam around objects submerged in water - there's a bug I couldn't quite fix where it affects objects in front of the water, too. To fix it, you can do these steps:

In the video, at roughly the 4:40 mark, instead of hooking up the Step node into the brand new Lerp node, we'll add a Comparison node after it, with the Scene Depth node in eye-space in the A field, the raw Screen Position node's alpha component from the Split node in the B field, and the mode set to Greater. Plug its output into a new Branch node's Predicate field, pass the Step node output to the True field, and set the False value to 1. Pass the Branch output into the new Lerp node instead, and it should fix the issue! Hope that helps.

For funsies, after a bit more tinkering, the stylised hard-white intersection might not be what people want - if you want the intersection to have a smooth alpha falloff, just bypass the Step node and directly use the Saturate node output. You'll get a nice gradient of white dipping into the water. 

https://www.youtube.com/watch?v=NHy3rSKtRmc&t=30s 
https://github.com/daniel-ilett/water-urp 



