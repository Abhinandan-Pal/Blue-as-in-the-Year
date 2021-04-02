using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRaycasting : MonoBehaviour
{
    // Start is called before the first frame update
    //[SerializeFeild]
    public float range;
    private IInteractable currentTarget; 
    private Camera mainCamera;
    
    private void Awake() 
    {
        mainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        RayCastForInteractable();
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(currentTarget != null)
            {
                currentTarget.OnInteract();
                GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameController>().updateText("");
               //currentTarget.OnEndHover();
                currentTarget = null;
            }
        }
    }
    private void RayCastForInteractable()
    {
        RaycastHit whatIHit;
        //Ray ray = mainCamera.ScreenPointToRay(new Vector3(Screen.width / 2, (Screen.height / 2, 0)));

        if(Physics.Raycast(mainCamera.transform.position, mainCamera.transform.forward,out whatIHit, range))
        {
            IInteractable  interactable = whatIHit.collider.GetComponent<IInteractable>();

            if(interactable != null)
            {
                if(whatIHit.distance <= interactable.MaxRange)
                {
                    if(interactable == currentTarget)
                    {
                        return;
                    }
                    else if(currentTarget != null)
                    {
                        GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameController>().updateText("");
                        //currentTarget.OnEndHover();
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;
                    }
                    else
                    {
                        currentTarget = interactable;
                        currentTarget.OnStartHover();
                        return;   
                    }
                }
            }
        }
        if(currentTarget != null)
        {
            GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameController>().updateText("");
            //currentTarget.OnEndHover();
            currentTarget = null;
        }
        return;
    }
}
