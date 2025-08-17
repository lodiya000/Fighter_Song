using UnityEngine;

namespace Lodiya
{
    /// <summary>
    /// 狀態類別 包含進入/更新/離開狀態 三種方法
    /// </summary>
    public class State
    {
        //protected 保護修飾詞:允許子類別存取
        protected string name;
        protected StateMachine stateMachine;
        protected float timer;

        /// <summary>
        /// 進入狀態
        /// </summary>
        public virtual void Enter()
        {
            //Log.Text($"進入{name}狀態", "#6f6");
            timer = 0;
        }

        /// <summary>
        /// 更新狀態
        /// </summary>
        public virtual void Update()
        {
            //Log.Text($"更新{name}狀態", "#ff3");
            timer += Time.deltaTime;
        }

        /// <summary>
        /// 離開狀態
        /// </summary>
        public virtual void Exit()
        {
            //Log.Text($"離開{name}狀態", "#f66");
        }
    }
}
