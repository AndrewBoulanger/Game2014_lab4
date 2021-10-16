using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletManager : BulletManager
{
    protected override void AddBulletToPool() 
    {
        GameObject temp_Bullet = factory.CreateBullet(BulletType.PLAYER);
        temp_Bullet.SetActive(false);
        temp_Bullet.GetComponent<BulletBehaviour>().bulletManager = this;
        bulletPool.Enqueue(temp_Bullet);
        bulletCount++;
    }
}
