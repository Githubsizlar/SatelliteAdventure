using DG.Tweening;
using UnityEngine;

namespace DefaultNamespace
{
    public class FallingFromShip2: MonoBehaviour
    {
        private void Start()
        {
            transform.DOMove(new Vector3(0, 0.779999971F, 0), 1F);
        }
    }
}