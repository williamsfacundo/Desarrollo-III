using UnityEngine;

namespace ChickenVSZombies.GameplayItems //Move to gameplay Items or include the script into bullet folder
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