using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //acces function from player manager and call it 
            PlayerManager manager = collision.GetComponent<PlayerManager>();
            if (manager)
            {
               bool pickedUp = manager.PickUpItem(gameObject);
                if (pickedUp)
                {
                    Destroy(gameObject);
                 
                }
            }
            

           
            
        }
    }
}
