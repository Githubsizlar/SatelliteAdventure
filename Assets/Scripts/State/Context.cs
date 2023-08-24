using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Type;
using UnityEngine;

namespace State
{
    public interface IContext 
    {
        public IGameState CurrentState { get; }
        public IContext TransitionTo(IGameState state);
        public Task RunStateAsync(CancellationToken cancellationToken = default);
        
        public GameObject SpaceShip { get; set; }
        public GameObject Player { get; set; }
        public  GameObject TalkWithNativesPanel { get; set; }
        public List<Native> Natives { get; set; }
    }

    public class Context : IContext
    {
        public IGameState CurrentState { get; private set; } = null!;

        public GameObject SpaceShip { get; set; }
        public GameObject Player { get; set; }
        public GameObject TalkWithNativesPanel { get; set; }
        public List<Native> Natives { get; set; }


        public Context(GameObject spaceShip, GameObject player, GameObject talkWithNativesPanel, List<Native> natives)
        {
            SpaceShip = spaceShip;
            Player = player;
            TalkWithNativesPanel = talkWithNativesPanel;
            Natives = natives;
        }
        

        public IContext TransitionTo(IGameState state)
        {
            CurrentState = state;
            CurrentState.SetContext(this);
            return this;
        }

        public async Task RunStateAsync(CancellationToken cancellationToken = default) =>
            await CurrentState.RunStateAsync(cancellationToken);

    }
}