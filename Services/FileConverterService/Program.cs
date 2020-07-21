using Topshelf;

namespace FileConverterService
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(serviceConfig =>
            {
                serviceConfig.Service<ConverterService>(serviceInstance =>
                {
                    serviceInstance.ConstructUsing(
                        () => new ConverterService());

                    serviceInstance.WhenStarted(execute => execute.Start());
                    serviceInstance.WhenStopped(stop => stop.Stop());
                });
                serviceConfig.SetServiceName("AwesomeFileConverter");
                serviceConfig.SetDisplayName("Awesome File Converter");
                serviceConfig.SetDescription("A pluralsight demo service!");
                serviceConfig.StartAutomatically();
            });
        }
    }
}
