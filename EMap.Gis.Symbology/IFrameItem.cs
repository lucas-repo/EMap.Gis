﻿namespace EMap.Gis.Symbology
{
    public interface IFrameItem<T> where T: IFrame
    {
        T Frame { get; set; }
    }
}