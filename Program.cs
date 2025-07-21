namespace Program {


    internal class Program {

        public Program() {
            var _ = new Playground();
        }

        static void Main() {
            Console.WriteLine(Environment.MachineName);
            Console.WriteLine(Environment.OSVersion.ToString());
            Console.WriteLine(Environment.CurrentDirectory);

            var _ = new Program();
        }
    }
}
