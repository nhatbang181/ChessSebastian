using UnityEngine;

public class ChessBoard : MonoBehaviour
{
 [SerializeField] private Material whiteSquareMaterial;
 [SerializeField] private Material blackSquareMaterial;
 [SerializeField] private GameObject squarePrefab ;
 [SerializeField] private Transform squareParent;
 [SerializeField] private float squareSize = 1f;
 void Start() {
    CreateChessBoardGraphic();
 }
 public void CreateChessBoardGraphic() {
    for (int file = 0; file < 8; file++) {
        for (int rank = 0; rank < 8; rank++) {
            GameObject square = Instantiate(squarePrefab, squareParent);
            square.transform.localScale = new Vector3(1, 1, 1);
            square.transform.localPosition = new Vector3(file * squareSize, 0, rank * squareSize)  ;
            square.transform.localRotation = Quaternion.identity;
            square.GetComponentInChildren<Renderer>().material = (file + rank) % 2 == 0 ? whiteSquareMaterial : blackSquareMaterial;
            square.name = $"{file}{rank}";
        }
    }
 }
}
