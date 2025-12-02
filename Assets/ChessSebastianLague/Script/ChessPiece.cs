using System;
using UnityEngine;

public class ChessPiece : MonoBehaviour
{
   public int Piece;
   private SpriteRenderer spriteRenderer;
   private Board Board;
   private int currentBoardIndex;
  
   public void SetUpPiece(int piece, int color, Board board, int currentBoardIndex) {
    Piece = piece | color;
    Board = board;
    spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    this.currentBoardIndex = currentBoardIndex;
    spriteRenderer.sprite = ChessData.Instance.GetPieceSprite(Piece);
   }
}
