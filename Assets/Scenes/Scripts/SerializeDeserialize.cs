using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SerializeDeserialize : MonoBehaviour
{
    // Start is called before the first frame update
    public string filePath;
    public int integer = 10;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            SaveTheData();
        }
        if(Input.GetKeyDown(KeyCode.L))
        {
            LoadTheData();
        }
        
    }
    public void SaveTheData()
    {
        filePath = Application.persistentDataPath + "/MyFile.Mrudula";
        FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate);
        BinaryWriter bw = new BinaryWriter(fs);
        bw.Write("Hello This is Mrudula");
        bw.Write(integer);
        bw.Close();
        fs.Close();
    }
    public void LoadTheData()
    {
        filePath = Application.persistentDataPath + "/MyFile.Mrudula";
        FileStream fs = new FileStream(filePath, FileMode.Open);
        BinaryReader binaryReader = new BinaryReader(fs);
       Debug.Log( binaryReader.Read());
        Debug.Log( binaryReader.ReadInt32());
        binaryReader.Close();
        fs.Close();


    }
}
