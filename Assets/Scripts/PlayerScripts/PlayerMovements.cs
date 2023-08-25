using InventoryScripts;
using UnityEngine;

namespace PlayerScripts
{
    public class PlayerMovements : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private Animator anim;

        #region Panels
        [SerializeField] private GameObject homePanel;
        [SerializeField] private GameObject nativeHomePanel1;
        [SerializeField] private GameObject nativeHomePanel2;
        [SerializeField] private GameObject nativeHomePanel3;
        #endregion

        #region Homes

        [SerializeField] private GameObject home1;
        [SerializeField] private GameObject home2;
        [SerializeField] private GameObject home3;

        #endregion
    
        public Inventory inventory;

        public int playerEnergy;
        public int playerHealth;
    
    
        private static readonly int IsMoving = Animator.StringToHash("isMoving");
        private Camera camera1;
        private bool iscamera1NotNull;

        private void Start()
        {
            iscamera1NotNull = camera1 != null;
            camera1 = Camera.main;
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
            
            if (Input.GetMouseButtonDown(0))
            {
                if (iscamera1NotNull)
                {
                    Ray ray = camera1.ScreenPointToRay(Input.mousePosition);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.collider.CompareTag("Apple"))
                        {
                            Destroy(hit.collider.gameObject);
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

            if (other.collider.CompareTag($"NativeHome1"))
            {
                nativeHomePanel1.SetActive(true);
                nativeHomePanel1.transform.SetParent(home1.transform);
                nativeHomePanel1.transform.localPosition = Vector3.zero;
            }

            if (other.collider.CompareTag($"NativeHome2"))
            {
                nativeHomePanel2.SetActive(true);
                nativeHomePanel2.transform.SetParent(home2.transform);
                nativeHomePanel2.transform.localPosition = Vector3.zero;
            }

            if (other.collider.CompareTag($"NativeHome3"))
            {
                nativeHomePanel3.SetActive(true);
                nativeHomePanel3.transform.SetParent(home3.transform);
                nativeHomePanel3.transform.localPosition = Vector3.zero;
            }
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.collider.CompareTag($"HomePanelTrigger")) homePanel.SetActive(false);
            if (other.collider.CompareTag($"NativeHome1")) nativeHomePanel1.SetActive(false);
            if (other.collider.CompareTag($"NativeHome2")) nativeHomePanel2.SetActive(false);
            if (other.collider.CompareTag($"NativeHome3")) nativeHomePanel3.SetActive(false);
        }
    }
}