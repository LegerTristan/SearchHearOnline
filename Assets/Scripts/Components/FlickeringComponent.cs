using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickeringComponent : MonoBehaviour
{
    [SerializeField]
    Light lightComp = null;

    WaitForSeconds flickeringWait = null;

    [SerializeField, Range(0.01f, 10f)]
    float maxFlickeringRate = 2.0f, flickeringRate = 0.1f, flickeringThreshold = 0.1f;

    float lightIntensity = 0f;

    bool isLightOn = true;

    void Start()
    {
        if (!lightComp)
            return;
        lightIntensity = lightComp.intensity;
        SetFlickeringWait();
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        Debug.Log("Flicker");
        InvertLight();
        yield return flickeringWait;
        Debug.Log("Flicker end");
        StartCoroutine(Flicker());
    }

    void SetFlickeringWait()
    {
        float _wait = flickeringRate + Random.Range(-flickeringThreshold, flickeringThreshold);
        _wait = _wait > maxFlickeringRate ? maxFlickeringRate : _wait;
        flickeringWait = new WaitForSeconds(_wait);
    }

    void InvertLight()
    {
        isLightOn = !isLightOn;
        lightComp.intensity = isLightOn ? lightIntensity : 0f;
        SetFlickeringWait();
    }
}
