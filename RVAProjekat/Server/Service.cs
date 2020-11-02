using Common.Contracts;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Service
    {
        private static ServiceHost UserServiceHost;
        private static ServiceHost GateHandlerHost;
        private static ServiceHost TokenServiceHost;
        private static ServiceHost GateServiceHost;

        public Service()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;

            UserServiceHost = new ServiceHost(typeof(UserService));
            UserServiceHost.AddServiceEndpoint(typeof(IUserService), binding, new Uri("net.tcp://localhost:11000/IUserService"));

            GateHandlerHost = new ServiceHost(typeof(GateHandler));
            GateHandlerHost.AddServiceEndpoint(typeof(IGateHandler), binding, new Uri("net.tcp://localhost:11000/IGateHandler"));

            TokenServiceHost = new ServiceHost(typeof(TokenService));
            TokenServiceHost.AddServiceEndpoint(typeof(ITokenService), binding, new Uri("net.tcp://localhost:11000/ITokenService"));

            GateServiceHost = new ServiceHost(typeof(GateService));
            GateServiceHost.AddServiceEndpoint(typeof(IGateService), binding, new Uri("net.tcp://localhost:11000/IGateService"));
        }
        public void Open()
        {
            UserServiceHost.Open();
            GateHandlerHost.Open();
            TokenServiceHost.Open();
            GateServiceHost.Open();
            Console.WriteLine("Service hosts are opened at " + DateTime.Now);
        }

        public void Close()
        {
            UserServiceHost.Close();
            GateHandlerHost.Close();
            TokenServiceHost.Close();
            GateServiceHost.Close();
            Console.WriteLine("Service hosts are closed at " + DateTime.Now);
        }
    }
}
