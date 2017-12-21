using UnityEditor;
using System.IO;
using UnityEngine;

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
            FileStream dataStream = File.Create("Assets/AssetBundles/qiu.jm", data.Length + sizeof(int));
            byte[] lengthData = System.BitConverter.GetBytes(data.Length);
            byte[] nameData = System.BitConverter.GetBytes(4);
            Debug.Log(lengthData.Length);
            Debug.Log(data.Length);
            int sizedata = sizeof(int);
            dataStream.Write(lengthData, 0, lengthData.Length);
            dataStream.Write(nameData, 0, nameData.Length);
            dataStream.Write(data, 0, data.Length);

            dataStream.Close();
            Debug.Log("文件加密完成 ... ");
        }
    }
}