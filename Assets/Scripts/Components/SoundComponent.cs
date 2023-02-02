 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundComponent : MonoBehaviour
{
    [SerializeField] List<AudioClip> allSources = new List<AudioClip> ();
    [SerializeField] AudioSource source;
    float timer = 0;
    float timerMax = 5;

    void Start()
    {
        timerMax = Random.Range(30, 60);
        Debug.Log(timerMax);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > timerMax)
        {
            timer = 0;
            timerMax = Random.Range(30, 60);
            source.clip = allSources[Random.Range(0,allSources.Count-1)];
            source.Play();
            Debug.Log("Play Sound");
            Debug.Log(source.clip);
        }
    }
}
