using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayCollider : MonoBehaviour
{
    void OnTriggerEnter(Collider c) {
        if(c.gameObject.tag == "Player")
        {
            Debug.Log("PLAY");
            //Application.LoadLevel("MainGame");
            StartCoroutine(LoadYourAsyncScene());
            
        }
    }
    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainGame");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
