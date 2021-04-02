
using UnityEngine;

public class ExitCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider c) {
        if(c.gameObject.tag == "Player")
        {
            Debug.Log("EXIT");
            Application.Quit();
        }
    }
}
