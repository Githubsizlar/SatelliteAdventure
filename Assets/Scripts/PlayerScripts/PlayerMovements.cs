using InventoryScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovements : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Animator anim;

        [SerializeField] private GameObject homePanel;
    
        public Inventory inventory;

        public int playerEnergy;
        public int playerHealth;
    
    
        private static readonly int IsMoving = Animator.StringToHash("isMoving");

        private void Start()
        {
            anim = GetComponent<Animator>();
        }

        private void Awake()
        {
            /*How many slot inventory have I gave it 10 */
            inventory = new Inventory(10);
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
            
            //Raycast
            if (Input.GetMouseButtonDown(0))
            {
                if (Camera.main != null)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.CompareTag("Apple"))
                        {
                            Destroy(hit.collider.gameObject);
                            Debug.Log("OLDU ANAM OLDU");
                        }
                    }
                }
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
}