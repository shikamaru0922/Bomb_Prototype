using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionEffect;  // 爆炸特效
    public float explosionRadius = 5f;  // 爆炸半径
    public float explosionForce = 700f; // 爆炸力

    private bool hasExploded = false;

    public void Detonate()
    {
        if (hasExploded) return;

        // 显示爆炸特效
        Instantiate(explosionEffect, transform.position, Quaternion.identity);

        // 获取爆炸范围内的物体
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // 施加爆炸力
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        hasExploded = true;
        Destroy(gameObject); // 销毁炸弹
    }
}