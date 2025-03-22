
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdList : MonoBehaviour
{
    public int panelIndex;
    private void Start()
    {
        //AssignSlots();
    }
   public void AssignSlots()
    {
        int i = 0;  
        Transform parent = gameObject.transform;
        foreach(Transform child in parent)
        {
            child.GetComponent<EqSlot>().slotIndex = i;
            child.GetComponent<EqSlot>().panelIndex = panelIndex;
            i++;
        }
    }

}
