using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class conceptoffirstair : MonoBehaviour
{
    public GameObject arrowanimation;
    public GameObject spotlights;

    public GameObject fallenvail;
    public GameObject mainvail;
    public MeshRenderer fallenvailmesh;

    public GameObject[] handPointers;

    public AudioSource entranceVRAudioSource;
    public AudioClip[] EntranceVRaudioclips;

    public GameObject cameraOVR;
    public GameObject teleportarea;
    public OVRScreenFade fadecame;

    //EntranceVR Audio
    public GameObject entrancevraudio;
    public GameObject entrancevraudio1;

    //MainButtons
    public GameObject mainButtons;


    //TeleportImage
    public GameObject enableconceptairteleportbutton;
    public Button teleportinteractable;

    public AudioSource ourAudioSource;

    //Buttons
    public Button conceptAirButtoninteract;

    //Removeglass

    public GameObject removeglass;


    //BlueLight
    public GameObject blueLight;

    //EnableParticles
    public GameObject particles;
    public ParticleSystem smallparticle;

    //EnableSmoke
    public GameObject smokeParticle;
    public ParticleSystem[] smokes;


    public GameObject valueimagnonviable;


    public AudioClip audio1;
    public AudioClip audio2;
    public AudioClip audio3;
    public AudioClip audio4;
    public AudioClip audio5; //Before we move further, in order to get a better view of inside, let us make the glass pane invisible (mp3cut.net)
    public AudioClip audio6; //In absence of any environmental control, there are always suspended (mp3cut.net)
    public AudioClip audio7;
    public AudioClip audio8;

    //Particlesvaibleandnonviable
    public GameObject particlesmainPanel;
    public GameObject viableparticleaudiosource;

    public Button viableparticlebutton;
    public Button nonviableparticlebutton;

    //Animation


    public AudioSource nonviableparticleaudiosource;

    public AudioClip NonViableaudio1;
    public AudioClip NonViableaudio2;
    public AudioClip NonViableaudio3;
    public AudioClip NonViableaudio4;
 //   public AudioClip NonViableaudio5;
    public AudioClip NonViableaudio6;
    public AudioClip NonViableaudio7;
    public AudioClip NonViableaudio8;
    public AudioClip NonViableaudio9;
    public AudioClip NonViableaudio10;
    public AudioClip NonViableaudio11;


    public Button letscontinuebuttoninnonviableparticle;

    public GameObject[] anims;
   


    public AudioSource firstAirAudiosource;
    public AudioClip[] firstairaudioclips;


    public Button firstairbuttoninteractable;

    public GameObject threeimportantfeaturesoffirstair;

    public Button filterdcleanairbutton;
    public Button Unidirectionalflow;
    public Button Uninterruptedflow;
    public Button continueButton;

   

    private void Awake()
    {
        mainvail.SetActive(true);
        fallenvail.SetActive(false);

        
        spotlights.SetActive(true);
        mainButtons.SetActive(false);
        //  entrancevraudio1.SetActive(false);
        conceptAirButtoninteract.interactable = false;
        blueLight.SetActive(false);
        removeglass.SetActive(true);
        particles.SetActive(false);
        smallparticle.Stop();
        smokeParticle.SetActive(false);
        teleportinteractable.interactable = false;

        //particlemainpanel

        particlesmainPanel.SetActive(false);
        viableparticleaudiosource.SetActive(false);
        //nonviableparticleaudiosource.SetActive(false);
        anims[0].SetActive(false);
        anims[1].SetActive(false);

        valueimagnonviable.SetActive(false);
        threeimportantfeaturesoffirstair.SetActive(false);

        firstairbuttoninteractable.interactable = false;

         filterdcleanairbutton.interactable = false;
         Unidirectionalflow.interactable = false;
        Uninterruptedflow.interactable = false;
        continueButton.interactable = false ;

        // vailtransform.transform.position = new Vector3(0, 0.4890001f, -0.045f);
        //vailtransform.transform.rotation = Quaternion.Euler(0, 0, 0);


        arrowanimation.SetActive(false);
    }

    private void Start()
    {

        enableconceptairteleportbutton.SetActive(false);
        entrancevraudio.SetActive(true);

        StartCoroutine(playEntranceAudioatstart());

        //smallparticle = GameObject.Find("ParticleSystemSMall").GetComponent<ParticleSystem>();
    }





    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            conceptofairteleport();
            

        }


        if (Input.GetKeyDown(KeyCode.F1))
        {
            StartCoroutine(playingaudio1andaudio2coceptoffirstair());
        }


        //playviableparticleaudio

        if (Input.GetKeyDown(KeyCode.V))
        {
            StartCoroutine(viableparticletimeraudio());
        }

        //nonplayviableparticleaudio
        if (Input.GetKeyDown(KeyCode.N))
        {
            StartCoroutine(nonviableparticletimeraudio());
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            StartCoroutine(letscontinuebtncoorutine());
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            firstAir();
        }


        if (Input.GetKeyDown(KeyCode.Z))
        {
            FilteredCleanAir();
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            unidirectionalflow();
        }


        if (Input.GetKeyDown(KeyCode.Y))
        {
            uninterruptedflow();
        }


        if (Input.GetKeyDown(KeyCode.M))
        {
            contineButton();
        }

    }


    //EntranceAudio

    IEnumerator playEntranceAudioatstart()
    {


        yield return new WaitForSeconds(4f);
        print("Playing Entrace VR audio1");
        entranceVRAudioSource.PlayOneShot(EntranceVRaudioclips[0]);


        yield return new WaitForSeconds(30f);
        print("Playing Entrace VR audio2");
        entranceVRAudioSource.PlayOneShot(EntranceVRaudioclips[1]);

       


        yield return new WaitForSeconds(30f);
        print("Playing Entrace VR audio3");
        entranceVRAudioSource.PlayOneShot(EntranceVRaudioclips[2]);
        mainButtons.SetActive(true);


        yield return new WaitForSeconds(5f);
        print("Playing Entrace VR audio4");
        entranceVRAudioSource.PlayOneShot(EntranceVRaudioclips[3]);

        yield return new WaitForSeconds(7f);
        print("Playing Entrace VR audio4");
        entranceVRAudioSource.PlayOneShot(EntranceVRaudioclips[4]);

        yield return new WaitForSeconds(3f);
        conceptAirButtoninteract.interactable = true;

    }


    public void concept_of_first_air()
    {
        StartCoroutine(playingaudio1andaudio2coceptoffirstair());
    }

    //TeleportMethod
    public void conceptofairteleport()
    {
        fadecame.GetComponent<OVRScreenFade>().FadeIn();
        cameraOVR.transform.position = teleportarea.transform.position;
        StartCoroutine(playingAudio3andParticles());



    }




    //conceptoffirststartshere

    IEnumerator playingaudio1andaudio2coceptoffirstair()
    {
        //ConceptofFirstAirAudio1
        yield return new WaitForSeconds(.4f);
        ourAudioSource.PlayOneShot(audio1);
        conceptAirButtoninteract.interactable = false;

        //ConceptofFirstAirAudio2
        yield return new WaitForSeconds(33f);
        ourAudioSource.PlayOneShot(audio2);

        //ConceptofFirstAirEnableTeleportButton
        yield return new WaitForSeconds(43f);
        ourAudioSource.PlayOneShot(audio3);
        enableconceptairteleportbutton.SetActive(true);
        yield return new WaitForSeconds(4f);
        teleportinteractable.interactable = true;



    }


    IEnumerator playingAudio3andParticles()
    {
        yield return new WaitForSeconds(.4f);
        enableconceptairteleportbutton.SetActive(false);

        yield return new WaitForSeconds(2f);
        ourAudioSource.PlayOneShot(audio4);

        yield return new WaitForSeconds(6.3f);
        removeglass.SetActive(false);

        yield return new WaitForSeconds(2f);
        ourAudioSource.PlayOneShot(audio5);

        yield return new WaitForSeconds(8.9f);
        ourAudioSource.PlayOneShot(audio6);
        yield return new WaitForSeconds(2f);
        spotlights.SetActive(false);
        blueLight.SetActive(true);
        yield return new WaitForSeconds(2f);
        particles.SetActive(true);
        anims[0].SetActive(true);
        anims[1].SetActive(true);

        yield return new WaitForSeconds(6f);
        ourAudioSource.PlayOneShot(audio7);

        yield return new WaitForSeconds(9f);
        ourAudioSource.PlayOneShot(audio8);

        yield return new WaitForSeconds(4f);
        particlesmainPanel.SetActive(true);

        yield return new WaitForSeconds(1.4f);
        viableparticlebutton.interactable = true;
        nonviableparticlebutton.interactable = false;
        letscontinuebuttoninnonviableparticle.interactable = false;


    }


    public void viableParticleAudio()
    {
        StartCoroutine(viableparticletimeraudio());
    }

    public void nonViableParticleAudio()
    {
        StartCoroutine(nonviableparticletimeraudio());
    }


    IEnumerator viableparticletimeraudio()
    {
        yield return new WaitForSeconds(1f);
        viableparticlebutton.interactable = false;

        viableparticleaudiosource.SetActive(true);
        yield return new WaitForSeconds(3f);
        particles.SetActive(true);
        anims[0].SetActive(true);
        anims[1].SetActive(true);
        yield return new WaitForSeconds(9f);
        //anims[0].SetActive(false);
        //anims[1].SetActive(false);
        nonviableparticlebutton.interactable = true;
        letscontinuebuttoninnonviableparticle.interactable = false;
        //nonviableparticleaudiosource.SetActive(false);

    }

    IEnumerator nonviableparticletimeraudio()
    {
        //Playing1stnonviableAudio
        yield return new WaitForSeconds(0.5f);
        nonviableparticlebutton.interactable = false;
        nonviableparticleaudiosource.PlayOneShot(NonViableaudio1);
        viableparticleaudiosource.SetActive(false);
        letscontinuebuttoninnonviableparticle.interactable = false;

        //playing2ndnonviableaudio
        yield return new WaitForSeconds(28f);
        nonviableparticleaudiosource.PlayOneShot(NonViableaudio2);
        yield return new WaitForSeconds(4f);
        letscontinuebuttoninnonviableparticle.interactable = true;
    }


    public void letscontineButton()
    {
        StartCoroutine(letscontinuebtncoorutine());
        
    }


    IEnumerator letscontinuebtncoorutine()
    {
        yield return new WaitForSeconds(1f);
        letscontinuebuttoninnonviableparticle.interactable = false;

        //playing2ndnonviableaudio
        yield return new WaitForSeconds(1f);
        anims[0].SetActive(false);
        anims[1].SetActive(false);
        particles.SetActive(false);
        //enable lets continue button here
      //  letscontinuebuttoninnonviableparticle.interactable = true;


        smokeParticle.SetActive(true);


        for (int i = 0; i < smokes.Length; i++)
        {
            smokes[i].Play();
        }
     



        anims[0].SetActive(false);
        anims[1].SetActive(false);
        particles.SetActive(false);

        yield return new WaitForSeconds(3f);
        nonviableparticleaudiosource.PlayOneShot(NonViableaudio3);



        yield return new WaitForSeconds(28f);
        nonviableparticleaudiosource.PlayOneShot(NonViableaudio4);
        valueimagnonviable.SetActive(true);
        anims[0].SetActive(true);
        anims[1].SetActive(true);
        particles.SetActive(true);
        for (int i = 0; i < smokes.Length; i++)
        {
            smokes[i].Stop();
        }
        //here wait check for the trigger to check the player interacated with particle if yes then play the next audio

        yield return new WaitForSeconds(14f);
       // nonviableparticleaudiosource.PlayOneShot(NonViableaudio5);
        valueimagnonviable.SetActive(false);
        anims[0].SetActive(true);
        anims[1].SetActive(true);
        particles.SetActive(true);

        yield return new WaitForSeconds(10f);
        nonviableparticleaudiosource.PlayOneShot(NonViableaudio10);

        yield return new WaitForSeconds(16f);
        nonviableparticleaudiosource.PlayOneShot(NonViableaudio6);

        yield return new WaitForSeconds(17f);
        nonviableparticleaudiosource.PlayOneShot(NonViableaudio11);


        yield return new WaitForSeconds(21f);
        nonviableparticleaudiosource.PlayOneShot(NonViableaudio7);
        yield return new WaitForSeconds(4f);
        letscontinuebuttoninnonviableparticle.interactable = false;

        firstairbuttoninteractable.interactable = true;


    }


    public void firstAir()
    {
        

        StartCoroutine(firstairenum());

        for (int i = 0; i < smokes.Length; i++)
        {
            smokes[i].Play();
        }




        particlesmainPanel.SetActive(false);
        threeimportantfeaturesoffirstair.SetActive(true);
        anims[0].SetActive(false);
        anims[1].SetActive(false);
        particles.SetActive(false);
        
    }


    IEnumerator firstairenum()
    {
        yield return new WaitForSeconds(1f);
        firstairbuttoninteractable.interactable = false;

       

        yield return new WaitForSeconds(1f);
        nonviableparticleaudiosource.PlayOneShot(NonViableaudio8);
        yield return new WaitForSeconds(25.2f);
        nonviableparticleaudiosource.PlayOneShot(NonViableaudio9);

        yield return new WaitForSeconds(6f);
        filterdcleanairbutton.interactable = true;

    }

    public void FilteredCleanAir()
    {
        
        StartCoroutine(FilteredCleanAirenum());
    }

    IEnumerator FilteredCleanAirenum()
    {
        yield return new WaitForSeconds(1f);
        filterdcleanairbutton.interactable = false;

        yield return new WaitForSeconds(1f);
        firstAirAudiosource.PlayOneShot(firstairaudioclips[0]);
        yield return new WaitForSeconds(19);
       
        firstairbuttoninteractable.interactable = false;
     
        Uninterruptedflow.interactable = false;

    
        Unidirectionalflow.interactable = true;//make it true



    }

    public void unidirectionalflow()
    {
        StartCoroutine(unidirectionalflowenum());
    }

    IEnumerator unidirectionalflowenum()
    {
       

        yield return new WaitForSeconds(1f);
        Unidirectionalflow.interactable = false;

        yield return new WaitForSeconds(1f);
        firstAirAudiosource.PlayOneShot(firstairaudioclips[1]);

        yield return new WaitForSeconds(1f);
        arrowanimation.SetActive(true);

        yield return new WaitForSeconds(5f);
        arrowanimation.SetActive(false);

        yield return new WaitForSeconds(27f);
        Uninterruptedflow.interactable = true;


    }

    public void uninterruptedflow()
    {
        StartCoroutine(uninterruptedflowenum());
    }

    IEnumerator uninterruptedflowenum()
    {

        yield return new WaitForSeconds(1f);
        Uninterruptedflow.interactable = false;

        yield return new WaitForSeconds(1f);
        firstAirAudiosource.PlayOneShot(firstairaudioclips[2]);
        Uninterruptedflow.interactable = false;
       
        yield return new WaitForSeconds(15f);
        firstAirAudiosource.PlayOneShot(firstairaudioclips[3]);


        yield return new WaitForSeconds(14f);
        firstAirAudiosource.PlayOneShot(firstairaudioclips[9]);
        yield return new WaitForSeconds(3.2f);
        continueButton.interactable = true;
    }


    public void contineButton()
    {
        StartCoroutine(continuebuttonflowenum());
    }


    IEnumerator continuebuttonflowenum()
    {
        yield return new WaitForSeconds(1f);
        continueButton.interactable = false;
        firstAirAudiosource.PlayOneShot(firstairaudioclips[4]);


        yield return new WaitForSeconds(22f);
        firstAirAudiosource.PlayOneShot(firstairaudioclips[10]);
        mainvail.SetActive(false);
        fallenvail.SetActive(true);
        //fallenvailmesh.material.color = Color.green;

        yield return new WaitForSeconds(30f);
        firstAirAudiosource.PlayOneShot(firstairaudioclips[5]);

        yield return new WaitForSeconds(41f);
        firstAirAudiosource.PlayOneShot(firstairaudioclips[6]);
        Uninterruptedflow.interactable = false;



        yield return new WaitForSeconds(21f);

        spotlights.SetActive(true);
        blueLight.SetActive(false);

        yield return new WaitForSeconds(1f);
        firstAirAudiosource.PlayOneShot(firstairaudioclips[7]);



    }
}
