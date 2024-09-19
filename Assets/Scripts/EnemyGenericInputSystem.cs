using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

public partial struct EnemyGenericInputSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        new EnemyGenericInputJob().Schedule();
    }
}

public partial struct EnemyGenericInputJob : IJobEntity
{
    private void Execute(ref MoveInput moveInput, in EnemyGenericInput enemyInput)
    {
        moveInput.moveDirection = enemyInput.GenericMoveInput;
    }
}


public struct EnemyGenericInput : IComponentData
{
    public float2 GenericMoveInput;
}