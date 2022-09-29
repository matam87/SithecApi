using Newtonsoft.Json;
using SithecWS.Api.Models;
using SithecWS.Api.Utilities;
using SQLConnection.NetCore;

namespace SithecWS.Api.Data
{
    public class HumanData
    {
        private static HumanData? _instance;

        Connection getConnection = Connection.GetInstance();

        public static HumanData GetHumanData()
        {
            if (_instance == null)
                _instance = new HumanData();
            return _instance;
        }

        public async Task<List<HumanModel>> GetHumanModel()
        {
            await Task.Delay(500);
            var result = new List<HumanModel>();
            using (StreamReader r = new(VariableGlobal.PathHumanData))
            {
                result = JsonConvert.DeserializeObject<List<HumanModel>>(r.ReadToEnd());
            }
            return result;
        }

        public async Task SetMigrationData()
        {
            _ = new List<HumanModel>();
            List<HumanModel>? result = await GetHumanModel();
            
            getConnection.ConnectionName("Default");
            getConnection.Clear();
            foreach (var item in result)
            {
                getConnection.Add("Opc", "ins");
                getConnection.Add("Id", item.Id);
                getConnection.Add("Nombre", item.Nombre);
                getConnection.Add("Sexo", item.Sexo);
                getConnection.Add("Altura", item.Altura);
                getConnection.Add("Peso", item.Peso);
                getConnection.Execute("dbo.sp_InsHumanData");
                await Task.Delay(500);
            }           
        }

        public async Task<List<HumanModel>> GetData()
        {
            await Task.Delay(500);
            getConnection.ConnectionName("Default");
            getConnection.Clear();
            return getConnection.Execute<HumanModel>("dbo.sp_SelHumanData");
        }

        public async Task<List<HumanModel>> GetData(int? id, string? nombre)
        {
            await Task.Delay(500);
            getConnection.ConnectionName("Default");
            getConnection.Clear();
            if (id > 0)
                getConnection.Add("Id", id);
            if(string.IsNullOrEmpty(nombre) || string.IsNullOrWhiteSpace(nombre))
                getConnection.Add("Nombre", nombre);
            return getConnection.Execute<HumanModel>("dbo.sp_SelHumanData");
        }

        public async Task SetHumanCreate(HumanModel model)
        {
            await Task.Delay(500);
            getConnection.ConnectionName("Default");
            getConnection.Clear();
            getConnection.Add("Opc", "ins");
            getConnection.AddClass(model);
            getConnection.Execute("dbo.sp_InsHumanData");
        }

        public async Task SetHumanEdit(HumanModel model)
        {
            await Task.Delay(500);
            getConnection.ConnectionName("Default");
            getConnection.Clear();
            getConnection.Add("Opc", "upd");
            getConnection.AddClass(model);
            getConnection.Execute("dbo.sp_InsHumanData");
        }
    }
}