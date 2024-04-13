using System.Security.Cryptography;
using System.Text;
using System.Text.Json;

using System.Text.Json.Serialization;

namespace SimpleBlockchain
{
    /// <summary>
    /// Represents a block in the blockchain
    /// </summary>
    public class Block
    {
        /// <summary>
        /// Gets or sets the index of the block.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of the block.
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.Now;

        /// <summary>
        /// Gets or sets the data stored in the block.
        /// </summary>
        public Object? Data { get; set; }

        /// <summary>
        /// Gets or sets the previous hash of the block.
        /// </summary>
        public String? PreviousHash { get; set; }

        /// <summary>
        /// Gets or sets the current hash of the block.
        /// </summary>
        public String? CurrentHash { get; set; } 

        /// <summary>
        /// Calculates the hash for the block.
        /// </summary>
        /// <returns>A base 64 string containing the hash for the block.</returns>
        public String CalculateHash()
        {
            string json;
            try
            {
                json = JsonSerializer.Serialize(Data);
            }
            catch (Exception)
            {
                
            }
            var bytes = Encoding.UTF8.GetBytes($@"{Timestamp:yyyyMMdd'T'HHmmss} - {PreviousHash ?? ""} - {json} ");
            return Convert.ToBase64String(SHA256.HashData(bytes));
        }
    }
}
