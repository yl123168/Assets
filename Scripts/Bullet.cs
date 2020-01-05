using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子弹、运动触发检测
/// </summary>
public class Bullet : MonoBehaviour
{
    /// <summary>
    /// 子弹飞行速度
    /// </summary>
    public float bulletSpeed = 50;

    private void Update()
    {
        BulletMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag) {
            case "Player":
                collision.GetComponent<Player>().Death();
                break;
            case  "Wall":
                break;
            case "Grass":
                break;
            case "Heart":
                break;
            case "Barriar":
                break;
            default:
                break;
        }
    }

    private void BulletMove() {
        this.transform.Translate(this.transform.up*bulletSpeed*Time.deltaTime,Space.World);
    }
}
