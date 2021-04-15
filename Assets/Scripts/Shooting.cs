using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform firepoint;
    public float shootingCooldown = 0.5f;

    public float bulletForce = 20f;
    private Rigidbody2D _rigidbody;
    private bool _isShooting = false;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey("up"))
        {
            if (Input.GetKey("left"))
            {
                Shoot("up-left");
            }
            else if (Input.GetKey("right"))
            {
                Shoot("up-right");
            }
            else
            {
                Shoot("up");
            }
        }
        else if (Input.GetKey("down"))
        {
            if (Input.GetKey("left"))
            {
                Shoot("down-left");
            }
            else if (Input.GetKey("right"))
            {
                Shoot("down-right");
            }
            else
            {
                Shoot("down");
            }
        }
        else if (Input.GetKey("left"))
        {
            Shoot("left");
        }
        else if (Input.GetKey("right"))
        {
            Shoot("right");
        }

    }

    private static float GetShootingAngle(string direction)
    {
        switch (direction)
        {
            case "up":
                return 0f;
            case "down":
                return 180f;
            case "left":
                return 90f;
            case "right":
                return -90f;
            case "up-left":
                return 45f;
            case "up-right":
                return -45f;
            case "down-left":
                return 135f;
            case "down-right":
                return 225f;
            default:
                return 15f;
        }
    }

    private void ShootCooldown()
    {
        _isShooting = false;
    }
    private void Shoot(string direction)
    {
        if (_isShooting)
        {
            return;
        }

        _isShooting = true;
        Invoke("ShootCooldown", shootingCooldown);
        _rigidbody.rotation = GetShootingAngle(direction);
        var projectile = Instantiate(bullet, firepoint.position, firepoint.rotation);
        var rb = projectile.GetComponent<Rigidbody2D>();
        rb.AddForce(firepoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
