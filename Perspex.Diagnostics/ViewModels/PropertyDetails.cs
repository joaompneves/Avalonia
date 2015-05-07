﻿// -----------------------------------------------------------------------
// <copyright file="PropertyDetails.cs" company="Steven Kirk">
// Copyright 2014 MIT Licence. See licence.md for more information.
// </copyright>
// -----------------------------------------------------------------------

namespace Perspex.Diagnostics.ViewModels
{
    using System;
    using ReactiveUI;

    internal class PropertyDetails : ReactiveObject
    {
        private object value;

        public PropertyDetails(PerspexPropertyValue value)
        {
            this.Name = value.Property.IsAttached ?
                string.Format("[{0}.{1}]", value.Property.OwnerType.Name, value.Property.Name) :
                value.Property.Name;
            this.IsAttached = value.Property.IsAttached;

            this.value = value.Value ?? "(null)";
            this.Priority = (value.Priority != BindingPriority.Unset) ?
                value.Priority.ToString() :
                value.Property.Inherits ? "Inherited" : "Unset";

            //if (value.PriorityValue != null)
            //{
            //    value.PriorityValue.Changed.Subscribe(x => this.Value = x.Item2);
            //}
        }

        public string Name
        {
            get;
        }

        public bool IsAttached
        {
            get;
        }

        public object Value
        {
            get { return this.value; }
            private set { this.RaiseAndSetIfChanged(ref this.value, value); }
        }

        public string Priority
        {
            get;
            private set;
        }
    }
}
