using Unity.Burst;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

[UpdateInGroup(typeof(InitializationSystemGroup),OrderLast = true)]
public partial class PlayerInputSystem : SystemBase
{
    private GameActions InputActions;
    private Entity Player;
    
    [BurstCompile]
    protected override void OnCreate()
    {
        RequireForUpdate<PlayerTag>();
        RequireForUpdate<PlayerGenericInput>();
        InputActions = new GameActions();
    }

    [BurstCompile]
    protected override void OnStartRunning()
    {
        InputActions.Enable();
        InputActions.Player.Shoot.performed += OnShoot;
        Player = SystemAPI.GetSingletonEntity<PlayerTag>();
    }

    [BurstCompile]
    private void OnShoot(InputAction.CallbackContext context)
    {
        if (!SystemAPI.Exists(Player)) return;
        
        SystemAPI.SetComponentEnabled<FireProjectileTag>(Player, true);
    }

    [BurstCompile]
    protected override void OnUpdate()
    {
        foreach (RefRW<PlayerGenericInput> playerGenericInput in SystemAPI.Query<RefRW<PlayerGenericInput>>())
        {
            playerGenericInput.ValueRW.GenericMoveInput = InputActions.Player.Move.ReadValue<Vector2>();
        }
    }

    protected override void OnStopRunning()
    {
        InputActions.Disable();
        Player = Entity.Null;
    }
}
