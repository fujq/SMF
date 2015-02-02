using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using System.Windows.Browser;
using System.Windows.Threading;
using Microsoft.SilverlightMediaFramework.Utilities.Extensions;

namespace Microsoft.SilverlightMediaFramework.Core.Media
{
    /// <summary>
    /// Represents information about an audio track.
    /// </summary>
    [ScriptableType]
    public class AudioTrackData : DependencyObject, INotifyPropertyChanged
    {
        private string _name;
        private Uri _uri;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    NotifyPropertyChanged("Name");
                }
            }
        }

        public Uri Uri
        {
            get { return _uri; }
            set
            {
                if (value != _uri)
                {
                    _uri = value;
                }
            }
        }

        public AudioTrackData(string name, Uri uri)
        {
            Name = name;
            Uri = uri;
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            var audioTrackData = obj as AudioTrackData;
            return audioTrackData != null
                   && audioTrackData.Name == Name
                   && audioTrackData.Uri == Uri;
        }

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (propertyName == null)
                throw new ArgumentNullException("propertyName");

            VerifyProperty(propertyName);

            PropertyChangedEventHandler propertyChangedHandler = PropertyChanged;

            if (propertyChangedHandler != null)
            {
                if (Application.Current != null && Application.Current.RootVisual != null)
                {
                    Dispatcher currentDispatcher = Application.Current.RootVisual.Dispatcher;
                    if (currentDispatcher.CheckAccess() == false)
                    {
                        currentDispatcher.BeginInvoke(
                            () => propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName)));
                    }
                    else
                    {
                        propertyChangedHandler(this, new PropertyChangedEventArgs(propertyName));
                    }
                }
            }
        }

        [Conditional("DEBUG")]
        private void VerifyProperty(string propertyName)
        {
            PropertyInfo property = GetType().GetProperty(propertyName);

            if (property == null)
            {
                string message = string.Format("Invalid property: {0}", propertyName);
                throw new Exception(message);
            }
        }

    }
}
