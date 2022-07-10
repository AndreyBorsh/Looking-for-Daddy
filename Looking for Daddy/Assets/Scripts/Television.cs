using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Television : MonoBehaviour
{
    public AudioClip hitSound;
    new AudioSource audio;

    public AudioClip hitSound2;
    AudioSource audio2;

    public AudioClip hitSound3;
    AudioSource audio3;

    bool inZone;

    public GameObject textTV;

    public static bool isReady;

    bool inDist;

    public Transform other;

    public GameObject partSecondText;

    public static bool isCasSec;

    bool isPlay;

    //GameObject roof;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio2 = GetComponent<AudioSource>();
        audio3 = GetComponent<AudioSource>();
        textTV.gameObject.SetActive(false);
        partSecondText.SetActive(false);
        //audio3.PlayOneShot(hitSound3);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && inZone && inDist && MouseOnCasset.isGet && !isCasSec)
        {
            partSecondText.SetActive(false);
            audio2.PlayOneShot(hitSound2);
            isCasSec = true;
            inZone = false;
            partSecondText.SetActive(false);
            //Movement.isWalk = false;
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && inZone && !isReady && inDist)
        {
            isReady = true;
            EnterTV();
        }

        if (MusicalKeys.isThirdCas && !isPlay)
        {
            audio2.Stop();
            audio3.PlayOneShot(hitSound3);
            isPlay = true;
            StartCoroutine(YieldOneSecond());
        }

    }
    IEnumerator YieldOneSecond()
    {
        if (isPlay)
        {
            yield return new WaitForSeconds(1);
            Door.isOpen = true;
        }
    }
        void EnterTV()
    {
        textTV.gameObject.SetActive(false);
        audio.PlayOneShot(hitSound);
        inZone = false;
    }

    void OnMouseEnter()
    {
        float dist = Vector3.Distance(other.position, transform.position);
        if (other && dist <= 3.5f && MouseOnCasset.isGet && !isCasSec)
        {
            inZone = true;
            partSecondText.SetActive(true);
            inDist = true;
        }
        else if (other && dist <= 3.5f && !isReady)
        {
            inZone = true;
            textTV.gameObject.SetActive(true);
            inDist = true;
        }
    }
    void OnMouseExit()
    {
        if (MouseOnCasset.isGet)
        {
            inZone = false;
            partSecondText.SetActive(false);
        }
        else if (!isReady)
        {
            inZone = false;
            textTV.gameObject.SetActive(false);
        }
        
    }
}
