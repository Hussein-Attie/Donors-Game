using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioSource SFXaudioSource;
    public AudioSource MusicaudioSoutce;
    public Toggle SFXToggle;
    public Toggle MusicToggle;
    public  bool SFXToggleValue;
    public  bool MusicToggleValue;
    private static SoundManager soundmanager;
   
    // Start is called before the first frame update
    private void Awake()
    {
     
            if(soundmanager == null)
            {
            soundmanager = this;
            }
            else
            {
            Destroy(gameObject);
            return;
            }
        DontDestroyOnLoad(gameObject);
   
    
       

    }
    // Update is called once per frame
    void Update()
    {

        SFXToggle = GameObject.FindGameObjectWithTag("SFXToggle").GetComponent<Toggle>();
        MusicToggle = GameObject.FindGameObjectWithTag("MusicToggle").GetComponent<Toggle>();
        SFXToggleValue = !SFXToggle.isOn;
        MusicToggleValue = !MusicToggle.isOn;
        SFXaudioSource.mute = SFXToggleValue;

        MusicaudioSoutce.mute = MusicToggleValue;

       
    }
}
