﻿using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GridCreator : MonoBehaviour {

  List<string> Arrangements = new List<string> { };
  string Log = "";

  char[] Numbers = { '0', '1', '2', '3', '4', '5', '6', '7', '0', '1', '2', '3', '4', '5', '6', '7', '0', '1', '2', '3', '4', '5', '6', '7', '0', '1', '2', '3', '4', '5', '6', '7' };

  void Create () {
    do {
      Numbers.Shuffle();
      if (Arrangements.Count() == 0) {
        Arrangements.Add(Numbers[0].ToString() + Numbers[1].ToString() + Numbers[2].ToString() + Numbers[3].ToString());
      }
      else if (Arrangements.Count() < 19) {
        if (WasTaken(Arrangements.Last()[1].ToString() + Numbers[1].ToString() + Arrangements.Last()[3].ToString() + Numbers[3].ToString())) {
          Numbers.Shuffle();
        }
        else {
          Arrangements.Add(Arrangements.Last()[1].ToString() + Numbers[1].ToString() + Arrangements.Last()[3].ToString() + Numbers[3].ToString());
        }
      }
      else if (Arrangements.Count() % 19 == 0) {
        if (WasTaken(Arrangements[(Arrangements.Count() - 19)][2].ToString() + Arrangements[(Arrangements.Count() - 19)][3].ToString() + Numbers[2].ToString() + Numbers[3].ToString())) {
          Numbers.Shuffle();
        }
        else {
          Arrangements.Add(Arrangements[(Arrangements.Count() - 19)][2].ToString() + Arrangements[(Arrangements.Count() - 19)][3].ToString() + Numbers[2].ToString() + Numbers[3].ToString());
        }
      }
      else {
        if (WasTaken(Arrangements[(Arrangements.Count() - 19)][2].ToString() + Arrangements[(Arrangements.Count() - 19)][3].ToString() + Arrangements.Last()[3].ToString() + Numbers[3].ToString())) {
          Numbers.Shuffle();
        }
        else {
          Arrangements.Add(Arrangements[(Arrangements.Count() - 19)][2].ToString() + Arrangements[(Arrangements.Count() - 19)][3].ToString() + Arrangements.Last()[3].ToString() + Numbers[3].ToString());
        }
      }
    } while (Arrangements.Count() != 361);
    for (int i = 0; i < Arrangements.Count(); i++) {
      for (int j = 0; j < 4; j++) {
        if (j % 4 == 0) {
          Log += "new int[] {" + Arrangements[i][j] + ", ";
        }
        else if (j % 4 != 3) {
          Log += Arrangements[i][j] + ", ";
        }
        else {
          Log += Arrangements[i][j] + "}, ";
        }
      }
    }
    Debug.Log(Log);
  }

  bool WasTaken(string Input) {
    for (int i = 0; i < Arrangements.Count(); i++) {
      if (Input == Arrangements[i]) {
        return true;
      }
    }
    return false;
  }

  //public void AlterToHTML () {
    //string Input = "3, 3, 2, 6 }, , 3, 1, 6, 7 }, , 1, 7, 7, 5 }, , 7, 2, 5, 5 }, , 2, 3, 5, 6 }, , 3, 3, 6, 6 }, , 3, 6, 6, 4 }, , 6, 3, 4, 2 }, , 3, 5, 2, 3 }, , 5, 1, 3, 1 }, , 1, 2, 1, 4 }, , 2, 0, 4, 6 }, , 0, 2, 6, 7 }, , 2, 1, 7, 2 }, , 1, 4, 2, 7 }, , 4, 5, 7, 7 }, , 5, 4, 7, 7 }, , 4, 3, 7, 3 }, , 3, 3, 3, 2 }, , 2, 6, 6, 1 }, , 6, 7, 1, 4 }, , 7, 5, 4, 2 }, , 5, 5, 2, 2 }, , 5, 6, 2, 4 }, , 6, 6, 4, 2 }, , 6, 4, 2, 3 }, , 4, 2, 3, 7 }, , 2, 3, 7, 5 }, , 3, 1, 5, 7 }, , 1, 4, 7, 2 }, , 4, 6, 2, 7 }, , 6, 7, 7, 1 }, , 7, 2, 1, 4 }, , 2, 7, 4, 4 }, , 7, 7, 4, 5 }, , 7, 7, 5, 2 }, , 7, 3, 2, 6 }, , 3, 2, 6, 7 }, , 6, 1, 0, 7 }, , 1, 4, 7, 7 }, , 4, 2, 7, 0 }, , 2, 2, 0, 3 }, , 2, 4, 3, 0 }, , 4, 2, 0, 0 }, , 2, 3, 0, 6 }, , 3, 7, 6, 3 }, , 7, 5, 3, 7 }, , 5, 7, 7, 6 }, , 7, 2, 6, 4 }, , 2, 7, 4, 0 }, , 7, 1, 0, 6 }, , 1, 4, 6, 2 }, , 4, 4, 2, 4 }, , 4, 5, 4, 0 }, , 5, 2, 0, 4 }, , 2, 6, 4, 5 }, , 6, 7, 5, 6 }, , 0, 7, 0, 5 }, , 7, 7, 5, 5 }, , 7, 0, 5, 0 }, , 0, 3, 0, 0 }, , 3, 0, 0, 7 }, , 0, 0, 7, 3 }, , 0, 6, 3, 1 }, , 6, 3, 1, 2 }, , 3, 7, 2, 1 }, , 7, 6, 1, 0 }, , 6, 4, 0, 1 }, , 4, 0, 1, 2 }, , 0, 6, 2, 4 }, , 6, 2, 4, 1 }, , 2, 4, 1, 2 }, , 4, 0, 2, 1 }, , 0, 4, 1, 3 }, , 4, 5, 3, 4 }, , 5, 6, 4, 0 }, , 0, 5, 4, 1 }, , 5, 5, 1, 2 }, , 5, 0, 2, 2 }, , 0, 0, 2, 7 }, , 0, 7, 7, 7 }, , 7, 3, 7, 7 }, , 3, 1, 7, 1 }, , 1, 2, 1, 5 }, , 2, 1, 5, 6 }, , 1, 0, 6, 6 }, , 0, 1, 6, 3 }, , 1, 2, 3, 3 }, , 2, 4, 3, 1 }, , 4, 1, 1, 1 }, , 1, 2, 1, 0 }, , 2, 1, 0, 2 }, , 1, 3, 2, 5 }, , 3, 4, 5, 2 }, , 4, 0, 2, 4 }, , 4, 1, 6, 4 }, , 1, 2, 4, 0 }, , 2, 2, 0, 5 }, , 2, 7, 5, 2 }, , 7, 7, 2, 7 }, , 7, 7, 7, 3 }, , 7, 1, 3, 7 }, , 1, 5, 7, 4 }, , 5, 6, 4, 5 }, , 6, 6, 5, 1 }, , 6, 3, 1, 3 }, , 3, 3, 3, 7 }, , 3, 1, 7, 0 }, , 1, 1, 0, 4 }, , 1, 0, 4, 2 }, , 0, 2, 2, 4 }, , 2, 5, 4, 7 }, , 5, 2, 7, 5 }, , 2, 4, 5, 1 }, , 6, 4, 6, 5 }, , 4, 0, 5, 1 }, , 0, 5, 1, 5 }, , 5, 2, 5, 5 }, , 2, 7, 5, 1 }, , 7, 3, 1, 7 }, , 3, 7, 7, 5 }, , 7, 4, 5, 5 }, , 4, 5, 5, 3 }, , 5, 1, 3, 4 }, , 1, 3, 4, 0 }, , 3, 7, 0, 4 }, , 7, 0, 4, 1 }, , 0, 4, 1, 7 }, , 4, 2, 7, 4 }, , 2, 4, 4, 2 }, , 4, 7, 2, 2 }, , 7, 5, 2, 7 }, , 5, 1, 7, 1 }, , 6, 5, 4, 6 }, , 5, 1, 6, 5 }, , 1, 5, 5, 3 }, , 5, 5, 3, 2 }, , 5, 1, 2, 3 }, , 1, 7, 3, 5 }, , 7, 5, 5, 1 }, , 5, 5, 1, 6 }, , 5, 3, 6, 6 }, , 3, 4, 6, 5 }, , 4, 0, 5, 3 }, , 0, 4, 3, 4 }, , 4, 1, 4, 3 }, , 1, 7, 3, 3 }, , 7, 4, 3, 3 }, , 4, 2, 3, 5 }, , 2, 2, 5, 6 }, , 2, 7, 6, 2 }, , 7, 1, 2, 7 }, , 4, 6, 5, 4 }, , 6, 5, 4, 2 }, , 5, 3, 2, 3 }, , 3, 2, 3, 3 }, , 2, 3, 3, 5 }, , 3, 5, 5, 7 }, , 5, 1, 7, 2 }, , 1, 6, 2, 1 }, , 6, 6, 1, 4 }, , 6, 5, 4, 1 }, , 5, 3, 1, 4 }, , 3, 4, 4, 7 }, , 4, 3, 7, 7 }, , 3, 3, 7, 3 }, , 3, 3, 3, 5 }, , 3, 5, 5, 0 }, , 5, 6, 0, 6 }, , 6, 2, 6, 5 }, , 2, 7, 5, 4 }, , 5, 4, 1, 2 }, , 4, 2, 2, 1 }, , 2, 3, 1, 7 }, , 3, 3, 7, 5 }, , 3, 5, 5, 1 }, , 5, 7, 1, 7 }, , 7, 2, 7, 1 }, , 2, 1, 1, 2 }, , 1, 4, 2, 2 }, , 4, 1, 2, 0 }, , 1, 4, 0, 0 }, , 4, 7, 0, 0 }, , 7, 7, 0, 5 }, , 7, 3, 5, 5 }, , 3, 5, 5, 6 }, , 5, 0, 6, 1 }, , 0, 6, 1, 5 }, , 6, 5, 5, 3 }, , 5, 4, 3, 4 }, , 1, 2, 6, 1 }, , 2, 1, 1, 6 }, , 1, 7, 6, 7 }, , 7, 5, 7, 2 }, , 5, 1, 2, 0 }, , 1, 7, 0, 2 }, , 7, 1, 2, 0 }, , 1, 2, 0, 3 }, , 2, 2, 3, 5 }, , 2, 0, 5, 0 }, , 0, 0, 0, 7 }, , 0, 0, 7, 6 }, , 0, 5, 6, 5 }, , 5, 5, 5, 2 }, , 5, 6, 2, 7 }, , 6, 1, 7, 5 }, , 1, 5, 5, 1 }, , 5, 3, 1, 1 }, , 3, 4, 1, 4 }, , 6, 1, 0, 3 }, , 1, 6, 3, 4 }, , 6, 7, 4, 2 }, , 7, 2, 2, 4 }, , 2, 0, 4, 7 }, , 0, 2, 7, 6 }, , 2, 0, 6, 4 }, , 0, 3, 4, 1 }, , 3, 5, 1, 5 }, , 5, 0, 5, 3 }, , 0, 7, 3, 0 }, , 7, 6, 0, 3 }, , 6, 5, 3, 3 }, , 5, 2, 3, 0 }, , 2, 7, 0, 3 }, , 7, 5, 3, 5 }, , 5, 1, 5, 4 }, , 1, 1, 4, 4 }, , 1, 4, 4, 1 }, , 0, 3, 5, 7 }, , 3, 4, 7, 6 }, , 4, 2, 6, 2 }, , 2, 4, 2, 0 }, , 4, 7, 0, 2 }, , 7, 6, 2, 7 }, , 6, 4, 7, 0 }, , 4, 1, 0, 1 }, , 1, 5, 1, 2 }, , 5, 3, 2, 2 }, , 3, 0, 2, 1 }, , 0, 3, 1, 2 }, , 3, 3, 2, 4 }, , 3, 0, 4, 1 }, , 0, 3, 1, 7 }, , 3, 5, 7, 0 }, , 5, 4, 0, 5 }, , 4, 4, 5, 3 }, , 4, 1, 3, 3 }, , 5, 7, 0, 3 }, , 7, 6, 3, 7 }, , 6, 2, 7, 6 }, , 2, 0, 6, 2 }, , 0, 2, 2, 2 }, , 2, 7, 2, 7 }, , 7, 0, 7, 0 }, , 0, 1, 0, 7 }, , 1, 2, 7, 1 }, , 2, 2, 1, 7 }, , 2, 1, 7, 5 }, , 1, 2, 5, 7 }, , 2, 4, 7, 1 }, , 4, 1, 1, 3 }, , 1, 7, 3, 0 }, , 7, 0, 0, 5 }, , 0, 5, 5, 1 }, , 5, 3, 1, 5 }, , 3, 3, 5, 1 }, , 0, 3, 4, 0 }, , 3, 7, 0, 1 }, , 7, 6, 1, 6 }, , 6, 2, 6, 2 }, , 2, 2, 2, 7 }, , 2, 7, 7, 5 }, , 7, 0, 5, 7 }, , 0, 7, 7, 1 }, , 7, 1, 1, 0 }, , 1, 7, 0, 7 }, , 7, 5, 7, 4 }, , 5, 7, 4, 2 }, , 7, 1, 2, 5 }, , 1, 3, 5, 6 }, , 3, 0, 6, 7 }, , 0, 5, 7, 1 }, , 5, 1, 1, 5 }, , 1, 5, 5, 6 }, , 5, 1, 6, 1 }, , 4, 0, 7, 6 }, , 0, 1, 6, 0 }, , 1, 6, 0, 6 }, , 6, 2, 6, 7 }, , 2, 7, 7, 2 }, , 7, 5, 2, 5 }, , 5, 7, 5, 3 }, , 7, 1, 3, 3 }, , 1, 0, 3, 3 }, , 0, 7, 3, 5 }, , 7, 4, 5, 7 }, , 4, 2, 7, 2 }, , 2, 5, 2, 0 }, , 5, 6, 0, 0 }, , 6, 7, 0, 4 }, , 7, 1, 4, 6 }, , 1, 5, 6, 1 }, , 5, 6, 1, 6 }, , 6, 1, 6, 6 }, , 7, 6, 4, 7 }, , 6, 0, 7, 5 }, , 0, 6, 5, 1 }, , 6, 7, 1, 6 }, , 7, 2, 6, 7 }, , 2, 5, 7, 5 }, , 5, 3, 5, 7 }, , 3, 3, 7, 0 }, , 3, 3, 0, 1 }, , 3, 5, 1, 3 }, , 5, 7, 3, 6 }, , 7, 2, 6, 1 }, , 2, 0, 1, 0 }, , 0, 0, 0, 4 }, , 0, 4, 4, 7 }, , 4, 6, 7, 4 }, , 6, 1, 4, 0 }, , 1, 6, 0, 7 }, , 6, 6, 7, 3 }, , 4, 7, 5, 3 }, , 7, 5, 3, 0 }, , 5, 1, 0, 5 }, , 1, 6, 5, 5 }, , 6, 7, 5, 2 }, , 7, 5, 2, 4 }, , 5, 7, 4, 1 }, , 7, 0, 1, 7 }, , 0, 1, 7, 4 }, , 1, 3, 4, 1 }, , 3, 6, 1, 5 }, , 6, 1, 5, 0 }, , 1, 0, 0, 7 }, , 0, 4, 7, 3 }, , 4, 7, 3, 6 }, , 7, 4, 6, 0 }, , 4, 0, 0, 4 }, , 0, 7, 4, 2 }, , 7, 3, 2, 3 }, , 5, 3, 6, 4 }, , 3, 0, 4, 0 }, , 0, 5, 0, 2 }, , 5, 5, 2, 5 }, , 5, 2, 5, 2 }, , 2, 4, 2, 6 }, , 4, 1, 6, 7 }, , 1, 7, 7, 4 }, , 7, 4, 4, 6 }, , 4, 1, 6, 1 }, , 1, 5, 1, 1 }, , 5, 0, 1, 6 }, , 0, 7, 6, 1 }, , 7, 3, 1, 6 }, , 3, 6, 6, 3 }, , 6, 0, 3, 5 }, , 0, 4, 5, 6 }, , 4, 2, 6, 4 }, , 2, 3, 4, 4 }".Replace("}", "").Replace(" , ", ",").Replace(" ,", ",").Replace(", ", ",").Replace(",,", ",");
    //string Input = "3,3,2,6,3,1,6,7,1,7,7,5,7,2,5,5,2,3,5,6,3,3,6,6,3,6,6,4,6,3,4,2,3,5,2,3,5,1,3,1,1,2,1,4,2,0,4,6,0,2,6,7,2,1,7,2,1,4,2,7,4,5,7,7,5,4,7,7,4,3,7,3,3,3,3,2,2,6,6,1,6,7,1,4,7,5,4,2,5,5,2,2,5,6,2,4,6,6,4,2,6,4,2,3,4,2,3,7,2,3,7,5,3,1,5,7,1,4,7,2,4,6,2,7,6,7,7,1,7,2,1,4,2,7,4,4,7,7,4,5,7,7,5,2,7,3,2,6,3,2,6,7,6,1,0,7,1,4,7,7,4,2,7,0,2,2,0,3,2,4,3,0,4,2,0,0,2,3,0,6,3,7,6,3,7,5,3,7,5,7,7,6,7,2,6,4,2,7,4,0,7,1,0,6,1,4,6,2,4,4,2,4,4,5,4,0,5,2,0,4,2,6,4,5,6,7,5,6,0,7,0,5,7,7,5,5,7,0,5,0,0,3,0,0,3,0,0,7,0,0,7,3,0,6,3,1,6,3,1,2,3,7,2,1,7,6,1,0,6,4,0,1,4,0,1,2,0,6,2,4,6,2,4,1,2,4,1,2,4,0,2,1,0,4,1,3,4,5,3,4,5,6,4,0,0,5,4,1,5,5,1,2,5,0,2,2,0,0,2,7,0,7,7,7,7,3,7,7,3,1,7,1,1,2,1,5,2,1,5,6,1,0,6,6,0,1,6,3,1,2,3,3,2,4,3,1,4,1,1,1,1,2,1,0,2,1,0,2,1,3,2,5,3,4,5,2,4,0,2,4,4,1,6,4,1,2,4,0,2,2,0,5,2,7,5,2,7,7,2,7,7,7,7,3,7,1,3,7,1,5,7,4,5,6,4,5,6,6,5,1,6,3,1,3,3,3,3,7,3,1,7,0,1,1,0,4,1,0,4,2,0,2,2,4,2,5,4,7,5,2,7,5,2,4,5,1,6,4,6,5,4,0,5,1,0,5,1,5,5,2,5,5,2,7,5,1,7,3,1,7,3,7,7,5,7,4,5,5,4,5,5,3,5,1,3,4,1,3,4,0,3,7,0,4,7,0,4,1,0,4,1,7,4,2,7,4,2,4,4,2,4,7,2,2,7,5,2,7,5,1,7,1,6,5,4,6,5,1,6,5,1,5,5,3,5,5,3,2,5,1,2,3,1,7,3,5,7,5,5,1,5,5,1,6,5,3,6,6,3,4,6,5,4,0,5,3,0,4,3,4,4,1,4,3,1,7,3,3,7,4,3,3,4,2,3,5,2,2,5,6,2,7,6,2,7,1,2,7,4,6,5,4,6,5,4,2,5,3,2,3,3,2,3,3,2,3,3,5,3,5,5,7,5,1,7,2,1,6,2,1,6,6,1,4,6,5,4,1,5,3,1,4,3,4,4,7,4,3,7,7,3,3,7,3,3,3,3,5,3,5,5,0,5,6,0,6,6,2,6,5,2,7,5,4,5,4,1,2,4,2,2,1,2,3,1,7,3,3,7,5,3,5,5,1,5,7,1,7,7,2,7,1,2,1,1,2,1,4,2,2,4,1,2,0,1,4,0,0,4,7,0,0,7,7,0,5,7,3,5,5,3,5,5,6,5,0,6,1,0,6,1,5,6,5,5,3,5,4,3,4,1,2,6,1,2,1,1,6,1,7,6,7,7,5,7,2,5,1,2,0,1,7,0,2,7,1,2,0,1,2,0,3,2,2,3,5,2,0,5,0,0,0,0,7,0,0,7,6,0,5,6,5,5,5,5,2,5,6,2,7,6,1,7,5,1,5,5,1,5,3,1,1,3,4,1,4,6,1,0,3,1,6,3,4,6,7,4,2,7,2,2,4,2,0,4,7,0,2,7,6,2,0,6,4,0,3,4,1,3,5,1,5,5,0,5,3,0,7,3,0,7,6,0,3,6,5,3,3,5,2,3,0,2,7,0,3,7,5,3,5,5,1,5,4,1,1,4,4,1,4,4,1,0,3,5,7,3,4,7,6,4,2,6,2,2,4,2,0,4,7,0,2,7,6,2,7,6,4,7,0,4,1,0,1,1,5,1,2,5,3,2,2,3,0,2,1,0,3,1,2,3,3,2,4,3,0,4,1,0,3,1,7,3,5,7,0,5,4,0,5,4,4,5,3,4,1,3,3,5,7,0,3,7,6,3,7,6,2,7,6,2,0,6,2,0,2,2,2,2,7,2,7,7,0,7,0,0,1,0,7,1,2,7,1,2,2,1,7,2,1,7,5,1,2,5,7,2,4,7,1,4,1,1,3,1,7,3,0,7,0,0,5,0,5,5,1,5,3,1,5,3,3,5,1,0,3,4,0,3,7,0,1,7,6,1,6,6,2,6,2,2,2,2,7,2,7,7,5,7,0,5,7,0,7,7,1,7,1,1,0,1,7,0,7,7,5,7,4,5,7,4,2,7,1,2,5,1,3,5,6,3,0,6,7,0,5,7,1,5,1,1,5,1,5,5,6,5,1,6,1,4,0,7,6,0,1,6,0,1,6,0,6,6,2,6,7,2,7,7,2,7,5,2,5,5,7,5,3,7,1,3,3,1,0,3,3,0,7,3,5,7,4,5,7,4,2,7,2,2,5,2,0,5,6,0,0,6,7,0,4,7,1,4,6,1,5,6,1,5,6,1,6,6,1,6,6,7,6,4,7,6,0,7,5,0,6,5,1,6,7,1,6,7,2,6,7,2,5,7,5,5,3,5,7,3,3,7,0,3,3,0,1,3,5,1,3,5,7,3,6,7,2,6,1,2,0,1,0,0,0,0,4,0,4,4,7,4,6,7,4,6,1,4,0,1,6,0,7,6,6,7,3,4,7,5,3,7,5,3,0,5,1,0,5,1,6,5,5,6,7,5,2,7,5,2,4,5,7,4,1,7,0,1,7,0,1,7,4,1,3,4,1,3,6,1,5,6,1,5,0,1,0,0,7,0,4,7,3,4,7,3,6,7,4,6,0,4,0,0,4,0,7,4,2,7,3,2,3,5,3,6,4,3,0,4,0,0,5,0,2,5,5,2,5,5,2,5,2,2,4,2,6,4,1,6,7,1,7,7,4,7,4,4,6,4,1,6,1,1,5,1,1,5,0,1,6,0,7,6,1,7,3,1,6,3,6,6,3,6,0,3,5,0,4,5,6,4,2,6,4,2,3,4,4".Replace(",", "");
    //Debug.Log(Input);
    //string Input = "3,3,2,6,3,1,6,7,1,7,7,5,7,2,5,5,2,3,5,6,3,3,6,6,3,6,6,4,6,3,4,2,3,5,2,3,5,1,3,1,1,2,1,4,2,0,4,6,0,2,6,7,2,1,7,2,1,4,2,7,4,5,7,7,5,4,7,7,4,3,7,3,3,3,3,2,2,6,6,1,6,7,1,4,7,5,4,2,5,5,2,2,5,6,2,4,6,6,4,2,6,4,2,3,4,2,3,7,2,3,7,5,3,1,5,7,1,4,7,2,4,6,2,7,6,7,7,1,7,2,1,4,2,7,4,4,7,7,4,5,7,7,5,2,7,3,2,6,3,2,6,7,6,1,0,7,1,4,7,7,4,2,7,0,2,2,0,3,2,4,3,0,4,2,0,0,2,3,0,6,3,7,6,3,7,5,3,7,5,7,7,6,7,2,6,4,2,7,4,0,7,1,0,6,1,4,6,2,4,4,2,4,4,5,4,0,5,2,0,4,2,6,4,5,6,7,5,6,0,7,0,5,7,7,5,5,7,0,5,0,0,3,0,0,3,0,0,7,0,0,7,3,0,6,3,1,6,3,1,2,3,7,2,1,7,6,1,0,6,4,0,1,4,0,1,2,0,6,2,4,6,2,4,1,2,4,1,2,4,0,2,1,0,4,1,3,4,5,3,4,5,6,4,0,0,5,4,1,5,5,1,2,5,0,2,2,0,0,2,7,0,7,7,7,7,3,7,7,3,1,7,1,1,2,1,5,2,1,5,6,1,0,6,6,0,1,6,3,1,2,3,3,2,4,3,1,4,1,1,1,1,2,1,0,2,1,0,2,1,3,2,5,3,4,5,2,4,0,2,4,4,1,6,4,1,2,4,0,2,2,0,5,2,7,5,2,7,7,2,7,7,7,7,3,7,1,3,7,1,5,7,4,5,6,4,5,6,6,5,1,6,3,1,3,3,3,3,7,3,1,7,0,1,1,0,4,1,0,4,2,0,2,2,4,2,5,4,7,5,2,7,5,2,4,5,1,6,4,6,5,4,0,5,1,0,5,1,5,5,2,5,5,2,7,5,1,7,3,1,7,3,7,7,5,7,4,5,5,4,5,5,3,5,1,3,4,1,3,4,0,3,7,0,4,7,0,4,1,0,4,1,7,4,2,7,4,2,4,4,2,4,7,2,2,7,5,2,7,5,1,7,1,6,5,4,6,5,1,6,5,1,5,5,3,5,5,3,2,5,1,2,3,1,7,3,5,7,5,5,1,5,5,1,6,5,3,6,6,3,4,6,5,4,0,5,3,0,4,3,4,4,1,4,3,1,7,3,3,7,4,3,3,4,2,3,5,2,2,5,6,2,7,6,2,7,1,2,7,4,6,5,4,6,5,4,2,5,3,2,3,3,2,3,3,2,3,3,5,3,5,5,7,5,1,7,2,1,6,2,1,6,6,1,4,6,5,4,1,5,3,1,4,3,4,4,7,4,3,7,7,3,3,7,3,3,3,3,5,3,5,5,0,5,6,0,6,6,2,6,5,2,7,5,4,5,4,1,2,4,2,2,1,2,3,1,7,3,3,7,5,3,5,5,1,5,7,1,7,7,2,7,1,2,1,1,2,1,4,2,2,4,1,2,0,1,4,0,0,4,7,0,0,7,7,0,5,7,3,5,5,3,5,5,6,5,0,6,1,0,6,1,5,6,5,5,3,5,4,3,4,1,2,6,1,2,1,1,6,1,7,6,7,7,5,7,2,5,1,2,0,1,7,0,2,7,1,2,0,1,2,0,3,2,2,3,5,2,0,5,0,0,0,0,7,0,0,7,6,0,5,6,5,5,5,5,2,5,6,2,7,6,1,7,5,1,5,5,1,5,3,1,1,3,4,1,4,6,1,0,3,1,6,3,4,6,7,4,2,7,2,2,4,2,0,4,7,0,2,7,6,2,0,6,4,0,3,4,1,3,5,1,5,5,0,5,3,0,7,3,0,7,6,0,3,6,5,3,3,5,2,3,0,2,7,0,3,7,5,3,5,5,1,5,4,1,1,4,4,1,4,4,1,0,3,5,7,3,4,7,6,4,2,6,2,2,4,2,0,4,7,0,2,7,6,2,7,6,4,7,0,4,1,0,1,1,5,1,2,5,3,2,2,3,0,2,1,0,3,1,2,3,3,2,4,3,0,4,1,0,3,1,7,3,5,7,0,5,4,0,5,4,4,5,3,4,1,3,3,5,7,0,3,7,6,3,7,6,2,7,6,2,0,6,2,0,2,2,2,2,7,2,7,7,0,7,0,0,1,0,7,1,2,7,1,2,2,1,7,2,1,7,5,1,2,5,7,2,4,7,1,4,1,1,3,1,7,3,0,7,0,0,5,0,5,5,1,5,3,1,5,3,3,5,1,0,3,4,0,3,7,0,1,7,6,1,6,6,2,6,2,2,2,2,7,2,7,7,5,7,0,5,7,0,7,7,1,7,1,1,0,1,7,0,7,7,5,7,4,5,7,4,2,7,1,2,5,1,3,5,6,3,0,6,7,0,5,7,1,5,1,1,5,1,5,5,6,5,1,6,1,4,0,7,6,0,1,6,0,1,6,0,6,6,2,6,7,2,7,7,2,7,5,2,5,5,7,5,3,7,1,3,3,1,0,3,3,0,7,3,5,7,4,5,7,4,2,7,2,2,5,2,0,5,6,0,0,6,7,0,4,7,1,4,6,1,5,6,1,5,6,1,6,6,1,6,6,7,6,4,7,6,0,7,5,0,6,5,1,6,7,1,6,7,2,6,7,2,5,7,5,5,3,5,7,3,3,7,0,3,3,0,1,3,5,1,3,5,7,3,6,7,2,6,1,2,0,1,0,0,0,0,4,0,4,4,7,4,6,7,4,6,1,4,0,1,6,0,7,6,6,7,3,4,7,5,3,7,5,3,0,5,1,0,5,1,6,5,5,6,7,5,2,7,5,2,4,5,7,4,1,7,0,1,7,0,1,7,4,1,3,4,1,3,6,1,5,6,1,5,0,1,0,0,7,0,4,7,3,4,7,3,6,7,4,6,0,4,0,0,4,0,7,4,2,7,3,2,3,5,3,6,4,3,0,4,0,0,5,0,2,5,5,2,5,5,2,5,2,2,4,2,6,4,1,6,7,1,7,7,4,7,4,4,6,4,1,6,1,1,5,1,1,5,0,1,6,0,7,6,1,7,3,1,6,3,6,6,3,6,0,3,5,0,4,5,6,4,2,6,4,2,3,4,4".Replace(",", "");
    //Debug.Log(Input);
  //}
}