using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; // この行も追加が必要なので注意

public class ObjClickSample : MonoBehaviour, IPointerExitHandler, IPointerEnterHandler, IPointerClickHandler//必要なインターフェースを実装
    //このサンプルの場合、Enter/Exit/Clickイベントに対しての処理を記述している
{
    [SerializeField]
    private GameObject hibana;

    private Renderer cube_renderer;
    private Vector3 hit_pos;
    private const float waittime = 0.5f;

    private bool enterflag = false;

    public void InsertHitPos(Vector3 pos){ hit_pos = pos; }


    private List<GameObject> objs = new List<GameObject>();

    private void Awake()
    {
        cube_renderer = this.GetComponent<Renderer>();

        for (int i = 0;i < 8;i++)
        {
            GameObject a = Instantiate(hibana);
            a.SetActive(false);
            objs.Add(a);
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)//クリックの場合はここに記述
    {
        cube_renderer.material.color -= new Color(0, 0.1f, 0.1f);

        //CallObj();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)//エンターの場合はここに記述
    {
        enterflag = true;
    }

    public void OnPointerExit(PointerEventData pointerEventData)//Exitの場合はここに記述
    {
        if (cube_renderer.material.color.b < 1)
        {
            StartCoroutine(FadeWhite());
        }

        hit_pos = Vector3.zero;
        enterflag = false;
    }

    private void CallObj()
    {
        foreach(GameObject a in objs)
        {
            if(!a.activeInHierarchy)
            {
                a.SetActive(true);
                a.transform.position = hit_pos;
                break;
            }
        }
    }


    private IEnumerator FadeWhite()
    {

        yield return new WaitForSeconds(waittime);

        while (true)
        {
            cube_renderer.material.color += new Color(0, Time.deltaTime, Time.deltaTime);

            if(cube_renderer.material.color.b > 1)
            {
                cube_renderer.material.color = Color.white;
                break;
            }

            yield return null;
        }
    }
}