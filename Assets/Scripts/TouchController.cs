﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {
    PlayerController _plr;

    private void Start()
    {
        _plr = PlayerController.Instance;
    }

    void Update () {
		if(!PlayerManager.IsPaused && Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width/2) _plr.MoveRight();
            else _plr.MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PlayerManager.StaticPause();
        }

        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //SoundManager.PlaySound(SoundManager.Instance.TapSound);
        }
        
    }
}
