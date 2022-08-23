using Newtonsoft.Json;
using RestSharp;

namespace Reports
{
    public class API
    {

        public List<Contadores> GetContadores()
        {
            var client = new RestClient("https://api.infordoc.com/novaGen?raw");
            
            var request = new RestRequest("https://api.infordoc.com/novaGen?raw", Method.Post);
            request.Timeout = -1;
            request.AddHeader("X-API-Key", "58298c01d224f9a492be1cee0c35270b");
            request.AddHeader("Content-Type", "text/plain");
            var body = @"Declare @Data varchar(700) = DATEFROMPARTS(YEAR(GETDATE()),MONTH(GETDATE()),DAY(GETDATE()))
" + "\n" +
            @"select 'AB Brasil' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensABBrasil where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Aguia Branca' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensAguiaBranca where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Andra' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensAndra where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Bispo' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensBispo where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Catupiry' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensCatupiry where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Cavaletti' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensCavaletti where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'EcoCargo' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensEcoCargo where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Emporio Mega 100' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensEmporioMega100 where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'FazendaBV' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensFazendaBV where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Kozzy' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensKozzy where data_digitalizacao = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Life Cargo' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensLifeCargo where Cast(datesys as date) = Cast(GETDATE() as date)
" + "\n" +
            @"union
" + "\n" +
            @"select 'LogWork' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensLogWork where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Nino' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensNino where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Reus' as Empresa, count(id_movimento) as [Total Comprovantes] from tbdimagensReus where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Prime Cargo' as Empresa, count(id_movimento) as [Total Comprovantes] from [PRIMECARGO].dtbNovo.dbo.tbdimagens_Infordoc where data_baixa = @Data
" + "\n" +
            @"union
" + "\n" +
            @"select 'Taff' as Empresa, count(id_movimento) as [Total Comprovantes] from [TAFF].dtbTransporteTaffBrasil.dbo.tbdimagens_infordoc where datesys = @Data
" + "\n" +
            @"order by [Total Comprovantes] desc";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            RestResponse response = client.Execute(request);
            try
            {
                
                Console.WriteLine(response.Content);
                return JsonConvert.DeserializeObject<List<Contadores>>(response.Content);
            }
            catch
            {
                return null;
            }

        }

    }
}
