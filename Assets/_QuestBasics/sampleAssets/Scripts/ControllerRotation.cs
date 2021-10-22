using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerRotation : MonoBehaviour
{
    public GameObject blade;
    private Material m;

    private Vector3 beforepos;

    private GameObject copy;
    private List<GameObject> _pool = new List<GameObject>();
    private const int _poolnum = 10;
    public TextMesh rotationMesh;

    // Use this for initialization
    void Start()
    {
        for(int i = 0;i < _poolnum;i++)
        {
            GameObject a = Instantiate(blade);
            _pool.Add(a);
            a.AddComponent<BeamFade>();
            a.SetActive(false);
        }

        beforepos = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //OVRInput.Controller activeController = OVRInput.GetActiveController();
        //Quaternion rot = OVRInput.GetLocalControllerRotation(activeController);

        CallFade();

        Quaternion rot = OVRInput.GetLocalControllerRotation(OVRInput.Controller.RTouch);
        Quaternion q = Quaternion.AngleAxis(180, Vector3.up);
        Quaternion p = Quaternion.AngleAxis(30, Vector3.right);

        transform.rotation = rot * q * p;
        rotationMesh.text = rot.eulerAngles.ToString();

        beforepos = blade.transform.position;
    }

    private void CallFade()
    {
        foreach(GameObject a in _pool)
        {
            if(!a.activeInHierarchy)
            {
                a.SetActive(true);
                a.transform.position = blade.transform.position;
                a.transform.rotation = blade.transform.rotation;
                break;
            }
        }
    }
}
