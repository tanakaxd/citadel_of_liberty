using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    //GMはすべての参照を持っていてController同士をつなぐ役割
    //あるいはそうではなく
    //ゲーム内の情報を一括している持っているModelが欲しい？
    //データの引継ぎやセーブを考えると望ましい
    //GameManagerがModel的な役割を持っていてもいいが、基本はゲーム全体をコントロールするロジッククラス

    /*
public BoardController boardController { get; private set; }
public ManaController manaController{ get; private set; }
public DeckController deckController { get; private set; }
public TopPanelController TopPanelController { get; private set; }

*/

    public GameModel gameModel;

    private BoardEntity board;
    private PlayerEntity player;

    //State
    public bool isDiscarding = false;
    public bool isBuilding = false;

    protected override void Awake()
    {
        base.Awake();
        board = GameObject.Find("BoardEntity").GetComponent<BoardEntity>();
        player = GameObject.Find("PlayerEntity").GetComponent<PlayerEntity>();
    }


    void Start()
    {
        Debug.Log("GM start");
        StartCoroutine(BeginTurn());
    }

    public IEnumerator BeginTurn()
    {
        Debug.Log("Coroutine start");
        yield return null;
        Debug.Log("Coroutine frame after");


        //建物のパッシブ
        GenerateMana(board);

        yield return new WaitForSeconds(1);

        //ドロー
        Draw();
    }

    public void GenerateMana(BoardEntity board)
    {
        Debug.Log("GenerateMana");
        board.buildings.GenerateMana(board);
    }
    public void Draw()
    {
        Debug.Log("Draw");
        board.deck.Draw(gameModel.initialDraw);
    }

    #region getter&setter

    public static int getCurrentTurn()
    {
        return Instance.gameModel.currentTurn.Value;
    }
    public static int getMoney()
    {
        return Instance.gameModel.money.Value;
    }
    public static int getFood()
    {
        return Instance.gameModel.food.Value;
    }
    public static IntReactiveProperty getReactiveTurn()
    {
        return Instance.gameModel.currentTurn;
    }
    public static IntReactiveProperty getReactiveMoney()
    {
        return Instance.gameModel.money;
    }
    public static IntReactiveProperty getReactiveFood()
    {
        return Instance.gameModel.food;
    }

    public static void AddFood(int amounts)
    {
        Instance.gameModel.food.Value += amounts;
    }

    public static void AddMoney(int amounts)
    {
        Instance.gameModel.money.Value += amounts;
    }

    public static void AddTurn(int amounts)
    {
        Instance.gameModel.currentTurn.Value += amounts;
    }

    #endregion

}
