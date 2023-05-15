using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int coinCount;

    public bool PickUpItem(GameObject obj)
    {
        switch(obj.tag)
        {
            case Constants.TAG_CURRENCY:
                coinCount++;
                return true;
                break;
            default:
                Debug.LogWarning($"WARNING: No Handler implemented for tag {obj.tag}.");
                return false;
                

        }
        
    }
}
