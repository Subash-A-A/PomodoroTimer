using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    [SerializeField] Text TaskName;
    public int taskId;

    private TodoList todoList;

    private void Start()
    {
        todoList = FindObjectOfType<TodoList>();
    }

    public void SetTask(string taskName, int id)
    {
        TaskName.text = taskName;
        taskId = id;
        Debug.Log("Task Created with ID: " + taskId);
    }

    public void DeleteTask()
    {
        todoList.Tasks.Remove(taskId);
        Debug.Log("Task Removed");
        Destroy(gameObject);       
    }

    public void CompleteTask()
    {
        Debug.Log("Task Completed");
        Destroy(gameObject);
    }

}
