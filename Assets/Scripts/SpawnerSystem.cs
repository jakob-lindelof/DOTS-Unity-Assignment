using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using Random = UnityEngine.Random;

public partial struct SpawnerSystem : ISystem
{

    public void OnUpdate(ref SystemState state) {
        foreach(RefRW<Spawner> spawner in SystemAPI.Query<RefRW<Spawner>>())
        {
            if (spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime)
            {
                for (int i = 0; i < 37; i++)
                {
                    Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.EnemyPrefab);
                    float3 pos = new float3(
                        spawner.ValueRO.SpawnPosition.x - 9 + i * 0.5f,
                        spawner.ValueRO.SpawnPosition.y + 5,
                        0
                    );
                    state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPositionRotationScale(pos, quaternion.identity, 0.5f));
                }
                spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.SpawnRate;
            }
        }
    }
}
