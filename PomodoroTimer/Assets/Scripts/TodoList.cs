using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class TodoList : MonoBehaviour
{
    [SerializeField] GameObject Task;
    [SerializeField] InputField TaskInput;
    [SerializeField] Transform Content;

    public List<string> Tasks;

    private void Start()
    {   
        LoadTodoList();
    }
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

        if (Tasks.Contains(taskName))
        {
            Debug.Log("Task is already in Todo List!");
            return;
        }

        GameObject task = Instantiate(Task, Content);
        Task currentTask = task.GetComponent<Task>();
        currentTask.SetTask(taskName, taskId);
        Tasks.Add(taskName);

        SaveTodoList();
    }

    public void SaveTodoList()
    {
        SaveSystem.SaveTodo(this);
    }
    public void LoadTodoList()
    {
        TodoData data = SaveSystem.LoadTodo();
        Tasks = data.Tasks;

        foreach(string taskName in Tasks)
        {
            GameObject task= Instantiate(Task, Content);
            Task currentTask = task.GetComponent<Task>();
            currentTask.SetTask(taskName, taskName.GetHashCode());
        }
    }
}
