﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwinfieldFinderService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.twinfield.com/", ConfigurationName="TwinfieldFinderService.FinderSoap")]
    public interface FinderSoap
    {
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/Search", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TwinfieldFinderService.SearchResponse> SearchAsync(TwinfieldFinderService.SearchRequest request);
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public partial class Header
    {
        
        private string sessionIDField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public string SessionID
        {
            get
            {
                return this.sessionIDField;
            }
            set
            {
                this.sessionIDField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public partial class FinderData
    {
        
        private int totalRowsField;
        
        private string[] columnsField;
        
        private string[][] itemsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public int TotalRows
        {
            get
            {
                return this.totalRowsField;
            }
            set
            {
                this.totalRowsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=1)]
        public string[] Columns
        {
            get
            {
                return this.columnsField;
            }
            set
            {
                this.columnsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=2)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfString")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public string[][] Items
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public partial class MessageOfErrorCodes
    {
        
        private MessageType typeField;
        
        private string textField;
        
        private ErrorCodes codeField;
        
        private string[] parametersField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public MessageType Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public string Text
        {
            get
            {
                return this.textField;
            }
            set
            {
                this.textField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=2)]
        public ErrorCodes Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute(Order=3)]
        public string[] Parameters
        {
            get
            {
                return this.parametersField;
            }
            set
            {
                this.parametersField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public enum MessageType
    {
        
        /// <remarks/>
        Error,
        
        /// <remarks/>
        Warning,
        
        /// <remarks/>
        Informational,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public enum ErrorCodes
    {
        
        /// <remarks/>
        NoAccessToOffice,
        
        /// <remarks/>
        OptionNotAllowed,
        
        /// <remarks/>
        InvalidBooleanOptionValue,
        
        /// <remarks/>
        InvalidIntegerOptionValue,
        
        /// <remarks/>
        InvalidDecimalOptionValue,
        
        /// <remarks/>
        InvalidEnumerationOptionValue,
        
        /// <remarks/>
        OptionValueOutOfRange,
        
        /// <remarks/>
        ParameterOutOfRange,
        
        /// <remarks/>
        InvalidFinderType,
        
        /// <remarks/>
        ParameterTooSmall,
        
        /// <remarks/>
        OptionLevelMandatoryForSectionTEQ,
        
        /// <remarks/>
        OptionICIncompatableWithOptionHidden,
        
        /// <remarks/>
        InvalidDateTimeOptionLength,
        
        /// <remarks/>
        InvalidDateTimeOptionValue,
        
        /// <remarks/>
        InvalidDateTimeOptionOutOfRange,
        
        /// <remarks/>
        OptionMandatory,
        
        /// <remarks/>
        DisableAccessRulesNotAllowed,
        
        /// <remarks/>
        Option1MandatoryIfOption2IsUsed,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Search", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class SearchRequest
    {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldFinderService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string type;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public string pattern;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=2)]
        public int field;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=3)]
        public int firstRow;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=4)]
        public int maxRows;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=5)]
        [System.Xml.Serialization.XmlArrayItemAttribute("ArrayOfString")]
        [System.Xml.Serialization.XmlArrayItemAttribute(NestingLevel=1)]
        public string[][] options;
        
        public SearchRequest()
        {
        }
        
        public SearchRequest(TwinfieldFinderService.Header Header, string type, string pattern, int field, int firstRow, int maxRows, string[][] options)
        {
            this.Header = Header;
            this.type = type;
            this.pattern = pattern;
            this.field = field;
            this.firstRow = firstRow;
            this.maxRows = maxRows;
            this.options = options;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SearchResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class SearchResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public TwinfieldFinderService.MessageOfErrorCodes[] SearchResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public TwinfieldFinderService.FinderData data;
        
        public SearchResponse()
        {
        }
        
        public SearchResponse(TwinfieldFinderService.MessageOfErrorCodes[] SearchResult, TwinfieldFinderService.FinderData data)
        {
            this.SearchResult = SearchResult;
            this.data = data;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    public interface FinderSoapChannel : TwinfieldFinderService.FinderSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    public partial class FinderSoapClient : System.ServiceModel.ClientBase<TwinfieldFinderService.FinderSoap>, TwinfieldFinderService.FinderSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public FinderSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(FinderSoapClient.GetBindingForEndpoint(endpointConfiguration), FinderSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FinderSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(FinderSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FinderSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(FinderSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public FinderSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<TwinfieldFinderService.SearchResponse> SearchAsync(TwinfieldFinderService.SearchRequest request)
        {
            return base.Channel.SearchAsync(request);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.FinderSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.FinderSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpsTransportBindingElement httpsBindingElement = new System.ServiceModel.Channels.HttpsTransportBindingElement();
                httpsBindingElement.AllowCookies = true;
                httpsBindingElement.MaxBufferSize = int.MaxValue;
                httpsBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpsBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.FinderSoap))
            {
                return new System.ServiceModel.EndpointAddress("https://c1.twinfield.com/webservices/finder.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.FinderSoap12))
            {
                return new System.ServiceModel.EndpointAddress("https://c1.twinfield.com/webservices/finder.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            FinderSoap,
            
            FinderSoap12,
        }
    }
}
