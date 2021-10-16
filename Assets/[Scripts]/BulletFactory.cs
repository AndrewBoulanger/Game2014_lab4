using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum BulletType
{
    ENEMY, PLAYER, 
    END
}

[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    string bullets;
   
  
    [Header("Bullet Types")]
    public List<GameObject> bulletTypes = new List<GameObject>();

    public GameObject CreateBullet(BulletType type = BulletType.ENEMY)
    {
        if(bulletTypes == null)
            bulletTypes = new List<GameObject>();

        GameObject temp_bullet = null;
        temp_bullet = Instantiate(bulletTypes[(int)type]);

        return temp_bullet;
    }

}
