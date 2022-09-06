using UnityEngine;

namespace ChickenVSZombies.GameplayItems
{
    public class BulletDestroyer : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.transform.tag == "Bullet")
            {
                Destroy(collision.gameObject);
            }
        }        
    }
}