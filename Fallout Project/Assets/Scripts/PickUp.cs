using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public AudioClip soundEffect;
    public GameObject pickupEffect;

   private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerManager manager = collision.GetComponent<PlayerManager>();
        if(manager)
        {
            bool pickedUp = manager.PickUpItem(gameObject);
            if (pickedUp)
            {
                RemoveItem();
            }
            
        }
    }
    private void RemoveItem()
    {
        AudioSource.PlayClipAtPoint(soundEffect, transform.position);
        Instantiate(pickupEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
