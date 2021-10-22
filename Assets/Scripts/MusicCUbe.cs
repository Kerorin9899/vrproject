using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicCUbe : MonoBehaviour
{
    private const float bpm = 150.0f;
    public float volume = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Sizeup", 0, 60.00f / bpm);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.localScale.x >= 1)
        {
            transform.localScale -= 2 * Time.deltaTime * new Vector3(1,1,1);
        }
    }

    private void Sizeup()
    {
        if ((1 + volume) > transform.localScale.x)
        {
            this.gameObject.transform.localScale = (1 + volume) * new Vector3(1,1,1);
        }
        else
        {
            transform.localScale += 0.1f * new Vector3(1,1,1);
        }
    }
}
