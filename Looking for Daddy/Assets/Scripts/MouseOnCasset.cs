using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOnCasset : MonoBehaviour
{
    public GameObject textCasset;

    bool inZone;

    public static bool isGet;

    public Text partSecond;

    bool fadeIn;
    bool fadeOut;
    float alphaColor;

    public Image fadeImage;
    public Color fadeInColor;
    public Color fadeOutColor;

    // Start is called before the first frame update
    void Start()
    {
        textCasset.SetActive(false);

        partSecond.gameObject.SetActive(false);

        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(fadeOutColor.r, fadeOutColor.g, fadeOutColor.b, 1f);
        fadeOut = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && inZone)
        {
            textCasset.SetActive(false);
            isGet = true;
            Destroy(this);
            enabled = false;
            
            ButtonStartGame();
        }

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
        }

        if (alphaColor < 0.05 && fadeOut)
        {
            fadeOut = false;
            fadeImage.gameObject.SetActive(false);
        }
    }

    private void OnMouseEnter()
    {
        textCasset.SetActive(true);
        inZone = true;
    }
    private void OnMouseExit()
    {
        textCasset.SetActive(false);
        inZone = false;
    }

    private void ButtonStartGame()
    {
        fadeImage.gameObject.SetActive(true);
        fadeImage.color = new Color(fadeInColor.r, fadeInColor.g, fadeInColor.b, 0);
        fadeIn = true;
        //partSecond.gameObject.SetActive(true);
        StartCoroutine(YieldOneSecond());
        
    }

    IEnumerator YieldOneSecond()
    {
        gameObject.SetActive(false);
        yield return new WaitForSeconds(3);
    }
}
