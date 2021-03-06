﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Homework_2.BankService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="BankService.IService1")]
    public interface IService1 {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getCard", ReplyAction="http://tempuri.org/IService1/getCardResponse")]
        int getCard();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/getCard", ReplyAction="http://tempuri.org/IService1/getCardResponse")]
        System.Threading.Tasks.Task<int> getCardAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/validateCard", ReplyAction="http://tempuri.org/IService1/validateCardResponse")]
        string validateCard(string encryptedCardNo);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IService1/validateCard", ReplyAction="http://tempuri.org/IService1/validateCardResponse")]
        System.Threading.Tasks.Task<string> validateCardAsync(string encryptedCardNo);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IService1Channel : Homework_2.BankService.IService1, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class Service1Client : System.ServiceModel.ClientBase<Homework_2.BankService.IService1>, Homework_2.BankService.IService1 {
        
        public Service1Client() {
        }
        
        public Service1Client(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public Service1Client(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public Service1Client(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public int getCard() {
            return base.Channel.getCard();
        }
        
        public System.Threading.Tasks.Task<int> getCardAsync() {
            return base.Channel.getCardAsync();
        }
        
        public string validateCard(string encryptedCardNo) {
            return base.Channel.validateCard(encryptedCardNo);
        }
        
        public System.Threading.Tasks.Task<string> validateCardAsync(string encryptedCardNo) {
            return base.Channel.validateCardAsync(encryptedCardNo);
        }
    }
}
