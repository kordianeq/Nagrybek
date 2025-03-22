using System.Collections.Generic;
using UnityEngine;

public class LootBoxManager : MonoBehaviour
{
    public Case newCase;
    bool canOpen;
    public float timeBetweenOpenings;
    public int caseOpened = 0;

    public List<int> specialCases;

    public int slotLimit, panelLimit;

    InventoryManager inventoryManager;
    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
        canOpen = true;

    }
    public void OpenCase()
    {
        if (canOpen)
        {
            if (caseOpened == 0)
            {
                newCase = GameObject.Find("Skinner").GetComponent<Case>();
            }
            else if (specialCases[caseOpened] == 0);
            else
            {
                newCase = GameObject.Find("DefaultCase").GetComponent<Case>();
            }
            canOpen = false;
            //Play animation





            //inventoryManager.GetSlot(randomSlot, randomPanel);
            caseOpened++;

            Invoke(nameof(CaseReset), timeBetweenOpenings);
        }
        else
        {
            Debug.Log("Case on cooldown. Please wait");

        }

    }

    void CaseReset()
    {
        canOpen = true;
        Debug.Log("Reset");
    }
}
