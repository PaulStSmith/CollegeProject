using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBlockchain
{
    /// <summary>
    /// Represents a simple blockchain.
    /// </summary>
    public class BlockChain
    {
        /// <summary>
        /// Gets the chain in this blockchain.
        /// </summary>
        public readonly IList<Block> Chain = [(new Block { Index = 0, Data = null })];

        /// <summary>
        /// Gets the latest block added to the chain.
        /// </summary>
        public Block LatestBlock
        {
            get { return Chain[Chain.Count - 1]; }
        }

        /// <summary>
        /// Adds a the specified block to the chain.
        /// </summary>
        /// <param name="block">The <see cref="Block"/> to be added.</param>
        public void AddBlock(Block block)
        {
            block.Index = LatestBlock.Index + 1;
            block.PreviousHash = LatestBlock.CurrentHash;
            block.CurrentHash = block.CalculateHash();
            Chain.Add(block);
        }
    }
}
