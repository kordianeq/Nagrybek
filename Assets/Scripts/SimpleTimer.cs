using UnityEngine;

public class SimpleTimer : MonoBehaviour
{
    public bool timerStarted = false;
    public float targetTime = 10f;

    void Update()
    {
        if(timerStarted)
        targetTime -= Time.deltaTime;

        if (targetTime <= 0.0f)
        {
            timerEnded();
        }

    }
    public void TimerStart(float time)
    {
        targetTime = time;
        timerStarted = true;
    }

    void timerEnded()
    {
        timerStarted = false;
    }


}