using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

public class LSystem : MonoBehaviour
{
    public String Head;
    public List<Transition> Transitions = new List<Transition>();

    public LSystem(string filename)
    {
        string[] lines = File.ReadAllLines(filename);
        foreach (var line in lines)
        {
            var trimmed = line.Trim();
            if (trimmed.Length == 0) continue;

            Transition transition = new Transition();

            var halves = trimmed.Split('>');
            if (halves.Length != 2) continue;
            var trimmedLeftHalf = halves[0].Trim();
            var trimmedRightHalf = halves[1].Trim();
            if (trimmedLeftHalf.Length == 0 || trimmedRightHalf.Length == 0) continue;
            transition.head = trimmedLeftHalf;

            ///Now do the right half
            ///

            var ends = trimmedRightHalf.Split('|');
            foreach (var end in ends)
            {
                var trimmedEnd = end.Trim();
                if (trimmedEnd == "") continue;

                End End = new End();

                End.Strength = 1;

                var parts = trimmedEnd.Split(',');

                foreach (var part in parts)
                {
                    var trimmedPart = part.Trim();
                    if (trimmedPart == "") continue;
                    End.values.Add(part);
                }

                transition.Ends.Add(End);
            }

            Transitions.Add(transition);
        }
    }

    public string[] Calculate()
    {
        List<string> toReturn = new List<string>();

        Stack<string> pending = new Stack<string>();

        pending.Push(Head);

        while (pending.Count > 0)
        {
            string current = pending.Pop().Trim();

            bool foundMatch = false;
            for (int i = 0; i < Transitions.Count; i++)
            {
                var Transition = Transitions[i];
                if (Transition.head == current)
                {
                    foundMatch = true;
                    //Pick a random end
                    End end = Transition.RandomEnd();
                    var endStrings = end.values.ToArray();
                    Array.Reverse(endStrings);
                    foreach (var s in endStrings)
                    {
                        pending.Push(s);
                    }
                }
            }
            if (!foundMatch)
            {
                toReturn.Add(current);
            }
        }



        return toReturn.ToArray();
    }


}

