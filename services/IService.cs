namespace WebApiAutores.services {
    public interface IService
    {
        Guid ObtenerScoped();
        Guid ObtenerSingleton();
        Guid ObtenerTrasient();
        void RealizarTarea();
    }

    public class ServiceA : IService {
        public readonly ILogger<ServiceA> logger;
        private readonly ServiceTrasient serviceTrasient;
        private readonly ServiceScoped serviceScoped;
        private readonly ServiceSingleton serviceSingleton;

        public ServiceA( ILogger<ServiceA> logger, 
            ServiceTrasient serviceTrasient, ServiceScoped serviceScoped, ServiceSingleton serviceSingleton) {
            this.logger = logger;
            this.serviceTrasient = serviceTrasient;
            this.serviceScoped = serviceScoped;
            this.serviceSingleton = serviceSingleton;
        }

        public Guid ObtenerTrasient() {
            return serviceTrasient.Guid;
        }
        public Guid ObtenerScoped() {
            return serviceScoped.Guid;
        }
        public Guid ObtenerSingleton() {
            return serviceSingleton.Guid;
        }

        public void RealizarTarea() {
            throw new NotImplementedException();
        }
    }
    
    public class ServiceB : IService {
        public Guid ObtenerScoped()
        {
            throw new NotImplementedException();
        }

        public Guid ObtenerSingleton()
        {
            throw new NotImplementedException();
        }

        public Guid ObtenerTrasient()
        {
            throw new NotImplementedException();
        }

        public void RealizarTarea() {
            throw new NotImplementedException();
        }
    }

    public class ServiceTrasient {
        public Guid Guid = Guid.NewGuid();
    }

    public class ServiceScoped {
        public Guid Guid = Guid.NewGuid();
    }

    public class ServiceSingleton {
        public Guid Guid = Guid.NewGuid();
    }
    
}