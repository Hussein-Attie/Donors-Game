using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class GameButtonsSFX : MonoBehaviour
{
    public AudioSource sfxGamep1;
    public AudioSource sfxGamep2;
    public Toggle SFXToggle;
    bool SFXToggleValue;
    void Start()
    {
        sfxGamep1 = GameObject.FindGameObjectWithTag("SFXGamep1").GetComponent<AudioSource>();
        sfxGamep2 = GameObject.FindGameObjectWithTag("SFXGamep2").GetComponent<AudioSource>();

    }
    // Update is called once per frame
    void Update()
    {
        SFXToggleValue = !SFXToggle.isOn;
 
        sfxGamep1.mute = SFXToggleValue;

        sfxGamep2.mute = SFXToggleValue;

    }

    public void DownSound()
    {
        sfxGamep1.Play();
    }
    public void UpSound()
    {

        sfxGamep2.Play();
    }
   
}
