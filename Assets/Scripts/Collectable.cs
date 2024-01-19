using UnityEngine;

public class Collectable : MonoBehaviour
{
    public PlayerInventorySO playerInventorySO;


    private void OnTriggerEnter(Collider other)
    {
        if (other != null)
        {
            if (this.gameObject.CompareTag("Magazine"))
            {
                if (other.CompareTag("Player"))
                {
                    playerInventorySO.currentAmmo += 10;
                    Destroy(this.gameObject);
                }
            }
            if (this.gameObject.CompareTag("Grenade"))
            {
                if (other.CompareTag("Player"))
                {
                    Destroy(this.gameObject);
                    playerInventorySO.currentGrenade += 1;
                }
            }
        }
    }
}
