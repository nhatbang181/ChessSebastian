using System;
using System.Collections.Generic;
using UnityEngine;

public class ChessData : MonoBehaviour
{
    public static ChessData Instance;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);
    }

    public   List<ChessPieceData> chessPieceDataList = new List<ChessPieceData>();

    public Sprite GetPieceSprite(int piece) {
        DataChess chessData = CalculateChess.CalculateDataChess(piece);
        Debug.Log( "Chess Data type " +  chessData.type);
        Debug.Log( "Chess Data color" + chessData.color);
        ChessPieceData chessPieceData = chessPieceDataList.Find(x => x.type == chessData.type && x.color == chessData.color);
        return chessPieceData.sprite;
    }
}
[System.Serializable]
public struct ChessPieceData {
    public ChessPieceType type;
    public ChessPieceColor color;
    public Sprite sprite;
}
public enum ChessPieceType {
    None,
    Pawn,
    Knight,
    Bishop,
    Rook,
    Queen,
    King
}
public enum ChessPieceColor {
    White,
    Black
}
[Serializable] 
public struct DataChess {
    public ChessPieceType type;
    public ChessPieceColor color;
}