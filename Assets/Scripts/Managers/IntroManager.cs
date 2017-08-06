using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// Autor Leamzi
/// Class that manage game intro.
/// </summary>
public class IntroManager : MonoBehaviour {

    public Image imagePanelIntro01;
    public Image imagePanelIntro02;
    public Image imagePanelIntro03;

    public GameObject buttonIntro01;
    public GameObject buttonIntro02;
    public GameObject buttonIntro03;
    public GameObject buttonIntro04;

    public float fadeOutDuration = 0.5f;

    private int introCount = 0;
    private Image elementImage;

    private void Start()
    {
        OnFadeIn();
    }
    public void OnFadeIn()
    {
        introCount++;
        print("intro count: " + introCount);
        if(introCount == 1)
        {
            elementImage = imagePanelIntro01;
            buttonIntro01.SetActive(false);
            StartCoroutine(fadeOutAnimation());
            buttonIntro02.SetActive(true);
        }
        else if (introCount == 2)
        {
            elementImage = imagePanelIntro02;
            buttonIntro02.SetActive(false);
            SoundManager.instance.PlaySfx(GameGlobalVariables.SFX_INTRO_GLUP);
            StartCoroutine(fadeOutAnimation());
            buttonIntro03.SetActive(true);
        }
        else if (introCount == 3)
        {
            elementImage = imagePanelIntro03;
            buttonIntro03.SetActive(false);
            SoundManager.instance.PlaySfx(GameGlobalVariables.SFX_INTRO_NOTA);
            StartCoroutine(fadeOutAnimation());
            buttonIntro04.SetActive(true);
        }
    }

    IEnumerator fadeOutAnimation()
    {
        float fadeOutDuration = 0.5f;
        float t = 0.0f;
        Color currentColor;

        currentColor = elementImage.color;

        while (t < fadeOutDuration)
        {

            currentColor.a = Mathf.Lerp(1, 0, t / fadeOutDuration);
            elementImage.color = currentColor;
            yield return null;
            t += Time.unscaledDeltaTime;
        }

        currentColor.a = 0;
        elementImage.color = currentColor;
    }

    public void onChangeScreen()
    {
        SceneManager.LoadScene("Scene_Gameplay");
    }
}
