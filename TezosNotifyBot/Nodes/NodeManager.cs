using System;
using System.Linq;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using NornPool.Model;
using TezosNotifyBot.Model;
using TezosNotifyBot.Tezos;

namespace TezosNotifyBot.Nodes
{
    public class NodeManager
    {
        private readonly HttpClient _http;
        private readonly BotConfig _config;
        private readonly ILogger<Node> _logger;
        
        /// <summary>
        /// All nodes described in Settings/Nodes.json
        /// </summary>
        public Node[] Nodes { get; } = new Node[0];

        /// <summary>
        /// Currently active node. Changing using SwitchTo methods
        /// </summary>
        public Node Active { get; private set; }
        
        public NodeClient Client { get; }

        public NodeManager(Node[] nodes, HttpClient http, BotConfig config, ILogger<Node> logger)
        {
            _http = http;
            _config = config;
            _logger = logger;
            
            Nodes = nodes;
            Active = Nodes[0];
            Client = CreateNodeClient(Active);
        }

        public void SwitchTo(int index)
        {
            var changeTo = Nodes.ElementAtOrDefault(index);
            if (changeTo is null)
                throw new ArgumentException($"Node in {index} index doesn't exists");

            Active = changeTo;
            Client.SetNodeUrl(changeTo.Url);
        }

        // TODO: For refactoring
        public string GetStatus(Node node)
        {
            var client = CreateNodeClient(node);
            try
            {
                var bh = client.GetBlockHeader("head");
                return $"{bh.level} ({bh.timestamp}) 🆗";
            }
            catch(Exception e)
            {
                return e.Message;
            }
        }

        public BlockHeader GetNodeHeader(Node node)
        {
            var client = CreateNodeClient(node);
            try
            {
                return client.GetBlockHeader("head");
            }
            catch(Exception e)
            {
                return null;
            }
        }

        private NodeClient CreateNodeClient(Node node)
        {
            return new NodeClient(node.Url, _http, _config.CryptoCompareToken, _logger);
        }
    }
}