using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIExpMeter : MonoBehaviour
{
    public RectTransform rect;


    private float posymax = 145.8f;

    public static bool shouldlerp = false;
    public static float timestartedlerping;
    private float lerptime;

    Vector2 newpos;

    public Animator animator;

   

    public TextMeshProUGUI leveltxt;
    private bool Increaselevel;

    public AudioSource levelupSFX;

    public Animator Leveltextanim;

    bool scenestarted;

    private Vector3 oldpos;
    private AudioSource LevelUpFx;
   
    public static void StartLerping()
    {
        timestartedlerping = Time.time;
        shouldlerp = true;

    }
    // Start is called before the first frame update
    void Start()
    {
        LevelUpFx = GameObject.FindGameObjectWithTag("LevelUpfx").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
      
     


        
        leveltxt.text = ExpManager.level.ToString();
        newpos = new Vector3(rect.localPosition.x, ExpManager.percentage * posymax, rect.localPosition.z);
      
        if (PlayerPrefs.GetFloat("Exp") >= ExpManager.expmax)
        {
            Increaselevel = true;
            StartCoroutine(resetlevel());

        }

      

     
        
            rect.localPosition = Lerp(rect.localPosition, newpos, timestartedlerping, 30f);
           

        
        

    }
    public Vector3 Lerp(Vector3 start, Vector3 end, float timestartedlerping, float lerptime = 1)
    {
        float timesincestarted = Time.time - timestartedlerping;
        float percentagecomplete = timesincestarted / lerptime;
        var result = Vector3.Lerp(start, end, percentagecomplete);
        return result;
    }
    public IEnumerator resetlevel()
    {

        yield return new WaitForSeconds(4f);


        ExpManager.exp = 0;
        PlayerPrefs.SetFloat("Exp", ExpManager.exp);
        if (Increaselevel)
        {
            ExpManager.level++;
            PlayerPrefs.SetInt("Level", ExpManager.level);
            Leveltextanim.Play("leveltxtanimUI");
            LevelUpFx.Play();
            Increaselevel = false;
 
           
        }
    }
}