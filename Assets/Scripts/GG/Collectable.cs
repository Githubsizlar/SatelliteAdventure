using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public CollectableType type;
    // player walks into 
    // add collectable to player
    // delete collectable from the screen
    [SerializeField] private void OnTriggerEnter2D(Collider2D collision)
    {
        /* gets components of player*/ 
        Player player = collision.GetComponent<Player>();
        if (player)
        {
            player.inventory.Add(type);
            Destroy(this.gameObject);
        }
    }
}
public enum CollectableType
{
    NONE, APPLE
}
