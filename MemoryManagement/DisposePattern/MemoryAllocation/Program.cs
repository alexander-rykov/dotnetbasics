namespace MemoryAllocation
{
    class Program
    {
        static void Main(string[] args)
        {
            var holder = new ResourceHolder(1000, 101);
            holder.CopyTo();
            holder.CopyFrom();
        }
    }
}
