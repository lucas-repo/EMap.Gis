﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace EM.GIS.Data
{
    /// <summary>
    /// 数据工厂
    /// </summary>
    public class DataFactor : IDataFactory
    {

        private static IDataFactory _default;
        /// <summary>
        /// 默认数据工厂
        /// </summary>
        public static IDataFactory Default
        {
            get 
            {
                if (_default == null)
                {
                    _default = new DataFactor();
                }
                return _default;
            }
        }
        private IProgressHandler _progressHandler;

        [Category("Handlers")]
        [Description("Gets or sets the object that implements the IProgressHandler interface for recieving status messages.")]
        public IProgressHandler ProgressHandler
        {
            get { return _progressHandler; }
            set
            { 
                _progressHandler = value;
                if (DriverFactory != null)
                {
                    DriverFactory.ProgressHandler = value;
                }
            }
        }

        public IDriverFactory DriverFactory {get;}

        [Browsable(false)]
        [Import(AllowRecomposition = true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual IGeometryFactory GeometryFactory { get; set; }

        public DataFactor()
        {
            DriverFactory = new DriverFactory()
            {
                ProgressHandler=ProgressHandler
            };
        }
    }
}