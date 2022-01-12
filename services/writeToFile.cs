using System;

namespace WebApiAutores.services {
    public class writeToFile : IHostedService {
        private readonly IWebHostEnvironment env;
        private readonly string fileName = "File 1.txt";

        public Timer timer;

        public writeToFile( IWebHostEnvironment env) {
            this.env = env;
        }

        public Task StartAsync(CancellationToken cancellationToken) {
            timer = new Timer( DoWork, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
            write("Proceso inicio");
            return Task.CompletedTask;

        }

        public Task StopAsync(CancellationToken cancellationToken) {
            timer.Dispose();
            write("Proceso finalizado");
            return Task.CompletedTask;
        }

        private void DoWork(object state) {
            write($"proceso en ejecución: { DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss")}");
        }
        public void write( string msg ) {
            var route = $@"{env.ContentRootPath}\wwwroot\{fileName}";
            using( StreamWriter writer = new StreamWriter(route, append: true)) {
                writer.WriteLine(msg);
            }
        }
    }
}