using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMetaGame : MonoBehaviour
{
    public Vector3 inputMovement;
    bool jumpInput;
    public Vector3 startPosition;
    Rigidbody rb;
    [SerializeField] Keyboard keyboard;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector3.right * inputMovement.x + Vector3.up * rb.velocity.y + Vector3.forward * inputMovement.z;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateVariables();
        UpdateControlls();
    }

    void UpdateControlls()
    {
        if(keyboard.IsPressed(Key.KeyType.A))
        {
            inputMovement.x -= 1;
        }
        if (keyboard.IsPressed(Key.KeyType.D))
        {
            inputMovement.x += 1;
        }

        if (keyboard.IsPressed(Key.KeyType.W))
        {
            inputMovement.z += 1;
        }
        if (keyboard.IsPressed(Key.KeyType.S))
        {
            inputMovement.z -= 1;
        }
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

    public void ResetHorizontal()
    {
        inputMovement.x = 0;
    }
    public void ResetVertical()
    {
        inputMovement.z = 0;
    }

    public void SetHorizontalMovement(float _input)
    {
        inputMovement.x += _input;
        if (inputMovement.x > 1) inputMovement.x = 1;
        else if (inputMovement.x < -1) inputMovement.x = -1;
    }

    public void SetVerticalMovement(float _input)
    {
        inputMovement.z += _input;
        if (inputMovement.z > 1) inputMovement.z = 1;
        else if (inputMovement.z < -1) inputMovement.z = -1;
    }

    public void SetJumpInput(bool _jump)
    {
        jumpInput = _jump;
    }

    
}
