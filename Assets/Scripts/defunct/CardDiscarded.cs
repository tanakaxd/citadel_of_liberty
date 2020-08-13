using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;


public class CardDiscarded : MonoBehaviour
{
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Vector3 positionAfterDrag;
    private Vector3 offset;
    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = FindObjectOfType<Canvas>();
    }

    void Start()
    {
        var trigger = gameObject.AddComponent<ObservableEventTrigger>();

        trigger.OnBeginDragAsObservable()
            .Subscribe(e => OnBeginDrag(e));

        trigger.OnDragAsObservable()
            .Subscribe(e => OnDrag(e));

        trigger.OnEndDragAsObservable()
            .Subscribe(e => OnEndDrag(e));
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        positionAfterDrag = transform.position;
        parentAfterDrag = transform.parent;
        transform.SetParent(canvas.transform, false);
        canvasGroup.alpha = 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(parentAfterDrag, false);
        transform.position = positionAfterDrag;
        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1.0f;
    }


}
