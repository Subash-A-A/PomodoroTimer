using UnityEngine;
using UnityEngine.UI;

public class Pomodoro : MonoBehaviour
{
    [SerializeField] Text TimerText;
    [SerializeField] float setTimer = 25f;

    private float currentTime;
    public bool startTimer = false;

    private void Start()
    {
        currentTime = setTimer * 60f;
        startTimer = false;
    }

    private void Update()
    {
        SetTimerText();
        Timer();
    }

    void SetTimerText()
    {
        TimerText.text = currentTime.ToString("0");
    }

    public void Timer()
    {
        if (startTimer && currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
        }
    }
    public void StartTimer()
    {
        startTimer = true;
    }

    public void StopTimer()
    {
        startTimer = false;
    }

}
