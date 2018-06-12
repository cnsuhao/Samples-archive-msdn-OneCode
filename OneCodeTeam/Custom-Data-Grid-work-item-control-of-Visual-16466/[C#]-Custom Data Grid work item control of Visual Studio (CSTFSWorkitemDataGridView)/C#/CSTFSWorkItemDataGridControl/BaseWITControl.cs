/****************************** Module Header ******************************\
 * Module Name:   BaseWITControl.cs
 * Project:       CSTFSWorkItemDataGridControl
 * Copyright (c) Microsoft Corporation.
 * 
 * This class implements the basic logic of a custom workitem control.
 * 
 * This source is subject to the Microsoft Public License.
 * See http://www.microsoft.com/en-us/openness/licenses.aspx#MPL
 * All other rights reserved.
 * 
 * THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
 * EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
 * WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
\***************************************************************************/

using System;
using System.Collections.Specialized;
using System.Windows.Forms;
using Microsoft.TeamFoundation.WorkItemTracking.Client;
using Microsoft.TeamFoundation.WorkItemTracking.Controls;

namespace CSTFSWorkItemDataGridControl
{
    public abstract class BaseWITControl : UserControl, IWorkItemControl
    {
        #region Fields and properties

        private static object EventBeforeUpdateDatasource = new object();
        private static object EventAfterUpdateDatasource = new object();

        private StringDictionary properties;
        private bool readOnly = false;

        private IServiceProvider serviceProvider;

        /// <summary>
        /// From this service provider, we can get the services of Visual Studio.
        /// </summary>
        protected IServiceProvider ServiceProvider
        {
            get
            {
                return serviceProvider;
            }
        }

        protected WorkItem workItem;
        protected string fieldName;

        protected bool HasValidField
        {
            get
            {
                return (this.Field != null);
            }
        }

        Field fieldCache = null;
        protected virtual Field Field
        {
            get
            {
                if ((this.fieldCache == null) && ((this.workItem != null) && !string.IsNullOrEmpty(this.fieldName)))
                {
                    try
                    {
                        this.fieldCache = this.workItem.Fields[this.fieldName];
                    }
                    catch
                    {
                        this.fieldCache = null;
                    }
                }
                return this.fieldCache;
            }
            set
            {
                this.fieldCache = value;
            }
        }

        #endregion

        #region IWorkItemControl interface

        /// <summary>
        /// Raise this event after updating WorkItem object with values.
        /// When value is changed by a control, work item form asks all controls (except
        /// current control) to refresh their display values (by calling 
        /// InvalidateDatasource) in case if affects other controls 
        /// </summary>
        public event EventHandler AfterUpdateDatasource
        {
            add
            {
                Events.AddHandler(EventAfterUpdateDatasource, value);
            }
            remove
            {
                Events.RemoveHandler(EventAfterUpdateDatasource, value);
            }
        }

        /// <summary>
        /// Raise this events before updating WorkItem object with values.
        /// When value is changed by a control, work item form asks all controls (except
        /// current control) to refresh their display values (by calling 
        /// InvalidateDatasource) in case if affects other controls 
        /// </summary>
        public event EventHandler BeforeUpdateDatasource
        {
            add
            {
                Events.AddHandler(EventBeforeUpdateDatasource, value);
            }
            remove
            {
                Events.RemoveHandler(EventBeforeUpdateDatasource, value);
            }
        }

        /// <summary>
        /// Control is asked to clear its contents
        /// </summary>
        public abstract void Clear();

        /// <summary>
        /// Control is requested to flush any data to workitem object. 
        /// </summary>
        public abstract void FlushToDatasource();

        ///<summary>
        /// Asks control to invalidate the contents and redraw.
        /// </summary>
        public abstract void InvalidateDatasource();


        ///<summary>
        /// All attributes specified in work item type definition file for this 
        /// control, including custom attributes.
        /// </summary>
        public virtual StringDictionary Properties
        {
            get
            {
                return properties;
            }
            set
            {
                properties = value;
            }
        }

        /// <summary>
        /// Whether the control is readonly.
        /// </summary>
        public virtual bool ReadOnly
        {
            get
            {
                return this.readOnly;
            }
            set
            {
                this.SetReadOnly(value);
            }
        }

        /// <summary>
        /// We can use the serviceProvider to get Visual Studio services.
        /// </summary>
        /// <param name="serviceProvider"></param>
        public virtual void SetSite(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// WorkItemDatasource refers to current work item object. 
        /// </summary>
        public virtual object WorkItemDatasource
        {
            get
            {
                return workItem;
            }
            set
            {
                workItem = (WorkItem)value;
            }
        }

        /// <summary>
        /// The field name which the control is associated with in work item type
        /// definition.
        ///</summary>
        public virtual string WorkItemFieldName
        {
            get
            {
                return fieldName;
            }
            set
            {
                fieldName = value;
            }
        }

        #endregion

        #region Common Methods

        /// <summary>
        /// Set value to current field.
        /// </summary>
        protected virtual void SetFieldValue(object value)
        {
            if (this.HasValidField && this.Field.IsEditable)
            {
                this.OnBeforeUpdateDatasource(EventArgs.Empty);
                this.Field.Value = value;
                this.OnAfterUpdateDatasource(EventArgs.Empty);
            }
        }

        /// <summary>
        /// Set current control as readonly.
        /// </summary>
        /// <param name="readOnly"></param>
        protected virtual void SetReadOnly(bool readOnly)
        {
            this.readOnly = readOnly;
        }

        protected virtual void OnAfterUpdateDatasource(EventArgs e)
        {
            EventHandler handler = (EventHandler)base.Events[EventAfterUpdateDatasource];
            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void OnBeforeUpdateDatasource(EventArgs e)
        {
            EventHandler handler = (EventHandler)base.Events[EventBeforeUpdateDatasource];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion
    }
}
