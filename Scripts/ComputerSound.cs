using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ComputerSound : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public float MaxRange {get{ return maxRange;}}
    //public GameObject Message;
    private const float maxRange = 5f;

    public bool StoryPlayed = false;
    public GameController gameC;
    //public CameraShake cameraShake;
    void Start()
    {
        gameC = GameObject.FindGameObjectsWithTag("GameController")[0].GetComponent<GameController>();
    }
    public void OnStartHover()
    {
        Debug.Log("Press E");
        gameC.updateText("Press E");
        //Message.GetComponent<Text>().text = "Press E";
    }
    public void OnInteract()
    {
        //StartCoroutine(cameraShake.Shake(.15f,.15f));
        //Debug.Log("Sound Playing 1 time then bomb");
        if(StoryPlayed == false)
        {
            FindObjectOfType<AudioManager>().PlayStory();
            StoryPlayed = true;
            gameC.TimeIncrease();
            gameC.StoryReadIncrease();
            return;
        }
        FindObjectOfType<AudioManager>().Play("lensDistort");
        StartCoroutine(gameC.PostProcessChange());
        gameC.TimeDecrease();
        Debug.Log("Story Played Now BOOM BOOM");
    }
    public void OnEndHover()
    {
        Debug.Log("No need to Press E");
        gameC.updateText("");
       // Message.GetComponent<Text>().text = "";
        //Message.text = "";
    }
}
