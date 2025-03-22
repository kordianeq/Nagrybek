using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    public GameObject exitButton;
    public GameObject skinner;
    public GameObject notyfyIcon;

    public int mailNotifications;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mailNotifications > 0)
        {
            notyfyIcon.SetActive(true);
            AddMailNotification();
        }
        else
        {
            notyfyIcon.SetActive(false);
        }
    }
    public void ActivateSkinner()
    {

    }

    public void OnClickExit()
    {
        Application.Quit();
    }
    
    void AddMailNotification()
    {
        
        notyfyIcon.GetComponentInChildren<TextMeshProUGUI>().text = mailNotifications.ToString();
    }

    public void AllNotyficationsRead()
    {
        mailNotifications = 0;
    }
}
