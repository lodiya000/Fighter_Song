using UnityEngine;

namespace Lodiya
{
    public class Log
    {
        /// <summary>
        /// 
        /// <param name="text">想輸入的文字</param>
        /// <param name="color">想設定的顏色</param>
        /// </summary>

        public static void Text(object text, string color = "#fff")
        {
            string result = $"<color={color}>{text}</color>";
            Debug.Log(result);
        }
    }

}
