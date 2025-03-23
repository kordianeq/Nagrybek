using UnityEngine;

public class boxAnimControll : MonoBehaviour
{
    Animator animator;
    public GameObject claimRewardPanel;
    public LootBoxManager boxManager;
    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    public void OpenBox()
    {
        animator.SetTrigger("BoxOpen");
    }

    public void ClaimReward()
    {
        animator.SetTrigger("Claim");
    }
    public void DisplayReward()
    {
        claimRewardPanel.SetActive(true);
        boxManager.UnlockReward();
    }
}
