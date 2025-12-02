using UnityEngine;

public class Board : MonoBehaviour
{
     int boardSize = 8;
   public int [] Square;
    [SerializeField] GameObject chessPiecePrefab;
   void Start() {
    boardSize = ChessBoard.BoardSize;

   }
public void InitialBoard() {
    Square = new int[64];
    for (int file = 0; file < 8; file++) {
        for (int rank = 0; rank < 8; rank++) {
        
            Transform parentTransform = ChessBoard.instance.GetSquare(file, rank);
                GameObject chessPiece = Instantiate(chessPiecePrefab, parentTransform);
                chessPiece.transform.localPosition = new Vector3(0, 0, 0);
                ChessPiece chessPieceScript = chessPiece.GetComponent<ChessPiece>();
                chessPieceScript.SetUpPiece(Piece.Pawn, Piece.Black, this, file * boardSize + rank);
            
        }
    }
}
        
}