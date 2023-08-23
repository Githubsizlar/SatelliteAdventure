using System.Threading;
using System.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace State
{
    public class FallingFromShip2: GameState 
    {
        public override async Task RunStateAsync(CancellationToken cancellationToken = default)
        {
            Debug.Log("Ship is falling");
            SpaceShipMovements();
            Context.TransitionTo(new TalkingWithNatives());
            _ = Context.CurrentState.RunStateAsync(cancellationToken);
        }

        private void SpaceShipMovements()
        {
            Sequence s = DOTween.Sequence(); s.
                Append(Context.SpaceShip.transform.DOMove(new Vector3(0, 0.779999971F, 0), 1F)).
                AppendInterval(2f);
        }
        
    }
}