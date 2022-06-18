using UnityEngine;
using UnityEngine.UI;

public class TodoList : MonoBehaviour
{
    [SerializeField] GameObject Task;
    [SerializeField] InputField TaskInput;
    [SerializeField] Transform Content;
    
    public void AddTask()
    {
        string taskText = TaskInput.text;
        if (string.IsNullOrEmpty(taskText))
        {
            taskText = "Empty Task";
        }
        GameObject task = Instantiate(Task, Content);
        Task currentTask = task.GetComponent<Task>();
        currentTask.SetTask(taskText);
    }

}
