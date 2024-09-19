using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class SpawnerAuthoring : MonoBehaviour
{
    public GameObject Prefab;
    public float SpawnRate;

    [BurstCompile]
    class SpawnerBaker : Baker<SpawnerAuthoring>
    {
        public override void Bake(SpawnerAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.None);

            AddComponent(entity, new Spawner
                {
                    EnemyPrefab = GetEntity(authoring.Prefab, TransformUsageFlags.Dynamic),
                    SpawnPosition = float2.zero,
                    NextSpawnTime =  0,
                    SpawnRate = authoring.SpawnRate
                }
            );
        }
    }
}
