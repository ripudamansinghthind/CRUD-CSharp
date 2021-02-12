using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace CRUD_Blender {
    public class DataAccess {
        public List<Model> GetModel() {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("BlenderDB"))) {
                var output = connection.Query<Model>("dbo.GetAllModels").ToList();
                return output;
            }
        }
        public List<Model> SearchModel(string id) {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("BlenderDB"))) {
                int i = int.Parse(id);
                var output = connection.Query<Model>($"select * from dbo.CleanModels where CleanModelId = '{i}'").ToList();
                return output;
            }
        }
        public void DeleteModel(string id) {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("BlenderDB"))) {
                int i = int.Parse(id);
                //var output = connection.Query<Model>("dbo.DeleteByModelId", i).ToList();
                connection.Execute("EXEC dbo.DeleteByModelId @p1", new { i = i });
            }
        }
    }
}
