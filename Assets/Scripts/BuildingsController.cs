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

    public void GenerateSpell()
    {
        slots.ForEach(s => { if (s.building != null) s.building.GenerateSpell(); });
    }

    public void BlocksRaycast(bool blocks)
    {
        slots.ForEach(s => { if (s.building != null) s.building.movement.BlocksRaycast(blocks); });
    }
}
