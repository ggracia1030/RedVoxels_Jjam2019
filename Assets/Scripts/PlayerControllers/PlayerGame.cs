using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGame : MonoBehaviour
{
    Transform tf;
    Rigidbody rb;
    public float speed;
    Quaternion direction;
    Vector3 inputMovement;

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
        inputMovement = new Vector3(InputManager.Instance.GetAxis("Horizontal") * Time.deltaTime * speed * 100, -4f, InputManager.Instance.GetAxis("Vertical") * Time.deltaTime * speed * 100);
        if (InputManager.Instance.GetKeyDown(KeyCode.Space)) Debug.Log("hdjsafdsaf");
    }

    void PlayerMovement()
    {
        rb.velocity = inputMovement;
    }

    void RotatePlayer()
    {
        tf.rotation = Quaternion.Euler(0,Vector3.Normalize(inputMovement).y,0);
    }
}
