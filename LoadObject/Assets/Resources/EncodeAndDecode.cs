using System.IO;

namespace EnAndDecode
{
    public class EncodeAndDecode
    {
        public static byte[] Encode(byte[] text)
        {
            if (text == null)
            {
                return null;
            }
            /*
             * TODO: 加密算法
             */
            
            // demo
            int encodeVersion = 1;
            byte[] versionData = System.BitConverter.GetBytes(encodeVersion);
            int offset = sizeof(int);
            byte[] resultData = new byte[text.Length + offset];
            int j = 0;
            for (int i = 0; i < versionData.Length; i++)
            {
                resultData[j++] = versionData[i];
            }
            for (int i = 0; i < text.Length; i++)
            {
                resultData[j++] = text[i];
            }
            return resultData;
        }

        public static byte[] Decode(byte[] text)
        {
            if (text == null)
                return null;
            /**
             *  TODO: 解密算法 
             */


            // demo 
            int offset = sizeof(int);
            byte[] result = new byte[text.Length - offset];
            for (int i = offset, j = 0; i < text.Length; i++, j++)
            {
                result[j] = text[i];
            }
            return result;
        }
    }

}

