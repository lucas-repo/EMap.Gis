﻿namespace EMap.Gis.Symbology
{
    /// <summary>
    /// LayerSelectedEventArgs
    /// </summary>
    public class LayerSelectedEventArgs : LayerEventArgs
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="LayerSelectedEventArgs"/> class.
        /// </summary>
        /// <param name="layer">The layer of the event.</param>
        /// <param name="selected">Indicates whether the layer is selected.</param>
        public LayerSelectedEventArgs(IBaseLayer layer, bool selected)
            : base(layer)
        {
            IsSelected = selected;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether or not the layer is selected.
        /// </summary>
        public bool IsSelected { get; protected set; }

        #endregion
    }
}