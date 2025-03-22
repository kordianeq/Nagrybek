using System.Collections.Generic;
using UnityEngine;

public class LootBoxManager : MonoBehaviour
{
    UiManager uiManager;
    public Case newCase;
    bool canOpen;
    float timeBetweenOpenings;
    public int caseOpened;
    int messages = 0;

    public List<E_unusualCases> specialCases;

    Item item;

    public int slotLimit, panelLimit;

    InventoryManager inventoryManager;
    private void Start()
    {
        inventoryManager = GameObject.Find("Inventory").GetComponent<InventoryManager>();
        uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        canOpen = true;
        timeBetweenOpenings = 0;
        caseOpened = 0;

    }
    public void OpenCase()
    {

        if (canOpen)
        {
            if (caseOpened == 0)
            {
                
                newCase = GameObject.Find("Skinner").GetComponent<Case>();
                Debug.Log("skinnerOpened");
                uiManager.ActivateSkinner();

            }
            else if (specialCases[caseOpened] == E_unusualCases.Timer)
            {
                Debug.Log("timer");
                timeBetweenOpenings = 10;
            }
            else if (specialCases[caseOpened] == E_unusualCases.Exit)
            {
                Debug.Log("Exit");
                uiManager.exitButton.SetActive(true);
            }
            else if (specialCases[caseOpened] == E_unusualCases.normalMessage)
            {
                Debug.Log("Message");
                messages++;
            }
            else
            {
                newCase = GameObject.Find("DefaultCase").GetComponent<Case>();
                Debug.Log("Default");
                CaseOpening(newCase);
            }


            if (timeBetweenOpenings > 0)
            {
                canOpen = false;
                Invoke(nameof(CaseReset), timeBetweenOpenings);
            }

            //Play animation

            //inventoryManager.GetSlot(randomSlot, randomPanel);
            caseOpened++;

        }
        else
        {
            Debug.Log("Case on cooldown. Please wait");

        }

    }

    void CaseOpening(Case currentCase)
    {
        if (currentCase.gameObject.name == "DefaultCase")
        {
            int i = Random.Range(0, 101);
            if (i > 0 && i < 50)
            {
                item = currentCase.cases[0];
            }
            else if (i >= 50 && i < 90)
            {
                item = currentCase.cases[1];
            }
            else if (i >= 90 && i < 99)
            {
                item = currentCase.cases[2];
            }
            else
            {
                item = currentCase.cases[3];
            }

            Debug.Log(item.rarity);
        }


    }

    void CaseReset()
    {
        canOpen = true;
        Debug.Log("Reset");
    }
}
