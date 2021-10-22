using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HibanaFade : MonoBehaviour
{
    private ParticleSystem ps;

    private void Awake()
    {
        ps = this.gameObject.GetComponent<ParticleSystem>();
    }

    private void OnBecameVisible()
    {
        StartCoroutine(ActiveTime());
    }

    private IEnumerator ActiveTime()
    {
        yield return new WaitWhile(() => ps.IsAlive(true));
        gameObject.SetActive(false);
    }
}
