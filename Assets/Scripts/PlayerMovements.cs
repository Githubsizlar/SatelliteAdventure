using UnityEngine;
using UnityEngine.Serialization;

public class PlayerMovements : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Animator anim;

    [SerializeField] private GameObject homePanel;

    public int playerEnergy;
    public int playerHealth;
    
    
    private static readonly int IsMoving = Animator.StringToHash("isMoving");

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector2(horizontal, vertical);
        transform.position += direction * (speed * Time.deltaTime);
        
        
        if (horizontal != 0 || vertical != 0)
        {
            anim.SetBool(IsMoving,true);
            if (horizontal < 0)
            {
                transform.rotation = Quaternion.Euler(new Vector3(0,180,0));
            }
            if (horizontal > 0)
            {
                transform.rotation  = Quaternion.Euler(new Vector3(0,0,0));
            }
        }

        if (horizontal == 0 && vertical == 0)
        {
            anim.SetBool(IsMoving,false);
        }

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag($"HomePanelTrigger"))
        {
            homePanel.SetActive(true);
        }
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.collider.CompareTag($"HomePanelTrigger"))
        {
            homePanel.SetActive(false);
        }
    }
}