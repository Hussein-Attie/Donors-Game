using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class ExpMeter : MonoBehaviour
{
   
    private RectTransform rect;
    private float posymax = 1.65f;

    public static bool shouldlerp = false;
    public static float timestartedlerping;
    private float lerptime;
    Vector2 newpos;
    private bool Increaselevel;
    public Animator animator;
    public Animator Levetxtanim;
    public TextMeshProUGUI LevelText;
    private AudioSource LevelUpFx;
    public static  void StartLerping()
    {
        timestartedlerping = Time.time;
        shouldlerp = true;
       
    }
    // Start is called before the first frame update
    void Start()
    {
        rect = gameObject.GetComponent<RectTransform>();
        LevelUpFx = GameObject.FindGameObjectWithTag("LevelUpfx").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        LevelText.text = ExpManager.level.ToString();


        newpos = new Vector3(rect.localPosition.x, ExpManager.percentage * posymax, rect.localPosition.z);
       rect.localPosition = Lerp(rect.localPosition, newpos, timestartedlerping, 30f);

        if(PlayerPrefs.GetFloat("Exp") == ExpManager.expmax)
        {
           Increaselevel= true;
            StartCoroutine(resetlevel());
          
        }

        if(PlayerPrefs.GetFloat("Exp") > ExpManager.expmax)
        {
            ExpManager.exp = ExpManager.expmax;
            PlayerPrefs.SetFloat("Exp", ExpManager.exp);
        }
        


        
           
        

      if(Input.GetKeyDown(KeyCode.Space))
      {
            
            ExpManager.exp += 0.25f;
            PlayerPrefs.SetFloat("Exp", ExpManager.exp);
            StartLerping();
            animator.Play("wave4");
           
        }
    
    }
    public Vector3 Lerp( Vector3 start , Vector3 end , float timestartedlerping , float lerptime = 1)
    {
        float timesincestarted = Time.time - timestartedlerping;
        float percentagecomplete = timesincestarted / lerptime;
        var result = Vector3.Lerp(start, end, percentagecomplete);
        return result;
    }
    public IEnumerator resetlevel()
    {
       

        yield return new WaitForSeconds(2f);
       
        ExpManager.exp = 0;
        PlayerPrefs.SetFloat("Exp", ExpManager.exp);
        if (Increaselevel)
        {
            ExpManager.level++;
            PlayerPrefs.SetInt("Level", ExpManager.level);
            Levetxtanim.Play("leveltxtanim");
            LevelUpFx.Play();
            Increaselevel = false;
          

        }
    }
  
}
