﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwinfieldSessionService
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="http://www.twinfield.com/", ConfigurationName="TwinfieldSessionService.SessionSoap")]
    public interface SessionSoap
    {
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/Logon", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TwinfieldSessionService.LogonResponse> LogonAsync(TwinfieldSessionService.LogonRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/SmsLogon", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TwinfieldSessionService.SmsLogonResponse> SmsLogonAsync(TwinfieldSessionService.SmsLogonRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/SmsSendCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TwinfieldSessionService.SmsSendCodeResponse> SmsSendCodeAsync(TwinfieldSessionService.SmsSendCodeRequest request);
        
        // CODEGEN: Generating message contract since the operation has multiple return values.
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/ChangePassword", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TwinfieldSessionService.ChangePasswordResponse> ChangePasswordAsync(TwinfieldSessionService.ChangePasswordRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/SelectCompany", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TwinfieldSessionService.SelectCompanyResponse> SelectCompanyAsync(TwinfieldSessionService.SelectCompanyRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/KeepAlive", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TwinfieldSessionService.KeepAliveResponse> KeepAliveAsync(TwinfieldSessionService.KeepAliveRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/Abandon", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TwinfieldSessionService.AbandonResponse> AbandonAsync(TwinfieldSessionService.AbandonRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://www.twinfield.com/GetRole", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<TwinfieldSessionService.GetRoleResponse> GetRoleAsync(TwinfieldSessionService.GetRoleRequest request);
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
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public enum LogonResult
    {
        
        /// <remarks/>
        Ok,
        
        /// <remarks/>
        Blocked,
        
        /// <remarks/>
        Untrusted,
        
        /// <remarks/>
        Invalid,
        
        /// <remarks/>
        Deleted,
        
        /// <remarks/>
        Disabled,
        
        /// <remarks/>
        OrganisationInactive,
        
        /// <remarks/>
        ClientInvalid,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public enum LogonAction
    {
        
        /// <remarks/>
        None,
        
        /// <remarks/>
        SMSLogon,
        
        /// <remarks/>
        ChangePassword,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Logon", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class LogonRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string user;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public string password;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=2)]
        public string organisation;
        
        public LogonRequest()
        {
        }
        
        public LogonRequest(string user, string password, string organisation)
        {
            this.user = user;
            this.password = password;
            this.organisation = organisation;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="LogonResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class LogonResponse
    {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldSessionService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public TwinfieldSessionService.LogonResult LogonResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public TwinfieldSessionService.LogonAction nextAction;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=2)]
        public string cluster;
        
        public LogonResponse()
        {
        }
        
        public LogonResponse(TwinfieldSessionService.Header Header, TwinfieldSessionService.LogonResult LogonResult, TwinfieldSessionService.LogonAction nextAction, string cluster)
        {
            this.Header = Header;
            this.LogonResult = LogonResult;
            this.nextAction = nextAction;
            this.cluster = cluster;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public enum SMSLogonResult
    {
        
        /// <remarks/>
        Ok,
        
        /// <remarks/>
        Invalid,
        
        /// <remarks/>
        TimeOut,
        
        /// <remarks/>
        Disabled,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SmsLogon", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class SmsLogonRequest
    {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldSessionService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string smsCode;
        
        public SmsLogonRequest()
        {
        }
        
        public SmsLogonRequest(TwinfieldSessionService.Header Header, string smsCode)
        {
            this.Header = Header;
            this.smsCode = smsCode;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SmsLogonResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class SmsLogonResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public TwinfieldSessionService.SMSLogonResult SmsLogonResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public TwinfieldSessionService.LogonAction nextAction;
        
        public SmsLogonResponse()
        {
        }
        
        public SmsLogonResponse(TwinfieldSessionService.SMSLogonResult SmsLogonResult, TwinfieldSessionService.LogonAction nextAction)
        {
            this.SmsLogonResult = SmsLogonResult;
            this.nextAction = nextAction;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SmsSendCode", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class SmsSendCodeRequest
    {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldSessionService.Header Header;
        
        public SmsSendCodeRequest()
        {
        }
        
        public SmsSendCodeRequest(TwinfieldSessionService.Header Header)
        {
            this.Header = Header;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SmsSendCodeResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class SmsSendCodeResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public int SmsSendCodeResult;
        
        public SmsSendCodeResponse()
        {
        }
        
        public SmsSendCodeResponse(int SmsSendCodeResult)
        {
            this.SmsSendCodeResult = SmsSendCodeResult;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public enum ChangePasswordResult
    {
        
        /// <remarks/>
        Ok,
        
        /// <remarks/>
        Invalid,
        
        /// <remarks/>
        NotDifferent,
        
        /// <remarks/>
        NotSecure,
        
        /// <remarks/>
        Disabled,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ChangePassword", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class ChangePasswordRequest
    {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldSessionService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string currentPassword;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public string newPassword;
        
        public ChangePasswordRequest()
        {
        }
        
        public ChangePasswordRequest(TwinfieldSessionService.Header Header, string currentPassword, string newPassword)
        {
            this.Header = Header;
            this.currentPassword = currentPassword;
            this.newPassword = newPassword;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ChangePasswordResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class ChangePasswordResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public TwinfieldSessionService.ChangePasswordResult ChangePasswordResult;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=1)]
        public TwinfieldSessionService.LogonAction nextAction;
        
        public ChangePasswordResponse()
        {
        }
        
        public ChangePasswordResponse(TwinfieldSessionService.ChangePasswordResult ChangePasswordResult, TwinfieldSessionService.LogonAction nextAction)
        {
            this.ChangePasswordResult = ChangePasswordResult;
            this.nextAction = nextAction;
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.twinfield.com/")]
    public enum SelectCompanyResult
    {
        
        /// <remarks/>
        Ok,
        
        /// <remarks/>
        Invalid,
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SelectCompany", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class SelectCompanyRequest
    {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldSessionService.Header Header;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string company;
        
        public SelectCompanyRequest()
        {
        }
        
        public SelectCompanyRequest(TwinfieldSessionService.Header Header, string company)
        {
            this.Header = Header;
            this.company = company;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SelectCompanyResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class SelectCompanyResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public TwinfieldSessionService.SelectCompanyResult SelectCompanyResult;
        
        public SelectCompanyResponse()
        {
        }
        
        public SelectCompanyResponse(TwinfieldSessionService.SelectCompanyResult SelectCompanyResult)
        {
            this.SelectCompanyResult = SelectCompanyResult;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="KeepAlive", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class KeepAliveRequest
    {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldSessionService.Header Header;
        
        public KeepAliveRequest()
        {
        }
        
        public KeepAliveRequest(TwinfieldSessionService.Header Header)
        {
            this.Header = Header;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="KeepAliveResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class KeepAliveResponse
    {
        
        public KeepAliveResponse()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="Abandon", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class AbandonRequest
    {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldSessionService.Header Header;
        
        public AbandonRequest()
        {
        }
        
        public AbandonRequest(TwinfieldSessionService.Header Header)
        {
            this.Header = Header;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="AbandonResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class AbandonResponse
    {
        
        public AbandonResponse()
        {
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetRole", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class GetRoleRequest
    {
        
        [System.ServiceModel.MessageHeaderAttribute(Namespace="http://www.twinfield.com/")]
        public TwinfieldSessionService.Header Header;
        
        public GetRoleRequest()
        {
        }
        
        public GetRoleRequest(TwinfieldSessionService.Header Header)
        {
            this.Header = Header;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetRoleResponse", WrapperNamespace="http://www.twinfield.com/", IsWrapped=true)]
    public partial class GetRoleResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="http://www.twinfield.com/", Order=0)]
        public string GetRoleResult;
        
        public GetRoleResponse()
        {
        }
        
        public GetRoleResponse(string GetRoleResult)
        {
            this.GetRoleResult = GetRoleResult;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    public interface SessionSoapChannel : TwinfieldSessionService.SessionSoap, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.1-preview-30514-0828")]
    public partial class SessionSoapClient : System.ServiceModel.ClientBase<TwinfieldSessionService.SessionSoap>, TwinfieldSessionService.SessionSoap
    {
        
        /// <summary>
        /// Implement this partial method to configure the service endpoint.
        /// </summary>
        /// <param name="serviceEndpoint">The endpoint to configure</param>
        /// <param name="clientCredentials">The client credentials</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public SessionSoapClient(EndpointConfiguration endpointConfiguration) : 
                base(SessionSoapClient.GetBindingForEndpoint(endpointConfiguration), SessionSoapClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SessionSoapClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(SessionSoapClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SessionSoapClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(SessionSoapClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public SessionSoapClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<TwinfieldSessionService.LogonResponse> LogonAsync(TwinfieldSessionService.LogonRequest request)
        {
            return base.Channel.LogonAsync(request);
        }
        
        public System.Threading.Tasks.Task<TwinfieldSessionService.SmsLogonResponse> SmsLogonAsync(TwinfieldSessionService.SmsLogonRequest request)
        {
            return base.Channel.SmsLogonAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TwinfieldSessionService.SmsSendCodeResponse> TwinfieldSessionService.SessionSoap.SmsSendCodeAsync(TwinfieldSessionService.SmsSendCodeRequest request)
        {
            return base.Channel.SmsSendCodeAsync(request);
        }
        
        public System.Threading.Tasks.Task<TwinfieldSessionService.SmsSendCodeResponse> SmsSendCodeAsync(TwinfieldSessionService.Header Header)
        {
            TwinfieldSessionService.SmsSendCodeRequest inValue = new TwinfieldSessionService.SmsSendCodeRequest();
            inValue.Header = Header;
            return ((TwinfieldSessionService.SessionSoap)(this)).SmsSendCodeAsync(inValue);
        }
        
        public System.Threading.Tasks.Task<TwinfieldSessionService.ChangePasswordResponse> ChangePasswordAsync(TwinfieldSessionService.ChangePasswordRequest request)
        {
            return base.Channel.ChangePasswordAsync(request);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TwinfieldSessionService.SelectCompanyResponse> TwinfieldSessionService.SessionSoap.SelectCompanyAsync(TwinfieldSessionService.SelectCompanyRequest request)
        {
            return base.Channel.SelectCompanyAsync(request);
        }
        
        public System.Threading.Tasks.Task<TwinfieldSessionService.SelectCompanyResponse> SelectCompanyAsync(TwinfieldSessionService.Header Header, string company)
        {
            TwinfieldSessionService.SelectCompanyRequest inValue = new TwinfieldSessionService.SelectCompanyRequest();
            inValue.Header = Header;
            inValue.company = company;
            return ((TwinfieldSessionService.SessionSoap)(this)).SelectCompanyAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TwinfieldSessionService.KeepAliveResponse> TwinfieldSessionService.SessionSoap.KeepAliveAsync(TwinfieldSessionService.KeepAliveRequest request)
        {
            return base.Channel.KeepAliveAsync(request);
        }
        
        public System.Threading.Tasks.Task<TwinfieldSessionService.KeepAliveResponse> KeepAliveAsync(TwinfieldSessionService.Header Header)
        {
            TwinfieldSessionService.KeepAliveRequest inValue = new TwinfieldSessionService.KeepAliveRequest();
            inValue.Header = Header;
            return ((TwinfieldSessionService.SessionSoap)(this)).KeepAliveAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TwinfieldSessionService.AbandonResponse> TwinfieldSessionService.SessionSoap.AbandonAsync(TwinfieldSessionService.AbandonRequest request)
        {
            return base.Channel.AbandonAsync(request);
        }
        
        public System.Threading.Tasks.Task<TwinfieldSessionService.AbandonResponse> AbandonAsync(TwinfieldSessionService.Header Header)
        {
            TwinfieldSessionService.AbandonRequest inValue = new TwinfieldSessionService.AbandonRequest();
            inValue.Header = Header;
            return ((TwinfieldSessionService.SessionSoap)(this)).AbandonAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<TwinfieldSessionService.GetRoleResponse> TwinfieldSessionService.SessionSoap.GetRoleAsync(TwinfieldSessionService.GetRoleRequest request)
        {
            return base.Channel.GetRoleAsync(request);
        }
        
        public System.Threading.Tasks.Task<TwinfieldSessionService.GetRoleResponse> GetRoleAsync(TwinfieldSessionService.Header Header)
        {
            TwinfieldSessionService.GetRoleRequest inValue = new TwinfieldSessionService.GetRoleRequest();
            inValue.Header = Header;
            return ((TwinfieldSessionService.SessionSoap)(this)).GetRoleAsync(inValue);
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
            if ((endpointConfiguration == EndpointConfiguration.SessionSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                result.Security.Mode = System.ServiceModel.BasicHttpSecurityMode.Transport;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.SessionSoap12))
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
            if ((endpointConfiguration == EndpointConfiguration.SessionSoap))
            {
                return new System.ServiceModel.EndpointAddress("https://c1.twinfield.com/webservices/session.asmx");
            }
            if ((endpointConfiguration == EndpointConfiguration.SessionSoap12))
            {
                return new System.ServiceModel.EndpointAddress("https://c1.twinfield.com/webservices/session.asmx");
            }
            throw new System.InvalidOperationException(string.Format("Could not find endpoint with name \'{0}\'.", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            SessionSoap,
            
            SessionSoap12,
        }
    }
}
