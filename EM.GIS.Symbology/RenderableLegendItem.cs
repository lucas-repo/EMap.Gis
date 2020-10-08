﻿using EM.GIS.Data;
using System;
using System.ComponentModel;

namespace EM.GIS.Symbology
{
    public class RenderableLegendItem : LegendItem, IRenderableLegendItem
    {
        #region Fields

        private bool _isInitialized;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="RenderableLegendItem"/> class.
        /// </summary>
        public RenderableLegendItem()
        {
            IsChecked = true;
        }

        #endregion

        #region Events

        /// <summary>
        /// Occurs whenever the geographic bounds for this renderable object have changed
        /// </summary>
        public event EventHandler<ExtentArgs> EnvelopeChanged;

        /// <summary>
        /// Occurs when an outside request is sent to invalidate this object
        /// </summary>
        public event EventHandler Invalidated;

        /// <summary>
        /// Occurs immediately after the visible parameter has been adjusted.
        /// </summary>
        public event EventHandler VisibleChanged;

        #endregion

        #region Properties

        /// <summary>
        /// Gets an Envelope in world coordinates that contains this object. This is virtual, and
        /// will usually be reconfigured in subclasses to simply show the dataset extent.
        /// </summary>
        [Category("General")]
        [Description("Obtains an Envelope that contains this object")]
        public virtual IExtent IExtent { get;  }

        /// <summary>
        /// Gets or sets a value indicating whether or not the unmanaged drawing structures have been created for this item
        /// </summary>
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool IsInitialized
        {
            get
            {
                return _isInitialized;
            }

            set
            {
                _isInitialized = value;
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Invalidates the drawing methods
        /// </summary>
        public virtual void Invalidate()
        {
            _isInitialized = false;
            OnInvalidate(this, EventArgs.Empty);
        }

        /// <summary>
        /// Fires the EnvelopeChanged event.
        /// </summary>
        /// <param name="sender">The object sender for this event (this)</param>
        /// <param name="e">The EnvelopeArgs specifying the envelope</param>
        protected virtual void OnEnvelopeChanged(object sender, ExtentArgs e)
        {
            EnvelopeChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Fires the Invalidated event.
        /// </summary>
        /// <param name="sender">The object sender (usually this)</param>
        /// <param name="e">An EventArgs parameter</param>
        protected virtual void OnInvalidate(object sender, EventArgs e)
        {
            Invalidated?.Invoke(sender, e);
        }

        /// <summary>
        /// Fires the Visible Changed event.
        /// </summary>
        /// <param name="sender">The object sender (usually this)</param>
        /// <param name="e">An EventArgs parameter</param>
        protected virtual void OnVisibleChanged(object sender, EventArgs e)
        {
            VisibleChanged?.Invoke(sender, e);
        }

        #endregion
    }
}