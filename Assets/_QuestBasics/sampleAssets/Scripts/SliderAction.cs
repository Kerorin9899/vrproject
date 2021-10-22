using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderAction : MonoBehaviour {

    public Text uText;
	private GameObject cube;

	private MusicCUbe mc;
	private AudioSource audio;
	private void Awake()
	{
		cube = GameObject.Find("ActionCube");
		mc = cube.GetComponent<MusicCUbe>();
		audio = cube.GetComponent<AudioSource>();

		audio.volume = 0;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnSliderValueChanged(float sValue)
    {
		audio.volume = sValue;
		mc.volume = sValue;
    }

}
