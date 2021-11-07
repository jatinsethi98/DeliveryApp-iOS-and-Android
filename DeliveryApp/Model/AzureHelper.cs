using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace DeliveryApp.Model
{
    public class AzureHelper
    {
        public static MobileServiceClient MobileService = new MobileServiceClient("https://ghd-demo.azurewebsites.net");

        public static async Task<bool> Insert<T>(T objectToInsert)
        {
            try
            {
                await MobileService.GetTable<T>().InsertAsync(objectToInsert);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
