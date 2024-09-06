using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

[UpdateInGroup(typeof(InitializationSystemGroup),OrderLast = true)]
public partial class PlayerInputSystem : SystemBase
{
    private GameActions InputActions;
    private Entity Player;
    
    protected override void OnCreate()
    {
        RequireForUpdate<PlayerTag>();
        RequireForUpdate<PlayerGenericInput>();
        InputActions = new GameActions();
    }

    protected override void OnStartRunning()
    {
        InputActions.Enable();
        InputActions.Player.Shoot.performed += OnShoot;
        Player = SystemAPI.GetSingletonEntity<PlayerTag>();
    }

    private void OnShoot(InputAction.CallbackContext context)
    {
        if (!SystemAPI.Exists(Player)) return;
        
        SystemAPI.SetComponentEnabled<FireProjectileTag>(Player, true);
    }

    protected override void OnUpdate()
    {
        //Vector2 moveInput = InputActions.Player.Move.ReadValue<Vector2>();

        foreach (RefRW<PlayerGenericInput> playerGenericInput in SystemAPI.Query<RefRW<PlayerGenericInput>>())
        {
            playerGenericInput.ValueRW.GenericMoveInput = InputActions.Player.Move.ReadValue<Vector2>();
        }
        //SystemAPI.SetSingleton(new PlayerGenericInput { GenericMoveInput = moveInput });
    }

    protected override void OnStopRunning()
    {
        InputActions.Disable();
        Player = Entity.Null;
    }
}
