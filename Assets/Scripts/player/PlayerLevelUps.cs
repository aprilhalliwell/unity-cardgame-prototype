namespace player
{
  public static class PlayerLevelUps
  {
    public static bool ShouldLevelUp(int currentExp)
    {
      //there are only 10 levels
      //there are 25 matches
      /*
       * [1][2][3][4][5][6][7][8][9][0][1][2][3][4][5][6][7][8][9][0][1][2][3][4][5]
       * [1][ ][2][ ][3][ ][4][ ][5][6][ ][ ][7][ ][8][ ][ ][9][ ][0][ ][ ][ ][ ][ ]
       */
      switch (currentExp)
      {
        case 1: return true;
        case 3: return true;
        case 5: return true;
        case 7: return true;
        case 9: return true;
        case 10: return true;
        case 13: return true;
        case 15: return true;
        case 18 : return true;
        case 20 : return true;
        default: return false;
      }
    }
  }
}