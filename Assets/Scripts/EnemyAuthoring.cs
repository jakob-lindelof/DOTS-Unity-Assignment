using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class EnemyAuthoring : MonoBehaviour
{
    public float MoveSpeed;

    public float2 MoveDirection;

    [SerializeField] private float lifetime;

    [BurstCompile]
    class EnemyAuthoringBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity enemyEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent<EnemyTag>(enemyEntity);
            
            AddComponent(enemyEntity, new EnemyGenericInput()
            {
                GenericMoveInput = authoring.MoveDirection
            });
            
            AddComponent<MoveInput>(enemyEntity);
            
            AddComponent(enemyEntity, new MoveSpeed()
            {
                Value = authoring.MoveSpeed
            });
            
            AddComponent(enemyEntity, new LifeTime
            {
                Value = authoring.lifetime
            });
        }
    }
}


public struct EnemyTag : IComponentData { }

public struct EnemyMoveInput : IComponentData
{
    public float2 Value;
}

public struct EnemyMoveSpeed : IComponentData
{
    public float Value;
}