using UnityEngine;


public class playerControllerScript : MonoBehaviour
{
    // public variables
    public int health = 3;
    public int numOfHearts = 3;
    public float walkSpeed = 5f;
    public float runSpeed = 7f;
    public float jumpForce = 7f;
    public float jumpTime = 0.25f;
    public float rayDistance = 0.1f;
    
    public LayerMask whatIsGround;
    public Transform groundDetection;
    
    // private variables
    private bool _grounded;
    private bool _getDamage;
    
    private Animator _anim;
    private Rigidbody2D _rb;
    private jumpScript _jumpScript;
    private moveScript _moveScript;
    private raycastScript _raycastScript;
    private healthScript _healthScript;

    // Start is called before the first frame update
    private void Start()
    {
        // Getting access to components
        _healthScript = GetComponent<healthScript>();
        _raycastScript = GetComponent<raycastScript>();
        _moveScript = GetComponent<moveScript>();
        _jumpScript = GetComponent<jumpScript>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        _grounded = _raycastScript.IsISeeGround(rayDistance, groundDetection, whatIsGround);   
        _jumpScript.Jump(_grounded, Input.GetButton("Jump"), jumpForce, jumpTime, _rb);
        _healthScript.Health(health, numOfHearts);
    }

    private void FixedUpdate()
    {
        _anim.SetBool("Ground", _grounded);
        float move = Input.GetAxis("Horizontal");
        _anim.SetFloat("Speed", Mathf.Abs(move));
        var isRunning = Input.GetButton("Run");
        _moveScript.Moving(move, isRunning, walkSpeed, runSpeed, _rb, transform);
    }
}
