using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [Header("Enemy Movement")]

    public Bounds movementBounds;
    public Bounds startRange;
    private float startingPoint;
    private float randomSpeed;

    [Header("Bullets")]
    public Transform bulletSpawn;
    private EnemyBulletManager bulletManager;

    public int frameDelay;

    // Start is called before the first frame update
    void Start()
    {
        randomSpeed = Random.RandomRange(movementBounds.min, movementBounds.max);
        startingPoint = Random.RandomRange(startRange.min, startRange.max);
        bulletManager = FindObjectOfType<EnemyBulletManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(Mathf.PingPong(Time.time, randomSpeed) + startingPoint, transform.position.y);
    }

    private void FixedUpdate()
    {
        if(Time.frameCount % frameDelay == 0 )
        {
            bulletManager.ActivateBullet(bulletSpawn.position);
        }
    }
}
