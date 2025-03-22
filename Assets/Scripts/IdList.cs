
using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IdList : MonoBehaviour
{
    public List<GameObject> slotList;
    private void Start()
    {
        AssignSlots();
    }
    void AssignSlots()
    {
        int i = 0;  
        Transform parent = gameObject.transform;
        foreach(Transform child in parent)
        {
            slotList.Add(child.gameObject);
            child.GetComponent<EqSlot>().slotIndex = i;
            i++;
        }
    }

}
