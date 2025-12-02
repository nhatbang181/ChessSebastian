using UnityEngine;

public static class CalculateChess 
{
    private const int ColorMask = 1 << 5; // Bit 5 for color (32)

    public static DataChess CalculateDataChess(int piece)
    {
        DataChess dataChess = new DataChess();

        // Extract type: lower 3 bits (0b00000111)
        dataChess.type = (ChessPieceType)(piece & 7);

        // Extract color: check if bit 5 is set → Black, else White
        dataChess.color = (piece & ColorMask) != 0 ? ChessPieceColor.White : ChessPieceColor.Black;

        // Optional: Debug
        Debug.Log($"Piece: {piece} (binary: {System.Convert.ToString(piece, 2)})");
        Debug.Log($"Type: {dataChess.type}, Color: {dataChess.color}");

        return dataChess;
    }
}