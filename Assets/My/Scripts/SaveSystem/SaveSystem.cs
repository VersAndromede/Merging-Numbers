using System.IO;
using UnityEngine;

public static class SaveSystem
{
    private static readonly string _filePath;

    static SaveSystem()
    {
        _filePath = Application.persistentDataPath + "/Save.json";
    }

    public static void Save(SaveData saveData)
    {
        var json = JsonUtility.ToJson(saveData, true);

        using (var writer = new StreamWriter(_filePath))
        {
            writer.WriteLine(json);
        }
    }

    public static SaveData Load()
    {
        if (File.Exists(_filePath) == false)
            return new SaveData();

        string json = string.Empty;

        using (var reader = new StreamReader(_filePath))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
                json += line;
        }

        if (string.IsNullOrEmpty(json))
            return new SaveData();

        return JsonUtility.FromJson<SaveData>(json);
    }
}