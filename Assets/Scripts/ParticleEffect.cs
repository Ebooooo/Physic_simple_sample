using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleEffect : MonoBehaviour
{
    public Transform sparkle;
    void Start()
    {
        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }

    void Update()
    {
        
    }
    void OnTriggerEnter()
    {
        sparkle.GetComponent<ParticleSystem>().enableEmission = true;
        StartCoroutine(stopSparkles());
    }

    IEnumerator stopSparkles()
    {
        yield return new WaitForSeconds(.4f);

        sparkle.GetComponent<ParticleSystem>().enableEmission = false;
    }
}
