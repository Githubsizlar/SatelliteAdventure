using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using DG.Tweening;
using Interfaces.Type;
using State;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static CancellationTokenSource GeneralCancellationTokenSource { get; } = new CancellationTokenSource();
    private IContext _finalContext = null!;
    
    [SerializeField] private GameObject spaceShip = null!;
    [SerializeField] private GameObject player = null!;
    [SerializeField] private GameObject talkWithNativesPanel = null!;
    [SerializeField] private List<Native> Natives;
    private CancellationTokenSource StateCancellationTokenSource { get; set; } = null!;
    
    public void Start()
    {
       
        
        StateCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(GeneralCancellationTokenSource.Token);
        _finalContext = new Context(spaceShip, player,talkWithNativesPanel, Natives);
        _finalContext.TransitionTo(new FallingFromShip2());
        _ = _finalContext.RunStateAsync(StateCancellationTokenSource.Token);
    }
    
    private void OnApplicationQuit()
    {
        GeneralCancellationTokenSource.Cancel();
        GeneralCancellationTokenSource.Dispose();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Natives != null)
        {
            talkWithNativesPanel.SetActive(true);
            player.gameObject.transform.parent = default;
            player.gameObject.transform.position = new Vector3(0.4f, 1, 0);
        }
    }

    public void PassIntoPlacingHomeDraft()
    {
        talkWithNativesPanel.SetActive(false);
        for (int i = Natives.Count-1; i >= 0; i--)
        {
            Natives[i].gameObject.transform.rotation = new Quaternion(0,-180,0,0);
            Natives[i].gameObject.transform.DOMove(new Vector3(-10, 0, 0), 2f);
            Destroy(Natives[i].gameObject,.5f);
        }

        Natives = null;
    }
}
