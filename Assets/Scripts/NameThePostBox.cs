using UnityEngine;

public class NameThePostBox : MonoBehaviour
{

    [SerializeField] private GameObject player;
    
    public void DisablePlayerMovements()
    {
        player.GetComponent<PlayerMovements>().enabled = false;
    }


    public void EnablePlayerMovements()
    {
        player.GetComponent<PlayerMovements>().enabled = true;
    }
}
