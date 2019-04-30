using Microsoft.AspNetCore.Http;
using MyFinance.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.Models
{
    public class AnimaisModel
    {
        public int idAnimais { get; set; }
        public string Nome { get; set; }
        public string DataNascimento { get; set; }
        public string NomeMae { get; set; }
        public string Sexo { get; set; }
        public string NomePai { get; set; }
        public int Usuario_Id { get; set; }

        public IHttpContextAccessor HttpContextAccessor { get; set; }

        
        public AnimaisModel()
        {

        }

        public AnimaisModel(IHttpContextAccessor httpContextAccessor)
        {
            HttpContextAccessor = httpContextAccessor;
        }

        public List<AnimaisModel> ListaAnimais()
        {
            List<AnimaisModel> lista = new List<AnimaisModel>();
            AnimaisModel item;

            string id_usuario_logado = "1";
            string sql = $"SELECT idAnimais, Nome, DataNascimento, NomeMae, Sexo, NomePai, Usuario_Id FROM CADASTRO_ANIMAIS WHERE Usuario_Id = {id_usuario_logado} ";
            DAL objDAL = new DAL();
            DataTable dt = objDAL.RetDataTable(sql);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                item = new AnimaisModel();
                item.idAnimais = int.Parse(dt.Rows[i]["idAnimais"].ToString());
                item.Nome = dt.Rows[i]["Nome"].ToString();
                item.DataNascimento = dt.Rows[i]["DataNascimento"].ToString();
                item.NomeMae = dt.Rows[i]["NomeMae"].ToString();
                item.Sexo = dt.Rows[i]["Sexo"].ToString();
                item.NomePai = dt.Rows[i]["NomePai"].ToString();
                item.Usuario_Id = int.Parse(dt.Rows[i]["Usuario_Id"].ToString());
                lista.Add(item);
            }
            return lista;
        }

       
    }

}



