using Common.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace RVAProjekat
{
    public class Channel
    {
        public IUserService UserProxy { get; set; }
        public IGateHandler GateHandlerProxy { get; set; }
        public ITokenService TokenServiceProxy { get; set; }
        public IGateService GateServiceProxy { get; set; }


        private static Channel instance;

        //Singleton
        public static Channel Instance
        {
            get
            {
                if (instance == null)
                    instance = new Channel();
                return instance;
            }

        }

        public Channel()
        {
            NetTcpBinding binding = new NetTcpBinding();
            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            
            ChannelFactory<IUserService> channelFactoryUser = new ChannelFactory<IUserService>(binding, new EndpointAddress("net.tcp://localhost:11000/IUserService"));
            UserProxy = channelFactoryUser.CreateChannel();

            ChannelFactory<IGateHandler> channelFactoryGate = new ChannelFactory<IGateHandler>(binding, new EndpointAddress("net.tcp://localhost:11000/IGateHandler"));
            GateHandlerProxy = channelFactoryGate.CreateChannel();

            ChannelFactory<ITokenService> channelFactoryToken = new ChannelFactory<ITokenService>(binding, new EndpointAddress("net.tcp://localhost:11000/ITokenService"));
            TokenServiceProxy = channelFactoryToken.CreateChannel();

            ChannelFactory<IGateService> channelFactoryGateService = new ChannelFactory<IGateService>(binding, new EndpointAddress("net.tcp://localhost:11000/IGateService"));
            GateServiceProxy = channelFactoryGateService.CreateChannel();
        }
    }
}
