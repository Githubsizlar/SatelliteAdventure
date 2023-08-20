using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    private CancellationTokenSource StateCancellationTokenSource { get; set; } = null!;
    
    public void Start()
    {
       
        
        StateCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(GeneralCancellationTokenSource.Token);
        _finalContext = new Context(spaceShip, player,talkWithNativesPanel);
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
        if (Input.GetKeyDown(KeyCode.Space))
        {
            talkWithNativesPanel.SetActive(true);
            player.gameObject.transform.parent = default;
            player.gameObject.transform.position = new Vector3(0.4f, 1, 0);
        }
    }

    public void PassIntoPlacingHomeDraft()
    {
        talkWithNativesPanel.SetActive(false);
    }
}
