using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChickCapture : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public float MaxRange {get{ return maxRange;}}
    //public Text Message;
    private const float maxRange = 5f;
    
    //public CameraShake cameraShake;
    public static int MaxNoOfChicks = 10;
    public static int CurrentNoOfChicks = 0;
    public GameController gameC;
    public void Start() {
            
         CurrentNoOfChicks++;
         gameC = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameController>();
         if(CurrentNoOfChicks>MaxNoOfChicks)
         {
            gameC.updateText("NO AMMO");
            Debug.Log("Destroy");
            OnInteract();
            gameC.updateText("NO AMMO");
            return;
         }
          Debug.Log("CurrentNoOfChicks = "+CurrentNoOfChicks);
    }
    public void OnStartHover()
    {
        Debug.Log("Press E");
        gameC.updateText("Press E");
       // Message.text = "Press E";
    }
    public void OnInteract()
    {
        //StartCoroutine(cameraShake.Shake(.15f,.15f));
        CurrentNoOfChicks--;
        Destroy(gameObject);
    }
    public void OnEndHover()
    {
        gameC.updateText("");
        //if(gameObject != null)
        //{Debug.Log("No need to Press E");}
        
        //Message.text = "";
    }
}
