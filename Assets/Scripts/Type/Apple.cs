using DG.Tweening;
using UnityEngine;

namespace Type
{
    public class Apple: MonoBehaviour
    {
        private void Start()
        {
            transform.DOMoveY(gameObject.transform.position.y-3.5f, 1F);
            Destroy(gameObject, 5f);
        }
    }
}