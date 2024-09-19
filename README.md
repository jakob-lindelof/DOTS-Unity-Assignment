**Performance aware space shooter using DOTS assignment**

A simple game using the DOTS framework from Unity where BurstCompile as been used where applicable. I have split up the systems of movement in such a way that player and enemy positions are updated by the same system.
The arguments for the change in transform comes from systems reading input from the enemies and players respectively. 

I have a system that can enable a tag after a set amount of time, this tag is queried by another system that deletes the entity when the desired time is met.This system operates on both the projectile the player fires and the enemies.

