using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField] Text TaskName;
    public void SetTask(string taskName)
    {
        TaskName.text = taskName;
    }

    public void DeleteTask()
    {
        Debug.Log("Task Removed");
        Destroy(gameObject);       
    }

    public void CompleteTask()
    {
        Debug.Log("Task Completed");
        Destroy(gameObject);
    }

}
