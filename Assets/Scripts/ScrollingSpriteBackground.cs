using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingSpriteBackground : MonoBehaviour {
    public static ScrollingSpriteBackground Instance;
    public List<Sprite> NextBackgrounds;
    public SpriteRenderer BackgroundBase;
    public float Speed = 1.0f;
    SpriteRenderer[] _sr;
    int _spriteBuffer = 2;
    int _currentIndex = 0;
    Sprite _lastSprite;

    private void Awake()
    {
        Instance = this;
        _sr = new SpriteRenderer[_spriteBuffer];
        for (int i = 0; i < _spriteBuffer; i++)
        {
            //GameObject spriteObj = new GameObject("Background " + (i + 1), typeof(SpriteRenderer));
            _sr[i] = Instantiate<SpriteRenderer>(BackgroundBase);
            _sr[i].name = "Background " + (i + 1);
            _sr[i].transform.parent = transform;
            _sr[i].transform.localPosition = Vector3.up * (5-(10 * i));
            _sr[i].sortingOrder = 0;
        }
        BackgroundScrollFinished();
    }

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update () {
        transform.position += Vector3.up * Speed * Time.deltaTime;
        if (transform.position.y > 10)
        {
            BackgroundScrollFinished();
        }
	}

    void BackgroundScrollFinished()
    {
        if(_lastSprite == null)
        {
            _lastSprite = NextBackgrounds[0];
        }
        _sr[0].sprite = _lastSprite;
        if (NextBackgrounds.Count > 0)
        {
            _sr[1].sprite = NextBackgrounds[0];
            _lastSprite = NextBackgrounds[0];
            NextBackgrounds.RemoveAt(0);
        }
        else
        {
            _sr[1].sprite = _lastSprite;
        }
        transform.position = Vector3.up * 0;
        /*
        Sprite[] newQueue = new Sprite[NextBackgrounds.Count];
        NextBackgrounds.CopyTo(newQueue, 1);
        NextBackgrounds = new List<Sprite>(newQueue);
        */
    }

    int GetNextIndex(int i)
    {
        i++;
        if (i >= _sr.Length) i = 0;
        if (i < 0) i = _sr.Length - 1;
        return i;
    }
}
