<a href="https://dot.net/architecture">
   <img src="https://github.com/dotnet-architecture/eShopOnContainers/raw/dev/img/eshop_logo.png" alt="eShop logo" title="eShopOnContainers" align="right" height="60" />
</a>

# .NET Solution Ebra

Practice Xamarin Application, with clean code and SOLID principles.
Declaración de intenciones ()
Sample .NET Core reference application, powered by Microsoft, based on a simplified microservices architecture and Docker containers.

La solución Ebra está enfocada en aplicar todos los conceptos SOLID de manera práctica, así como aplicar también todas las buenas prácticas de código limpio

## Estructura de la solución
Explicar qué proyectos hay y para qué, cuál es la estructura interna de cada proyecto (Test, Android, Cliente) + carpetas

$ ./tree-md
# Ebra
 * [Clientes](./dir2)
   * [Xamarin](./dir2/file21.ext)
   * [WPF](./dir2/file22.ext)
   * [Shared](./dir2/file23.ext)
        * [Models](./dir2/file23.ext)
 * [Server](./dir1)
   * [Web API](./dir1/file11.ext)
   * [STS](./dir1/file12.ext)
        * [Shared](./dir2/file23.ext)
 * [Test](./file_in_root.ext)
      * [Unit Test](./dir2/file23.ext)
      * [Integration Test](./dir2/file23.ext)
      * [Test Cases](./dir2/file23.ext)
 * [README.md](./README.md)

   
![](img/eshop-spa-app-home.png)


## WPF Client
Used libraries
   Prism: 
      Inyección de dependencias
         Implementación Bootstrapper
            IContainerRegistry
      Regiones
         IRegionManager
         Definiciones
            Add/ Remove/ Activate/ Deactivate 
         Vistas
            Add/ Remove/ Activate/ Deactivate
         Modules
            Modularización
               Estático: Por código (moduleCatalog.Add (IModule)
               Dinámico: Por archivo de configuración (App.config)
      MVVM

## Xamarin Client
Used libraries
   Tamarack: 
      Chain of Responsiblity
   SQLite:
      BBDD
      Repositories

Used patterns
   Creational patterns:
      Builder 
      Factory Method
      MVVM
      Repository
      Chain of Responsiblity

## Patrones utilizados
Cadena de responsabilidades, FactoryMethod, Factory abstract, MVVM, Repository
| Patron | Implementación | Image | Status |
| ------------- | ------------- | ------------- | ------------- |
| Cadena de Responsabilidad | ChainOfResponsibilityFactory.cs | Shopping Aggregator (Web) | [![Web Shopping Aggregator](https://github.com/dotnet-architecture/eShopOnContainers/workflows/webshoppingagg/badge.svg)](https://github.com/dotnet-architecture/eShopOnContainers/actions?query=workflow%3Awebshoppingagg) |
| Basket API | [![Basket API](https://github.com/dotnet-architecture/eShopOnContainers/workflows/basket-api/badge.svg?branch=dev)](https://github.com/dotnet-architecture/eShopOnContainers/actions?query=workflow%3Abasket-api) | Shopping Aggregator (Mobile) | [![Mobile Shopping Aggregator](https://github.com/dotnet-architecture/eShopOnContainers/workflows/mobileshoppingagg/badge.svg?branch=dev)](https://github.com/dotnet-architecture/eShopOnContainers/actions?query=workflow%3Amobileshoppingagg) |
| Catalog API | [![Catalog API](https://github.com/dotnet-architecture/eShopOnContainers/workflows/catalog-api/badge.svg)](https://github.com/dotnet-architecture/eShopOnContainers/actions?query=workflow%3Acatalog-api) | Web Client (MVC) | [![WebMVC Client](https://github.com/dotnet-architecture/eShopOnContainers/workflows/webmvc/badge.svg?branch=dev)](https://github.com/dotnet-architecture/eShopOnContainers/actions?query=workflow%3Awebmvc) |
|Identity API | [![Identity API](https://github.com/dotnet-architecture/eShopOnContainers/workflows/identity-api/badge.svg?branch=dev)](https://github.com/dotnet-architecture/eShopOnContainers/actions?query=workflow%3Aidentity-api) | Web Client (SPA) | [![WebSPA Client](https://github.com/dotnet-architecture/eShopOnContainers/workflows/webspa/badge.svg?branch=dev)](https://github.com/dotnet-architecture/eShopOnContainers/actions?query=workflow%3Awebspa) |
| Ordering API | [![Ordering API](https://github.com/dotnet-architecture/eShopOnContainers/workflows/ordering-api/badge.svg?branch=dev)](https://github.com/dotnet-architecture/eShopOnContainers/actions?query=workflow%3Aordering-api) | Webhooks Client | [![Webhooks demo client](https://github.com/dotnet-architecture/eShopOnContainers/workflows/webhooks-client/badge.svg)](https://github.com/dotnet-architecture/eShopOnContainers/actions?query=workflow%3Awebhooks-client) |
| Payment API | [![Payment API](https://github.com/dotnet-architecture/eShopOnContainers/workflows/payment-api/badge.svg?branch=dev)](https://github.com/dotnet-architecture/eShopOnContainers/actions?query=workflow%3Apayment-api) | Ordering SignalR | [![Ordering SignalR](https://github.com/dotnet-architecture/eShopOnContainers/workflows/ordering-signalrhub/badge.svg)](https://github.com/dotnet-architecture/eShopOnContainers/actions?query=workflow%3Aordering-signalrhub) | |

_**Dev** branch contains the latest **beta** code and their images are tagged with `:linux-dev` in our [Docker Hub](https://hub.docker.com/u/eshop)_

## Inyección de dependencias

Dónde haces la inyección de dependencias y dónde se recupera
Make sure you have [installed](https://docs.docker.com/docker-for-windows/install/) and [configured](https://github.com/dotnet-architecture/eShopOnContainers/wiki/Windows-setup#configure-docker) docker in your environment. After that, you can run the below commands from the **/src/** directory and get started with the `eShopOnContainers` immediately.

```powershell
docker-compose build
docker-compose up
```

You should be able to browse different components of the application by using the below URLs :

```
Web Status : http://host.docker.internal:5107/
Web MVC :  http://host.docker.internal:5100/
Web SPA :  http://host.docker.internal:5104/
```

>Note: If you are running this application in macOS then use `docker.for.mac.localhost` as DNS name in `.env` file and the above URLs instead of `host.docker.internal`.

Below are the other avenues to setup *eShopOnContainers*.

### Basic scenario

The basic scenario can be run locally using docker-compose, and also deployed to a local Kubernetes cluster. Refer to these Wiki pages to Get Started:


- [Visual Studio (F5 experience)](https://github.com/dotnet-architecture/eShopOnContainers/wiki/Windows-setup#optional---use-visual-studio)
- [Docker compose on windows](https://github.com/dotnet-architecture/eShopOnContainers/wiki/Windows-setup)
- [Docker compose on macOS](https://github.com/dotnet-architecture/eShopOnContainers/wiki/Mac-setup)
- [Local Kubernetes](https://github.com/dotnet-architecture/eShopOnContainers/wiki/Deploy-to-Local-Kubernetes)




url del ejemplo
https://github.com/dotnet-architecture/eShopOnContainers/blob/dev/README.md?plain=1
