﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Collider
{
    public int[] points;

}
interface ICollidable
{
    Collider collider
    {
        get;
    }
}