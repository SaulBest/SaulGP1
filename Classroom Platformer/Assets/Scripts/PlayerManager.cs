using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour


{

    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int coinCount;

    public bool PickUpItem(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Currency":
                coinCount++;
                return true;


            case "Speed+":
                playerMovement.SpeedPowerUp();
                return true;
            default:
                Debug.Log("Item tag or reference not set");
                return false;
        }
      



       

    }

   


}
