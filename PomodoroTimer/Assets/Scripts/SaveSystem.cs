using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveTodo(TodoList todoList)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/data.todo";
        FileStream stream = new FileStream(path, FileMode.Create);

        TodoData todoData = new TodoData(todoList);

        formatter.Serialize(stream, todoData);
        stream.Close();
    }

    public static TodoData LoadTodo()
    {
        string path = Application.persistentDataPath + "/data.todo";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TodoData data = formatter.Deserialize(stream) as TodoData;
            stream.Close();

            return data;
        }
        else
        {
            return null;
        }
    }
}
