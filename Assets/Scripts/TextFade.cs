using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    // Start is called before the first frame update
    private Text t;

    private void Start()
    {
        t = GetComponent<Text>();
    }


    // Update is called once per frame
    void Update()
    {
        if (t.color.a > 0)
        {
            t.color -= new Color(0, 0, 0, Time.deltaTime);
        }
    }
}
