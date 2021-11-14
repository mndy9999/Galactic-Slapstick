using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile_Behavior : MonoBehaviour
{
    public string playerTag;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag(playerTag))
        {
            collision.gameObject.GetComponent<PlayerMovementController>().IsHit = true;
            var projRb = GetComponent<Rigidbody2D>();
            ProjectilesManager.Instance.RemoveProjectile(projRb);
            Destroy(gameObject);
        }
    }

    public void Update()
    {
        if(transform.position.x > 20 || transform.position.x < -20 || transform.position.y > 20 || transform.position.y < -20)
        {
            ProjectilesManager.Instance.RemoveProjectile(GetComponent<Rigidbody2D>());
            Destroy(gameObject);
        }
    }

}
