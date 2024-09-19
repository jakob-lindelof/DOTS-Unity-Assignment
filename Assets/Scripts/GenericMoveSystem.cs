using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;


[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct GenericMoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        new MoveJob
        {
            DeltaTime = deltaTime
        }.ScheduleParallel();
    }
}

[StructLayout(LayoutKind.Auto)]
public partial struct MoveJob : IJobEntity
{
    public float DeltaTime;

    private void Execute(ref LocalTransform transform, in MoveInput input)
    {
        transform.Position.xy += input.moveDirection * 5f * DeltaTime;
    }
}


public struct MoveInput : IComponentData
{ 
    public float2 moveDirection;
}

public struct MoveSpeed : IComponentData
{
    public float Value;
}