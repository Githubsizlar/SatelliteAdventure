using System.Collections.Generic;
using System.Threading;
using DG.Tweening;
using State;
using Type;
using UnityEngine;

namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        private static CancellationTokenSource GeneralCancellationTokenSource { get; } = new CancellationTokenSource();
        private IContext _finalContext = null!;

        #region ContextPrefs
        [SerializeField] private GameObject spaceShip = null!;
        [SerializeField] private GameObject player = null!;
        [SerializeField] private GameObject talkWithNativesPanel = null!;
        [SerializeField] private List<Native> natives;
        #endregion
    
        [SerializeField] private GameObject apple;
        private CancellationTokenSource StateCancellationTokenSource { get; set; } = null!;
    
        public void Start()
        {
            StateCancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(GeneralCancellationTokenSource.Token);
            _finalContext = new Context(spaceShip, player,talkWithNativesPanel, natives);
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

            
            if (Input.GetKeyDown(KeyCode.Space) && natives != null)
            {
                talkWithNativesPanel.SetActive(true);
                player.gameObject.transform.parent = default;
                player.gameObject.transform.position = new Vector3(0.4f, 1, 0);
            }

            //TODO:Gain energy using hit 
            // if (Input.GetMouseButtonDown(0))
            // {
            //     if (other.collider.CompareTag($"Apple"))
            //     {
            //         Destroy(gameObject);
            //         if (playerEnergy <= 95)
            //         {
            //             playerEnergy += 5;
            //         }
            //     }
            // }
        }

        public void PassIntoPlacingHomeDraft()
        {
            talkWithNativesPanel.SetActive(false);
            for (int i = natives.Count-1; i >= 0; i--)
            {
                natives[i].gameObject.transform.rotation = new Quaternion(0,-180,0,0);
                natives[i].gameObject.transform.DOMove(new Vector3(-10, 0, 0), 2f);
                Destroy(natives[i].gameObject,.5f);
            }

            natives = null;
        }

        private void AppleCreation()
        {
            Apple a = Factory.Factory.Instance.CreateObject<Apple>();
        }
    }
}
