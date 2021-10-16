using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [Header("Movement")]
    [Range(0, 0.5f )]
   public float speed;
    public Bounds bulletBounds;

    public BulletDirection direction;

    public BulletManager bulletManager;
    
    private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        switch(direction)
        {
            case BulletDirection.UP:
                velocity = new Vector3(0.0f, speed, 0.0f);
                break;
            case BulletDirection.RIGHT:
                velocity = new Vector3(speed, 0.0f, 0.0f);
                break;
            case BulletDirection.DOWN:
                velocity = new Vector3(0.0f, -speed, 0.0f);
                break;
            case BulletDirection.LEFT:
                velocity = new Vector3( -speed, 0.0f, 0.0f);
                break;

        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        transform.position += velocity;
    }
    private void CheckBounds()
    {
        if(transform.position.y < bulletBounds.max)
        {
            bulletManager.returnBullet(this.gameObject);
        }

        if (transform.position.y > bulletBounds.min)
        {
            bulletManager.returnBullet(this.gameObject);
        }
    }
}
