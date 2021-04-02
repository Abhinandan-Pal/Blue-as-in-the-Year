
using UnityEngine;

public class PlayerMovementContent : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float groundDistance = 0.4f;
    bool isGrounded;
    Vector3 velocity;


    // Update is called once per frame
    void Update()
    {
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");


        Vector3 move = transform.right*x + transform.forward*z;

        controller.Move(move*speed*Time.deltaTime);


        velocity.y += gravity*Time.deltaTime;

        controller.Move(velocity* Time.deltaTime);
    }
}
