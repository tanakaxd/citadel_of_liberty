using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationController : MonoBehaviour
{
    public PopulationModel model;
    public PopulationView view;

    public GameObject citizenPrefab;
    public List<Transform> rows;
    void Start()
    {
        LateStart().Forget();
    }

    public void AddNewPopulation()
    {
        //maxに達しているか
        if (model.citizens.Count >= GameManager.Instance.gameModel.maxPopulation) return;

        //十分な余剰食糧があるか




        GameObject citizenGameObject = Instantiate(citizenPrefab) as GameObject;
        CitizenController citizen = citizenGameObject.GetComponent<CitizenController>();
        citizen.Init();
        citizen.transform.SetParent(getRow(), false);
        model.citizens.Add(citizen);
    }

    public async UniTask LateStart()
    {
        await UniTask.Yield();

        for (int i = 0; i < GameManager.Instance.gameModel.initialPopulation; i++)
        {
            AddNewPopulation();
        }
    }

    private Transform getRow()
    {
        int index = model.citizens.Count / 5;
        return rows[index];
    }

    public void ProduceMana()
    {
        foreach (var c in model.citizens)
        {
            c.ProduceMana();
        }
    }


}
