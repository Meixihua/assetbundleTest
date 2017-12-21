using UnityEngine;
using System.Collections;
using System.IO;
// using UnityEditor;

public class Assetbundletest : MonoBehaviour {
    public string url;
    public int version;
    public string assetName;
    public string assetBundleName;

    string manifestName;

    void Start()
    {
        InitializeAssetBundlePath();
        StartCoroutine(LoadAssetBundleAsObject());
    }

    void InitializeAssetBundlePath()
    {
#if UNITY_EDITOR

        url = "file://" + Application.streamingAssetsPath + "/../AssetBundles/qiu.jm";        // 使用加密后的文件 
#endif
    }

    public IEnumerator LoadAssetBundleAsObject()
    {

        WWW www2 = new WWW(url);
        yield return www2;

        if (!string.IsNullOrEmpty(www2.error))
        {
            Debug.Log(www2.error);
        }
        else
        {
            Debug.Log("WWW 读取本地文件成功 。。。 ");
            byte[] testbyte = www2.bytes;
            //读取文件之后，对文件进行解密 
            /*
             * TODO : 对 testbyte 内容进行解密， 然后对解密的数据执行 LoadFromMemory 方法创建 AssetBundle 
             */
            // 解密过程 
            int offset = sizeof(int) + sizeof(int);
            byte[] testNew = new byte[testbyte.Length - offset];
            for(int i = offset, j = 0; i < testbyte.Length; i++, j++)
            {
                testNew[j] = testbyte[i];
            }

            AssetBundle ab = AssetBundle.LoadFromMemory(testNew);

            if(ab != null)
            {
                Debug.Log("loadAssetBundle 成功 。。。 ");
            }
            // 实际是 Sphere 是 Sphere.prefab 文件，可以不添加后缀（不添加后缀，注意重名问题）   
            GameObject qiu = ab.LoadAsset<GameObject>("Sphere.prefab");
            if(qiu == null)
            {
                Debug.Log("加载资源 失败");
            }
            else
            {
                Debug.Log("加载资源成功");
                Instantiate(qiu);
                Debug.Log("初始化实例成功");
            }


            //AssetBundle ab = www2.assetBundle;
            //GameObject gobj = ab.LoadAsset("qiu") as GameObject;
            //Instantiate(gobj);
        }

        www2.Dispose();
    }

}