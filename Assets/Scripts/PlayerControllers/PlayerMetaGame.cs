using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMetaGame : MonoBehaviour
{
    public Vector3 inputMovement;
    public float speed;
    bool jumpInput, canJump;
    public Vector3 startPosition, jumpForceVector;
    [SerializeField] float jumpForce;
    Rigidbody rb;
    [SerializeField] Keyboard keyboard;

    Vector3 cRightUp    = new Vector3( 0.5f, -0.5f,  0.5f);
    Vector3 cRightDown  = new Vector3( 0.5f, -0.5f, -0.5f);
    Vector3 cLeftUp     = new Vector3(-0.5f, -0.5f,  0.5f);
    Vector3 cLeftDown   = new Vector3(-0.5f, -0.5f, -0.5f);


    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody>();
        canJump = false;
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
        if (canJump && jumpInput)  PlayerJump();
        CheckJump();   
    }

    void UpdateControlls()
    {
        if(keyboard.IsPressed(Key.KeyType.A))
        {
            inputMovement.x -= speed;
        }
        if (keyboard.IsPressed(Key.KeyType.D))
        {
            inputMovement.x += speed;
        }

        if (keyboard.IsPressed(Key.KeyType.W))
        {
            inputMovement.z += speed;
        }
        if (keyboard.IsPressed(Key.KeyType.S))
        {
            inputMovement.z -= speed;
        }
        if(jumpInput = keyboard.IsPressed(Key.KeyType.Space))
        {
            
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

    void CheckJump()
    {
        bool h0, h1, h2, h3;
        h0 = h1 = h2 = h3 = false;

        RaycastHit hit0;
        if (Physics.Raycast(rb.position + cRightUp, Vector3.down, out hit0, Mathf.Infinity))
        {
            if (h0 = hit0.distance < 0.7f) { }

        }
        RaycastHit hit1;
        if (Physics.Raycast(rb.position + cRightDown, Vector3.down, out hit1, Mathf.Infinity))
        {
            if (h1 = hit1.distance < 0.7f) { }
        }
        RaycastHit hit2;
        if (Physics.Raycast(rb.position + cLeftUp, Vector3.down, out hit2, Mathf.Infinity))
        {
            if (h2 = hit2.distance < 0.7f) { }
        }
        RaycastHit hit3;
        if (Physics.Raycast(rb.position + cLeftDown, Vector3.down, out hit3, Mathf.Infinity))
        {
            if (h3 = hit3.distance < 0.7f) { }
        }

        if (h0 || h1 || h2 || h3) { canJump = true; }
    }


    void PlayerJump()
    {
        jumpForceVector = new Vector3(0f, jumpForce * 100, 0f);
        rb.AddForce(jumpForceVector);
        canJump = false;
        Debug.Log("jump");
    }


}
