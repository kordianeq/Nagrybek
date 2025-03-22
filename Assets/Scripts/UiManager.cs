using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class UiManager : MonoBehaviour
{
    public GameObject exitButton;
    public GameObject skinner;
    public GameObject notyfyIcon;
    public TextMeshProUGUI timerText;

    public int mailNotifications;

    public bool timerStarted;
    public float targetTime;
    void Start()
    {
        timerStarted = false; timerText.text = null;
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

        if (timerStarted)
        {
            targetTime -= Time.deltaTime;
            timerText.text = targetTime.ToString();
        }
        if (targetTime <= 0.0f)
        {
            timerText.text = "Ready";
            timerEnded();
        }
    }
    public void ActivateSkinner()
    {
        skinner.SetActive(true);
    }

    void timerEnded()
    {
        
        timerStarted = false;
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
