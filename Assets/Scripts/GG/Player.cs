using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory inventory;
    
    private void Awake()
    {
        /*How many slot inventory have I gave it 10 */
        inventory = new Inventory(10);
    }
}
