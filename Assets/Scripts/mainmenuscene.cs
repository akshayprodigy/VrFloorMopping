using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public enum FadeAction
{
    FadeIn,
    FadeOut,
    FadeInAndOut,
    FadeOutAndIn
}

public class mainmenuscene : MonoBehaviour
{

    public GameObject companyLogo;
    public GameObject firstextdisplay;
    public GameObject startButtonGo;
    public GameObject firstaudiotitle;
    public GameObject firstaudio;
    public GameObject audio2;
    public GameObject pressthebuttonaudio;



    [Tooltip("The Fade Type.")]
    [SerializeField] private FadeAction fadeType;

    [Tooltip("the image you want to fade, assign in inspector")]
    [SerializeField] private Image img;

    // Start is called before the first frame update

    private void Awake()
    {
        firstextdisplay.SetActive(false);
        firstaudiotitle.SetActive(false);
        firstaudio.SetActive(false);
        audio2.SetActive(false);
        pressthebuttonaudio.SetActive(false);
    }

    void Start()
    {

        companyLogo.SetActive(true);

        startButtonGo.SetActive(false);

        StartCoroutine(enablethestartbutton());


        if (fadeType == FadeAction.FadeIn)
        {

            StartCoroutine(FadeIn());

        }

        else if (fadeType == FadeAction.FadeOut)
        {

            StartCoroutine(FadeOut());

        }

        else if (fadeType == FadeAction.FadeInAndOut)
        {

            StartCoroutine(FadeInAndOut());

        }

        else if (fadeType == FadeAction.FadeOutAndIn)
        {

            StartCoroutine(FadeOutAndIn());

        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            startButton();
        }
        
    }


    public void startButton()
    {
        SceneManager.LoadScene("VRScene");
    }


    IEnumerator enablethestartbutton()
    {
        yield return new WaitForSeconds(7f);
        companyLogo.SetActive(false);

        yield return new WaitForSeconds(1f);
        firstaudiotitle.SetActive(true);

        yield return new WaitForSeconds(3f);
        firstaudio.SetActive(true);
        firstaudiotitle.SetActive(false);

       
        yield return new WaitForSeconds(11f);
        audio2.SetActive(true);
        firstaudio.SetActive(false);
        firstaudiotitle.SetActive(false);

        yield return new WaitForSeconds(17f);
        pressthebuttonaudio.SetActive(true);
        audio2.SetActive(false);
        firstaudio.SetActive(false);
        firstaudiotitle.SetActive(false);
        //startButtonGo.SetActive(true);

        yield return new WaitForSeconds(2.3f);
        startButtonGo.SetActive(true);
        pressthebuttonaudio.SetActive(false);
        audio2.SetActive(false);
        firstaudio.SetActive(false);
        firstaudiotitle.SetActive(false);
        //startButtonGo.SetActive(true);


    }

    IEnumerator FadeIn()
    {
 
        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
 
    }
 
    // fade from opaque to transparent
    IEnumerator FadeOut()
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
 
    IEnumerator FadeInAndOut()
    {
        // loop over 1 second
        for (float i = 0; i <= 4; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
 
        //Temp to Fade Out
        yield return new WaitForSeconds(1);
 
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
 
    IEnumerator FadeOutAndIn()
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
 
        //Temp to Fade In
        yield return new WaitForSeconds(1);
 
        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
