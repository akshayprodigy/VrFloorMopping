using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSceneManager : Singleton<IntroSceneManager>
{
    // Start is called before the first frame update
    int audoCount = 0;
   
    void Start()
    {
        IntoCanvasManager.instance.FadeInLogo();
    }

    public void OnLogoLoadComplete()
    {
        IntoCanvasManager.instance.ActivateModuleName();
        IntroAudioManager.instance.PlayNextAudioFile();
    }
    // Update is called once per frame
    public void LoadNextScene()
    {
        StartCoroutine(LoadYourAsyncScene());
    }

    public void OnAudioComplete()
    {
        audoCount++;
        if(audoCount == 4)
        {
            // show start button
            IntoCanvasManager.instance.ShowStartButton();
        }
        IntroAudioManager.instance.PlayNextAudioFile();

    }

    IEnumerator LoadYourAsyncScene()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("MainScene");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
