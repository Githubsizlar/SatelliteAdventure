using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FallingFromShip1 : MonoBehaviour
{
    [SerializeField] private GameObject clouds;
    [SerializeField] private GameObject boomEffect;
    private void Start()
    {
        transform.DOMove(new Vector3(0, 0.779999971F, 0), 1F);
        clouds.transform.DOMove(new Vector3(-1.74192357F, 15F, 12.3390713F), 2F);
        boomEffect.transform.DOMove(new Vector3(-0.0636740923f,0.230000004f,0), 1.5f);
        StartCoroutine(Movements());
    }

    IEnumerator  Movements()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MainScene");
    }
}
