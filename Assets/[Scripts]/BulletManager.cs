using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{

    public Queue<GameObject> bulletPool;
    public GameObject bulletPrefab;
    public int maxBulletNumber;
    public int minBulletNumber = 5;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();

        BuildBulletPool();
    }

    private void BuildBulletPool()
    {
        for(int i = 0; i < maxBulletNumber; i++ )
        {
            AddBulletToPool();
        }
    }

    private void AddBulletToPool()
    {
        var temp_Bullet = Instantiate(bulletPrefab);
        temp_Bullet.SetActive(false);
        temp_Bullet.transform.parent = transform;
        bulletPool.Enqueue(temp_Bullet);
    }

    public GameObject ActivateBullet(Vector2 spawnPosition)
    {
        if(bulletPool.Count < minBulletNumber)
        {
            for(int i = 0; i < minBulletNumber; i++)
            { 
                AddBulletToPool();
                maxBulletNumber++;
            }
        }

        var temp_bullet = bulletPool.Dequeue();
        temp_bullet.transform.position = spawnPosition;
        temp_bullet.SetActive(true);
        return temp_bullet;
    }

    public void returnBullet(GameObject returned_bullet)
    {
        returned_bullet.SetActive(false);
        bulletPool.Enqueue(returned_bullet);
            
    }

}
