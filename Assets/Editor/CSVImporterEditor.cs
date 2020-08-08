using UnityEditor;
using UnityEngine;
using static CardData;

[CustomEditor(typeof(CsvImporter))]
public class CSVImpoterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var csvImpoter = target as CsvImporter;
        DrawDefaultInspector();

        if (GUILayout.Button("プレイヤーモデルデータの作成"))
        {
            Debug.Log("プレイヤーモデルデータ作成ボタンが押された");
            SetCsvDataToScriptableObject(csvImpoter);
        }
    }

    private void SetCsvDataToScriptableObject(CsvImporter csvImporter)
    {
        // ボタンを押されたらパース実行
        if (csvImporter.csvFile == null)
        {
            Debug.LogWarning(csvImporter.name + " : 読み込むCSVファイルがセットされていません。");
            return;
        }

        // csvファイルをstring形式に変換
        string csvText = csvImporter.csvFile.text;

        // 改行ごとにパース
        string[] textLines = csvText.Split('\n');

        for (int i = 0; i < textLines.Length; i++)
        {
            string[] elementsInLine = textLines[i].Split(',');

            //0はID
            int column = 0;

            // 先頭の列が空であればその行は読み込まない
            if (elementsInLine[column] == "")
            {
                continue;
            }

            // codeNameからファイル名とパスを作成
            string fileName = "CardData_"+elementsInLine[0]+"_"+elementsInLine[2] + ".asset";
            string path = "Assets/ImportedData/" + fileName;

            // CardModelDataのインスタンスをメモリ上に作成
            var cardModelData = CreateInstance<CardData>();

            cardModelData.ID = int.Parse(elementsInLine[column]);

            column++;
            cardModelData.cardName = elementsInLine[column];

            column++;
            cardModelData.codeName = elementsInLine[column];

            column++;
            switch (elementsInLine[column])
            {
                case "BUILDING":
                    cardModelData.type = CardType.BUILDING;
                    break;
                case "SPELL":
                    cardModelData.type = CardType.SPELL;
                    break;
                default:
                    Debug.LogError("invalid card type");
                    break;
            }

            column++;
            switch (elementsInLine[column])
            {
                case "AGRICULTURE":
                    cardModelData.category = CardCategory.AGRICULTURE;
                    break;
                case "CONSTRUCTION":
                    cardModelData.category = CardCategory.CONSTRUCTION;
                    break;
                case "GATHERING":
                    cardModelData.category = CardCategory.GATHERING;
                    break;
                case "STUDY":
                    cardModelData.category = CardCategory.STUDY;
                    break;
                case "COMMERCIAL":
                    cardModelData.category = CardCategory.COMMERCIAL;
                    break;
                case "RELIGION":
                    cardModelData.category = CardCategory.RELIGION;
                    break;
                case "AGORA":
                    cardModelData.category = CardCategory.AGORA;
                    break;
                default:
                    Debug.LogError("invalid card category");
                    break;
            }

            column++;
            cardModelData.discardsToBuild = int.Parse(elementsInLine[column]);

            column++;
            cardModelData.greenPerTurn = int.Parse(elementsInLine[column]);

            column++;
            cardModelData.bluePerTurn = int.Parse(elementsInLine[column]);

            column++;
            cardModelData.redPerTurn = int.Parse(elementsInLine[column]);

            column++;
            cardModelData.greenToActivate = int.Parse(elementsInLine[column]);

            column++;
            cardModelData.blueToActivate = int.Parse(elementsInLine[column]);

            column++;
            cardModelData.redToActivate = int.Parse(elementsInLine[column]);

            column++;
            cardModelData.anythingToActivate = int.Parse(elementsInLine[column]);

            //csvの行の最後は,で終わらせておいた方がいい


            // インスタンス化したものをアセットとして保存
            var asset = (CardData)AssetDatabase.LoadAssetAtPath(path, typeof(CardData));
            if (asset == null)
            {
                // 指定のパスにファイルが存在しない場合は新規作成
                AssetDatabase.CreateAsset(cardModelData, path);
            }
            else
            {
                // 指定のパスに既に同名のファイルが存在する場合は更新
                EditorUtility.CopySerialized(cardModelData, asset);
                AssetDatabase.SaveAssets();
            }
            AssetDatabase.Refresh();
        }
        Debug.Log(csvImporter.name + " : カードモデルデータの作成が完了しました。");
    }
}