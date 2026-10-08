using UnityEngine;
using UnityEngine.EventSystems;

public class UIDraggable : MonoBehaviour, IDragHandler, IBeginDragHandler
{
    private RectTransform rectTransform;
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        // Khi bắt đầu kéo có thể thêm effect nếu muốn
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canvas != null)
        {
            // Di chuyển UI theo delta của chuột, chia cho scaleFactor để chuẩn xác trên mọi độ phân giải
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }
}
