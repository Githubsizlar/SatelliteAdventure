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
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.CompareTag("Player"))
            {
                player.inventory.Add(this);
                Destroy(this.gameObject);
            }
        }
    }
    
    public enum CollectableType
    {
        NONE, 
        APPLE,
    }
}