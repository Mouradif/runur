using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D _rb;
    private Vector2 _movement;
    private SpriteRenderer _renderer;

    private Animator _animator;

    private static readonly int IsWalking = Animator.StringToHash("isWalking");
    private static readonly int IsRunning = Animator.StringToHash("isRunning");

    // Update is called once per frame
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        var isRunning = Input.GetKey(KeyCode.LeftShift);
        var speedMultiplier = (isRunning) ? 1.5f : 1f;
        _movement.x= Input.GetAxisRaw("Horizontal");
        _renderer.flipX = (_movement.x < 0);
        _movement.y= Input.GetAxisRaw("Vertical");
        _animator.SetBool(IsWalking, (_movement.x != 0 || _movement.y != 0));
        _animator.SetBool(IsRunning, isRunning);

        _rb.MovePosition(_rb.position + _movement * (moveSpeed * speedMultiplier * Time.fixedDeltaTime));
    }
}
