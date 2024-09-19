using Unity.Burst;
using Unity.Entities;
using UnityEngine;

public class ProjectileAuthoring : MonoBehaviour
{
    public float ProjectileSpeed;

    [BurstCompile]
    public class ProjectileAuthoringBaker : Baker<ProjectileAuthoring>
    {
        public override void Bake(ProjectileAuthoring authoring)
        {
            Entity entity = GetEntity(TransformUsageFlags.Dynamic);
            AddComponent(entity, new ProjectileMoveSpeed { Value = authoring.ProjectileSpeed });
        }
    }
    
    
}
