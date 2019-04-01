using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public enum Actions { };
    public enum KeyBoardButtons { };
    public enum GamePadButtons { };


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool GetButtonDown(string btn)
    {
        
        return Input.GetButtonDown(btn);
    }

    public bool GetButton(string btn)
    {
        return Input.GetButton(btn);
    }

    public bool GetButtonUp(string btn)
    {
        return Input.GetButtonUp(btn);
    }

    public float GetAxis(string axis)
    {
        return Input.GetAxis(axis);
    }
}
