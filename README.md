**Performance aware space shooter using DOTS assignment**

A simple game using the DOTS framework from Unity where BurstCompile as been used where applicable. I have split up the systems of movement in such a way that player and enemy positions are updated by the same system.
The arguments for the change in transform comes from systems reading input from the enemies and players respectively. 

I have a system that adds a component to an entity, this component is queried by another system that deletes entities with the component when the desired time is met. This system operates on both the projectile the player fires and the enemies.

The system spawning enemies will loop through and set transforms for 37 entities at a time. This is to fulfill the "waves of enemies" part of the assignment. The enemies are destroyed after a set amount of time (default 5 seconds) using the LifeTime component.
