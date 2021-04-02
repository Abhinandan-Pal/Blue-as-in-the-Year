
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.8f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    Vector3 velocity;

    public CameraShake cameraShake;
    
    public AudioManager audioManager;
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if(Mathf.Abs(x)>0.0f || Mathf.Abs(z)>0.0f)
        {
            if(Input.GetKeyDown(KeyCode.F))
            {
                x = x/2;
                z = z/2;
            }
            else
            {
                StartCoroutine(cameraShake.Shake(.15f,.15f));
            }
            //audioManager.Play("Walk");

        }

        Vector3 move = transform.right*x + transform.forward*z;

        controller.Move(move*speed*Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight*-2f*gravity);
        }

        velocity.y += gravity*Time.deltaTime;

        controller.Move(velocity* Time.deltaTime);
    }
}
