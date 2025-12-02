using System;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
   [SerializeField] private Color whiteColor;
   [SerializeField] private Color blackColor;
 
   [SerializeField] private Transform squareParent;
   public const  int BoardSize = 8;
    [SerializeField] private GameObject squarePrefab;
    [SerializeField] private float oneChessSize = 1;
   List<Transform> squares = new List<Transform>();
    List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();
    public static ChessBoard instance;

    private void Awake()
    {
       if (instance == null) instance = this;
       else Destroy(gameObject);
    }

    void Start() {
      CreateChessBoardGraphic();
   }

   public Transform GetSquare(int file, int rank)
   {
      return  squares[file * BoardSize + rank];
   }
   void LateUpdate() {
    for (int file = 0;  file < BoardSize; file++) {
        for (int rank = 0; rank < BoardSize; rank++) {
            int index = file * BoardSize + rank;
            spriteRenderers[index].color = (file + rank) % 2 == 0 ? blackColor : whiteColor;
        }
    }
   }
   public void CreateChessBoardGraphic() {
      for (int file = 0; file < BoardSize; file++) {
         for (int rank = 0; rank < BoardSize; rank++) {

            GameObject square = Instantiate(squarePrefab, squareParent);
            square.transform.parent = squareParent;
            square.transform.localScale = new Vector3(1, 1, 1);
            square.transform.localPosition = new Vector3(rank * oneChessSize, file * oneChessSize, 0);
            square.transform.localRotation = Quaternion.identity;
            square.name = $"{file}{rank}";
            spriteRenderers.Add(square.GetComponentInChildren<SpriteRenderer>());
            squares.Add(square.transform);
         }
      }
      
      Board board = FindFirstObjectByType<Board>();
      board.InitialBoard();
   }
}
