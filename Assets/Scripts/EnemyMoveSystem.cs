using System.Collections;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Transforms;
using UnityEngine;

public partial struct EnemyMoveSystem : ISystem
{
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        new EnemyMoveJob
        {
            DeltaTime = deltaTime
        }.Schedule();
    }
}


public partial struct EnemyMoveJob : IJobEntity
{
    public float DeltaTime;

    private void Execute(ref LocalTransform transform, in EnemyMoveInput input, EnemyMoveSpeed speed)
    {
        transform.Position.xy += input.Value * speed.Value * DeltaTime;
    }
}