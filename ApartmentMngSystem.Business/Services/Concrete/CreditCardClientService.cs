using ApartmentMngSystem.Business.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentMngSystem.Business.Services.Concrete
{
    public class CreditCardClientService
    {
        public async Task<bool> MakePayment(PaymentDto paymentDto)
        {
            using (var client = new HttpClient())
            {
                var response = await client.PostAsJsonAsync("http://localhost:52911/api/CreditCard", paymentDto);
                if (response.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
        }
    }
}
