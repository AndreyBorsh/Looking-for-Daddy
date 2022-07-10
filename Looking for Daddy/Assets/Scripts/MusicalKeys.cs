using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicalKeys : MonoBehaviour
{
    bool inZone;

    public AudioClip hitSound;
    new AudioSource audio;

    public Text text;

    List<string> pin = new List<string>();

    public static bool isThirdCas;

    public Camera camera1;
    public Camera camera2;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        PlayerPrefs.SetString("Piano", "");
    }

    // Update is called once per frame
    void Update()
    {
        if (Television.isCasSec)
        {
            transform.position = new Vector3(transform.position.x, 0.797f, transform.position.z);
        }
        string lenght = PlayerPrefs.GetString("Piano");
        if (lenght.Length == 2)
        {
            if($"{lenght[0]}" == Music.musical[0] && $"{lenght[1]}" == Music.musical[1])
            {
                gameObject.SetActive(false);
                Destroy(this);
                enabled = false;
                isThirdCas = true;
                camera2.gameObject.SetActive(false);
                camera1.gameObject.SetActive(true);
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Debug.Log("NN");
                pin.Clear();
                PlayerPrefs.SetString("Piano", "");
            }

        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && inZone)
        {
            audio.Play();
            pin.Add(text.text);
            string a = PlayerPrefs.GetString("Piano");
            PlayerPrefs.SetString("Piano", pin[0]);
            PlayerPrefs.SetString("Piano", a + pin[0]);
        }
    }

    private void OnMouseEnter()
    {
        inZone = true;
    }
    private void OnMouseExit()
    {
        inZone = false;
    }
}
