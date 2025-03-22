using UnityEngine;

public class LootBoxManager : MonoBehaviour
{

    public void OpenCase()
    {
        //Play animation
        int randomNumber = Random.Range(1, 4);
        Debug.Log(randomNumber);
    }
}
