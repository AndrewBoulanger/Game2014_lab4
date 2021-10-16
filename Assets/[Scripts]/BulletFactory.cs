using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum BulletType
{
    ENEMY, PLAYER
}

[System.Serializable]
public class BulletFactory : MonoBehaviour
{
    string bullets;
   
  
    [Header("Bullet Types")]
    [Tooltip("order:\n enemy\n player")]
    public List<GameObject> bulletTypes = new List<GameObject>();

    public GameObject CreateBullet(BulletType type = BulletType.ENEMY)
    {
        GameObject temp_bullet = null;
        temp_bullet = Instantiate(bulletTypes[(int)type]);

        return temp_bullet;
    }

}
