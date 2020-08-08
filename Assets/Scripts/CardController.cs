using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{

    public CardModel model;
    public CardView view;
    void Start()
    {
        model.reactiveID.Subscribe()
    }

    void Update()
    {
        
    }
}
