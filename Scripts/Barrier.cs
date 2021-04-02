using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public float MaxRange {get{ return maxRange;}}
    //public Text Message;
    private const float maxRange = 5f;
    public GameController gameC;
    void Start()
    {
        gameC = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameController>();
    }
     public void OnStartHover()
    {
        gameC.updateText("I NEED TO KNOW MORE BEFORE THAT PATH");
    }
    public void OnInteract()
    {

    }
    public void OnEndHover()
    {
        gameC.updateText("");
    }
}
