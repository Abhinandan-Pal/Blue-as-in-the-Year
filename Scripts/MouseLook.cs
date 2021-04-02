
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensetivity = 100f;
    public Transform playerBody;
    //public Transform GUN;
    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X")*mouseSensetivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y")*mouseSensetivity * Time.deltaTime;
        
        if (Input.GetKey(KeyCode.Z))
            Cursor.lockState = CursorLockMode.None;
        
        playerBody.Rotate(Vector3.up*mouseX);

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation,-90f,90f);


        
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
        float CoolRotVal = Mathf.Clamp(mouseY*mouseX*0.5f,-20f,20f);
        
        //GUN.Rotate(Vector3.left *mouseY*0.5f);

    }
}
