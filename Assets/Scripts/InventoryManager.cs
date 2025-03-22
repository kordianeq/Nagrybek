using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    Transform parent;
    [SerializeField] Image activeField;
    private void Start()
    {
        AssignPanels();

    }
    void AssignPanels()
    {
        int i = 0;
        parent = gameObject.transform;
        foreach (Transform child in parent)
        {
            child.gameObject.GetComponent<IdList>().panelIndex = i;
            child.gameObject.GetComponent<IdList>().AssignSlots();
            i++;
        }
    }

    public void GetSlot(int slotIndex, int panelIndex)
    {

        foreach (Transform child in parent)
        {
            if (child.gameObject.GetComponent<IdList>().panelIndex == panelIndex)
            {
                foreach (Transform child2 in child)
                {
                    if (child2.GetComponent<EqSlot>().slotIndex == slotIndex)
                    {
                        child2.gameObject.GetComponent<EqSlot>().isUnlocked = true;
                        //child2.gameObject.GetComponent<EqSlot>().ChangeImage(activeField);

                    }
                }
            }
        }

    }
}
