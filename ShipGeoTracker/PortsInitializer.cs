using ShipGeoTracker.Database;
using ShipGeoTracker.Database.Entities;

namespace ShipGeoTracker.Api
{
    public static class PortsInitializer
    {
        public static WebApplication Seed(this WebApplication webApplication)
        {
            using (var scope = webApplication.Services.CreateScope())
            {
                using var context = scope.ServiceProvider.GetRequiredService<ShipGeoTrackerContext>();

                try
                {
                    context.Database.EnsureCreated();

                    var ports = context.Ports.FirstOrDefault();

                    if (ports == null)
                    {
                        context.Ports.AddRange(
                           new Port() { Id = Guid.NewGuid(), Name = "Namibe", Latitude = 12.1575544, Longitude = -15.1978317, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Soyo", Latitude = 12.3521148, Longitude = -6.1410265, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Bahia Blanca", Latitude = -62.28, Longitude = -38.72, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Buenos Aires", Latitude = -58.67, Longitude = -34.58, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Campana", Latitude = -58.95, Longitude = -34.15, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Corrientes", Latitude = -58.8306349, Longitude = -27.4692131, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Comodoro Rivadavia", Latitude = -67.4822429, Longitude = -45.8656149, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Caleta Olivia", Latitude = -67.5171533, Longitude = -46.4425647, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Delta Dock", Latitude = -34.0447572, Longitude = -59.199761, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "La Plata", Latitude = -57.88, Longitude = -34.85, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Mar del Plata", Latitude = -57.53, Longitude = -38.05, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Necochea", Latitude = -58.7396087999999, Longitude = -38.5544968, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Goya", Latitude = -59.2643242, Longitude = -29.1442242, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Puerto Madryn", Latitude = -65.03, Longitude = -42.75, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Puerto Deseado", Latitude = -65.9, Longitude = -47.75, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Rio Grande", Latitude = -67.7, Longitude = -53.78, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Rio Gallegos", Latitude = -69.22, Longitude = -51.63, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Rio Cullen", Latitude = -68.3523021, Longitude = -52.8955609, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Rosario", Latitude = -60.65, Longitude = -32.95, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "San Antonio Este", Latitude = -64.73, Longitude = -40.8, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Santa Fe", Latitude = -60.68, Longitude = -31.6, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "San Lorenzo", Latitude = -60.7238722, Longitude = -32.8072889, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "San Nicolas de los Arroyos", Latitude = -60.23, Longitude = -33.33, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "San Pedro", Latitude = -59.17, Longitude = -33.68, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Ushuaia", Latitude = -68.3, Longitude = -54.8, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Zarate", Latitude = -59.03, Longitude = -34.1, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Pago Pago", Latitude = -170.7020359, Longitude = -14.2756319, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Hainfeld", Latitude = 15.7733196, Longitude = 48.0337274, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Abbot Point", Latitude = 148.0846726, Longitude = -19.9078861, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Adelaide", Latitude = 138.58, Longitude = -34.92, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Ardrossan", Latitude = 137.9174283, Longitude = -34.4230702, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Bremer Bay", Latitude = 119.379376, Longitude = -34.3926208, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Bell Bay", Latitude = 146.8635558, Longitude = -41.1154147, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Brisbane", Latitude = 153.02, Longitude = -27.47, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Booby Island", Latitude = 141.92, Longitude = -10.6, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Burnie", Latitude = 145.9068513, Longitude = -41.0524649, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Chittering", Latitude = 116.1010108, Longitude = -31.4700549, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Cairns", Latitude = 145.7708595, Longitude = -16.9203338, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Devonport", Latitude = 146.3609534, Longitude = -41.1783532, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Darwin", Latitude = 130.83, Longitude = -12.45, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Fremantle", Latitude = 115.7471797, Longitude = -32.0560399, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Gladstone", Latitude = 151.2597998, Longitude = -23.8487083, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Gove", Latitude = 130.8717878, Longitude = -12.3780716, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Hobart", Latitude = 147.3, Longitude = -42.87, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Hay Point", Latitude = 149.2921629, Longitude = -21.3055785, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Launceston", Latitude = 147.1124679, Longitude = -41.4261807, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Melbourne", Latitude = 144.97, Longitude = -37.82, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "New Norfolk", Latitude = 147.0636496, Longitude = -42.7806827, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Newcastle", Latitude = 151.7789205, Longitude = -32.926689, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Port Adelaide", Latitude = 138.5073616, Longitude = -34.8477448, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Port Hedland", Latitude = 118.5752577, Longitude = -20.3116266, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Port Kembla", Latitude = 150.900495, Longitude = -34.4800735, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Sydney", Latitude = 151.2, Longitude = -33.85, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Townsville", Latitude = 146.8178707, Longitude = -19.2576268, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Weipa", Latitude = 141.8384064, Longitude = -12.6591475, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Aruba", Latitude = -69.97, Longitude = 12.5, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Oranjestad", Latitude = -70.0086306, Longitude = 12.5092044, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Baku", Latitude = 49.8670924, Longitude = 40.4092616999999, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Bridgetown", Latitude = -59.5988088999999, Longitude = 13.1132219, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Chittagong", Latitude = 91.8123324, Longitude = 22.3475365, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Chalna", Latitude = 89.5139693, Longitude = 22.6036965, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Dhaka", Latitude = 90.4125181, Longitude = 23.810332, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Mongla", Latitude = 89.6016171, Longitude = 22.4942196, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Antwerpen", Latitude = 4.42, Longitude = 51.22, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Bossuit", Latitude = 3.4072881, Longitude = 50.7481174, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Doel", Latitude = 4.26497489999999, Longitude = 51.3105975999999, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Gent (Ghent)", Latitude = 3.72, Longitude = 51.05, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Oostende (Ostend)", Latitude = 2.92, Longitude = 51.2, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Zeebrugge", Latitude = 3.2, Longitude = 51.33, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Ouagadougou", Latitude = -1.5196603, Longitude = 12.3714277, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Burgas", Latitude = 27.4626361, Longitude = 42.5047925999999, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Varna", Latitude = 27.9147333, Longitude = 43.2140504, IsActive = true },
                             new Port() { Id = Guid.NewGuid(), Name = "Bahrain", Latitude = 50.63, Longitude = 26.27, IsActive = true }
                            );

                        context.SaveChanges();
                    }
                }
                catch (Exception)
                {

                    throw;
                }

                return webApplication;
            }
        }
    }
}
