using System.Threading.Tasks;

namespace ILEM
{
    interface ISerialWriter
    {
        Task InitializeConnection(int busAddress, string deviceSelector);

        void Write(byte[] bytes);

        void Write(string message);
    }
}
