using UnityEngine;
using UnityEngine.UI;

public class Pomodoro : MonoBehaviour
{
    [Header("Timer Sliders")]
    [SerializeField] Text TimerText;
    [SerializeField] Image TimeSlider;
    [SerializeField] Image SessionSlider;

    [Header("SessionTimings")]
    public float[] SessionTimings;

    [Header("Debugging")]
    [SerializeField] private bool startTimer = false;
    [SerializeField] private bool isLongBreak = false;

    private float iteration;
    private float maxLongBreakTime;
    private float currentTime;
    private float maxTimeInMins;
    
    private int session;

    private float mins;
    private float secs;

    private void Start()
    {
        session = 0;
        iteration = 0;
        maxLongBreakTime = SessionTimings[2] * 60f;

        startTimer = false;
        maxTimeInMins = SessionTimings[session] * 60f;
        currentTime = SessionTimings[session] * 60f;
        TimeSlider.fillAmount = currentTime / maxTimeInMins;
        SessionSlider.fillAmount = iteration / maxLongBreakTime;
    }

    private void Update()
    {
        SetTimerText();
        Timer();
        SliderLerper();

        if (currentTime <= 0)
        {
            ChangeSession();
        }
        if (iteration <= 0 && isLongBreak)
        {
            ResetSession();
        }
    }

    void SetTimerText()
    {

        if (!isLongBreak)
        {
            mins = Mathf.Clamp(Mathf.Floor(currentTime / 60), 0, 60f);
            secs = Mathf.Clamp(currentTime % 60, 0, 59f);
        }
        else 
        {
            mins = Mathf.Clamp(Mathf.Floor(iteration / 60f), 0, 60f);
            secs = Mathf.Clamp(iteration % 60, 0, 59f);
        }
        
        TimerText.text = mins.ToString("00") +":"+ secs.ToString("00");
    }

    public void Timer()
    {
        if (startTimer && currentTime > 0 && !isLongBreak)
        {
            currentTime -= 1 * Time.deltaTime;
        }
        if (isLongBreak && startTimer && iteration > 0)
        {
            iteration -= 1 * Time.deltaTime;
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
    void ChangeSession()
    {
        StopTimer();
        if(session == 0)
        {
            iteration += maxLongBreakTime / 4;
        }
        if(iteration == maxLongBreakTime)
        {
            Debug.Log("Long Break!");
            isLongBreak = true;
        }
        else
        {
            session = (session + 1) % (SessionTimings.Length - 1);
        }
        SetSession();
    }
    void ResetSession()
    {
        startTimer = false;
        isLongBreak = false;
        session = 0;
        iteration = 0;
        maxLongBreakTime = SessionTimings[2] * 60f;
    }
    void SetSession()
    {
        currentTime = SessionTimings[session] * 60f;
        maxTimeInMins = SessionTimings[session] * 60f;
    }

    void SliderLerper()
    {
        TimeSlider.fillAmount = Mathf.Lerp(TimeSlider.fillAmount, currentTime / maxTimeInMins, 10 * Time.deltaTime);
        SessionSlider.fillAmount = Mathf.Lerp(SessionSlider.fillAmount, iteration / maxLongBreakTime, 10 * Time.deltaTime);
    }

}
