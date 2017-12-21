该工程是进行资源加密时所写的 demo 例子。

项目的大致流程为：
1. 创建 AssetBundle 包文件，即对 Asset 资源进行打包；
2. 对 AssetBundle 包文件进行加密；
3. 使用 AssetBundle 包时，通过 WWW 加载文件，读取文件内容进行解密；
4. 从解密数据中创建 AssetBundle 对象；
5. 正常使用 AssetBundle 对象获取 GameObject 等资源。



