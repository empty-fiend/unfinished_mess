using CharacterScripts.functions;
using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public float distance = 0.1f;
    public float speed = 3f;

    private bool _isGrounded;
    private bool _isShooting;
    private bool _isDead;

    public Transform groundDetection;
    public LayerMask groundLayers;

    private CollideManager _collideManager;
    private MoveScript _moveScript;

    public enum enemyType
    {
        Walker,
        Shooter,
        Flyer
    }
    public enemyType type;
    private void Start()
    {
        _collideManager = GetComponent<CollideManager>();
        _moveScript = GetComponent<MoveScript>();
    }

    private void Update()
    {
        _isGrounded = _collideManager.IsISeeGround(distance, groundDetection, groundLayers);
        switch (type)
        {
            case enemyType.Walker: EnemyWalker();
                break;
            case enemyType.Shooter: EnemyShooter();
                break;
            case enemyType.Flyer: EnemyFlyer();
                break;
        }
    }

    private void EnemyWalker()
    {
        if (_isDead)
        {
            Destroy(gameObject);
        }
        else
        {
            _moveScript.Moving(speed, _isGrounded);
        }
    }

    private void EnemyShooter()
    {
        Destroy(gameObject);
    }

    private void EnemyFlyer()
    {
        Destroy(gameObject);
    }
}
