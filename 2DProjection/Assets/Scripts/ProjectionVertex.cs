using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class ProjectionVertex : MonoBehaviour
{
    public GameObject Sprite;
    private List<GameObject> objectList = new List<GameObject>();
    [SerializeField, Tooltip("ファイル名の末尾に付く文字")]
    private string _imageTitle = "img";

    //保存先の指定 (末尾に / を付けてください)
    [SerializeField, Tooltip("ファイルの保存先 末尾の/ を含めてください")]
    private string _imagePath = "Assets/ScreenShots/";

    [SerializeField]
    private int _timeStampType = 0;
    private int CreateNumber = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        ClickMouseCreate();

        if (Input.GetKeyDown(KeyCode.S))
        {
            CaptureScreen();
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckNumber();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            ListRemoveObject();
        }


    }

    void ClickMouseCreate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            worldPos.z = -5;
            GameObject CreateSprite = Instantiate(Sprite, worldPos, Quaternion.identity);
            objectList.Add(CreateSprite);
        }
    }

    void ListRemoveObject()
    {
        int Count = objectList.Count;
        GameObject listLast = objectList[Count - 1];
        Debug.Log(listLast);
        Destroy(listLast);
        objectList.Remove(listLast);
    }

    void CaptureScreen()
    {
        int stringObjectCount = objectList.Count;
        string objectCount = stringObjectCount.ToString();
        string Name = getTimeStamp() + _imageTitle + objectCount + ".png";
        ScreenCapture.CaptureScreenshot(_imagePath + Name);
        //AssetDatabase.Refresh();
        Debug.Log("screenshot");
    }

    void CheckNumber()
    {
        Debug.Log(objectList.Count);
    }

    private string getTimeStamp()
    {
        string time;

        //タイムスタンプの設定書き足せます
        // 0 数字の連番 / 20180101125959
        // 1 数字の連番(年無し) / 0101125959
        // 2 年月日付き / 2018年01月01日12時59分59秒
        // 3 年月日付き(年無し) / 01月01日12時59分59秒
        switch (_timeStampType)
        {
            case 0:
                time = DateTime.Now.ToString("yyyyMMddHHmmss");
                return time;
                break;
            case 1:
                time = DateTime.Now.ToString("MMddHHmmss");
                return time;
                break;
            case 2:
                time = DateTime.Now.ToString("yyyy年MM月dd日HH時mm分ss秒");
                return time;
                break;
            case 3:
                time = DateTime.Now.ToString("MM月dd日HH時mm分ss秒");
                return time;
                break;
            default:
                time = DateTime.Now.ToString("yyyyMMddHHmmss");
                return time;
                break;
        }
    }

}
