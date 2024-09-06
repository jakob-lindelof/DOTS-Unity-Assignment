using System.Runtime.InteropServices;
using Unity.Burst;
using Unity.Entities;
using Unity.Transforms;

[UpdateBefore(typeof(TransformSystemGroup))]
public partial struct PlayerMoveSystem : ISystem
{
    [BurstCompile]
    public void OnUpdate(ref SystemState state)
    {
        float deltaTime = SystemAPI.Time.DeltaTime;

        new PlayerMoveJob
        {
            DeltaTime = deltaTime
        }.Schedule();

    }

    [StructLayout(LayoutKind.Auto)]
    public partial struct PlayerMoveJob : IJobEntity
    {
        public float DeltaTime;

        private void Execute(ref LocalTransform transform, in PlayerMoveInput input, 
            PlayerMoveSpeed speed) //ref ReadWrite       //in Readonly     //-- by value
        {
            transform.Position.xy += input.Value * speed.Value * DeltaTime;
        }
    }
}

