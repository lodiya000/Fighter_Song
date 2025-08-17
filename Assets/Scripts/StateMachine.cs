using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 狀態機 : 用來設定預設狀態與狀態切換
    /// </summary>

    public class StateMachine
    {
        /// <summary>
        /// 當前狀態
        /// </summary>
        private State curentState;

        public void Initialize(State state)
        {
            curentState = state;    //指定當前狀態
            curentState.Enter();    //進入當前狀態
        }

        /// <summary>
        /// 更新當前狀態
        /// </summary>
        public void Update()
        {
            curentState.Update();   //更新當前狀態
        }

        /// <summary> 
        /// 切換狀態 
        /// </summary> 
        /// <param name="newState">下一個狀態</param>
        public void SwitchState(State newState)
        {
            curentState.Exit();     //先退出當前狀態
            curentState = newState; //指定為新的狀態
            curentState.Enter();    //進入當前狀態
        }
    }
}