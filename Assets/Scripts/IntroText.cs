using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class IntroText : MonoBehaviour {
    public Image ButtonImage;
    public Sprite Intro1;
    public Sprite Intro2;
    public Sprite Intro3;
    int _currentStage = 0;
    public AudioClip TapSound;
    public AudioSource TapSource;
    public void Proceed()
    {
        switch (_currentStage)
        {
            case 0:
                ButtonImage.color = Color.white;
                ButtonImage.sprite = Intro1;
                break;
            case 1:
                ButtonImage.sprite = Intro2;
                break;
            case 2:
                ButtonImage.sprite = Intro3;

                break;
            case 3:
                SceneManager.LoadScene("Main");
                break;
        }
        _currentStage++;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !SoundManager.Muted)
        {
            TapSource.PlayOneShot(TapSound);
        }

    }
}
