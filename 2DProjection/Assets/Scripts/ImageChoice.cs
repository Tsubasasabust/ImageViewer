using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ImageChoice : MonoBehaviour
{
    //Texture texture;
    public Texture Sample; //確認用

    private string fullPath = "D:/ExperimentUnityImage/Check/";
    //byte[] values;

    [SerializeField, Tooltip("画像のインポート元 末尾のpng を含めてください")]
    private string _imageImportPath = "D:/ExperimentUnityImage/Check";

    [SerializeField, Tooltip("画像のインポート元 末尾のpng を含めてください")]
    private string _imageImportPath1 = "D:/ExperimentUnityImage/Point1";

    [SerializeField, Tooltip("画像のインポート元 末尾のpng を含めてください")]
    private string _imageImportPath2 = "D:/ExperimentUnityImage/Point2";

    [SerializeField, Tooltip("画像のインポート元 末尾のpng を含めてください")]
    private string _imageImportPath3 = "D:/ExperimentUnityImage/Point3";

    [SerializeField, Tooltip("画像のインポート元 末尾のpng を含めてください")]
    private string _imageImportPath4 = "D:/ExperimentUnityImage/Point4";

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            fullPath = _imageImportPath;
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            fullPath = _imageImportPath1;
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            fullPath = _imageImportPath2;
        }
        else if (Input.GetKeyDown(KeyCode.U))
        {
            fullPath = _imageImportPath3;
        }
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            fullPath = _imageImportPath4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            TextureChange(readByBinary(ChoiceImage(1)));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TextureChange(readByBinary(ChoiceImage(2)));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TextureChange(readByBinary(ChoiceImage(3)));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            TextureChange(readByBinary(ChoiceImage(4)));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            TextureChange(readByBinary(ChoiceImage(5)));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            TextureChange(readByBinary(ChoiceImage(6)));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            TextureChange(readByBinary(ChoiceImage(7)));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            TextureChange(readByBinary(ChoiceImage(8)));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TextureChange(readByBinary(ChoiceImage(9)));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            TextureChange(readByBinary(ChoiceImage(0)));
        }
        else if (Input.GetKeyDown(KeyCode.W))//確認用
        {
            TextureChangeSample();
        }
    }

    byte[] ChoiceImage(int point)
    {
        string pointNumber = point.ToString();
        string imagePath = fullPath + pointNumber + ".png";
        using (FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
        {
            BinaryReader bin = new BinaryReader(fileStream);
            byte[] values = bin.ReadBytes((int)bin.BaseStream.Length);
            bin.Close();
            return values;
        }
    }

    public Texture readByBinary(byte[] bytes)
    {
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);
        return texture;
    }

    void TextureChange(Texture texture)
    {
        Renderer renderer = this.GetComponent<Renderer>();
        renderer.material.mainTexture = texture;
    }

    void TextureChangeSample()//確認用
    {
        Renderer renderer = this.GetComponent<Renderer>();
        renderer.material.mainTexture = Sample;
    }


}
