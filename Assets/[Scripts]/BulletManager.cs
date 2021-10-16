using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletManager : MonoBehaviour
{
    public  Queue<GameObject> bulletPool; 
    public int bulletCount ;
    public int minBulletNumber = 5;

    protected BulletFactory factory;

    // Start is called before the first frame update
    void Start()
    {
        bulletPool = new Queue<GameObject>();
    
        factory = GetComponent<BulletFactory>();
    }

    protected virtual void AddBulletToPool()
    {

    }

    public virtual GameObject ActivateBullet(Vector2 spawnPosition)
    {
        if(bulletPool.Count < minBulletNumber)
        {
            for(int i = 0; i < minBulletNumber; i++)
            { 
                AddBulletToPool();
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
