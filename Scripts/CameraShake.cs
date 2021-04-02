using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPos = transform.localPosition;
        float elapsed = 0.0f;
        while((elapsed < duration) && (elapsed%1==0))
        {
            float x = Random.Range(-7f,7f)*magnitude;
            //float y = Random.Range(-5f,5f)*magnitude;
            //float z = Random.Range(-5f,5f)*magnitude;
            //transform.Rotate(new Vector3(0.0f,0.0f,z));
            float st = GetComponent<Camera>().fieldOfView + x;
            st = Mathf.Clamp(st,50f,70f);
            GetComponent<Camera>().fieldOfView = st;
            elapsed += Time.deltaTime;
            
            yield return null;
            
        }
        transform.localPosition = originalPos;
    }
}
