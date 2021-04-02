using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Text press;
    public Text TimeDisp;
    public PostProcessVolume postProfile;
    public PostProcessVolume postProfileHealth;

    public float DistortDuration = 20f ;

    float currentTime = 0f;
    public float TotalTime = 60f;
    public float PenaltyTime = 30f ;
    public float EmergencyTime = 50f ;

    public GameObject sphereGroup;
    public GameObject barrierGroup;

    int storyRead = 0;
    public int MinStoryReadEnd = 2;
    public int MinStoryReadBarrier = 1;

    bool isPostProcessHealthActive = false;
    bool isdying = false;

    // Start is called before the first frame update
    void Start() {
        //PostProcessHealthActive();
        currentTime = TotalTime;
    }
    public void updateText(string s)
    {
        press.text = s;
    }
    public void TimeIncrease()
    {
        currentTime += PenaltyTime;
    }
    public void StoryReadIncrease()
    {
        storyRead += 1;
        Debug.Log("Story Read : "+storyRead);
        if(storyRead>MinStoryReadBarrier)
        {
            barrierGroup.SetActive(false);
        }
        if(storyRead>MinStoryReadEnd)
        {
            sphereGroup.SetActive(true);
        }
    }
    public void TimeDecrease()
    {
        currentTime -= PenaltyTime;
    }
    void Update() {
        currentTime-=(1.0f * Time.deltaTime);
        //Debug.Log((int)currentTime);
        TimeDisp.text = ""+(int)currentTime;
        if(currentTime<EmergencyTime && isPostProcessHealthActive == false)
        {
            isPostProcessHealthActive = true;
            FindObjectOfType<AudioManager>().Play("Dying");
            PostProcessHealthActive();
        }
        if(currentTime>EmergencyTime && isPostProcessHealthActive == true)
        {
            isPostProcessHealthActive = false;
            PostProcessHealthDeactive();
        }
        if(currentTime<6 && isdying == false)
        {
            isdying = true;
            FindObjectOfType<AudioManager>().Play("Dying");
            updateText("SAD STORY SHORT : YOU ARE AlMOST DEAD :)");
        }
        if(currentTime>6 && isdying == true)
        {
            isdying = false;
        }
        if(currentTime<0)
        {
            updateText("NOW YOU ARE ACTUALLY DEAD");
            StartCoroutine(LoadMenuScene());
        }
    }
    IEnumerator LoadMenuScene()
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MenuScene");
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    public IEnumerator PostProcessChange()
    {
        float elapsed = 0.0f;
        float duration = 5f;
        postProfile.enabled = true;        
        while(elapsed < duration)
        {
            postProfile.weight=Mathf.Lerp(0,1,elapsed/duration);
            yield return null;
            elapsed += Time.deltaTime;
        }
      
        
        yield return new WaitForSeconds(DistortDuration);
        
      
        elapsed = 0.0f;
        while(elapsed < duration)
        {
            postProfile.weight=Mathf.Lerp(1,0,elapsed/duration);
            yield return null;
            elapsed += Time.deltaTime;
        }
        postProfile.enabled = false;
        
    }
    public void PostProcessHealthActive()
    {
        postProfileHealth.enabled = true;         
    }
    public void PostProcessHealthDeactive()
    {
        postProfileHealth.enabled = false;         
    }
}
