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
            if (spawner.ValueRO.NextSpawnTime < SystemAPI.Time.ElapsedTime) {
                Entity newEntity = state.EntityManager.Instantiate(spawner.ValueRO.EnemyPrefab);
                float3 pos = new float3(
                    spawner.ValueRO.SpawnPosition.x + Random.Range(Camera.main.ScreenToWorldPoint(
                            new Vector2(0,0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0,Screen.height)).y),
                    spawner.ValueRO.SpawnPosition.y + Random.Range(Camera.main.ScreenToWorldPoint(
                            new Vector2(0,0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,0)).x),
                    0
                    );
                state.EntityManager.SetComponentData(newEntity, LocalTransform.FromPosition(pos));
                spawner.ValueRW.NextSpawnTime = (float)SystemAPI.Time.ElapsedTime + spawner.ValueRO.SpawnRate;
            }
        }
    }
}
