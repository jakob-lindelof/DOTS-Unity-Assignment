using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

public class EnemyAuthoring : MonoBehaviour
{
    public float MoveSpeed;

    public float2 MoveDirection;

    class EnemyAuthoringBaker : Baker<EnemyAuthoring>
    {
        public override void Bake(EnemyAuthoring authoring)
        {
            Entity enemyEntity = GetEntity(TransformUsageFlags.Dynamic);

            AddComponent<EnemyTag>(enemyEntity);
            
            AddComponent(enemyEntity, new EnemyMoveInput
            {
                Value = authoring.MoveDirection
            });
            
            AddComponent(enemyEntity, new EnemyMoveSpeed
            {
                Value = authoring.MoveSpeed
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