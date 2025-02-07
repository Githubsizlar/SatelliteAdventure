﻿using System.Threading;
using System.Threading.Tasks;
using DG.Tweening;
using Type;


namespace State
{
    public class TalkingWithNatives : GameState
    {
       

        public override Task RunStateAsync(CancellationToken cancellationToken = default)
        {
            Context.TalkWithNativesPanel.SetActive(false);
            CreateNative();
            Context.TransitionTo(new PlacingHomeDraft());
            _ = Context.CurrentState.RunStateAsync(cancellationToken);
            return Task.CompletedTask;
        }



        private void CreateNative()
        {
            int c = -5;
            for (int i = 0; i < 5; i++)
            {
                Native a = Factory.Factory.Instance.CreateObject<Native>();
                Context.Natives.Add(a);
                a.gameObject.transform.position = new UnityEngine.Vector3(-10, 0, 0);
                a.gameObject.transform.DOMove(new UnityEngine.Vector3(c, 0, 0), 3F);
                c++;
            }

          
        }

        
    }
}
