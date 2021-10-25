using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioUI : MonoBehaviour
{
    public AudioSource clickBtn;
    public AudioSource StartSound;
    //public AudioSource StartSound;
    // Start is called before the first frame update
    void Start()
    {
        PlayStar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void PlayClick()
    {
        clickBtn.Play();
    }
    public void PlayStar()
    {
        StartSound.Play();
    }
}
