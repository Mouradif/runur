using UnityEngine;

public class Attacking: MonoBehaviour
{
    public float shootingCooldown = 0.5f;
    public GameObject player;

    private Rigidbody2D _rigidbody;
    private Animator _anim;
    private bool _isAttacking;
    private static readonly int Attack = Animator.StringToHash("attack");

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        transform.SetParent(player.transform, false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown("up"))
        {
            Shoot("up");
        }
        else if (Input.GetKeyDown("down"))
        {
            Shoot("down");
        }
        else if (Input.GetKeyDown("left"))
        {
            Shoot("left");
        }
        else if (Input.GetKeyDown("right"))
        {
            Shoot("right");
        }

    }

    private static float GetShootingAngle(string direction)
    {
        return direction switch
        {
            "up" => 90f,
            "down" => -90f,
            "left" => 180f,
            _ => 0f
        };
    }

    private static Vector3 GetLocalPosition(string direction)
    {
        return direction switch
        {
            "up" => new Vector3(-0.5f, 1f),
            "down" => new Vector3(0.1f, -1f),
            "left" => new Vector3(-1, 0),
            _ => new Vector3(0.8f, 0.3f)
        };
    }

    private void ShootCooldown()
    {
        _isAttacking = false;
        _rigidbody.transform.localPosition = new Vector3(0.8f, 0.3f);
        _rigidbody.rotation = 0f;
    }
    private void Shoot(string direction)
    {
        if (_isAttacking)
        {
            return;
        }

        _isAttacking = true;
        _anim.SetTrigger(Attack);
        
        Invoke(nameof(ShootCooldown), shootingCooldown);
        _rigidbody.rotation = GetShootingAngle(direction);
        _rigidbody.transform.localPosition = GetLocalPosition(direction);
    }
}