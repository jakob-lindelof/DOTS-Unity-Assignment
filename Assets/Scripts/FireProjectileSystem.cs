using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct FireProjectileSystem : ISystem
{

    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.Temp);

        foreach (var (projectilePrefab, transform, lifeTime) in SystemAPI.Query<ProjectilePrefab, LocalTransform, ProjectileLifeTime>().WithAll<FireProjectileTag>())
        {
            var newProjectile = ecb.Instantiate(projectilePrefab.Value);
            var projectileTransform = LocalTransform.FromPositionRotationScale(
                new float3(transform.Position.x, transform.Position.y + 1,0),
                transform.Rotation,
                0.15f);
            ecb.SetComponent(newProjectile, projectileTransform);
            ecb.AddComponent(newProjectile, new LifeTime { Value = lifeTime.Value });
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
