using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame : MonoBehaviour
{
    Transform tf;
    Rigidbody rb;
    public float speed, jumpForce;
    Quaternion direction;
    Vector3 inputMovement, jumpForceVector;
    bool space, canJump, isCarrying, eKey, eKeyUp;
    

    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateInput();
    }

    private void FixedUpdate()
    {
        PlayerMovement();
        RotatePlayer();
    }


    void UpdateInput()
    {
        inputMovement = new Vector3(InputManager.Instance.GetAxis("Horizontal") * Time.deltaTime * speed * 100, 0, InputManager.Instance.GetAxis("Vertical") * Time.deltaTime * speed * 100);
        space = InputManager.Instance.GetButtonDown("Jump");
        eKey = InputManager.Instance.GetButtonDown("Action");
        eKeyUp = InputManager.Instance.GetButtonUp("Action");
        if(eKeyUp && isCarrying)
        {
            isCarrying = false;
            foreach(Transform child in tf)
            {
                child.transform.parent = null;
            }
        }
    }

    void PlayerMovement()
    {
        rb.velocity = inputMovement + rb.velocity.y * Vector3.up;
        if (space && canJump) PlayerJump();
    }

    void PlayerJump()
    {
        jumpForceVector = new Vector3(0f, jumpForce * 100, 0f);
        rb.AddForce(jumpForceVector);
        canJump = false;
        Debug.Log("jump");
    }

    void RotatePlayer()
    {
        tf.rotation = Quaternion.Euler(0,Vector3.Normalize(inputMovement).y,0);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (canJump = collision.contacts[0].normal.y > 0.5) { }
    }



    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Carriable" && eKey && !isCarrying)
        {
            other.gameObject.transform.parent = tf;
            isCarrying = true;
        }
    }
}
