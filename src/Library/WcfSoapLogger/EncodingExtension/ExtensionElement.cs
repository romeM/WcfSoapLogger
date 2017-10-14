﻿using System;
using System.Configuration;
using System.ServiceModel.Configuration;

namespace WcfSoapLogger.EncodingExtension
{
    public class ExtensionElement : BindingElementExtensionElement
    {
        private const string LogPathName = "logPath";
        private const string UseCustomHandlerName = "useCustomHandler";

        [ConfigurationProperty(LogPathName, IsRequired = true)]
        public string LogPath {
            get {
                return (string)base[LogPathName];
            }
        }

        [ConfigurationProperty(UseCustomHandlerName, IsRequired = false)]
        public string UseCustomHandler {
            get {
                return (string)base[UseCustomHandlerName];
            }
        }

        protected override System.ServiceModel.Channels.BindingElement CreateBindingElement() {
            var bindingElement = new BindingElement(LogPath, UseCustomHandler);
            ApplyConfiguration(bindingElement);
            return bindingElement;
        }

        public override Type BindingElementType {
            get { return typeof(BindingElement); }
        }
    }
}
