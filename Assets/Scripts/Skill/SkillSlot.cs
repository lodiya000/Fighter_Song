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
        [field: SerializeField, Header("符文")]
        public DataRune dataRune { get; private set; }
        [field: SerializeField, Header("技能插槽編號")]
        public int slotIndex { get; private set; }

        private Vector3 originalPoint;
        private Transform traCanvas;
        private Transform parent;

        public Image imgSkill { get; private set; }
        public Sprite sprSkill => imgSkill.sprite;
        public Color colorSkill => imgSkill.color;

        private void Awake()
        {
            originalPoint = transform.localPosition;
            imgSkill = GetComponent<Image>();
            imgSkill.sprite = dataRune.runeIcon;
            imgSkill.color = Color.white;
            traCanvas = GameObject.Find("畫布").transform;
            parent = transform.parent;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            imgSkill.raycastTarget = false;
            transform.SetParent(traCanvas);
            transform.SetAsLastSibling();
        }

        public void OnDrag(PointerEventData eventData)
        {
            transform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            // 如果放開後下方是另一個技能插槽就互換
            var target = eventData.pointerCurrentRaycast.gameObject;
            if (target != null && target.TryGetComponent(out SkillSlot targetSkillSlot))
            {
                var sprite = imgSkill.sprite;
                var color = imgSkill.color;
                var tempRune = dataRune;
                imgSkill.sprite = targetSkillSlot.sprSkill;
                targetSkillSlot.imgSkill.sprite = sprite;
                imgSkill.color = targetSkillSlot.colorSkill;
                targetSkillSlot.imgSkill.color = color;
                dataRune = targetSkillSlot.dataRune;
                targetSkillSlot.UpdateRune(tempRune);
                SkillSlotManager.instance.UpdateSkillTypeSorder(slotIndex, targetSkillSlot.slotIndex);
            }

            transform.SetParent(parent);
            transform.SetAsFirstSibling();
            imgSkill.raycastTarget = true;
            transform.localPosition = originalPoint;
        }

        public void UpdateRune(DataRune newRune)
        {
            dataRune = newRune;
        }
    }
}
