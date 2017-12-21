using UnityEditor;
using System.IO;
using UnityEngine;
using EnAndDecode;

public class CreateAssetBundles
{
    [MenuItem("Assets/Build AssetBundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = "Assets/AssetBundles";
        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }
        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows);

        // 获取所有需要加密的文件
        // 读取文件对内容进行加密 
        if(File.Exists("Assets/AssetBundles/qiu"))
        {
            Debug.Log("创建 AB 包文件成功");

            byte[] data = File.ReadAllBytes("./Assets/AssetBundles/qiu");
            FileStream dataStream = File.Create("Assets/AssetBundles/qiu.jm");

            // 使用加密  
            byte[] result = EnAndDecode.EncodeAndDecode.Encode(data);

            Debug.Log("加密前数据长度");
            Debug.Log(data.Length);
            Debug.Log("加密后数据长度");
            Debug.Log(result.Length);
            // 写入加密数据 
            dataStream.Write(result, 0, result.Length);

            dataStream.Close();
            Debug.Log("文件加密完成 ... ");
        }
    }
}