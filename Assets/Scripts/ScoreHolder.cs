using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
	public static ScoreHolder Instance;
        public string PlayerName;
        public int PlayerScore;
        public string BestPlayerName;
        public int BestPlayerScore;



        private void Awake()
        {
		    if (Instance != null)
		    {
		        Destroy(gameObject);
		        return;
		    }
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadScore(); 
        }

    [System.Serializable]
    class SaveData
    {
        public string Name;
        public int Score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.Name = BestPlayerName;
        data.Score = BestPlayerScore;

        string json = JsonUtility.ToJson(data);
      
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestPlayerName = data.Name;
            BestPlayerScore = data.Score;
        }
    }
}
