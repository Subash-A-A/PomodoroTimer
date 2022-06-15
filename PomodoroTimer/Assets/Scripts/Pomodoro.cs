using UnityEngine;
using UnityEngine.UI;

public class Pomodoro : MonoBehaviour
{
    [SerializeField] Text TimerText;
    [SerializeField] Image TimeSlider;
    [SerializeField] float setTimer = 25f;

    private float currentTime;
    private float maxTimeInMins;
    public bool startTimer = false;

    private void Start()
    {
        maxTimeInMins = setTimer * 60f;
        currentTime = setTimer * 60f;
        startTimer = false;
        TimeSlider.fillAmount = currentTime/ maxTimeInMins;
    }

    private void Update()
    {
        SetTimerText();
        Timer();
    }

    void SetTimerText()
    {
        float mins = Mathf.Clamp(Mathf.Floor(currentTime / 60f), 0, 60f);
        float secs = Mathf.Clamp(Mathf.Floor(currentTime % 60f), 0, 60f);
        TimerText.text = mins.ToString("00") +":"+ secs.ToString("00");
    }

    public void Timer()
    {
        if (startTimer && currentTime > 0)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        TimeSlider.fillAmount = Mathf.Lerp(TimeSlider.fillAmount, currentTime / maxTimeInMins, 10 * Time.deltaTime);
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
