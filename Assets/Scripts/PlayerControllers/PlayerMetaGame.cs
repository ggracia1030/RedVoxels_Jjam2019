using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMetaGame : MonoBehaviour
{
    Vector3 inputMovement;
    bool jumpInput;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
    }

    public void ResetPlayer()
    {
        transform.position = startPosition;
    }

    void UpdateVariables()
    {
        inputMovement = Vector3.zero;
    }

    void SetInputMovement(Vector3 _input)
    {
        inputMovement = _input;
    }

    public void SetHorizontalMovement(float _input)
    {
        inputMovement.x += _input;
    }

    public void SetVerticalMovement(float _input)
    {
        inputMovement.z += _input;
    }

    public void SetJumpInput(bool _jump)
    {
        jumpInput = _jump;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
