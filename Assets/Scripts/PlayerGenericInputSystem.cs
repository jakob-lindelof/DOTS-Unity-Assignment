using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;

public partial struct PlayerGenericInputSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        new PlayerGenericInputJob().Schedule();
    }
}

public partial struct PlayerGenericInputJob : IJobEntity
{
    private void Execute(ref MoveInput moveInput, in PlayerGenericInput playerInput)
    {
        moveInput.moveDirection = playerInput.GenericMoveInput;
    }
}

public partial struct PlayerGenericInput : IComponentData
{
    public float2 GenericMoveInput;
}