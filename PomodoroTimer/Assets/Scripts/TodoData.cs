using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class TodoData
{
    public List<string> Tasks;
    public TodoData(TodoList todoList)
    {
        Tasks = todoList.Tasks;
    }
}
