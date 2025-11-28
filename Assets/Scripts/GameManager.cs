using UnityEngine;

public class GameManager
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null) _instance = new GameManager(); 
            return _instance;
        }
    }

    /// <summary>
    /// 設定指標能見度
    /// </summary>
    /// <param name="isVisible">是否能見</param>
    public void SetCursorVisible(bool isVisible)
    {
        Cursor.visible = isVisible;
        Cursor.lockState = isVisible ?
           CursorLockMode.None : CursorLockMode.Locked;
    }
}
