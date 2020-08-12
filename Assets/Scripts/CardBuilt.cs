using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;
using UniRx;
using UniRx.Triggers;

public class CardBuilt : MonoBehaviour
{
    private Canvas canvas;
    private CanvasGroup canvasGroup;
    [HideInInspector] public Transform parentBeforeDrag;
    [HideInInspector] public Vector3 positionAfter;
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
            //.Where(_=>GameManager.Instance.isBuilding)
            .Do(_ => Debug.Log("OnBeginDragAsObservable CardBuilt Onnext"))
            .Do(e => Debug.Log(e.pointerDrag))
            .Subscribe(e=>OnBeginDrag(e));

        trigger.OnDragAsObservable()
            //.Where(_ => GameManager.Instance.isBuilding)
            //.Do(_ => Debug.Log("OnDragAsObservable CardBuilt Onnext"))
            //.Do(e => Debug.Log(e.pointerDrag))
            .Subscribe(e=>OnDrag(e));

        trigger.OnEndDragAsObservable()
            //.Where(_ => GameManager.Instance.isBuilding)
            .Do(_ => Debug.Log("OnEndDragAsObservable CardBuilt Onnext"))
            .Do(e => Debug.Log(e.pointerDrag))
            .Subscribe(e=>OnEndDrag(e));
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.blocksRaycasts = false;
        positionAfter = transform.position;

        parentBeforeDrag = transform.parent;
        transform.SetParent(canvas.transform, false);

        canvasGroup.alpha = 0.5f;
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;

    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //SlotならparentBeforeDragとpositionAfterが書き換えられる
        transform.SetParent(parentBeforeDrag, false);
        transform.position = positionAfter;

        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1.0f;
    }


}
