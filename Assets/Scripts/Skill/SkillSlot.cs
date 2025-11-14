using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Lodiya
{
    /// <summary>
    /// 技能插槽
    /// </summary>
    public class SkillSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private Vector3 originalPoint;
        private Transform traCanvas;
        private Transform parent;

        public  Image imgSkill { get; private set; }
        public Sprite sprSkill => imgSkill.sprite;
        public Color colorSkill => imgSkill.color;

        private void Awake()
        {
            originalPoint = transform.localPosition;
            imgSkill = GetComponent<Image>();
            traCanvas = GameObject.Find("畫布").transform;
            parent = transform.parent;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            imgSkill.raycastTarget = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            Debug.Log($"{name}拖拉中");
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            Debug.Log($"{name}拖拉結束");

            //若放開的地點有另一個技能插槽，則交換
            var target = eventData.pointerCurrentRaycast.gameObject;

            if (target != null && target.TryGetComponent(out SkillSlot targetSkillSlot))
            {
                var speite = imgSkill.sprite;
                var color = imgSkill.color;

                imgSkill.sprite = targetSkillSlot.sprSkill;
                targetSkillSlot.imgSkill.sprite = speite;
                imgSkill.color = targetSkillSlot.colorSkill;
                targetSkillSlot.imgSkill.color = color;
            }

            transform.SetParent(parent);
            transform.SetAsFirstSibling();
            imgSkill.raycastTarget = true;
            transform.localPosition = originalPoint;
        }
    }
}