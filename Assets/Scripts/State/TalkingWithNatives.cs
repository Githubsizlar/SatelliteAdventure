using System;
using System.Threading;
using System.Threading.Tasks;
using DG.Tweening;
using Interfaces.Type;
using UnityEngine;
using Vector3 = System.Numerics.Vector3;

namespace State
{
    public class TalkingWithNatives : GameState
    {
        
        public override Task RunStateAsync(CancellationToken cancellationToken = default)
        {

            SequenceFunction();
            Context.TransitionTo(new PlacingHomeDraft());
            _ = Context.CurrentState.RunStateAsync(cancellationToken);
            return Task.CompletedTask;
        }

        private void SequenceFunction()
        {
            Sequence s = DOTween.Sequence(); s.Append(CreateNative()).
                AppendInterval(100F).
                Append(TalkWithNatives());
        }
        
        private Tween CreateNative()
        {
            int c = -5;
            for (int i = 0; i < 5; i++)
            {
               Native a = Factory.Factory.Instance.CreateObject<Native>();
               a.gameObject.transform.position = new UnityEngine.Vector3(-10, 0, 0);
               a.gameObject.transform.DOMove(new UnityEngine.Vector3(c, 0, 0), 3F);
               c++;
            }

            return null;
        }

        private Tween TalkWithNatives()
        {
            if (Context.Player.gameObject.transform.position.x != 0.2)
            {
                Context.TalkWithNativesPanel.SetActive(true);
            }
            return null;
        }
        
    }
}