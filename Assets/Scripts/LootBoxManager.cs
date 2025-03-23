using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class LootBoxManager : MonoBehaviour
{
    [SerializeField] boxAnimControll boxAnimControll;
    [SerializeField] GameObject claimButton;

    [SerializeField] Item skinner;
    UiManager uiManager;
    [SerializeField] TextMeshProUGUI itemNameText;
    [SerializeField] Image itemBg;
    [SerializeField] List<Sprite> rarityImages;
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
            boxAnimControll.OpenBox();
            claimButton.SetActive(true);
            if (caseOpened == 0)
            {
                
                newCase = GameObject.Find("Skinner").GetComponent<Case>();
                Debug.Log("skinnerOpened");
                item = skinner;
                

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
                uiManager.targetTime = 10f;
                uiManager.timerStarted = true;
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

    public void UnlockReward()
    {
       switch(item.type)
        {
            case E_ItemType.skinner:

                uiManager.ActivateSkinner();
                itemNameText.text = item.name;
                
                return;
            case E_ItemType.normal:

                itemNameText.text = item.name;
                switch (item.rarity)
                {
                    case E_Rarity.common:
                        itemBg.sprite = rarityImages[0];
                        return;
                    case E_Rarity.rare:
                        itemBg.sprite = rarityImages[1];
                        return;
                    case E_Rarity.epic:
                        itemBg.sprite = rarityImages[2];
                        return;
                    case E_Rarity.legendary:
                        itemBg.sprite = rarityImages[3];
                        return;
                }
                return;
        }
    }
    void CaseReset()
    {
        canOpen = true;
        Debug.Log("Reset");
    }
}
