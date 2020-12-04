using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[ExecuteAlways]
public class FPSAgentInput : MonoBehaviour
{
    public bool DisableInput = false;
    private FPSPlayerInputActions inputActions;
    private FPSPlayerInputActions.PlayerActionMapActions actionMap;
    private Gamepad gamepad;

    public Vector2 moveInput;

    public bool shootInput;
    public bool jumpInput;
    public bool dashInput;
    public float rotateInput;
    public bool shieldInput;

    // Start is called before the first frame update
    void Awake()
    {
        inputActions = new FPSPlayerInputActions();
        actionMap = inputActions.PlayerActionMap;
    }
    void OnEnable()
    {
        gamepad = Gamepad.current;
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    public bool CheckIfInputSinceLastFrame(ref bool input)
    {
        if (input)
        {
            input = false;
            return true;
        }
        return false;
    }
    //    public bool JumpCheck(ref bool input)
    //    {
    //        if (jumped)
    //        {
    //            jumped = false;
    //            return true;
    //        }
    //        return false;
    //    }


    // Update is called once per frame
    void FixedUpdate()
    {
        //        Vector2 move = gamepad.leftStick.ReadValue();

        if (DisableInput)
        {
            return;
        }
        moveInput = actionMap.Walk.ReadValue<Vector2>();
        shootInput = actionMap.Shoot.ReadValue<float>() > 0;
        //        shootInput = gamepad.rightTrigger.isPressed;
        shieldInput = actionMap.Shield.ReadValue<float>() > 0;
        //        rotateInput = actionMap.RotateBody.ReadValue<Vector2>();
        rotateInput = actionMap.Rotate.ReadValue<float>();
        //        rotateInput = actionMap.RotateBody.ReadValue<Vector2>();
        //        jumpInput = actionMap.Jump.ReadValue<float>() > 0;
        //        jumpInput = actionMap.Jump.triggered;
        if (actionMap.Dash.triggered)
        {
            dashInput = true;
        }
        if (actionMap.Jump.triggered)
        {
            jumpInput = true;
        }
        //        if (jumpInput)
        //        {
        //        print($"Input: Jump: {jumpInput} : {Time.frameCount}");
        //
        //        }
        //        jumpInput = gamepad.buttonSouth.isPressed;
        //        dashInput = actionMap.Dash.ReadValue<float>() > 0;
        //        actionMap.Dash.phase == InputActionPhase.
        //        dashInput = gamepad.buttonWest.isPressed;
    }
}