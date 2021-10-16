using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")]
    [Range(0.0f, 100f)]
    public float horizontalForce;
    private Rigidbody2D rigidbody;
    [Range (0f, 1f)]
    public float decay;
    public Bounds bounds;

    [SerializeField]
    float frameDelay;

    [SerializeField]
    PlayerBulletManager bulletManager;
    [SerializeField]
    Transform bulletSpawner;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }




    private void FixedUpdate()
    {
        Move();
        CheckBounds();
        CheckFire();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");

        rigidbody.AddForce(new Vector2(x * horizontalForce, 0.0f));

        rigidbody. velocity *= (1f - decay);
;
    }

    private void CheckBounds()
    {
        if(transform.position.x < bounds.min)
        {
            transform.position = new Vector2(bounds.min, transform.position.y);
        }
        else if (transform.position.x > bounds.max)
        {
            transform.position = new Vector2(bounds.max, transform.position.y);
        }
    }

    private void CheckFire()
    {
        if(Input.GetAxisRaw("Jump") > 0 && Time.frameCount % frameDelay == 0)
        {
            bulletManager.ActivateBullet(bulletSpawner.position);
        }
    }

}
