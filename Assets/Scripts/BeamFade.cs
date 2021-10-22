using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamFade : MonoBehaviour
{
    private Renderer ren;
    private Material mat;

    public int num = 10;

    private void Awake()
    {
        ren = GetComponent<Renderer>();
        mat = ren.material;
    }

    private void OnBecameVisible()
    {
        mat = ren.material;
        mat.color += new Color(0,0,0,1);
    }

    // Update is called once per frame
    void Update()
    {
        if(mat.color.a <= 0)
        {
            gameObject.SetActive(false);
        }

        mat.color -= new Color(0,0,0, 1.0f / (float)(num));
    }
}
