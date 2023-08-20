using System.Collections;
using System.Collections.Generic;
using System.Threading;
using State;
using UnityEngine;

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
}
