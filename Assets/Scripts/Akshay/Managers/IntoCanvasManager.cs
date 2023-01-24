using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntoCanvasManager : Singleton<IntoCanvasManager>
{
    // Start is called before the first frame update
    [SerializeField]
    Image Logo;
    [SerializeField]
    GameObject ModuleNane;
    [SerializeField]
    GameObject StartButton;
    [SerializeField]
    GameObject FullScreenCanvas;
    [SerializeField]
    Image Bg;
    bool isLogo = false;

    public void FadeInLogo()
    {
        isLogo = true;
        StartCoroutine(FadeIn(Logo));
    }

    public void OnImageFadeIn()
    {
        if (isLogo)
        {
            isLogo = false;
            IntroSceneManager.instance.OnLogoLoadComplete();
        }
    }

    public void ActivateModuleName()
    {
        ModuleNane.SetActive(true);
    }

    public void ShowStartButton()
    {
        StartButton.SetActive(true);
    }

    public void StartButtonClick()
    {
        FullScreenCanvas.SetActive(true);
        StartCoroutine(FadeIn(Bg));
        IntroSceneManager.instance.LoadNextScene();
    }

    IEnumerator FadeIn(Image img)
    {

        // loop over 1 second
        for (float i = 0; i <= 1; i += Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
        OnImageFadeIn();
    }

    // fade from opaque to transparent
    IEnumerator FadeOut(Image img)
    {
        // loop over 1 second backwards
        for (float i = 1; i >= 0; i -= Time.deltaTime)
        {
            // set color with i as alpha
            img.color = new Color(1, 1, 1, i);
            yield return null;
        }
    }
}
