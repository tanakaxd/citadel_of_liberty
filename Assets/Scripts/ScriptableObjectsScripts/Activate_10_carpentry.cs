using Cysharp.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Activate_10_carpentry")]
public class Activate_10_carpentry : ActivateCardEffect
{



    public override async UniTask Activate(CardController card, PlayerEntity player, BoardEntity board)
    {
        GameManager.Instance.isChoicePrompting = true;

        //建物カード建築
        GameManager.Instance.isBuilding = true;
        Debug.Log("Activate_10_carpentry begin");


        //建築完了まで待つ
        //Slotcontrollerが確認
        await UniTask.WaitUntil(()=>!GameManager.Instance.isBuilding);

        //コスト分カードを捨てる
        Debug.Log("手札を捨ててください");
        GameManager.Instance.isDiscarding = true;

        await player.hands.StartDiscard();

        //Trashcontrollerが確認
        await UniTask.WaitUntil(() => !GameManager.Instance.isDiscarding);


        Debug.Log("Activate_10_carpentry done");
        GameManager.Instance.isChoicePrompting = false;

    }

}