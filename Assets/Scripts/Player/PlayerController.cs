using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private PlayerStates playerStates;

    private PlayerInput playerInput;

    //store our controls
    private InputAction moveAction;
    private InputAction jumpAction;
    private InputAction attackAction;

    private void Awake()
    {
        playerStates = GetComponent<PlayerStates>();

        playerInput = GetComponent<PlayerInput>();
        moveAction = playerInput.actions["Move"];
        jumpAction = playerInput.actions["Jump"];
        attackAction = playerInput.actions["Attack"];

        //player
    }

    private void OnEnable()
    {
        moveAction.started += MoveControl;
        moveAction.performed += MoveControl;
        moveAction.canceled += MoveControl;

        jumpAction.started += JumpControl;
        jumpAction.performed += JumpControl;
        jumpAction.canceled += JumpControl;

        attackAction.started += AttackControl;
        attackAction.performed += AttackControl;
        attackAction.canceled += AttackControl;
    }

    private void OnDisable()
    {
        moveAction.started -= MoveControl;
        moveAction.performed -= MoveControl;
        moveAction.canceled -= MoveControl;

        jumpAction.started -= JumpControl;
        jumpAction.performed -= JumpControl;
        jumpAction.canceled -= JumpControl;

        attackAction.started -= AttackControl;
        attackAction.performed -= AttackControl;
        attackAction.canceled -= AttackControl;
    }

    private void MoveControl(InputAction.CallbackContext context)
    {
        Vector2 direction = moveAction.ReadValue<Vector2>();
        if(context.started)
        {
            if(direction.x == 1)
                playerStates.SetMovePressed(true, 1);
            else if(direction.x == -1)
                playerStates.SetMovePressed(true, -1);
            //Debug.Log();
        }
        else if(context.canceled && (direction.x != 1 || direction.x != -1))
        {
            playerStates.SetMovePressed(false, 0);
            //Debug.Log("Stop move left");
        }
    }

    private void JumpControl(InputAction.CallbackContext context)
    {
        if(context.started)
            playerStates.SetJumpPressed(true);
        else if(context.canceled)
            playerStates.SetJumpPressed(false);
    }

    private void AttackControl(InputAction.CallbackContext context)
    {
        if(context.started)
            playerStates.SetAttackPressed(true);
        Debug.Log("AttackPressed");
    }

    private void Update()
    {
        //Vector2 move = moveAction.ReadValue<Vector2>();
        //Debug.Log(move);
    }
}
