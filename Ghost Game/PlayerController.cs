using UnityEditor;
using UnityEditor.EditorTools;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //----------------VARIABLES--------------------

    [SerializeField] 
    [Tooltip("Set the player's movement speed.")]
    float moveSpeed = 15f;

    [SerializeField] 
    [Tooltip("Top right bound for player.")]
    Transform TRbound;

    [SerializeField] 
    [Tooltip("Bottom left bound for player.")] 
    Transform BLbound;
    
    //variables for UpdateMovement
    float verticalInput, horizontalInput, xMove, yMove;
    Vector3 pos;

    //variables for ShootBullet
    [SerializeField] 
    [Tooltip("Bullet prefab game object.")]
    GameObject bulletPrefab;

    [SerializeField] 
    [Tooltip("Empty game object representing the bullet spawn point.")]
    Transform bulletSpawnPoint;

    [SerializeField] 
    [Tooltip("How fast the bullets fly.")]
    float shootSpeed = 10f;

    public Animator animator;

    //------------------CODE STARTS HERE-----------------

    void Start()
    {
        
    }

    void Update()
    {
        UpdateMovement();
        ShootBullet();
    }

    private void UpdateMovement()
    {
        //Get user input & calculate user movement
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        yMove = verticalInput * moveSpeed * Time.deltaTime;
        xMove = horizontalInput * moveSpeed * Time.deltaTime;

        //Get player position
        pos = new Vector3 (transform.position.x, transform.position.y, 0);
        
        //Move the player within the bounds
        if(verticalInput < 0 && pos.y > BLbound.position.y || verticalInput > 0 && pos.y < TRbound.position.y)
        {
            transform.Translate(0, yMove, 0);
        }

        if(horizontalInput > 0 && pos.x < TRbound.position.x || horizontalInput < 0 && pos.x > BLbound.position.x)
        {
            transform.Translate(xMove, 0, 0);
        }
    }

    private void ShootBullet()
    {
        //when player hits the space bar, instantiates a copy of the bullet prefab shoots right
        bool shoot = Input.GetKeyDown(KeyCode.Mouse0);
        if(shoot)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = bulletSpawnPoint.right * shootSpeed;
            animator.SetBool("Shoot", shoot);
        }
    }
}
