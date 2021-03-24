using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject girl;
    public AudioSource musicAudioSource;

    public AudioSource SFXAudioSource;
    public AudioClip death;

    // Start is called before the first frame update
    void Start()
    {
        girl = GameObject.Find("Girl");
    }

    // Update is called once per frame
    void Update()
    {
        if(girl.transform.position.y <= 0){
            SFXAudioSource.clip = death;
            SFXAudioSource.Play();
        }
    }
}
