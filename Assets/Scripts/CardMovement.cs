using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UniRx;
using UniRx.Triggers;

public class CardMovement : MonoBehaviour { 

    private Canvas canvas;
    private CanvasGroup canvasGroup;
    [HideInInspector] public Transform parentAfterDrag;
    [HideInInspector] public Vector3 positionAfterDrag;
    private Vector3 offset;

    //TODO
    private BoardEntity board;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = FindObjectOfType<Canvas>();

        board = GameObject.Find("BoardEntity").GetComponent<BoardEntity>();
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
        //自分ではなくボード上のカードの状態を変える
        //この必要があるのが建てる時のみなので、専用のクラスを作っているが一応他のと兼用できる
        //他のボード上のオブジェクトも透過させる必要があるからこのスクリプトで一括して行う？

        board.buildings.BlocksRaycast(false);

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
        //SlotならparentBeforeDragとpositionAfterが書き換えられる
        //drag自体はいつでもできるがslotに入る場合を限定
        transform.SetParent(parentAfterDrag, false);
        transform.position = positionAfterDrag;

        canvasGroup.blocksRaycasts = true;
        canvasGroup.alpha = 1.0f;

        board.buildings.BlocksRaycast(true);
    }

    public void BlocksRaycast(bool blocks)
    {
        canvasGroup.blocksRaycasts = blocks;
    }
}
