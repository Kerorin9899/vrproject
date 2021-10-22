using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonAction : MonoBehaviour
{
    // [SerializeField] Image image;
    public Text buttonText;

    private GameObject cube;

    [SerializeField]
    private Text t;

    private void Awake()
    {
        cube = GameObject.Find("ActionCube");
    }

    public void OnClick()
    {
        if(cube.activeInHierarchy)
        {
            cube.SetActive(false);
        }
        else
        {
            if (t.color.a != 1)
            {
                t.color = new Color(0,0,0,1);
                t.text = "Cube is allready Invisible!";
            }
        }
    }

    public void OnClickTwo()
    {
        if(!cube.activeInHierarchy)
        {
            cube.SetActive(true);
        }
        else
        {
            if (t.color.a != 1)
            {
                t.color = new Color(0, 0, 0, 1);
                t.text = "Cube is allready Exist!";
            }
        }
    }
}