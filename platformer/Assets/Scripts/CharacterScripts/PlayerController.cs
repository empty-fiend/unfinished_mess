using UnityEngine;
using CharacterScripts.functions;
using UIScripts;

public class PlayerController : MonoBehaviour
    {
        public int heartsAmount = 3;
        public float walkSpeed = 5f;
        public float runSpeed = 7f;
        public float jumpForce = 7f;
        public float jumpTime = 0.25f;
        public float rayDistance = 0.1f;
    
        public LayerMask whatIsGround;
        public Transform groundDetection;
        public GameObject lifeBar;

        private bool _grounded;
        private bool _getDamage;
        private const int MinAmountOfHearts = 3;
        private const int MaxAmountOfHearts = 16;

        private Animator _anim;
        private Rigidbody2D _rb;
        private JumpScript _jumpScript;
        private MoveScript _moveScript;
        private CollideManager _collideManager;
        private HealthManager _healthManager;
        
        private void Start()
        {
            if (heartsAmount > MaxAmountOfHearts)
                heartsAmount = MaxAmountOfHearts;
            else
            if (heartsAmount < MinAmountOfHearts)
                heartsAmount = MinAmountOfHearts;
            
            _healthManager = GetComponent<HealthManager>();
            _collideManager = GetComponent<CollideManager>();
            _moveScript = GetComponent<MoveScript>();
            _jumpScript = GetComponent<JumpScript>();
            _rb = GetComponent<Rigidbody2D>();
            _anim = GetComponent<Animator>();
            
            lifeBar.GetComponent<LifeBarUserInterface>().InitializeLifeBar(heartsAmount);
        }

        private void Update()
        {
            _grounded = _collideManager.IsISeeGround(rayDistance, groundDetection, whatIsGround);   
            _jumpScript.Jump(_grounded, Input.GetButton("Jump"), jumpForce, jumpTime, _rb);
        }

        private void FixedUpdate()
        {
            _anim.SetBool("Ground", _grounded);
            var move = Input.GetAxis("Horizontal");
            _anim.SetFloat("Speed", Mathf.Abs(move));
            var isRunning = Input.GetButton("Run");
            _moveScript.Moving(move, isRunning, walkSpeed, runSpeed, _rb, transform);
        }
    }
