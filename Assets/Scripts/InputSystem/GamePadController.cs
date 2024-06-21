using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GamePadController : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    void Start()
    {
        playerInput.SwitchCurrentActionMap("GamePad");
    }

    void Update()
    {
        if (playerInput.actions["North"].triggered == true)
        {
            InputAction inputAction = playerInput.actions["North"];
            string currentButtonName = inputAction.GetBindingDisplayString();
            Debug.Log("<color=green>currentButtonName : " + currentButtonName + "</color>");
        }
        else if (playerInput.actions["South"].triggered == true)
        {
            InputAction inputAction = playerInput.actions["South"];
            string currentButtonName = inputAction.GetBindingDisplayString();
            Debug.Log("<color=blue>currentButtonName : " + currentButtonName + "</color>");
        }
        else if (playerInput.actions["East"].triggered == true)
        {
            InputAction inputAction = playerInput.actions["East"];
            string currentButtonName = inputAction.GetBindingDisplayString();
            Debug.Log("<color=red>currentButtonName : " + currentButtonName + "</color>");
        }
        else if (playerInput.actions["West"].triggered == true)
        {
            InputAction inputAction = playerInput.actions["West"];
            string currentButtonName = inputAction.GetBindingDisplayString();
            Debug.Log("<color=purple>currentButtonName : " + currentButtonName + "</color>");
        }
    }
}
