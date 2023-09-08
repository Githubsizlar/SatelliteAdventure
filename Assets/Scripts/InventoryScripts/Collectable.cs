using System;
using PlayerScripts;
using UnityEngine;

namespace InventoryScripts
{
    public class Collectable : MonoBehaviour
    {
        public CollectableType type;
        public Sprite icon;

        public PlayerMovements player;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            player = collision.GetComponent<PlayerMovements>();
            if (player)
            {
                player.inventory.Add(this);
                Destroy(this.gameObject);
            }
            /*
            if (other.collider.CompareTag("Player"))
            {
                player.inventory.Add(this);
                Destroy(gameObject);
            }
            */
        }
    }
    
    public enum CollectableType
    {
        NONE, 
        APPLE,
    }
}