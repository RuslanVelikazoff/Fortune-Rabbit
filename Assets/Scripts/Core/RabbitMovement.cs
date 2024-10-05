using UnityEngine;

public class RabbitMovement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rabbitRigidbody;
    [SerializeField] 
    private Joystick joystick;

    [Space(13)]
    
    [SerializeField]
    private float normalSpeed;
    [SerializeField] 
    private float jumpForce;
    
    private Vector2 moveDirection;
    
    private bool isWalk = false;
    private bool isJump = false;
    private bool isGround;

    [Space(13)]
    
    [SerializeField] 
    private SpawnRabbit spawnRabbit;
    private Animator rabbitAnimator;
    private GameObject rabbitGameObject;

    private void Awake()
    {
        SetJumpForce();
    }

    private void Start()
    {
        rabbitAnimator = spawnRabbit.GetRabbitAnimator();
        rabbitGameObject = spawnRabbit.GetRabbit();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rabbitRigidbody.position, Vector2.down, 1.5f, LayerMask.GetMask("Platform"));

        if (hit.collider != null)
        {
            isGround = true;
            isJump = false;
        }
        else
        {
            isGround = false;
            isJump = true;
        }

        if (joystick.Horizontal != 0)
        {
            isWalk = true;
        }
        else
        {
            isWalk = false;
        }
        
        RotationPlayer();
        rabbitAnimator.SetBool("IsRun", isWalk);
        rabbitAnimator.SetBool("IsJump", isJump);
    }

    private void FixedUpdate()
    {
        moveDirection = new Vector2(joystick.Horizontal * normalSpeed, rabbitRigidbody.velocity.y);
        rabbitRigidbody.velocity = moveDirection;
    }

    private void RotationPlayer()
    {
        if (joystick.Horizontal > 0)
        {
            rabbitGameObject.transform.rotation = new Quaternion(
                rabbitGameObject.transform.rotation.x,
                0,
                rabbitGameObject.transform.rotation.z,
                0);
        }
        else if(joystick.Horizontal == 0)
        {
            
        }
        else
        {
            rabbitGameObject.transform.rotation = new Quaternion(
                rabbitGameObject.transform.rotation.x,
                180,
                rabbitGameObject.transform.rotation.z,
                0);
        }
    }

    private void SetJumpForce()
    {
        switch (PlayerPrefs.GetInt("PurchasedMegaJump"))
        {
            case 0:
                jumpForce = 6;
                break;
            case 1:
                jumpForce = 10;
                break;
        }
    }

    public void Jump()
    {
        if (isGround)
        {
            rabbitRigidbody.velocity = Vector2.up * jumpForce;
        }
    }
}
