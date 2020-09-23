using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class Buttons : MonoBehaviour
{
    public AudioSource sfx;
    public GameObject puasebutton;
    GameManagerTwo GMT;
    // Start is called before the first frame update
    void Start()
    {
        sfx = GameObject.FindGameObjectWithTag("SFX").GetComponent<AudioSource>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameManagerTwo.score = 0;
        Time.timeScale = 1;
        sfx.Play();
        puasebutton.SetActive(true);
      
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
        sfx.Play();
        GameManagerTwo.score = 0;

    }
    public void StartTheGame()
    {
        SceneManager.LoadScene(1);
        sfx.Play();
    }
    public void Exit()
    {
        Application.Quit();
        sfx.Play();
    }
    public void PlayClick()
    {
        sfx.Play();
    }
    public void StopTime()
    {
        Time.timeScale = 0;

    }
    public void ContinueTime()
    {
        Time.timeScale = 1;

    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Level", 1);
    }
}
