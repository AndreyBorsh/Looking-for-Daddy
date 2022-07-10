using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MouseOnStart : MonoBehaviour
{
    public GameObject btn;

    bool inZone;

    public Text partFirst;

    bool fadeIn;
    bool fadeOut;
    float alphaColor;

    public Image fadeImage;
    public Color fadeInColor;
    public Color fadeOutColor;

    // Start is called before the first frame update
    void Start()
    {
        partFirst.gameObject.SetActive(false);

        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(fadeOutColor.r, fadeOutColor.g, fadeOutColor.b, 1f);
        fadeOut = true;
    }

    void OnMouseEnter()
    {
        inZone = true;
    }
    void OnMouseExit()
    {
        inZone = false;
    }

    private void ButtonStartGame()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(fadeInColor.r, fadeInColor.g, fadeInColor.b, 0);
        fadeIn = true;
        partFirst.gameObject.SetActive(true);
    }

    private void StartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && inZone)
            ButtonStartGame();
        if (fadeIn)
        {
            alphaColor = Mathf.Lerp(fadeImage.color.a, 1, Time.deltaTime);
            fadeImage.color = new Color(fadeInColor.r, fadeInColor.g, fadeInColor.b, alphaColor);
        }

        if (fadeOut)
        {
            alphaColor = Mathf.Lerp(fadeImage.color.a, 0, Time.deltaTime);
            fadeImage.color = new Color(fadeOutColor.r, fadeOutColor.g, fadeOutColor.b, alphaColor);
        }

        if (alphaColor > 0.95 && fadeIn)
        {
            fadeIn = false;
            StartScene();
        }

        if (alphaColor < 0.05 && fadeOut)
        {
            fadeOut = false;
            fadeImage.gameObject.SetActive(false);
        }
    }
}
