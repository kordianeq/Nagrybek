using UnityEngine;
using UnityEngine.UI;

public class EqSlot : MonoBehaviour
{
    Button button;
    IdList parent;
    Image image;
    public int slotIndex;
    public bool isUnlocked;
    public Sprite imageSlot;
    private void Start()
    {
        image = GetComponent<Image>();
        button = GetComponent<Button>();

        if (isUnlocked)
        {
            image.material.SetFloat("_GrayscaleAmount", 0);
        }
        else
        {
            image.material.SetFloat("_GrayscaleAmount", 1);
        }
    }
    private void Update()
    {
        if (isUnlocked)
        {
            image.material.SetFloat("_GrayscaleAmount", 0);
        }
        else
        {
            image.material.SetFloat("_GrayscaleAmount", 1);
        }
    }

    public void SetIsUnlocked(bool unlocked)
    {
        isUnlocked = unlocked;
    }


}
