using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

public class NestedData : MonoBehaviour
{
    // Start is called before the first frame update
    private string Name = "Mrudula";
    private int score=90;
    private int maxScore = 100;
    private int maxHealth=5;
    private int health=5;
   
    [System.Serializable]
    public class ToSerializedData
    {
        public string Name;
        public int score;
        public int health;
        public int Errors;
    }
    void Start()
    {
        ToSaveData();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            ToLoadTheData();
        }
    }
    public void ToSaveData()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
       string filePath=Application.persistentDataPath+"/Mrudula.PT";
       // FileStream fs = File.Open(filePath, FileMode.Create);
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
       // BinaryWriter bw = new BinaryWriter(fs);
        ToSerializedData Instance=new ToSerializedData();
        Instance.score=score;
        Instance.health=health;
        Instance.Name=Name;
        Instance.Errors = 50;
        binaryFormatter.Serialize(fs, Instance);
        fs.Close();

}
    public void ToLoadTheData()
    {
        
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        string filePath = Application.persistentDataPath + "/Mrudula.PT";
         FileStream fs = File.Open(filePath, FileMode.Open);
        //FileStream fs = new FileStream(filePath, FileMode.Open);
        ToSerializedData Instance= binaryFormatter.Deserialize(fs) as ToSerializedData;
       Debug.Log(Instance.Name);
        Debug.Log(Instance.score );
        Debug.Log(Instance.health);
        Debug.Log(Instance.Errors );
        //string myData = Instance.ToString();
      

    }


}
