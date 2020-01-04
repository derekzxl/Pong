using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextSwitch : MonoBehaviour
{
    string[] texts;
    Text text;
    int curidx = 0;
    void Start()
    {
        curidx = 0;
        texts = new string[2]{"Pause", "Resume"};
        text = GetComponent<Text>();
        text.text = texts[0];
    }
    public void Switch()
    {
        curidx ^= 1;
        text.text = texts[curidx];
    }
}
