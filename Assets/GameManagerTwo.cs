using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;
using UnityEngine.UI;
//using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class GameManagerTwo : MonoBehaviour
{
    #region 
    public List<GameObject> Donors = new List<GameObject>();

    public Transform donorhandler;
    int random;

    public GameObject GameOverScreeen;
    public GameObject puasebutton;
    public GameObject A_Donor;
    public GameObject B_Donor;
    public GameObject AB_Donor;
    public GameObject O_Donor;

    private int A_Needed;
    private int B_Needed;
    private int AB_Needed;
    private int O_Needed;

    private int A_Supplied;
    private int AB_Supplied;
    private int B_Supplied;
    private int O_Supplied;

    private int A_Remain;
    private int B_Remain;
    private int AB_Remain;
    private int O_Remain;

    private int wave =0;

    public TextMeshProUGUI WaveCounter;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI HighScore;

    public TextMeshProUGUI EndWaveCounter;
    public TextMeshProUGUI EndScoreText;
    public TextMeshProUGUI EndHighScore;


    public static int score;
    private int highscore;

    public TextMeshProUGUI A_Statstxt;
    public TextMeshProUGUI B_Statstxt;
    public TextMeshProUGUI AB_Statstxt;
    public TextMeshProUGUI O_Statstxt;

    int AGenerate;
    int BGenerate;
    int ABGenerate;
    int OGenerate;
    private float bounostime ;
    public int A_DestroyedByAB;

    public Button AButton;
    public Button BButton;
    public Button ABButton;
    public Button OButton;

    public RectTransform[] buttonposition;
    public int[] randomNumbers = { 0, 1, 2, 3 };
    public Transform CenterPosition;
    public TextMeshProUGUI comboTxt;
    private int combo;

    private float combotimer=1f;
    private float combotimervalue = 1f;
    private bool opencombo;
    public RectTransform comboTxtRec;

    public GameObject BigWaveCounter;
    public TextMeshProUGUI BigWaveText;
    public GameObject newhighscore;

    public Animator anim;

    public AudioSource powerupone;
    public AudioSource poweruptwo;
    public AudioSource gameover;
    public AudioSource waveclear;

    public ParticleSystem timeparticles;
    public ParticleSystem expparticles;
    public ParticleSystem wavedoneparticles;
    public Image buttonimage1;

    public GameObject puasemenu;
    #endregion variables

    void Start()
    {
        powerupone = GameObject.FindGameObjectWithTag("powerup1").GetComponent<AudioSource>();
        poweruptwo = GameObject.FindGameObjectWithTag("powerup2").GetComponent<AudioSource>();
        gameover = GameObject.FindGameObjectWithTag("gameover").GetComponent<AudioSource>();
        waveclear = GameObject.FindGameObjectWithTag("wavecomplete").GetComponent<AudioSource>();

        StartCoroutine(SetWaveObjectFalse());
        HighScore.text ="H.S: " + PlayerPrefs.GetInt("HighScore", 0).ToString();
        Donors.Add(A_Donor);
        Donors.Add(B_Donor);
        Donors.Add(AB_Donor);
        Donors.Add(O_Donor);
        wave++;
        AGenerate = Random.Range(1, 4);
        BGenerate = Random.Range(1, 4);
        ABGenerate = Random.Range(1, 4);
        OGenerate = Random.Range(1, 4);
        ShuffleButtons();
        if (newhighscore.activeSelf)
        {

            newhighscore.SetActive(false);
        }
        else
        { return; }



        for (int i = 0; i <= AGenerate; i++)
        {
            Instantiate(A_Donor, donorhandler);
        }
        for (int i = 0; i <= BGenerate; i++)
        {
            Instantiate(B_Donor, donorhandler);
        }
        for (int i = 0; i <= ABGenerate; i++)
        {
            Instantiate(AB_Donor, donorhandler);
        }
        for (int i = 0; i <= OGenerate; i++)
        {
            Instantiate(O_Donor, donorhandler);
        }

        for (int i = 0; i <= donorhandler.childCount - 1; i++)
        {
            donorhandler.GetChild(i).SetSiblingIndex(Random.Range(0, donorhandler.childCount));
        }
        foreach (Transform child in donorhandler)
        {
            child.gameObject.SetActive(false);
        }
        if (donorhandler.childCount > 0)
        {
            donorhandler.GetChild(0).gameObject.SetActive(true);

        }
        if (donorhandler.childCount > 0)
        {
            for (int i = 1; i >= donorhandler.childCount; i++)
            {
                donorhandler.GetChild(i).gameObject.SetActive(false);
            }
        }

    }

    void Update()
    {
        Debug.Log(Time.timeScale);
        WaveCounter.text = "Wave: " + wave.ToString();
        comboTxt.text = "ComboX"+ combo.ToString();
        ScoreText.text = "Score: " + score.ToString();
      
        
        if (BigWaveText != null)
        {
        BigWaveText.text = "Wave: " + wave.ToString(); 
        }
        A_Remain = (AGenerate + 1) - A_Supplied;
        B_Remain = (BGenerate + 1) - B_Supplied;
        AB_Remain = (ABGenerate + 1) - AB_Supplied;
        O_Remain = (OGenerate + 1) - O_Supplied;

        //A_Statstxt.text = A_Remain.ToString();
        //B_Statstxt.text = (B_Remain).ToString();
        //AB_Statstxt.text = AB_Remain.ToString();
        //O_Statstxt.text = O_Remain.ToString();

        DisableButton(AButton ,A_Remain);
        DisableButton(BButton, B_Remain);
        DisableButton(ABButton, AB_Remain);
        DisableButton(OButton, O_Remain);

        if (A_Remain == 0 && B_Remain == 0 && AB_Remain == 0 && O_Remain == 0)
        {
            StartCoroutine(GenerateWave());
            ExpManager.exp += 0.5f;
            PlayerPrefs.SetFloat("Exp", ExpManager.exp);
            ExpMeter.StartLerping();
            anim.Play("wave4");
        }

    
        if (donorhandler.childCount > 0)
        {
            donorhandler.GetChild(0).gameObject.SetActive(true);

        }

        if (AB_Remain == 0)
        {
            
            foreach (Transform child in donorhandler)
            {
                if (child.CompareTag("AB"))
                {
                    Destroy(child.gameObject);
                }
            }
        }
        if (O_Remain == 0)
        {
            foreach (Transform child in donorhandler)
            {
                if (child.CompareTag("O"))
                {
                    Destroy(child.gameObject);
                }
            }
        }
        if (B_Remain == 0)
        {
            foreach (Transform child in donorhandler)
            {
                if (child.CompareTag("B"))
                {
                    Destroy(child.gameObject);
                }
            }
        }
        if (A_Remain == 0)
        {
            foreach (Transform child in donorhandler)
            {
                if (child.CompareTag("A"))
                {
                    Destroy(child.gameObject);
                }
            }
        }


        if (opencombo)
        {

            combotimer -= Time.deltaTime;
        }
        if (combotimer <= 0)
        {
            opencombo = false;
            combotimer = combotimervalue;
            combo = 0;
           
        }
        if (combotimer >= combotimervalue)
        {
            combotimer = combotimervalue;
        }
        if(combotimer <0)
        {
            combotimer = 0;
        }
        if (combo >= 3)
        {
            LeanTween.moveX(comboTxtRec, -51, 0.2f);
            
            //comboTxtRec.position = new Vector2(0, 0);
        }
        else
        {
            LeanTween.moveX(comboTxtRec, 437, 0.2f);
        }

        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {
            newhighscore.SetActive(true);
            PlayerPrefs.SetInt("HighScore", score);
            HighScore.text = "H.S: " + score.ToString();
            
        }
       
       
        if(Input.GetKeyDown(KeyCode.Escape))
        { 
            if (!puasemenu.activeSelf)
            {
                puasemenu.SetActive(true);
                Time.timeScale = 0f;
            }
            else if(puasemenu.activeSelf)
            {

                puasemenu.SetActive(false);
                Time.timeScale = 1f;
            }
        }
     

    }
    public void ActivateNext()
    {
        if (donorhandler.childCount > 1)

            donorhandler.GetChild(1).gameObject.SetActive(true);
        bounostime = 0.25f;
        Timer.timeleft += bounostime;
        score++;
       
    }
    public void Abutton()
    {
        if (donorhandler.childCount > 0)
        {
            if (donorhandler.GetChild(0).gameObject.CompareTag("A"))
            {
                // Destroy(donorhandler.GetChild(0).gameObject);
                DestroyObject(donorhandler.GetChild(0).gameObject);
                A_Supplied++;
            }
            else if (donorhandler.GetChild(0).gameObject.CompareTag("O"))
            {

                Instantiate(O_Donor, donorhandler);
                // Destroy(donorhandler.GetChild(0).gameObject);
                DestroyObject(donorhandler.GetChild(0).gameObject);
                A_Supplied++;
                for (int i = 0; i <= donorhandler.childCount - 1; i++)
                {
                    donorhandler.GetChild(i).SetSiblingIndex(Random.Range(0, donorhandler.childCount));
                }


            }
            else
            {
                GameOver();
            }

            foreach (Transform child in donorhandler)
            {
                child.gameObject.SetActive(false);
            }
            if (donorhandler.childCount > 0)
            {
                donorhandler.GetChild(0).gameObject.SetActive(true);

            }
        }
    }
    public void Bbutton()
    {
        if (donorhandler.childCount > 0)
        {
            if (donorhandler.GetChild(0).gameObject.CompareTag("B"))
            {
                // Destroy(donorhandler.GetChild(0).gameObject);
                DestroyObject(donorhandler.GetChild(0).gameObject);
                B_Supplied++;
            }
            else if (donorhandler.GetChild(0).gameObject.CompareTag("O"))
            {

                Instantiate(O_Donor, donorhandler);
                // Destroy(donorhandler.GetChild(0).gameObject);
                DestroyObject(donorhandler.GetChild(0).gameObject);
                B_Supplied++;
                for (int i = 0; i <= donorhandler.childCount - 1; i++)
                {
                    donorhandler.GetChild(i).SetSiblingIndex(Random.Range(0, donorhandler.childCount));
                }


            }
            else
            {
                GameOver();
            }

            foreach (Transform child in donorhandler)
            {
                child.gameObject.SetActive(false);
            }
            if (donorhandler.childCount > 0)
            {
                donorhandler.GetChild(0).gameObject.SetActive(true);

            }

        }
    }
    public void ABbutton()
    {
        if (donorhandler.childCount > 0)
        {
            if (donorhandler.GetChild(0).gameObject.CompareTag("A"))
            {

                Instantiate(A_Donor, donorhandler);

                for (int i = 0; i <= donorhandler.childCount - 1; i++)
                {
                    donorhandler.GetChild(i).SetSiblingIndex(Random.Range(0, donorhandler.childCount));
                }


            }
            if (donorhandler.GetChild(0).gameObject.CompareTag("B"))
            {
                Instantiate(B_Donor, donorhandler);

                for (int i = 0; i <= donorhandler.childCount - 1; i++)
                {
                    donorhandler.GetChild(i).SetSiblingIndex(Random.Range(0, donorhandler.childCount));
                }


            }

            if (donorhandler.GetChild(0).gameObject.CompareTag("O"))
            {
                Instantiate(O_Donor, donorhandler);

                for (int i = 0; i <= donorhandler.childCount - 1; i++)
                {
                    donorhandler.GetChild(i).SetSiblingIndex(Random.Range(0, donorhandler.childCount));
                }

            }

            //Destroy(donorhandler.GetChild(0).gameObject);
            DestroyObject(donorhandler.GetChild(0).gameObject);

            AB_Supplied++;
            foreach (Transform child in donorhandler)
            {
                child.gameObject.SetActive(false);
            }
            if (donorhandler.childCount > 0)
            {
                donorhandler.GetChild(0).gameObject.SetActive(true);

            }
            if (donorhandler.GetChild(0).CompareTag("AB"))
            {


                if (donorhandler.GetChild(0).gameObject.GetComponent<Person>().powernumber == 1 || donorhandler.GetChild(0).gameObject.GetComponent<Person>().powernumber == 13)
                {
                    Timer.timeleft += 20f;
                    powerupone.Play();
                    timeparticles.Play();
                }

                if (donorhandler.GetChild(0).gameObject.GetComponent<Person>().powernumber == 2 || donorhandler.GetChild(0).gameObject.GetComponent<Person>().powernumber == 24)
                {
                    ExpManager.exp += 1;
                    PlayerPrefs.SetFloat("Exp", ExpManager.exp);
                    poweruptwo.Play();
                    expparticles.Play();
                }
                if (donorhandler.GetChild(0).gameObject.GetComponent<Person>().powernumber == 19)
                {
                    wavedoneparticles.Play();
                    StartCoroutine(GenerateWave());
                    ExpManager.exp += 0.5f;
                    PlayerPrefs.SetFloat("Exp", ExpManager.exp);
                    ExpMeter.StartLerping();
                    anim.Play("wave4");
                }
            }
        }
    }
    public void Obutton()
    {
        if (donorhandler.childCount > 0)
        {
            if (donorhandler.GetChild(0).gameObject.CompareTag("O"))
            {
                // Destroy(donorhandler.GetChild(0).gameObject);
                DestroyObject(donorhandler.GetChild(0).gameObject);
                O_Supplied++;
            }
            else
            {
                GameOver();
            }
        }
    }
    public IEnumerator GenerateWave()
    {
      
        //anim.Play("wave4");
        wave++;
        waveclear.Play();
        BigWaveCounter.SetActive(true);
        AGenerate = Random.Range(wave, wave * 2 + 1);
        BGenerate = Random.Range(wave, wave * 2 + 1);
        ABGenerate = Random.Range(wave, wave * 2 + 1);
        OGenerate = Random.Range(wave, wave * 2 + 1);

        A_Supplied =0;
        B_Supplied = 0;
        AB_Supplied = 0;
        O_Supplied = 0;
        Timer.maxtime += 5;
        Timer.timeleft = Timer.maxtime;
        ShuffleButtons();
        yield return new WaitForSeconds(2f);
        BigWaveCounter.SetActive(false);
        Timer.timeleft = Timer.maxtime;
        for (int i = 0; i <= AGenerate; i++)
        {
            Instantiate(A_Donor, donorhandler);
        }
        for (int i = 0; i <= BGenerate; i++)
        {
            Instantiate(B_Donor, donorhandler);
        }
        for (int i = 0; i <= ABGenerate; i++)
        {
            Instantiate(AB_Donor, donorhandler);
        }
        for (int i = 0; i <= OGenerate; i++)
        {
            Instantiate(O_Donor, donorhandler);
        }

        for (int i = 0; i <= donorhandler.childCount - 1; i++)
        {
            donorhandler.GetChild(i).SetSiblingIndex(Random.Range(0, donorhandler.childCount));
        }
        foreach (Transform child in donorhandler)
        {
            child.gameObject.SetActive(false);
        }
        if (donorhandler.childCount > 0)
        {
            donorhandler.GetChild(0).gameObject.SetActive(true);

        }

        foreach (Transform child in donorhandler)
        {
            Destroy(child);
        }

        
    }

    public void DestroyObject(GameObject obj)
    {

        Destroy(obj, 0.01f);

        opencombo = true;
        combo++;
        if (opencombo)
        {
            combotimer += combotimervalue;
        }

        if (obj.GetComponent<Person>().powernumber == 1 ||  obj.GetComponent<Person>().powernumber == 13)
        {
            Timer.timeleft += 20f;
            powerupone.Play();
            timeparticles.Play();
        }

        if (obj.GetComponent<Person>().powernumber ==2|| obj.GetComponent<Person>().powernumber == 24)
        {
            ExpManager.exp += 1;
            PlayerPrefs.SetFloat("Exp", ExpManager.exp);
            poweruptwo.Play();
            expparticles.Play();
        }
       if (obj.GetComponent<Person>().powernumber == 19)
        {
            wavedoneparticles.Play();
            StartCoroutine(GenerateWave());
            ExpManager.exp += 0.5f;
            PlayerPrefs.SetFloat("Exp", ExpManager.exp);
            ExpMeter.StartLerping();
            anim.Play("wave4");
        }
      
    }

    public void DisableButton(Button button , int remain)
    {
        if(remain <=0)
        {
            button.image.color = new Color(1, 1, 1, 0.65f);
            button.interactable = false;
        }
        else
        {
            button.image.color = new Color(1, 1, 1, 1f);
            button.interactable = true;
        }
    }

    void GameOver()
    {
        Time.timeScale = 0;
        gameover.Play();
        GameOverScreeen.SetActive(true);
        donorhandler.gameObject.SetActive(false);
        combotimer = 0;
        puasebutton.SetActive(false);
        EndHighScore.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
        EndScoreText.text = ScoreText.text;
        EndWaveCounter.text = "Waves: " + wave.ToString();
       
    }
    public IEnumerator SetWaveObjectFalse()
    {
        BigWaveCounter.SetActive(true);

        yield return new WaitForSecondsRealtime(2f);
      
        BigWaveCounter.SetActive(false);
        
       
    }
    public void ContinueAfterVideo ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ShuffleButtons()
    {
        for (int i = 0; i < randomNumbers.Length; i++)
        {
            int num = randomNumbers[i];
            int randomizearray = Random.Range(0, i);
            randomNumbers[i] = randomNumbers[randomizearray];
            randomNumbers[randomizearray] = num;
        }
        if (wave > 1)
        {
            MoveButtons();
        }
        else
        {
            AButton.transform.position = buttonposition[randomNumbers[0]].position;
            BButton.transform.position = buttonposition[randomNumbers[1]].position;
            ABButton.transform.position = buttonposition[randomNumbers[2]].position;
            OButton.transform.position = buttonposition[randomNumbers[3]].position;
        }
    }

    private void MoveButtons()
    {
        
        LeanTween.move(AButton.gameObject, CenterPosition.position, 1f);
        LeanTween.move(BButton.gameObject, CenterPosition.position, 1f);
        LeanTween.move(ABButton.gameObject, CenterPosition.position, 1f);
        LeanTween.move(OButton.gameObject, CenterPosition.position, 1f);

        LeanTween.move(AButton.gameObject,  buttonposition[randomNumbers[0]].position, 1f);
        LeanTween.move(BButton.gameObject,  buttonposition[randomNumbers[1]].position, 1f);
        LeanTween.move(ABButton.gameObject, buttonposition[randomNumbers[2]].position, 1f);
        LeanTween.move(OButton.gameObject,  buttonposition[randomNumbers[3]].position, 1f);
    }
}
