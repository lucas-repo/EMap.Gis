﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EMap.Gis.Symbology
{
    public interface IDynamicVisibility
    {
        bool UseDynamicVisibility { get; set; }
        double MaxScaleFactor { get; set; }
        double MinScaleFactor { get; set; }
    }
}
