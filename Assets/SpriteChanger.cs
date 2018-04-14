using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChanger : MonoBehaviour {

    public List<Sprite> sprites;
    private Image image;
    private int i = -1;

    void Start () {
        image = GetComponent<Image>();
        InvokeRepeating("Change", 0, 0.25f);
	}

    void Change()
    {
        i++;
        if (i > sprites.Count - 1)
        {
            i = 0;
        }
        image.sprite = sprites[i];
    }

}
