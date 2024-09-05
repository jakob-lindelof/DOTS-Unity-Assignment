using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public struct Spawner : IComponentData
{
    public Entity EnemyPrefab;
    public float2 SpawnPosition;    //Better Vector2
    public float NextSpawnTime;
    public float SpawnRate;
}
