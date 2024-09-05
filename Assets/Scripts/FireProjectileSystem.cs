using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

[UpdateInGroup(typeof(SimulationSystemGroup))]
[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct FireProjectileSystem : ISystem
{

    public void OnUpdate(ref SystemState state)
    {
        var ecb = new EntityCommandBuffer(Unity.Collections.Allocator.TempJob);

        foreach (var (projectilePrefab, transform) in SystemAPI.Query<ProjectilePrefab, LocalTransform>().WithAll<FireProjectileTag>())
        {
            var newProjectile = ecb.Instantiate(projectilePrefab.Value);
            var projectileTransform = LocalTransform.FromPositionRotationScale(
                new float3(transform.Position.x, transform.Position.y + 1,0),
                transform.Rotation,
                0.15f);
            ecb.SetComponent(newProjectile, projectileTransform);
        }
        ecb.Playback(state.EntityManager);
        ecb.Dispose();
    }
}
