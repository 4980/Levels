using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Transition
{
    public String head;
    public List<End> Ends = new List<End>();

    static Random Random = new Random();

    public End RandomEnd()
    {
        float sumStrength = 0;
        foreach(var End in Ends)
        {
            sumStrength += End.Strength;
        }

        float chosenStrength = (float)(Random.NextDouble() * sumStrength);

        sumStrength = 0;
        for(int i = 0; i < Ends.Count; i++)
        {
            End End = Ends[i];
            sumStrength += End.Strength;
            if (sumStrength >= chosenStrength)
                return End;

        }

        //If we get here, something went wrong.
        throw new Exception("You had a chosen strength that was greater than your maximum sum strength...");

    }
}

