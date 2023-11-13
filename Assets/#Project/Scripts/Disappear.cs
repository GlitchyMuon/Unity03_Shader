using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        //mat = GetComponent<Renderer>().material;
        //mat.SetFloat("_DissolveLevel", 0.9f);
        StartCoroutine("DoDissolve");
    }

    IEnumerator DoDissolve() {
        float dissolveLevel;
        float dissolveDuration = 5f;
        float startTime = Time.time;

        while (Time.time < startTime + dissolveDuration) {  //si l'heure actuel est avant le temps qui devrait commencer et la durée de dissolution
            dissolveLevel = Mathf.Lerp(0, 1, (Time.time-startTime)/ dissolveDuration);  //le temps actuel moins le temps qui s'est passé 
            //(A, B, Proportion)
            mat.SetFloat("_DissolveLevel", dissolveLevel);
            yield return new WaitForEndOfFrame();
        }
        mat.SetFloat("_DissolveLevel", 1f);
    }
}
