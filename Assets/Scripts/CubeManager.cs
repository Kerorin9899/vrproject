using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour, IEventCaller
{
    public AudioClip ac;
    private AudioSource audio_soruce;
    private float sum_time = 0;


    [SerializeField]
    private float _height = 500;

    private void Start()
    {
        audio_soruce = GetComponent<AudioSource>();
    }

    private float Perlin(int a)
    {
        float t = Mathf.PerlinNoise(sum_time, a);
        t -= 0.5f;
        t *= _height;

        Debug.Log(t);

        return t;
    }

    // Update is called once per frame
    void Update()
    {
        sum_time += Time.deltaTime;

        this.gameObject.transform.Rotate(
            Time.deltaTime * new Vector3(Perlin(0), Perlin(3), Perlin(6)));

        if(transform.localScale.x > 1)
        {
            transform.localScale -= Time.deltaTime * new Vector3(2,2,2);
        }
    }

    public void TurnOnMusic()
    {
        audio_soruce.PlayOneShot(ac);
        gameObject.transform.localScale = new Vector3(3,3,3);
    }

    public void PitchShift(float pitch)
    {
        audio_soruce.pitch += pitch;
    }
}
