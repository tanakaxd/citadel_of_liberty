using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsController : MonoBehaviour
{
    public BuildingsModel model;
    public BuildingsView view;

    private List<SlotController> slots;

    private void Awake()
    {
        slots = new List<SlotController>(transform.GetComponentsInChildren<SlotController>());
        Debug.Log(this.slots.Count);
    }
    void Start()
    {
    }

    public void GenerateMana(BoardEntity board)
    {
        slots.ForEach(s => { if (s.building != null) s.building.GenerateMana(board); });
    }
}
