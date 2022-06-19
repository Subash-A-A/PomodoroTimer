using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TodoList : MonoBehaviour
{
    [SerializeField] GameObject Task;
    [SerializeField] InputField TaskInput;
    [SerializeField] Transform Content;

    public List<int> Tasks = new List<int>();

    public void AddTask()
    {
        string taskText = TaskInput.text;

        if (string.IsNullOrEmpty(taskText))
        {
            Debug.Log("Enter a Valid Task name");
            return;
        }

        string taskName = taskText;
        int taskId = taskText.GetHashCode();

        if (Tasks.Contains(taskId))
        {
            Debug.Log("Task is already in Todo List!");
            return;
        }

        GameObject task = Instantiate(Task, Content);
        Task currentTask = task.GetComponent<Task>();
        currentTask.SetTask(taskName, taskId);

        Tasks.Add(taskId);
    }
}
