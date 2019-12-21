using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class MovieChoice : MonoBehaviour
{
    public GameObject obj;
    private string fullPath = "D:/ExperimentUnityImage/Check/";
    [SerializeField, Tooltip("画像のインポート元 末尾のpng を含めてください")]
    private string _movieImportPath1 = "D:/ExperimentUnityImage/Point4/Movies/1.avi";
    [SerializeField, Tooltip("画像のインポート元 末尾のpng を含めてください")]
    private string _movieImportPath2 = "D:/ExperimentUnityImage/Point4/Movies/2.avi";
    [SerializeField, Tooltip("画像のインポート元 末尾のpng を含めてください")]
    private string _movieImportPath3 = "D:/ExperimentUnityImage/Point4/Movies/3.avi";
    [SerializeField, Tooltip("画像のインポート元 末尾のpng を含めてください")]
    private string _movieImportPath4 = "D:/ExperimentUnityImage/Point4/Movies/4.avi";
    private VideoPlayer videoPlayer;
    // Start is called before the first frame update
    void Start()
    {
        // VideoPlayerコンポーネント取得.
        videoPlayer = obj.GetComponent<VideoPlayer>();
        // 即再生されるのを防ぐ.
        videoPlayer.playOnAwake = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            fullPath = _movieImportPath1;
            VideoPripara();
            // // パス or VideoClip を設定.
            // videoPlayer.url = fullPath;
            // // 読込開始.
            // videoPlayer.Prepare();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            fullPath = _movieImportPath2;
            VideoPripara();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            fullPath = _movieImportPath3;
            VideoPripara();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            fullPath = _movieImportPath4;
            VideoPripara();
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            VideoPlay();
        }
    }

    void VideoPlay()
    {
        videoPlayer.Play();
    }

    void VideoPripara()
    {
        // パス or VideoClip を設定.
        videoPlayer.url = fullPath;
        // 読込開始.
        videoPlayer.Prepare();
    }
}
