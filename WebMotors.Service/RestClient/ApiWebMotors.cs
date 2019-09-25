using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebMotors.Domain.Enums;

namespace WebMotors.Service.RestClient
{
    public static class ApiWebMotors
    {
        public static string GetData(TypeRequestApi typeRequest, string id = "")
        {
            ApiRestClient.InitializeClient();
            var result = "";

            switch (typeRequest)
            {
                case TypeRequestApi.Marca:
                    {
                        result = ApiRestClient.GetJson("http://desafioonline.webmotors.com.br/api/OnlineChallenge/Make");

                        break;
                    }
                case TypeRequestApi.Modelo:
                    {
                        result = ApiRestClient.GetJson($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Model?MakeID={id}");
                        break;
                    }
                case TypeRequestApi.Versao:
                    {
                        result = ApiRestClient.GetJson($"http://desafioonline.webmotors.com.br/api/OnlineChallenge/Version?ModelID={id}");
                        break;
                    }
                

            }

            return result;

        }
    }
}
