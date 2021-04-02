
using UnityEngine;

public class GunScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage = 10f;
    public float range = 100f;
    
    public GameObject bulletHole;
    public Camera fpsCam;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            shoot();
        }
    }
    void shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward,out hit,range))
        {
            Debug.Log(hit.transform.name);
            //if(bulletHole.ChickCapture.CurrentNoOfChicks < bulletHole.ChickCapture.MaxNoOfChicks)
            //{}
            GameObject bH = Instantiate(bulletHole,hit.point+new Vector3(0f,0f,-0f),Quaternion.LookRotation(hit.normal));
               
        }
    }
}
